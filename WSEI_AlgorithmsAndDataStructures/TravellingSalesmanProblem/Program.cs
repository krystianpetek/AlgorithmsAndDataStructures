using System.Diagnostics;

namespace TravellingSalesmanProblem;


public class Program
{
    public static async Task Main()
    {
        InputFromUser(out int N, out DrawRange drawRange);

        var travellingSalesman = new TravellingSalesman(N,drawRange);
        Stopwatch stopwatch= Stopwatch.StartNew();
        await travellingSalesman.StartAsync();
        stopwatch.Stop();
        Console.WriteLine($"Program has ended working after: {(stopwatch.ElapsedMilliseconds) / 1000} seconds.");
    }
    private static void InputFromUser(out int N, out DrawRange drawRange)
    {
        try
        {
            Console.Write("Please enter the number of the city to visit by Travelling Salesman smaller than 500.\nN: ");
            bool tryParse = int.TryParse(Console.ReadLine(), out N);
            if (!tryParse || N > 500)
            {
                Console.WriteLine("Wrong value, error!");
                Environment.Exit(1);
            }
            Console.Write("Please enter minimal length between cities: ");
            var MinValue = int.Parse(Console.ReadLine());

            Console.Write("Please enter maximal length between cities: ");
            var MaxValue = int.Parse(Console.ReadLine());

            if (MaxValue < MinValue)
            {
                Console.WriteLine("Wrong value, error!");
                Environment.Exit(1);
            }

            drawRange = new DrawRange(MinValue, MaxValue);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong value, error!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ex.Message);
            Environment.Exit(-1);
            throw;
        }
    }
}
