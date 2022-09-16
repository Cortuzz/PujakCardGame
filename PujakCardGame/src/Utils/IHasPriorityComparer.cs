using System.Collections.Generic;

namespace PujakCardGame.Utils
{
    public class IHasPriorityComparer : IComparer<IHasPriority>
    {
        private static readonly Comparer<int> _comparer = Comparer<int>.Default;

        public int Compare(IHasPriority x, IHasPriority y) => _comparer.Compare(x.Priority, y.Priority);

        public static IHasPriorityComparer Instance = new();
    }
}
