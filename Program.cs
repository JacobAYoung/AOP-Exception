using Business;
using Core.Container;
using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(new MainProgram());
            Console.ReadLine();
        }
    }
}
