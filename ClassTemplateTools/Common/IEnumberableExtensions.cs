using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassTemplateTools.Common
{
    public static class IEnumberableExtensions
    {
        public static IEnumerable<T> RemoveFirst<T>(this IEnumerable<T> ts)
        {
            int start = -1;
            foreach(var t in ts)
            {
                if(start == -1)
                {
                    start = 0;
                    continue;
                }

                yield return t;
            }
        }

        public static bool Any(this IEnumerable ts)
        => ts.GetEnumerator().MoveNext();

        public static Type GetEnumerableMemberType(this IEnumerable ts)
        {
            if (!ts.Any())
                throw new ArgumentNullException($"{typeof(IEnumerable)} can't empty");

            if (ts.GetType().IsGenericType)
                return ts.GetType().GetGenericArguments()[0];

            var etor = ts.GetEnumerator();
            etor.MoveNext();
            return etor.Current.GetType();
        }
    }
}
