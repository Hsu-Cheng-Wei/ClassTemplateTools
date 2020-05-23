using ClassTemplateTools.Common;
using ClassTemplateTools.Contract;
using ClassTemplateTools.TypeHelp.Brackets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassTemplateTools.TypeHelp.ObjectType
{
    [TypeName("Object")]
    internal class ObjectTypeHelp : ITypeHelp
    {
        public string BaseName(object obj)
        => obj.GetType().Name;

        public string ReassemblyStringInBrackets(IEnumerable<string> strs, string title)
        {
            var brackets = new LineBreakBrackets();
            return brackets.ReassemblyStringInBrackets(strs, title);
        }

        public string ToConstructString(object obj)
        {
            var type = obj.GetType();

            var sb = new StringBuilder("new " + type.Name + "()");
            sb.AppendLine();
            sb.Append("{");

            foreach(var p in type.GetProperties())
            {
                var value = p.GetValue(obj);
                var pType = p.PropertyType;
                if (value == null || value is null)
                    continue;
                if (pType.IsValueType && value.Equals(Activator.CreateInstance(pType)))
                    continue;

                var despcript = value.DumpToString()
                    .SplitByNewLine();
                sb.AppendLine();
                sb.Append('\t' + p.Name + " = " + despcript.First());
                var content = despcript.AsEnumerable()
                    .RemoveFirst()
                    .EachLineAppendSpace()
                    .RemoveLastNewLine();
                if(!string.IsNullOrWhiteSpace(content))
                {
                    sb.AppendLine();
                    sb.Append(content);
                }
                sb.Append(",");
            }
            sb.AppendLine();
            sb.Append("}");
            return sb.ToString();
        }
    }
}
