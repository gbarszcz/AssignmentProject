using System.Collections.Generic;
using System.Linq;

namespace AssignmentProject.comparer
{
    public class IntListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            return y != null && x != null && x.SequenceEqual(y);
        }

        public int GetHashCode(List<int> obj)
        {
            unchecked
            {
                return (obj.Capacity * 397) ^ obj.Count;
            }
        }
    }
}