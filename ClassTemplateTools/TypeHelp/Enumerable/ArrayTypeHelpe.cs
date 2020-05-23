using ClassTemplateTools.Contract;
using ClassTemplateTools.TypeHelp.Brackets;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp.Enumerable
{
    [TypeName("Array")]
    internal class ArrayTypeHelpe : EnumberableTypeHelp
    {
        public override string BaseName(object obj)
        => base.BaseName(obj);

        public override string GetNewText(object obj)
        => "new[]";

        public override string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new LineBreakBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }
    }
}
