using System;
using Domain.Business;
using Domain.Container;

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
