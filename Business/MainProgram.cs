using Domain;
using System;

namespace Business
{
    public class MainProgram : IMainProgram
    {
        public void TestProgram()
        {
            RunCode(1);
        }

        [CustomException]
        public void RunCode(int parameterTest)
        {
            Console.WriteLine("test");
            //Throw an exception to test Interceptor
            throw new Exception("Throwing exception");
        }
    }
}
