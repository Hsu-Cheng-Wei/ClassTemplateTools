using ClassTemplateTools.Contract;
using ClassTemplateTools.TypeHelp.Brackets;
using System;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp.ValueType
{
    [TypeName("Guid")]
    internal class GuidTypeHelp : ValueTypeHelp
    {
        public override string BaseName(object obj)
        => "Guid";

        public override string ToConstructString(object obj)
        {
            var g = (Guid)obj;

            return $"Guid.Parse(\"{g.ToString()}\")";
        }

        public override string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new LineBreakBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }
    }
}
