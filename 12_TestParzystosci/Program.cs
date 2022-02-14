Console.WriteLine("TEST PARZYSTOŚCI");
Console.Write("Podaj liczbę parzystą: ");
string? wejscie = Console.ReadLine();
bool sprawdzParzystosc = int.TryParse(wejscie, out int parzysta);
if (!sprawdzParzystosc)
{
    Console.WriteLine("Niepoprawne dane wejściowe.");
    return;
}
string wynik = (parzysta % 2 == 0) ? $"Liczba {parzysta} jest parzysta" : $"Liczba {parzysta} nie jest parzysta";
Console.WriteLine(wynik);