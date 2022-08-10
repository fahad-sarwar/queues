using Core;
using Xunit;

namespace Tests
{
    public static class CircularQueueTestSpec
    {
        //https://isaaccomputerscience.org/concepts/dsa_datastruct_queue?examBoard=all&stage=all&topic=data_structures

        private static CircularQueue _queue;

        public static void SpecBeforeTest(int maxSize = 100)
            => _queue = new CircularQueue(maxSize);

        [Collection("UnitTest")]
        public class WhenInitialisingAQueue
        {
            public WhenInitialisingAQueue()
                => SpecBeforeTest();

            [Fact]
            public void A_default_max_size_of_100_is_returned()
                => Assert.Equal(100, _queue.MaxSize);

            [Fact]
            public void The_front_pointer_is_set_to_minus_1()
                => Assert.Equal(-1, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_minus_1()
                => Assert.Equal(-1, _queue.Rear);

            [Fact]
            public void The_number_of_items_in_the_queue_is_0()
                => Assert.Equal(0, _queue.Count());
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
            public void The_number_of_items_in_the_queue_is_5()
                => Assert.Equal(5, _queue.Count());

            [Fact]
            public void The_front_pointer_is_set_to_0()
                => Assert.Equal(0, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_4()
                => Assert.Equal(4, _queue.Rear);
        }

        [Collection("UnitTest")]
        public class WhenRemovingItemsFromTheQueue
        {
            private readonly object _dequeuedItem;

            public WhenRemovingItemsFromTheQueue()
            {
                SpecBeforeTest();

                _queue
                    .Enqueue("One")
                    .Enqueue("Two")
                    .Enqueue("Three")
                    .Enqueue("Four")
                    .Enqueue("Five");

                _dequeuedItem = _queue.Dequeue();
            }

            [Fact]
            public void The_number_of_items_in_the_queue_is_4()
                => Assert.Equal(4, _queue.Count());

            [Fact]
            public void The_front_pointer_is_set_to_1()
                => Assert.Equal(1, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_4()
                => Assert.Equal(4, _queue.Rear);

            [Fact]
            public void The_dequeued_item_is_not_null()
                => Assert.NotNull(_dequeuedItem);
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
                    .Enqueue("Five");
            }

            [Fact]
            public void A_queue_is_full_exception_is_thrown()
                => Assert.Throws<QueueIsFullException>(() => _queue.Enqueue("Six"));
        }

        [Collection("UnitTest")]
        public class WhenTheQueueIsEmpty
        {
            public WhenTheQueueIsEmpty()
            {
                SpecBeforeTest(2);

                _queue
                    .Enqueue("One")
                    .Enqueue("Two");

                _queue.Dequeue();
                _queue.Dequeue();
            }

            [Fact]
            public void No_item_is_returned()
                => Assert.Null(_queue.Dequeue());

            [Fact]
            public void The_number_of_items_in_the_queue_is_0()
                => Assert.Equal(0, _queue.Count());

            [Fact]
            public void The_front_pointer_is_set_to_minus_1()
                => Assert.Equal(-1, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_minus_1()
                => Assert.Equal(-1, _queue.Rear);
        }

        [Collection("UnitTest")]
        public class WhenTheQueueIsReset
        {
            public WhenTheQueueIsReset()
            {
                SpecBeforeTest(5);

                _queue
                    .Enqueue("One")
                    .Enqueue("Two")
                    .Enqueue("Three")
                    .Enqueue("Four")
                    .Enqueue("Five");

                _queue.Dequeue();
                _queue.Dequeue();

                _queue
                    .Enqueue("Six");
            }

            [Fact]
            public void The_number_of_items_in_the_queue_is_4()
                => Assert.Equal(4, _queue.Count());

            [Fact]
            public void The_front_pointer_is_set_to_2()
                => Assert.Equal(2, _queue.Front);

            [Fact]
            public void The_rear_pointer_is_set_to_0()
                => Assert.Equal(0, _queue.Rear);
        }
    }
}
