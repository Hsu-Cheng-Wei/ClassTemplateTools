using ClassTemplateTools.Common;
using ClassTemplateTools.Contract;
using System.Collections.Generic;
using System.Text;

namespace ClassTemplateTools.TypeHelp.Brackets
{
    internal class LineBreakBrackets : IEnumerableBrackets
    {
        public string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var sb = new StringBuilder();
            sb.AppendLine(title);
            sb.AppendLine("{");
            foreach (var str in strs)
            {
                sb.AppendLine(str.EachLineAppendSpace().RemoveLastNewLine() + ',');
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}
