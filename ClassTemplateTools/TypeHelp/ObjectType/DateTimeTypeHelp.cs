using ClassTemplateTools.Contract;
using ClassTemplateTools.TypeHelp.Brackets;
using System;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp.ObjectType
{
    [TypeName("DateTime")]
    internal class DateTimeTypeHelp : ITypeHelp
    {
        public string BaseName(object obj)
        => "DateTime";

        public string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new LineBreakBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }

        public string ToConstructString(object obj)
        {
            var date = (DateTime)obj;
            return $"new DateTime({date.Year}, {ToFillup(date.Month)}, {ToFillup(date.Day)}, {ToFillup(date.Hour)}, {ToFillup(date.Minute)}, {ToFillup(date.Second)}, DateTimeKind.{date.Kind.ToString()})";
        }

        private string ToFillup(int num)
        => num.ToString().PadLeft(2, '0');
    }
}
