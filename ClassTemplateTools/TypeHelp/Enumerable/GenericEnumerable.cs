using ClassTemplateTools.TypeHelp.Brackets;
using System.Collections.Generic;
using System.Text;

namespace ClassTemplateTools.TypeHelp.Enumerable
{
    internal abstract class GenericEnumerable : EnumberableTypeHelp
    {
        public override string GetNewText(object obj)
        {
            var name = BaseName(obj);

            return "new " + name + "()";
        }

        public override string BaseName(object obj)
        {
            var name = base.BaseName(obj);
            var sb = new StringBuilder(GetType().Name.Replace("TypeHelp",string.Empty));
            sb.Append('<');
            sb.Append(name);
            sb.Append('>');
            return sb.ToString();
        }

        public override string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new LineBreakBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }
    }
}
