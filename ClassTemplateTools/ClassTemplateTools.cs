using ClassTemplateTools.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ClassTemplateTools
{
    public static class ClassTemplateTools
    {
        private static Dictionary<string, ITypeHelp> _typeHelps;

        private static Dictionary<string, ITypeHelp> typeHelps
        {
            get
            {
                if(_typeHelps == null)
                {
                    var types = Assembly.GetAssembly(typeof(ITypeHelp))
                    .GetTypes()
                    .Where(t => !t.IsAbstract)
                    .Where(t => typeof(ITypeHelp).IsAssignableFrom(t))
                    .Select(t => (ITypeHelp)Activator.CreateInstance(t));

                    _typeHelps = new Dictionary<string, ITypeHelp>();
                    foreach (var type in types)
                    {
                        foreach (var attr in type.GetType().GetCustomAttributes()
                            .Where(t => t is TypeNameAttribute)
                            .Cast<TypeNameAttribute>())
                            _typeHelps.Add(attr.Name, type);
                    }
                }

                return _typeHelps;
            }
        }

        internal static ITypeHelp GetTypeHelp(this Type type)
        {
            var name = type.Name;
            if (!typeHelps.ContainsKey(type.Name))
                if (typeHelps.ContainsKey(type.BaseType.Name))
                    name = type.BaseType.Name;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(type.Name)} Can't not implement");

            return typeHelps[name];
        }

        internal static ITypeHelp GetTypeHelp(this object obj)
        => obj.GetType().GetTypeHelp();

        public static string DumpToString(this IEnumerable<object> objs)
        => objs.GetTypeHelp().ToConstructString(objs);

        public static string DumpToString(this object obj)
        => obj.GetTypeHelp().ToConstructString(obj);
    }
}
