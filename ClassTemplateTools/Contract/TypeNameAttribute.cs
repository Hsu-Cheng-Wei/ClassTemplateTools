using System;

namespace ClassTemplateTools.Contract
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    internal class TypeNameAttribute : Attribute
    {
        public string Name { get; }
        public TypeNameAttribute(string name)
        {
            Name = name;
        }
    }
}
