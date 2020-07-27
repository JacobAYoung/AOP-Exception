using System;
using System.Linq;
using Castle.DynamicProxy;
using Domain.Business;
using Domain.Container;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                var container = new Container(new MainProgram());

                var containerProxyObject = (IProxyTargetAccessor)container.ProxyObject;
                var proxyTarget = containerProxyObject.DynProxyGetTarget();
                var mainProgram = (IMainProgram)proxyTarget;
                mainProgram.RunCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Ideally run code like this.
            //container.ProxyObject.RunCode();
            Console.ReadLine();
        }
    }
}
