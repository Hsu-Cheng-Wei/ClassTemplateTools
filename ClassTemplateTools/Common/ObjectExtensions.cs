using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClassTemplateTools.Common
{
    public static class ObjectExtensions
    {
        public static T RemoveAtVirtualProperty<T>(this T obj) where T : class
        => RemoveAtVirtualProperty(obj, new HashSet<object>() { obj });

        public static T RemoveAtVirtualProperty<T>(this T obj, ICollection<object> partterns) where T : class
        {
            if (partterns.Contains(obj))
                return null;

            partterns.Add(obj);

            foreach (var dic in obj.GetType()
                .GetProperties()
                .Where(p => p.GetGetMethod().IsVirtual)
                .ToDictionary(key => key, value => value.GetValue(obj))
                .Where(dic => dic.Value != null))
            {
                if (typeof(IEnumerable).IsAssignableFrom(dic.Value.GetType()))
                {
                    if(!((IEnumerable)dic.Value).Any())
                    {
                        dic.Key.SetValue(obj, null);
                        continue;
                    }

                    var newCollect = Activator.CreateInstance(dic.Value.GetType());
                    var method = newCollect.GetType().GetMethod("Add");
                    try
                    {
                        foreach (var subValue in (IEnumerable)dic.Value)
                        {
                            if (partterns.All(p => !p.Equals(subValue)))
                            {
                                var value = subValue.RemoveAtVirtualProperty(partterns);
                                method.Invoke(newCollect, new[] { value });
                            }
                        }
                    }catch(Exception e)
                    {

                    }

                    var tmp = (IEnumerable)newCollect;
                    dic.Key.SetValue(obj, !tmp.Any() ? null : newCollect);
                }
                else
                {
                    if (!partterns.All(p => !p.Equals(dic.Value)))
                        dic.Key.SetValue(obj, null);
                    else
                        dic.Key.SetValue(obj, dic.Value.RemoveAtVirtualProperty(partterns));
                }
            }

            return obj;
        }
    }
}
