using System;
using System.Collections.Generic;
using System.Text;

namespace ClassTemplateTools.Common
{
    internal static class StringExtensions
    {
        public static string[] SplitByNewLine(this string str)
        => str.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        public static string EachLineAppendSpace(this string str)
        => str.SplitByNewLine()
              .EachLineAppendSpace();

        public static string EachLineAppendSpace(this IEnumerable<string> strs)
        => strs.EachLineAppendString("\t");

        public static string EachLineAppendString(this IEnumerable<string> strs, string append)
        {
            var sb = new StringBuilder();
            foreach (var str in strs)
                sb.AppendLine($"{append}{str}");

            return sb.ToString();
        }

        public static string RemoveLastNewLine(this string str)
        {
            var sb = new StringBuilder();

            var arr = str.SplitByNewLine();
            for(var i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);

                if (i + 1 != arr.Length)
                    sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
