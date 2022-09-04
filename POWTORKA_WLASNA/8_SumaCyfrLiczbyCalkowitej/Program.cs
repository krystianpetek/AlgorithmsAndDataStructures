Console.Write("Podaj liczbę do obliczenia sumy jej cyfr: ");
string? input = Console.ReadLine();
bool check = int.TryParse(input, out int output);
if (!check)
{
    Console.WriteLine("Błędne dane");
    return;
}
int wynik = 0;

int liczba = output;
while (liczba != 0)
{
    wynik += liczba % 10;
    liczba /= 10;
}
Console.WriteLine($"Suma cyfr liczby {output} to: {wynik}");