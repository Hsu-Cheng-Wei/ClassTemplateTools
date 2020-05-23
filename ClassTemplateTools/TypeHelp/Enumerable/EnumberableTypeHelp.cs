using ClassTemplateTools.Contract;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassTemplateTools.TypeHelp.Enumerable
{
    internal abstract class EnumberableTypeHelp : ITypeHelp
    {
        public abstract string GetNewText(object obj);

        public virtual string BaseName(object obj)
        {
            var _objs = (IEnumerable)obj;
            var etor = _objs.GetEnumerator();
            etor.MoveNext();
            var _obj = etor.Current;
            if (_obj == null)
                throw new ArgumentOutOfRangeException("Can't find list generic type");

            return _obj.GetType().GetTypeHelp().BaseName(_obj);
        }

        public string ToConstructString(object obj)
        {
            var objs = (IEnumerable)obj;
            var etr = objs.GetEnumerator();
            etr.MoveNext();
            var help = etr.Current.GetType().GetTypeHelp();

            var p = new List<string>();
            foreach (var _obj in objs)
            {
                var result = help.ToConstructString(_obj);
                p.Add(result);
            }

            return help.ReassemblyStringInBrackets(p, GetNewText(obj));
        }

        public abstract string ReassemblyStringInBrackets(IEnumerable<string> strs, string title);
    }
}
