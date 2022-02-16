int[] tablicaLiczb = { 1000, 33, 123, 10, 1, 12442, 99, 111 };
Console.Write($"Tablica liczb przed sortowaniem: [");
Wypisz(tablicaLiczb);
var tablicaLiczbPoSortowaniu = Sortowanie(tablicaLiczb);
Console.Write($"Tablica liczb po sortowaniu: [");
Wypisz(tablicaLiczbPoSortowaniu);

int[] Sortowanie(int[] tablica)
{
    for (int i = 1; i < tablica.Length; i++)
    {
        for (int j = 0; j < i; j++)
        {
            Console.Write($"Czy {tablica[j]} > {tablica[i]} ? ");

            if (tablica[j] > tablica[i])
            {
                Console.Write($"tak, zamieniam {tablica[j]} z {tablica[i]}\n");
                Zamiana(ref tablica[i], ref tablica[j]);
            }
            else
            {
                Console.WriteLine("nie");
            }
        }
    }
    return tablica;
}

void Zamiana(ref int x, ref int y)
{
    int temp = x;
    x = y;
    y = temp;
}

void Wypisz(int[] tablicaLiczb)
{
    for (int i = 0; i < tablicaLiczb.Length; i++)
    {
        if (i == tablicaLiczb.Length - 1)
            Console.Write($"{tablicaLiczb[i]}");
        else
            Console.Write($"{tablicaLiczb[i]}, ");
    }
    Console.Write("]\n");
}
// http://www.algorytm.org/algorytmy-sortowania/sortowanie-przez-wstawianie-insertionsort.html