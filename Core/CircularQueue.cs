using System.Linq;

namespace Core
{
    public class CircularQueue
    {
        private readonly object[] _items;

        public CircularQueue(int maxSize)
        {
            MaxSize = maxSize;
            Front = -1;
            Rear = -1;

            _items = new object[maxSize];
        }

        public int MaxSize { get; set; }
        public int Front { get; set; }
        public int Rear { get; set; }

        public CircularQueue Enqueue(object item)
        {
            if (IsFull())
                throw new QueueIsFullException();

            Rear = CalculateNextValue(Rear);

            if(Front == -1)
                Front += 1;

            _items[Rear] = item;

            return this;
        }

        public object Dequeue()
        {
            if (IsEmpty())
                return null;

            var item = _items[Front];
            _items[Front] = null;

            if (Front == Rear)
            {
                Front = -1;
                Rear = -1;
            }
            else
                Front = CalculateNextValue(Front);

            return item;
        }

        public int Count()
            => _items.Count(i => i != null);

        private bool IsFull()
            => CalculateNextValue(Rear) == Front;

        private bool IsEmpty()
            => Front == -1;

        private int CalculateNextValue(int pointer)
            => (pointer + 1) % MaxSize;
    }
}