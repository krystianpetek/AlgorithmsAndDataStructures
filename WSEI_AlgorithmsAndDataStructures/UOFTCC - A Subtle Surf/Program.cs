using System;
class SubtleSurf
{
    static void Main()
    {
        var D = int.Parse(Console.ReadLine());

        for (int i = 0; i < D; i++)
        {
            var line1 = Console.ReadLine().Split(" ");
            var N = int.Parse(line1[0]);
            var C = int.Parse(line1[1]);
            var T = int.Parse(line1[2]);

            var G = new int[N];

            var nextLine = Console.ReadLine().Split(" ");
            for (int j = 0; j < N; j++)
            {
                G[j] = int.Parse(nextLine[j]);
            }
            int current = G[0];
            Array.Sort(G);

            int index = 0;
            while (index < G.Length && G[index] <= current)
            {
                index++;
            }

            index--;
            
            int steps = 0;
            int k = index;

            for (; k < G.Length; k++)
            {
                current = G[k];
                while (k < G.Length && current + C >= G[k])
                {
                    k++;
                }

                k--;                
                if (G[k] == current) 
                    break;

                steps++;
                k--;
            }
            Console.WriteLine(G[k] + " " + T * steps);
        }
    }
}