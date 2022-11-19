using System;
using System.Collections.Generic;
public class StreetParade
{
    public static void Main()
    {
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int N))
                return;

            if (N == 0)
                return;

            var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var parade = Array.ConvertAll<string, int>(line, int.Parse);
            var queue = new Queue<int>(parade);
            var lane = new Stack<int>();

            var headOfParade = 1;
            while (queue.Count > 0 || lane.Count > 0)
            {

                if (lane.Count > 0 && lane.Peek() == headOfParade)
                {
                    lane.Pop();
                    headOfParade++;
                    continue;
                }

                if (queue.Count > 0 && queue.Peek() == headOfParade)
                {
                    queue.Dequeue();
                    headOfParade++;
                    continue;
                }

                if (queue.Count > 0 && queue.Peek() > headOfParade)
                {
                    lane.Push(queue.Dequeue());
                    continue;
                }

                Console.WriteLine("no");
                break;
            }

            if (queue.Count == 0 && lane.Count == 0)
            {
                Console.WriteLine("yes");
            }
        }
    }
}