int[] tablicaLiczb = new[] { 1, 7, 24, 25, 32, 43, 45, 49, 56, 58, 67, 69, 78, 95 };
Console.Write("Podaj szukaną wartość: ");
string? input = Console.ReadLine();
bool check = int.TryParse(input, out int szukanaWartosc);
if (!check)
{
    Console.WriteLine("Nieprawidłowa liczba.");
    return;
}
int poczatekT = 0;
int koniecT = tablicaLiczb.Length;

while (true)
{
    if (poczatekT >= koniecT)
    {
        Console.WriteLine($"Nie znaleziono elementu o wartości {szukanaWartosc}");
        return;
    }
    int srodekT = (poczatekT + koniecT) / 2;
    if (tablicaLiczb[srodekT] == szukanaWartosc)
    {
        Console.WriteLine($"Element {szukanaWartosc} został znaleziony pod indeksem {srodekT}");
        return;
    }
    if (szukanaWartosc > tablicaLiczb[srodekT])
    {
        poczatekT = ++srodekT;
    }
    else
    {
        koniecT = --srodekT;
    }
}

// http://www.algorytm.org/dla-poczatkujacych/szukanie-polowkowe-binarne.html