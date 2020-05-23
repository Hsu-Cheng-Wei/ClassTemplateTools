using ClassTemplateTools.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassTemplateToolsTests.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitLine(this string str, string split)
        {
            var sb = new StringBuilder();

            foreach(var s in str.SplitByNewLine())
            {
                if(s == split)
                {
                    if (sb.Length > 0)
                        yield return sb.ToString();

                    sb.Clear();
                    continue;
                }

                if (sb.Length > 0)
                    sb.AppendLine();
                sb.Append(s);
            }
        }
    }
}
