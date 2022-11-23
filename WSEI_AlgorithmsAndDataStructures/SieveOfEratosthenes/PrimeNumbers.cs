namespace SieveOfEratosthenes;

public class PrimeNumbers : INumber
{
    public PrimeNumbers(List<int>? primeNumbers)
    {
        this.primeNumbers = primeNumbers;
    }

    public List<int>? primeNumbers { get; set; }

    public void Display()
    {
        Console.Write("\nPrime numbers: ");
        for(int i = 0; i < primeNumbers?.Count; i++)
        {
            if(i % 5 == 0)
            {
                Console.WriteLine();
            }
            Console.Write($"{primeNumbers[i]}".PadRight(10));
        }
        Console.WriteLine();
    }
}
