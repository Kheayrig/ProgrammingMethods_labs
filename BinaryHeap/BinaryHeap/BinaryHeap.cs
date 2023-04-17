namespace BinaryHeap
{
    public class BinaryHeap<T>
    {
        protected List<T> _heap = new List<T>();
        protected IComparer<T> _comparer;
        public int Count { 
            get { return _heap.Count; }
        }

        public BinaryHeap(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public void Insert(T item)
        {
            _heap.Add(item);
            HeapifyUp(Count - 1);
        }

        public T Pop()
        {
            if (_heap.Count == 0) throw new InvalidOperationException("Empty binary heap!");
            T removed = _heap[0];
            _heap[0] = _heap[Count-1];
            _heap.RemoveAt(Count-1);
            HeapifyDown(0);
            return removed;
        }

        public T Peek()
        {
            if (_heap.Count == 0) throw new InvalidOperationException("Empty binary heap!");
            return _heap[0];
        }

        //work time = o(log n) -> depends on height of tree
        protected void HeapifyDown(int index)
        {
            while (index < Count)
            {
                var left = 2 * index + 1;
                var right = 2 * index + 2;
                var largest = index;
                if (left < Count && _comparer.Compare(_heap[left], _heap[index]) > 0)
                    largest = left;
                if (right < Count && _comparer.Compare(_heap[right], _heap[largest]) > 0)
                    largest = right;
                if (largest == index) return;

                Swap(index, largest);
                index = largest;
            }
        }

        //work time = o(1) or o(log n) -> depends on height of tree
        protected void HeapifyUp(int index)
        {
            while(index > 0)
            {
                int parent = (index - 1) / 2;
                if (_comparer.Compare(_heap[index], _heap[parent]) > 0)
                    Swap(index, parent);
                else return;
                index = parent;
            } 
        }

        protected void Swap(int index1, int index2)
        {
            var temp = _heap[index1];
            _heap[index1] = _heap[index2];
            _heap[index2] = temp;
        }
    }
}