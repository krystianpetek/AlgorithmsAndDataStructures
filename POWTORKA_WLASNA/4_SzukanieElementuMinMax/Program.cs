int[] tablicaLiczb = new[] { 4, 6, 2, 1, 3 };
int min = tablicaLiczb[0];
int max = tablicaLiczb[0];

for (int i = 1; i < tablicaLiczb.Length; i++)
{
    Console.Write($"Czy liczba {tablicaLiczb[i]} jest mniejsza od {min} ? ");
    if (tablicaLiczb[i] < min)
    {
        Console.WriteLine("Tak");
        min = tablicaLiczb[i];
    }
    else
    {
        Console.WriteLine("Nie");
    }
}
Console.WriteLine($"Wartość minimalna = {min}");
Console.WriteLine();

for (int i = 1; i < tablicaLiczb.Length; i++)
{
    Console.Write($"Czy liczba {tablicaLiczb[i]} jest wieksza od {max} ? ");
    if (tablicaLiczb[i] > max)
    {
        Console.WriteLine("Tak");
        max = tablicaLiczb[i];
    }
    else
    {
        Console.WriteLine("Nie");
    }
}
Console.WriteLine($"Wartość maksymalna = {max}");

// http://www.algorytm.org/dla-poczatkujacych/szukanie-elementu-minimalnego-maksymalnego.html