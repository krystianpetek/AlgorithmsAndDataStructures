int[] tablicaLiczb = new[] { 3, 54, 56, 44, 12, 8, 87, 34, 56, 72, 36, 90, 19, 4 };
Console.Write("Wprowadz poszukiwaną liczbę: ");
string? input = Console.ReadLine();
bool check = int.TryParse(input, out int output);
if (!check)
{
    Console.WriteLine("Wprowadzono nieprawidłową wartość.");
    return;
}
int[] tablicaLiczbIWartownik = new int[tablicaLiczb.Length + 1];
tablicaLiczb.CopyTo(tablicaLiczbIWartownik, 0);
tablicaLiczbIWartownik[^1] = output;

for (int i = 0; i < tablicaLiczbIWartownik.Length; i++)
{
    if (output == tablicaLiczbIWartownik[i])
    {
        if (i == tablicaLiczbIWartownik.Length - 1)
        {
            Console.WriteLine($"Nie odnaleziono w tablicy elementu {output}");
            return;
        }
        Console.WriteLine($"Odnaleziono element {output} na {i + 1} pozycji.");
        return;
    }
}

// http://www.algorytm.org/dla-poczatkujacych/szukanie-elementu-z-wartownikiem.html