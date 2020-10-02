using System;
using Castle.DynamicProxy;
using Domain.Business;
using Domain.Sharp;
using static Domain.Container.Container;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            //try
            //{
            //var container = new Container(new MainProgram());

            //var containerProxyObject = (IProxyTargetAccessor)container.ProxyObject;
            //var proxyTarget = containerProxyObject.DynProxyGetTarget();
            //var mainProgram = (IMainProgram)proxyTarget;
            //mainProgram.RunCode();

            var personClass = new MainProgram();
            var proxy2 = new ProxyCreator<IMainProgram>();
            var createdProxy = proxy2.GetProxyObject(personClass);
            createdProxy.RunCode();

            Console.ReadLine();
        }
    }

    
}
