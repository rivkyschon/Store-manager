using BlApi;
using BlImplementation;
using PL.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static Simulator.Simulator;

namespace PL;

/// <summary>
/// Interaction logic for SimulatorWindow.xaml
/// </summary>
public partial class SimulatorWindow : Window
{
    IBl bl;
    BackgroundWorker worker;

    #region the closing button
    private const int GWL_STYLE = -16;
    private const int WS_SYSMENU = 0x80000;

    public event PropertyChangedEventHandler? PropertyChanged;

    [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    void ToolWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
        SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
    }
    #endregion

    bool isTimerRun;
    Duration duration;
    DoubleAnimation doubleanimation;
    ProgressBar ProgressBar;
    private int seconds;
    DispatcherTimer _timer;
    TimeSpan _time;


    public BO.Order? order
    {
        get { return (BO.Order?)GetValue(orderProperty); }
        set { SetValue(orderProperty, value); }
    }

    public static readonly DependencyProperty orderProperty = DependencyProperty.Register("order", typeof(BO.Order), typeof(Window));

    public string? newStatus
    {
        get { return (string?)GetValue(newStatusProperty); }
        set { SetValue(newStatusProperty, value); }
    }

    public static readonly DependencyProperty newStatusProperty = DependencyProperty.Register("newStatus", typeof(string), typeof(Window));

    private void timer(int sec)
    {
        _time = TimeSpan.FromSeconds(sec);

        _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
        {
            tbTime.Text = string.Format("{0:D2}", _time.Seconds);
            if (_time == TimeSpan.Zero) _timer.Stop();
            _time = _time.Add(TimeSpan.FromSeconds(-1));
        }, Application.Current.Dispatcher);

        _timer.Start();
    }
    public SimulatorWindow(IBl Bl)
    {

        InitializeComponent();
        bl = Bl;
        Loaded += ToolWindow_Loaded;
        DataContext = this;
        workerStart();
    }
    void ProgressBarStart(int s)
    {
        if (ProgressBar != null) SBar.Items.Remove(ProgressBar);
        ProgressBar = new ProgressBar();
        ProgressBar.IsIndeterminate = false;
        ProgressBar.Orientation = Orientation.Horizontal;
        ProgressBar.Width = 500;
        ProgressBar.Height = 30;
        duration = new Duration(TimeSpan.FromSeconds(s * 2));
        doubleanimation = new DoubleAnimation(200.0, duration);
        ProgressBar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);

        SBar.Items.Add(ProgressBar);
    }

    void workerStart()
    {
        isTimerRun = true;
        worker = new BackgroundWorker();
        worker.DoWork += WorkerDoWork!;
        worker.WorkerReportsProgress = true;
        worker.WorkerSupportsCancellation = true;
        worker.ProgressChanged += workerProgressChanged!;
        worker.RunWorkerCompleted += RunWorkerCompleted!;
        worker.RunWorkerAsync();
    }

    void WorkerDoWork(object sender, DoWorkEventArgs e)
    {
        propsChanged += progressChanged!;
        Simulator.Simulator.stop += stop!;
        Run();
        while (!worker.CancellationPending && isTimerRun)
        {
            worker.ReportProgress(1);
            Thread.Sleep(1000);
        }
    }


    void workerProgressChanged(object sender, ProgressChangedEventArgs e) => simulatorTxt.Text = DateTime.Now.ToString("h:mm:ss");

    private void stopSimulatorBtn_Click(object sender, RoutedEventArgs e) => stop(sender, EventArgs.Empty);

    void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => this.Close();

    void stop(object sender, EventArgs e)
    {
        if (worker.WorkerSupportsCancellation == true)
            worker.CancelAsync();

        if (isTimerRun)
            isTimerRun = false;
        Simulator.Simulator.Stop();
        propsChanged -= progressChanged!;
        Simulator.Simulator.stop -= stop!;
        if (!CheckAccess())
            Dispatcher.BeginInvoke(stop, sender, e);
        else
        {

            this.Close();
        }
    }


    void progressChanged(object sender, EventArgs e)
    {
        OrderEventArgs orderEventArgs = (OrderEventArgs)e;
        seconds = orderEventArgs.seconds / 1000;

        if (!CheckAccess())
        {
            Dispatcher.BeginInvoke(progressChanged, sender, e);
        }
        else
        {

            timer(seconds - 1);
            ProgressBarStart(seconds);
            order = orderEventArgs.order;
            newStatus = ((BO.OrderStatus)((int)(object)orderEventArgs.order.Status! + 1)).ToString();
        }
    }
}
