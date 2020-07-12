﻿using Business;
using Castle.DynamicProxy;
using Core;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Container
{
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
}
