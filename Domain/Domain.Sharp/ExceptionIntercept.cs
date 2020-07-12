using System;
using Castle.DynamicProxy;

namespace Domain.Sharp
{
    public class ExceptionIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
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
    }
}