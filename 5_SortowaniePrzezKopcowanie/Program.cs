int[] tablicaLiczb = {0, 1000, 33, 123, 10, 1, 12442, 99, 111 };
tablicaLiczb = new[] {0, 1000, 33, 123, 10, 1, 12442, 99, 111 };
Console.Write($"Tablica liczb przed sortowaniem: [");
Wypisz(tablicaLiczb);
var tablicaLiczbPoSortowaniu = Sortowanie(tablicaLiczb);
Console.Write($"Tablica liczb po sortowaniu: [");
Wypisz(tablicaLiczbPoSortowaniu);

int[] Sortowanie(int[] tablica)
{
    // budowanie kopca
    for (int i = 2; i < tablica.Length; i++)
    {
        int rodzic = i / 2;
        int lisc = i;
        while(rodzic > 0 && tablica[lisc] > tablica[rodzic])
        {
            Zamiana(ref tablica[lisc], ref tablica[rodzic]);
            lisc = rodzic;
            rodzic = lisc / 2;
        }
    }

    // rozbiorka kopca
    for (int i = tablica.Length - 1; i > 1; i--)
    {
        Zamiana(ref tablica[1], ref tablica[i]);
        int korzen = 1;
        int rodzic = 2;
        while(rodzic < korzen)
        {
            if (rodzic + 1 < i && tablica[rodzic+1] > tablica[rodzic])
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
// http://www.algorytm.org/algorytmy-sortowania/sortowanie-stogowe-heapsort.html