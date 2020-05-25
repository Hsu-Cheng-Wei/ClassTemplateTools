using ClassTemplateTools.Contract;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp
{
    internal abstract class BaseTypeHelp : ITypeHelp
    {
        public virtual string BaseName(object obj)
        => GetType().Name.Replace("TypeHelp", "").ToLower();

        public abstract string ReassemblyStringInBrackets(IEnumerable<string> strs, string title);

        public abstract string ToConstructString(object obj);
    }
}
