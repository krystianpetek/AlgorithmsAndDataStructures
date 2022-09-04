Console.Write("Podaj tekst: ");
string? input = Console.ReadLine();
string result = String.Empty;
int count = 0;
while (count < input.Length)
{
    if (count % 2 == 0)
    {
        result += char.ToUpper(input[count]);
    }
    else
    {
        result += char.ToLower(input[count]);
    }
    count++;
}
Console.WriteLine($"Rezultat: {result}");

// http://www.algorytm.org/dla-poczatkujacych/naprzemiennosc-duzych-i-malych-liter-w-tekscie.html