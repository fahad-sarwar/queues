using Xunit;

namespace Tests
{
    public class LinearQueueTestSpec
    {
        [Collection("UnitTest")]
        public class WhenQueueIsInitialised
        {
            private readonly LinearQueue _queue;

            public WhenQueueIsInitialised()
            {
                _queue = new LinearQueue();
            }

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
    }

    public class LinearQueue
    {
        public LinearQueue(int maxSize = 100)
        {
            MaxSize = maxSize;
            Front = 0;
            Rear = -1;
        }

        public int MaxSize { get; }
        public int Front { get; }
        public int Rear { get; }
    }
}
