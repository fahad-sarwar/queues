using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public static class LinearQueueTestSpec
    {
        private static LinearQueue _queue;

        public static void SpecBeforeTest(int maxSize = 100)
            => _queue = new LinearQueue(maxSize);

        [Collection("UnitTest")]
        public class WhenQueueIsInitialised
        {
            public WhenQueueIsInitialised()
                => SpecBeforeTest();

            [Fact]
            public void A_default_max_size_of_100_is_returned()
                => Assert.Equal(100, _queue.MaxSize);

            [Fact]
            public void The_front_pointer_is_set_to_1()
                => Assert.Equal(0, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_minus_1()
                => Assert.Equal(-1, _queue.Rear);
        }

        [Collection("UnitTest")]
        public class WhenAddingItemsToTheQueue
        {
            public WhenAddingItemsToTheQueue()
            {
                SpecBeforeTest();

                _queue
                    .Enqueue("One")
                    .Enqueue("Two")
                    .Enqueue("Three")
                    .Enqueue("Four")
                    .Enqueue("Five");
            }

            [Fact]
            public void A_count_of_5_is_returned()
                => Assert.Equal(5, _queue.Count());

            [Fact]
            public void The_front_pointer_is_set_to_1()
                => Assert.Equal(0, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_4()
                => Assert.Equal(4, _queue.Rear);
        }

        [Collection("UnitTest")]
        public class WhenTheQueueIsFull
        {
            public WhenTheQueueIsFull()
            {
                SpecBeforeTest(5);

                _queue
                    .Enqueue("One")
                    .Enqueue("Two")
                    .Enqueue("Three")
                    .Enqueue("Four")
                    .Enqueue("Five")
                    .Enqueue("Six");
            }

            [Fact]
            public void A_count_of_5_is_returned()
                => Assert.Equal(5, _queue.Count());

            [Fact]
            public void The_front_pointer_is_set_to_1()
                => Assert.Equal(0, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_4()
                => Assert.Equal(4, _queue.Rear);
        }
    }

    public class LinearQueue
    {
        private readonly List<string> _items;

        public LinearQueue(int maxSize = 100)
        {
            MaxSize = maxSize;
            Front = 0;
            Rear = -1;

            _items = new List<string>();
        }

        public int MaxSize { get; }
        public int Front { get; private set; }
        public int Rear { get; private set; }

        public LinearQueue Enqueue(string item)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full....throw exception");
                return this;
            }

            _items.Add(item);

            Rear += 1;

            return this;
        }

        private bool IsFull()
            => Rear + 1 == MaxSize;

        public int Count()
            => _items.Count;
    }
}
