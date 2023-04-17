using BinaryHeap;

namespace ConsoleTask
{
    public class MaxThirdElement<T>: BinaryHeap<T>
    {
        public MaxThirdElement(IComparer<T> maxComparer) : base(maxComparer) { }

        public T GetThirdHeadOn()
        {
            if (Count < 3) throw new InvalidOperationException("Count less than 3, can't find max third element.");
            Pop();
            Pop();
            return Peek();
        }

        public T GetThirdFaster()
        {
            if (Count < 3) throw new InvalidOperationException("Count less than 3, can't find max third element.");
            int largest = 1;
            int min = 2;
            if (_comparer.Compare(_heap[min], _heap[largest]) > 0)
            {
                min = 1;
                largest = 2;
            }
            if (largest * 2 + 1 < Count && _comparer.Compare(_heap[min], _heap[largest * 2 + 1]) < 0)
                min = largest * 2 + 1;
            if (largest * 2 + 2 < Count && _comparer.Compare(_heap[min], _heap[largest * 2 + 2]) < 0)
                min = largest * 2 + 2;
            return _heap[min];
        }
    }
}
