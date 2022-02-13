int[] tablicaLiczb = new[] { 3, 54, 56, 44, 12, 8, 87, 34, 56, 72, 36, 90, 19, 4 };
Console.Write("Wprowadz poszukiwaną liczbę: ");
string? input = Console.ReadLine();
bool check = int.TryParse(input,out int output);
if(!check)
{
    Console.WriteLine("Wprowadzono nieprawidłową wartość.");
    return;
}

for (int i = 0; i < tablicaLiczb.Length; i++)
{
    Console.Write($"Czy liczba {output} jest równa {tablicaLiczb[i]}? ");
    if (output == tablicaLiczb[i])
    {
        Console.WriteLine("Tak!");
        Console.WriteLine("Znaleziono element w tablicy");
        return;
    }
    Console.WriteLine("Nie");
    if (i == tablicaLiczb.Length - 1)
        Console.WriteLine("Nie znaleziono elementu w tablicy");
}