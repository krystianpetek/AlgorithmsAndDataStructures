using System;

namespace SillySort;

class SSORT___Silly_Sort
{
    static void Main(string[] args)
    {
        int counter = 1;
        while (true)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 0) break;
            
            int[] arrA = Array.ConvertAll<string, int>(Console.ReadLine().Split(" "), int.Parse);
            int[] arrB = new int[arrA.Length];

            for (int i = 0; i < n; ++i) 
                arrB[i] = i;

            for (int i = 0; i < n; ++i)
                for (int j = i + 1; j < n; ++j)
                    if (arrA[arrB[i]] > arrA[arrB[j]])
                        (arrB[i],arrB[j]) = (arrB[j],arrB[i]);

            int mn = arrA[0];

            for (int i = 1; i < n; ++i)
                mn = Math.Min(mn, arrA[i]);

            bool[] flag = new bool[1000];
            int result = 0;

            for (int i = 0; i < n; ++i)
            {
                if (!flag[i])
                {
                    int mn2 = arrA[i];
                    int ind = i;
                    int sum = 0;
                    int sz = 0;

                    while (!flag[ind])
                    {
                        flag[ind] = true;
                        sum += arrA[ind];
                        mn2 = Math.Min(mn2, arrA[ind]);
                        ind = arrB[ind];
                        ++sz;
                    }

                    result += Math.Min(sum + (sz - 2) * mn2, sum + mn2 + (sz + 1) * mn);
                }
            }
            Console.WriteLine($"Case {counter++}: {result}\n");
        }
    }
}
