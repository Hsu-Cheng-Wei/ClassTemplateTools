using ClassTemplateTools.Contract;
using ClassTemplateTools.TypeHelp.Brackets;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp.ObjectType
{
    [TypeName("String")]
    internal class StringTypeHelp : BaseTypeHelp
    {
        public override string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new OneLineBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }

        public override string ToConstructString(object obj)
        => $"\"{obj.ToString()}\"";
    }
}
