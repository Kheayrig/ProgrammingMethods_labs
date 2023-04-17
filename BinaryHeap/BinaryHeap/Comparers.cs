namespace BinaryHeap
{
    public class MaxComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            if (x == null || y == null) throw new ArgumentNullException("Can't compare: argument is null.");
            return x.CompareTo(y);
        }
    }

    public class MinComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            if (x == null || y == null) throw new ArgumentNullException("Can't compare: argument is null.");
            return y.CompareTo(x);
        }
    }
}
