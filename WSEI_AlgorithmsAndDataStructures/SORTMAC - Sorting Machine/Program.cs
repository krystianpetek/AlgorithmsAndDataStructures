//namespace SORTMAC___Sorting_Machine
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //var xd = sort_list(new List<int> { 8, 12,25, 7,15, 19 });
//            var xd = sort_list(new List<int> { 1, -10, -1, -8,4 });
//            Console.WriteLine(xd);
//        }


//        static int sort_list(List<int> l)
//        {
//            // Initialize counter to 0
//            int counter = 0;
//            // Initialize pointer to the first element of the list
//            int i = 0;
//            // While the pointer is not at the end of the list
//            while (i < l.Count - 1)
//            {
//                //if (l[i] < l[i+1])
//                //{

//                //}
//                // If the element at the pointer is not in the correct position
//                if (l[i] > l[i + 1])
//                {
//                    // Find the correct position for the element

//                    //while (j < l.Count && l[j] < l[i])
//                    //{
//                    //    j += 1;
//                    //}
//                    // Move the element to the correct position using either MOVEBACK or MOVEFRONT
//                        // Use MOVEBACK
//                        //l.Add(l[i]);
//                        l.Add(l[i]);
//                        l.RemoveAt(i);
//                        counter += 1;

//                    // Use MOVEFRONT
//                }
//                else if (l[i+1] < l[i])
//                {
//                    l.Insert(0, l[i]);
//                    l.RemoveAt(i + 1);
//                    counter += 1;

//                }
//                // If the element at the pointer is in the correct position, move the pointer to the next element
//                else
//                {
//                    i += 1;
//                }


//            }
//            // Return the counter
//            return counter;
//        }
//    }
//}


//namespace SORTMAC___Sorting_Machine
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            var xd = sort_list(new List<int> { 8, 12, 25, 7, 15, 19 });
//            //var xd = sort_list(new List<int> { 1, -10, -1, -8, 4 });

//            Console.WriteLine(xd);
//        }


//        static int sort_list(List<int> l)
//        {
//            // Initialize counter to 0
//            int counter = 0;
//            // Initialize pointer to the first element of the list
//            int i = 0;
//            // While the pointer is not at the end of the list
//            while (i < l.Count - 1)
//            {
//                int current = l[i];
//                int next = l[i + 1];

//                if (current > next)
//                {
//                    l.RemoveAt(i+1);
//                    counter += 1;
//                }
//                //if (current < l[i + 1])
//                //{

//                //    l.Add(l[i]);
//                //    counter += 1;
//                //    i += 1;
//                //    // Use MOVEFRONT
//                //}
//                //else if (l[i + 1] < l[i])
//                //{
//                //    l.Insert(0, l[i]);
//                //    l.RemoveAt(i + 1);
//                //    counter += 1;

//                //}
//                else
//                {
//                    i += 1;
//                }
//            }

//            i = l.Count-1;
//            while(i > 0)
//            {
//                int current = l[i];
//                int next = l[i -1];

//                if (next > current)
//                {
//                    l.RemoveAt(i-1);
//                    counter += 1;
//                }
//                else
//                {
//                    i -= 1;
//                }
//            }
//             return counter;
//        }
//    }
//}

using System;
using System.Linq;

namespace SortMac;

class Program
{
    static void Main(string[] args)
    {
        int numTestCases = int.Parse(Console.ReadLine());

        for (int t = 0; t < numTestCases; t++)
        {
            int numElements = int.Parse(Console.ReadLine());
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numInstructions = 0;
            int lastMoved = int.MinValue;

            for (int i = 0; i < numElements; i++)
            {
                if (elements[i] < lastMoved)
                {
                    numInstructions++;
                    lastMoved = elements[i];
                }
                else if (elements[i] > lastMoved)
                {
                    numInstructions++;
                    lastMoved = elements[i];
                }
            }
            Console.WriteLine(numInstructions);
        }
    }
}
