namespace Core
{
    public class LinearQueue
    {
        private readonly object[] _items;

        public LinearQueue(int maxSize = 100)
        {
            MaxSize = maxSize;
            Front = 0;
            Rear = -1;

            _items = new object[maxSize];
        }

        public int MaxSize { get; }
        public int Front { get; private set; }
        public int Rear { get; private set; }

        public LinearQueue Enqueue(object item)
        {
            if (IsFull())
                throw new QueueIsFullException();

            Rear += 1;

            _items[Rear] = item;

            return this;
        }

        public object Dequeue()
        {
            if (IsEmpty())
                return null;

            var item = _items[Front];

            Front += 1;

            return item;
        }

        public int Count()
            => Rear - Front + 1;

        private bool IsFull()
            => Rear + 1 == MaxSize;

        private bool IsEmpty()
            => Front > Rear;
    }
}