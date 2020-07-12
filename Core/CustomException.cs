using System;

namespace Domain
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomException : Attribute
    {
        public CustomException()
        {
        }
    }
}
