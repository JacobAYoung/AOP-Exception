using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomException : Attribute
    {
        public CustomException()
        {
            Console.WriteLine("Log custom message");
        }
    }
}
