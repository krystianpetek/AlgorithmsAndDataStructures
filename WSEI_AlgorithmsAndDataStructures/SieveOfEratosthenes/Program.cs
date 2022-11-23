namespace SieveOfEratosthenes;

public class Program
{
    public static void Main()
    {
        InputFromUser(out int N);

        // generate list of numbers
        var numbers = Enumerable.Range(0, N).ToList();

        // computed range sqrt of inputed n
        var sqrtN = Math.Sqrt(N);

        // eratosthenes algorithm
        for (var i = 2; i <= sqrtN; i++)
        {
            if (numbers[i] == 0)
                continue;

            var j = i + i;
            while (j < N)
            {
                numbers[j] = 0;
                j += i;
            }
        }

        var primeNumbers = numbers.Where(x => x != 0).Where(x => x != 1).ToList();

        INumber primeList;
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
                case ConsoleKey.NumPad1:
                    primeList = new PrimeNumbers(primeNumbers);
                    primeList.Display();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    primeList = new TwinsNumbers(primeNumbers);
                    primeList.Display();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    primeList = new QuadrupletsNumbers(primeNumbers);
                    primeList.Display();
                    break;

                default:
                    exit = false;
                    break;
            }
        }
    }

    private static void InputFromUser(out int N)
    {
        Console.Write("Please enter the number of the end of the range lower than or equal 1000000\nN: ");
        bool tryParse = int.TryParse(Console.ReadLine(), out N);
        if (!tryParse || N >= 1000000)
        {
            Console.WriteLine("Wrong value, error!");
            Environment.Exit(1);
        }
    }
}