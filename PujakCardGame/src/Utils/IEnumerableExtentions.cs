using System;
using System.Collections.Generic;

namespace PujakCardGame.Utils
{
    public static class IEnumerableExtentions
    {
        public static IEnumerable<TDest> 
            PrioritySortedWhereType<TDest>(this IEnumerable<object> source) where TDest : class, IHasPriority
        {
            List<TDest> satisfying = new ();
            foreach (object item in source)
                if (item is TDest t) satisfying.Add(t);
            satisfying.Sort(IHasPriorityComparer.Instance);
            return satisfying;
        }
    }
}
