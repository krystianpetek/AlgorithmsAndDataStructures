namespace SieveOfEratosthenes;

public class QuadrupletsNumbers : INumber
{
    public QuadrupletsNumbers(List<int>? primeNumbers)
    {
        this.primeNumbers = primeNumbers;
    }

    public List<int>? primeNumbers { get; set; }

    public void Display()
    {
        Console.WriteLine("\nQuadruplet numbers: ");

        var quadruplets = new List<string>();
        for (var i = 1; i < primeNumbers?.Count - 2; i++)
        {
            var p = primeNumbers[i - 1];
            if (p + 2 == primeNumbers[i] && p + 6 == primeNumbers[i + 1] && p + 8 == primeNumbers[i + 2])
                quadruplets.Add($"{primeNumbers[i - 1]}, {primeNumbers[i]}, {primeNumbers[i + 1]}, {primeNumbers[i + 2]}");
        }

        quadruplets.ForEach(x => Console.WriteLine(x));
    }
}
