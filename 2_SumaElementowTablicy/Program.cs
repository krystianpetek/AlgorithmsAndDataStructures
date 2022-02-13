int[] tablicaLiczb = new[] {4,1,6,1,3};
int wynik = 0;
for(int i = 0; i < tablicaLiczb.Length; i++)
{
    Console.WriteLine($"wynik = wynik + a[{i}] = {wynik} + {tablicaLiczb[i]} = {wynik + tablicaLiczb[i]}");
    wynik += tablicaLiczb[i];
}
Console.WriteLine($"\nOstateczny wynik to {wynik}");

// http://www.algorytm.org/dla-poczatkujacych/suma-elementow-tablicy.html