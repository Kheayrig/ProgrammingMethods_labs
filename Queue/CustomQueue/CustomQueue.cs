namespace CustomQueue
{
    public class CustomQueue<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        public int Count { get; private set; }
        public CustomQueue(int capacity = 4) {
            _head = 0;
            _tail = 0;
            if (capacity < 0) throw new ArgumentOutOfRangeException($"{nameof(capacity)} должен быть больше 0");
            else
            {
                _items = new T[capacity];
            }
        }
        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("В очереди нет элементов");
            return _items[_head];
        }
        public void Enqueue(T item)
        {
            if(Count == _items.Length)
            {
                SetCapacity(_items.Length * 2);
            }
            _items[_tail] = item;
            _tail++;
            if(_tail == _items.Length) _tail = 0;
            Count++;
        }
        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("В очереди нет элементов");
            T removed = _items[_head];
            _head++;
            if (_head == _items.Length) _head = 0;
            Count--;
            return removed;
        }
        public bool Contains(T item)
        {
            if (Count == 0) return false;

            if (_head < _tail)
            {
                return Array.IndexOf(_items, item, _head, Count) >= 0;
            }

            return
                Array.IndexOf(_items, item, _head, _items.Length - _head) >= 0 ||
                Array.IndexOf(_items, item, 0, _tail) >= 0;
        }
        private void SetCapacity(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException($"{nameof(capacity)} должен быть больше 0");
            else if(capacity > Array.MaxLength) capacity = Array.MaxLength;
            else if (capacity < 4) capacity = 4;
            var newArray = new T[capacity];

            if(_head < _tail)
            {
                Array.Copy(_items, newArray, Count);
            }
            else
            {
                Array.Copy(_items, _head, newArray, 0, _items.Length - _head);
                Array.Copy(_items, 0, newArray, _items.Length - _head, _tail);
            }
            _items = newArray;
            _head = 0;
            _tail = (Count == capacity) ? 0 : Count;
        }
    }
}