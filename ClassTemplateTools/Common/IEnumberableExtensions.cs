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
    }
}
