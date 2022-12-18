using System;
using System.Collections.Generic;

namespace MedianQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            long t = long.Parse(Console.ReadLine());

            for (long i = 0; i < t; i++)
            {
                var maxHeap = new SortedSet<long>();
                var minHeap = new SortedSet<long>();

                string line;
                while ((line = Console.ReadLine()) != "0")
                {
                    long n = long.Parse(line);

                    if (n == -1)
                    {
                        long median;
                        if (maxHeap.Count == minHeap.Count)
                        {
                            median = maxHeap.Max;
                            maxHeap.Remove(median);
                        }
                        else
                        {
                            median = minHeap.Min;
                            minHeap.Remove(median);
                        }
                        Console.WriteLine(median);
                    }
                    else
                    {
                        if (maxHeap.Count == 0 || n < maxHeap.Max)
                        {
                            maxHeap.Add(n);
                        }
                        else
                        {
                            minHeap.Add(n);
                        }

                        if (maxHeap.Count > minHeap.Count + 1)
                        {
                            long max = maxHeap.Max;
                            maxHeap.Remove(max);
                            minHeap.Add(max);
                        }
                        else if (minHeap.Count > maxHeap.Count + 1)
                        {
                            long min = minHeap.Min;
                            minHeap.Remove(min);
                            maxHeap.Add(min);
                        }
                    }
                }
            }
        }
    }
}