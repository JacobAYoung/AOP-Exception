using System;

namespace Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomException : Attribute
    {
        public CustomException()
        {
        }
    }
}
