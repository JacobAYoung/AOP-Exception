﻿using Domain;
using System;
using System.Collections.Generic;

namespace DataContracts
{
    public class DependencyInjectionInfo
    {
        public Type TypeToInject { get; set; }

        public CustomException CustomExceptionAttribute { get; set; }

        public string MethodName { get; set; }

        public IEnumerable<string> ParameterNames { get; set; }
    }
}
