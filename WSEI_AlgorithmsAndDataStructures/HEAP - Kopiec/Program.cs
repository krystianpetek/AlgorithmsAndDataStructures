using System.Text;

namespace HEAP___Kopiec
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string n = Console.ReadLine();
            if (!int.TryParse(n, out int N))
                return;

            while (N > 0)
            {
                N -= 1;
                string numberOfTests = Console.ReadLine();

                if (!int.TryParse(numberOfTests, out int tests))
                    return;

                Heap heap = new Heap(tests);

                int count = 0;
                while (count < heap.HeapSize)
                {
                    string read = Console.ReadLine();
                    if (!int.TryParse(read, out int parsedNumber))
                        return;

                    heap.Insert(parsedNumber);

                    count++;
                }
                heap.BuildHeap();

                _ = Console.ReadLine();
                string m = Console.ReadLine();
                if (!int.TryParse(m, out int M))
                    return;

                while (M > 0)
                {
                    M -= 1;
                    string read = Console.ReadLine();
                    if (read == "P")
                        Console.WriteLine(heap.ReturnString());
                    else if (read == "E")
                        Console.WriteLine(heap.Remove());
                }
                _ = Console.ReadLine();
            }
        }
    }

    public class Heap
    {
        public long[] HeapArray { get; set; }
        public long HeapSize => HeapArray.Length;
        public long CurrentHeapSize { get; set; }

        public Heap(long capacity)
        {
            HeapArray = new long[capacity];
            CurrentHeapSize = 0;
        }

        public long Parent(long key) => (key - 1) / 2;
        public long Left(long key) => 2 * key + 1;
        public long Right(long key) => 2 * key + 2;
        public static void Swap(ref long left, ref long right) => (left, right) = (right, left);

        public void Insert(long value)
        {
            HeapArray[CurrentHeapSize] = value;
            //Sort(CurrentHeapSize);

            CurrentHeapSize += 1;
        }

        private void Sort(long counter)
        {
            while (counter > 0)
            {
                long father = HeapArray[Parent(counter)];
                long child = HeapArray[counter];

                if (child < father)
                {
                    (HeapArray[Parent(counter)], HeapArray[counter]) = (child, father);
                }
                counter = Parent(counter);
            }
        }

        public long? Remove()
        {
            long removed = HeapArray[0];
            try
            {
                HeapArray[0] = 0;
                Swap(ref HeapArray[CurrentHeapSize - 1], ref HeapArray[0]);
                CurrentHeapSize -= 1;

                long n = 0;
                long left = Left(n);
                long right = Right(n);

                while (true)
                {
                    if (right < CurrentHeapSize && HeapArray[n] > HeapArray[left] || HeapArray[n] > HeapArray[right])
                    {
                        if (HeapArray[right] < HeapArray[left])
                        {
                            (HeapArray[n], HeapArray[right]) = (HeapArray[right], HeapArray[n]);
                            n = Right(n);
                        }
                        else
                        {
                            (HeapArray[n], HeapArray[left]) = (HeapArray[left], HeapArray[n]);
                            n = Left(n);
                        }
                    }

                    else if (left < CurrentHeapSize && HeapArray[n] > HeapArray[left])
                    {
                        (HeapArray[n], HeapArray[left]) = (HeapArray[left], HeapArray[n]);
                        break;
                    }

                    else
                        break;

                    left = Left(n);
                    right = Right(n);
                }
            }
            catch (Exception e) { }
            return removed;
        }

        public string ReturnString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < CurrentHeapSize; i++)
                builder.Append(HeapArray[i] + " ");

            return builder.ToString();
        }

        private void Heapify(long i)
        {
            long smallest = i;
            long left = Left(i);
            long right = Right(i);

            if (CurrentHeapSize > left && HeapArray[left] < HeapArray[smallest])
                smallest = left;

            if (CurrentHeapSize > right && HeapArray[right] < HeapArray[smallest])
            {
                smallest = right;

                if (HeapArray[right] == HeapArray[left])
                    smallest = left;
            }

            if (smallest != i)
            {
                Swap(ref HeapArray[i], ref HeapArray[smallest]);
                Heapify(smallest);
            }
        }

        public void BuildHeap()
        {
            for (long i = CurrentHeapSize - 1; i >= 0; i--)
                Heapify(i);
        }
    }
}