using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
