using System;

namespace WatchDog.src.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SensitiveStringAttribute : Attribute
    {
    }
}
