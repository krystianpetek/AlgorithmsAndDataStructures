using System;
using System.Linq;

namespace SubarrayXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int[] nk = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                int n = nk[0];
                int k = nk[1];

                int[] a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    int xor = a[j];
                    if (xor < k)
                    {
                        count++;
                    }
                    for (int l = j + 1; l < n; l++)
                    {
                        xor = xor ^ a[l];
                        if (xor < k)
                        {
                            count++;
                        }
                    }
                }

                Console.WriteLine(count);
            }
        }
    }
}
