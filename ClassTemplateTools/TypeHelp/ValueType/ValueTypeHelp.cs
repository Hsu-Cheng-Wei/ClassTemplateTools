using ClassTemplateTools.TypeHelp.Brackets;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp.ValueType
{
    internal abstract class ValueTypeHelp : BaseTypeHelp
    {
        public override string ToConstructString(object obj)
        => obj.ToString();

        public override string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new OneLineBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }
    }
}
