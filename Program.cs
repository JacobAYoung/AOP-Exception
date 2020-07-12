using Castle.DynamicProxy;
using Castle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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


    public interface IMainProgram
    {
        void TestProgram();

        void RunCode(int parameterTest);
    }

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
            throw new Exception("Throwing exception");
        }
    }

    public class Container
    { 
        public Container(Object objectName)
        {
            var test = ExtractDependencyInectionInfo(objectName);
            Locator();
        }

        private void Locator()
        {
            var pg = new ProxyGenerator();
            TestLocator(pg.CreateInterfaceProxyWithTarget<IMainProgram>(new MainProgram(), new ExceptionIntercept()));
        }

        private void TestLocator(IMainProgram main)
        {
            main.RunCode(1);
        }

        public IEnumerable<DependencyInjectionInfo> ExtractDependencyInectionInfo(object objectWithDependencies)
        {
            return ExtractDependencyInectionInfoByType(objectWithDependencies.GetType());
        }

        private IEnumerable<DependencyInjectionInfo> ExtractDependencyInectionInfoByType(Type dependencyType)
        {
            return dependencyType.GetMethods().Where(x => x.IsPublic && x.IsDefined(typeof(CustomException))).Select(x => new DependencyInjectionInfo()
            {
                TypeToInject = x.ReturnType,
                CustomExceptionAttribute = x.GetCustomAttribute<CustomException>(),
                MethodName = x.Name,
                ParameterNames = x.GetParameters().ToList().Select(parameter => parameter.Name)
            });
        }

    }

    public class CustomExceptionAttributeProcess
    {
        
    }

    public class DependencyInjectionInfo
    {
        public Type TypeToInject { get; set; }

        public CustomException CustomExceptionAttribute { get; set; }

        public string MethodName { get; set; }

        public IEnumerable<string> ParameterNames { get; set; }
    }

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
            //throw new Exception("Intercept worked");
        }
    }
}
