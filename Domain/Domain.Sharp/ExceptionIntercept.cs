using System;
using Castle.DynamicProxy;

namespace Domain.Sharp
{
    public class ExceptionIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.IsDefined(typeof(CustomException), false))
            {
                try
                {
                    invocation.Proceed();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Caught Exception: {ex.Message}.");
                }
            }
            else
            {
                invocation.Proceed();
            }
            
        }
    }
}