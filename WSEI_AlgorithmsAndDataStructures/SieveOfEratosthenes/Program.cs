using System.Diagnostics;

namespace SieveOfEratosthenes;

static class Program
{
    static void Main()
    {
        bool tryParse = int.TryParse(Console.ReadLine(), out int n);
        if (!tryParse || n > 1000000)
        {
            Console.WriteLine("error");
            return;
        }

        // generate list of numbers
        var numbers = Enumerable.Range(0,n).ToList();
        
        // computed range sqrt of inputed n
        var sqrtN = Math.Sqrt(n);
        
        Stopwatch stopwatch = Stopwatch.StartNew();
        // eratosthenes algorithm
        for (var i = 2; i <= sqrtN; i++)
        {
            if (numbers[i] == 0)
                continue;
                
            var j = i+i;
            while (j<n)
            {
                numbers[j] = 0;
                j += i;
            }
        }
        stopwatch.Stop();
        var primeNumbers = numbers.Where(x => x != 0).Where(x => x != 1).ToList();

        // twins numbers
        var twinsNumbers = new List<string>();
        for (var i = 1; i < primeNumbers.Count; i++)
        {
            if (primeNumbers[i - 1] + 2 == primeNumbers[i])
                twinsNumbers.Add($"{primeNumbers[i-1]}, {primeNumbers[i]}");
        }
        
        // quadruplets
        var quadruplets = new List<string>();
        for (var i = 1; i < primeNumbers.Count-2; i++)
        {
            var p = primeNumbers[i - 1];
            if (p + 2 == primeNumbers[i] && p + 6 == primeNumbers[i + 1] && p + 8 == primeNumbers[i + 2])
                quadruplets.Add($"{primeNumbers[i-1]}, {primeNumbers[i]}, {primeNumbers[i+1]}, {primeNumbers[i+2]}");
        }


        bool exit = true;
        while (exit)
        {
            Console.WriteLine("1. Show prime numbers..");
            Console.WriteLine("2. Show twins numbers from prime numbers.");
            Console.WriteLine("3. Show quadruplets numbers from prime numbers.");
            Console.WriteLine("Any other to exit.");

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:

                    Console.WriteLine("\nPrime numbers: ");
                    primeNumbers.ForEach(x => Console.WriteLine(x));
                    break;
                
                case ConsoleKey.D2:
                    Console.WriteLine("\nTwins numbers: ");
                    twinsNumbers.ForEach(x => Console.WriteLine(x));
                    break;
                
                case ConsoleKey.D3:
                    Console.WriteLine("\nQuadruplets: ");
                    quadruplets.ForEach(x => Console.WriteLine(x));
                    break;
                
                default:
                    exit = false;
                    break;
            }
        }
    }    
}