int[] tablicaLiczb = { 1000, 33, 123, 10, 1, 12442, 99, 111 };
Console.Write($"Tablica liczb przed sortowaniem: [");
Wypisz(tablicaLiczb);
var tablicaLiczbPoSortowaniu = Sortowanie(tablicaLiczb);
Console.Write($"Tablica liczb po sortowaniu: [");
Wypisz(tablicaLiczbPoSortowaniu);

int[] Sortowanie(int[] tablica)
{
    for (int i = 0; i < tablica.Length; i++)
    {
        int minimum = tablica[i];
        int index = 0;
        for (int j = i + 1; j < tablica.Length; j++)
        {
            if (tablica[j] < minimum)
            {
                minimum = tablica[j];
                index = Array.IndexOf(tablica, minimum);
            }
        }
        if (tablica.Length - 1 == i)
            break;

        Console.WriteLine($"MINIMUM: {minimum}, zamieniam {tablica[i]} z indexu[{i}] na {tablica[index]} z indexu[{index}]");
        Zamiana(ref tablica[index], ref tablica[i]);
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

// http://www.algorytm.org/algorytmy-sortowania/sortowanie-przez-wymiane-wybor-selectionsort.html