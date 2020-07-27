using Castle.DynamicProxy;
using Domain.Business;
using Domain.DataContracts;
using Domain.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Domain.Container
{
    public class Container
    {

        public object ProxyObject { get; private set; }

        public Container(object objectName)
        {
            var test = ExtractDependencyInectionInfo(objectName);
        }

        private void Locator(Type interfaceClass, object concreteClass, string methodName)
        {
            var proxyGenerator = new ProxyGenerator();
            var proxyResult = proxyGenerator.CreateInterfaceProxyWithTargetInterface(interfaceClass, concreteClass, new ExceptionIntercept());
            ProxyObject = proxyResult;
        }

        public IEnumerable<DependencyInjectionInfo> ExtractDependencyInectionInfo(object objectWithDependencies)
        {
            var dependencies = ExtractDependencyInectionInfoByType(objectWithDependencies.GetType());
            var interfaceName = "IMainProgram"; //Get interface type from container
            var interfaceType = objectWithDependencies.GetType().GetInterface(interfaceName);
            dependencies.ToList().ForEach(x => Locator(interfaceType, objectWithDependencies, x.MethodName));
            return dependencies;
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
}
