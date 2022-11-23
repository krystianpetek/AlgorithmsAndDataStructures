namespace SieveOfEratosthenes;

public class TwinsNumbers : INumber
{
    public TwinsNumbers(List<int>? primeNumbers)
    {
        this.primeNumbers = primeNumbers;
    }

    public List<int>? primeNumbers { get; set; }

    public void Display()
    {
        Console.Write("\nTwin numbers: ");

        // twins numbers
        var twinsNumbers = new List<string>();
        for (var i = 1; i < primeNumbers?.Count; i++)
        {
            if (primeNumbers[i - 1] + 2 == primeNumbers[i])
                twinsNumbers.Add($"{primeNumbers[i - 1]}, {primeNumbers[i]}");
        }

        for (int i = 0; i < twinsNumbers?.Count; i++)
        {
            if (i % 3 == 0)
            {
                Console.WriteLine();
            }
            Console.Write($"{twinsNumbers[i]}".PadRight(20));
        }
        Console.WriteLine();
    }
}
