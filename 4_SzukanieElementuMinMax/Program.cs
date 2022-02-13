int[] tablicaLiczb = new[] { 4, 6, 2, 1, 3 };
int min = tablicaLiczb[0];
int max = tablicaLiczb[0];

for (int i = 1; i < tablicaLiczb.Length; i++)
{
    if(tablicaLiczb[i] < min)
    {
        min = tablicaLiczb[i];
        Console.WriteLine($"");
    }
}
Console.WriteLine($"Wartość minimalna = {min}");
Console.WriteLine();

for (int i = 1; i < tablicaLiczb.Length; i++)
{
    if(tablicaLiczb[i] > max)
    {
        max = tablicaLiczb[i];
        Console.WriteLine($"");
    }
}
Console.WriteLine($"Wartość maksymalna = {max}");