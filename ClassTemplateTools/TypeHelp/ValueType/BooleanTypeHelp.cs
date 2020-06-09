using ClassTemplateTools.Contract;
using ClassTemplateTools.TypeHelp.Brackets;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp.ValueType
{
    [TypeName("Boolean")]
    internal class BooleanTypeHelp : ITypeHelp
    {
        public string BaseName(object obj)
        => "bool";

        public string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new OneLineBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }

        public string ToConstructString(object obj)
        => obj.ToString().ToLower();
    }
}
