using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Castle.DynamicProxy;

namespace Domain.Sharp
{
    public class ExceptionIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var test = invocation.MethodInvocationTarget.GetCustomAttribute(typeof(CustomException));
            if (test != null)
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