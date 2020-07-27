using Domain.Sharp;
using System;

namespace Domain.Business
{
    public class MainProgram : IMainProgram
    {
        [CustomException]
        public void RunCode()
        {
            Console.WriteLine("test");
            //Throw an exception to test Interceptor
            throw new Exception("Throwing exception");
        }
    }
}
