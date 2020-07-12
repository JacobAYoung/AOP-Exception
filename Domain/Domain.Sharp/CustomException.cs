using System;

namespace Domain.Sharp
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomException : Attribute
    {
        public CustomException()
        {
        }
    }
}
