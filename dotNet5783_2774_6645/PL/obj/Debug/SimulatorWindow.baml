   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLPL  5   	       PL.SimulatorWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:PL     5   	     � Title$  SimulatorWindow��5   	   $	��500��6!   $	��800��6.   .��5	      � .+�5
   
   �� -   5        $��tbTime��5
       �� 
IsReadOnly$
 True��6    $��20(�62   $��472,354,266,83q�6@   �� 5   
   -   5        $��stopSimulatorBtn��5   +   $��Stop Simulation��6   $
��Left=�6C   $��64��6^   $��
641,15,0,0q�6j   $	��Top=�6~   $	��135��6�   6�   �� 5   
   -   5         ��Name$ simulatorTxt��5      $��00:00:00��6*   $
��Left=�6:   $��80��6U   $��	22,10,0,0q�6a   $
��Wrap=�6t   $	��Top=�6�   $	��230��6�   �� 5   
   -   5        $
��SBar��5      $��0��6!   $��5��61   $��Bottom=�6>   .@�5      �� $��80��6   .��5      �� $��72��6   $��20(�6'   	Status:6>   5      5      �� 5   
   $
��Left=�6   $��36��6+   $��385,147,0,0q�67   $��order ID��6L   $	��Top=�6_   $��67��6w   �� 5   
   -   5        $��
orderIDTxt��5      $
��Left=�6>   $
 True��6Y   $��36��6k   $��472,147,0,0q�6w    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��123��6�   ��6$   �� *
order.ID+6�   �� 5   
   -   5        $��	statusBtn��5      $
��Left=�6B   $
 True��6]   $��36��6o   $��472,214,0,0q�6{   $
 Wrap=�6�   $	��Top=�6�   $	��123��6�   ��6$   �� *order.Status+6�   �� 5   
   $
��Left=�6   $��36��6+   $��385,214,0,0q�67   $��
old status��6L   $	��Top=�6a   $��67��6y   �� 5   
   -   5        $��newStatusBtn��5      $
��Left=�6&   $
 True��6A   $��44��6S   $��472,283,0,0q�6_   $
 Wrap=�6t   $	��Top=�6�   $	��123��6�   ��6�   �� *	newStatus+�� 5   
   $
��Left=�6   $��36��6+   $��385,283,0,0q�67   $��
new status��6L   $	��Top=�6a   $��67��6y   �� 5   
   $
��Left=�6   $��45��6/   $��385,354,0,0q�6;   $
��Wrap=�6P   $��time remain��6d   $	��Top=�6w   $��67��6�   5      5      