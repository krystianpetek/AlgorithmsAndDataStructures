Console.WriteLine("Potęgowanie");
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
int wynik = 1;
for (int i = bOut; i > 0; i--)
{
    wynik *= aOut;
}
Console.WriteLine($"{aOut}^{bOut} = {wynik}");