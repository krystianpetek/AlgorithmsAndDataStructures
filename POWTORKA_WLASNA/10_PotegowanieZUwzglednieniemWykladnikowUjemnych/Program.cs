Console.WriteLine("Potęgowanie z uwzględnieniem wykładników ujemnych");
Console.Write("Podaj a: ");
string? aString = Console.ReadLine();
Console.Write("Podaj b: ");
string? bString = Console.ReadLine();
bool aCheck = int.TryParse(aString, out int aOut);
bool bCheck = int.TryParse(bString, out int bOut);
if (!aCheck && !bCheck)
{
    Console.WriteLine("Błędne dane");
    return;
}
double wynik = 1;

if (bOut >= 0)
{
    for (int i = bOut; i > 0; i--)
    {
        wynik *= aOut;
    }
    Console.WriteLine($"{aOut}^{bOut} = {wynik}");
}
else
{
    for (int i = bOut; i < 0; i++)
    {
        wynik *= aOut;
    }
    wynik = 1 / wynik;
    Console.WriteLine($"{aOut}^{bOut} = {wynik}");
}

// http://www.algorytm.org/dla-poczatkujacych/potegowanie-z-uwzglednieniem-wykladnikow-ujemnych.html