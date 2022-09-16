using System;
using System.Collections.Generic;
using PujakCardGame.Utils;

namespace PujakCardGame.Utils
{
    public static class TransitionHandlerHelper
    {
        public static IEnumerable<T> 
            PrioritySortedWhereType<T>(this IEnumerable<object> source) where T : class, IHasPriority
        {
            List<T> satisfying = new ();
            foreach (object item in source)
                if (item is T t) satisfying.Add(t);
            satisfying.Sort(IHasPriorityComparer.Instance);
            return satisfying;
        }
    }
}
