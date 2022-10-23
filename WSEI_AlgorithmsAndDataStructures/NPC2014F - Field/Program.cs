using System;

static class Field
{
    static void Main()
    {
        var plants = new int[26];
        var blockOfTiles = new int[26];

        long.TryParse(Console.ReadLine(), out long N);
        var letters = Console.ReadLine();
        long.TryParse(Console.ReadLine(), out long K);

        for (int i = 0; i < K; i++)
        {
            var lineK = Console.ReadLine().Split(" ");

            int Xi = int.Parse(lineK[0]);
            char Yi = char.Parse(lineK[1]);

            plants[Yi - 'a'] = Xi;
        }

        var left = 0;
        var right = 0;
        var counter = int.MaxValue;
        var windowCount = 0;

        while (left < N && right < N)
        {
            var letterPositionLeft = letters[right] - 'a';
            blockOfTiles[letterPositionLeft]++;

            if (blockOfTiles[letterPositionLeft] == plants[letterPositionLeft])
                windowCount++;

            if (windowCount == K)
            {
                while (blockOfTiles[letters[left] - 'a'] > plants[letters[left] - 'a'])
                {
                    left++;
                    blockOfTiles[letters[left - 1] - 'a']--;
                }
                counter = (right - left + 1 < counter) ? right - left + 1 : counter;
            }
            right++;
        }

        if (counter != int.MaxValue)
            Console.WriteLine(counter);
        else
            Console.WriteLine("Andy rapopo");
    }
}