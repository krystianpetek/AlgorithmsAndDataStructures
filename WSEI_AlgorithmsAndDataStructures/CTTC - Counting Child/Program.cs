using System.Text;
using System;
using System.Collections.Generic;

internal class Program
{

    static void Main(string[] args)
    {
        string readLine = Console.ReadLine();

        if (!int.TryParse(readLine, out int testCases))
            return;

        var list1 = new int[1000];
        var list2 = new int[1000];
        var list3 = new int[1000];

        StringBuilder output = new StringBuilder();

        for (int test = 0; test < testCases; test++)
        {
            string N = Console.ReadLine();

            if (!int.TryParse(N, out int n))
                return;

            int[] tokens1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int i = 1; i <= 2 * n; i++)
            {
                list1[i] = tokens1[i - 1];
            }
            for (int i = 1; i <= n; i++)
            {
                list2[i] = 0;
                list3[i] = 0;
            }

            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= 2 * n; i++)
            {
                if (list2[list1[i]] == 0)
                {
                    if (stack.Count > 0)
                    {
                        list3[stack.Peek()]++;
                    }
                    list2[list1[i]] = 1;
                    stack.Push(list1[i]);
                }
                else
                {
                    stack.Pop();
                }
            }
            output.Append($"Case {test + 1}:\n");
            for (int i = 1; i <= n; i++)
            {
                output.Append($"{i} -> {list3[i]}\n");
            }
        }
        Console.Write(output);
    }
}