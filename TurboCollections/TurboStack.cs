namespace TurboCollections
{
    public class TurboStack<T>
    {
        public int Count { get; private set; }

        public void Push(int item)
        {
            Count++;
        }
    }
}