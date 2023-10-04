// See https://aka.ms/new-console-template for more information
using System;
namespace Targil0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome6645();
            Welcome2774();
            Console.ReadKey();
        }

        static partial void Welcome2774();
        private static void Welcome6645()
        {
            Console.WriteLine( "hi hi hi hi hi");
            Console.Write("Enter your name: ");
            string? userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", userName);
        }
    }
}
