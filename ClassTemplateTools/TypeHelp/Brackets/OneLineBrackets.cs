using ClassTemplateTools.Contract;
using System.Collections.Generic;
using System.Text;

namespace ClassTemplateTools.TypeHelp.Brackets
{
    internal class OneLineBrackets : IEnumerableBrackets
    {
        public string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var sb = new StringBuilder(title + " {");
            foreach (var str in strs)
            {
                sb.Append(' ');
                sb.Append(str + ',');
            }
            sb.Append(' ');
            sb.Append('}');

            return sb.ToString();
        }
    }
}
