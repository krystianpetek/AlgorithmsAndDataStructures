int[] tablicaLiczb = { 0, 1000, 33, 123, 10, 55, 43, 12354, 332, 554, 124, 345, 456, 12442, 99, 111 };
Console.Write($"Tablica liczb przed sortowaniem: [");
Wypisz(tablicaLiczb);

int[] tablicaLiczbPoSortowaniu = new int[tablicaLiczb.Length];
Array.Copy(tablicaLiczb, tablicaLiczbPoSortowaniu, tablicaLiczb.Length);

Sortowanie(tablicaLiczbPoSortowaniu);
Console.Write($"Tablica liczb po sortowaniu: [");
Wypisz(tablicaLiczbPoSortowaniu);

int[] BudowanieKopca(int[] tablica)
{
    // budowanie kopca
    for (int i = 2; i < tablica.Length; i++)
    {
        int rodzic = i / 2;
        int lisc = i;
        while (rodzic > 0 && tablica[lisc] > tablica[rodzic])
        {
            Zamiana(ref tablica[lisc], ref tablica[rodzic]);
            lisc = rodzic;
            rodzic = lisc / 2;
        }
    }
    return tablica;
}
int[] RozbiorkaKopca(int[] tablica)
{
    // rozbiorka kopca
    for (int i = tablica.Length - 1; i >= 1; i--)
    {
        Zamiana(ref tablica[1], ref tablica[i]);
        int rodzic = 2;
        int korzen = 1;
        while (rodzic < i)
        {
            int dziecko;
            if (rodzic + 1 < i && tablica[rodzic + 1] > tablica[rodzic])
            {
                dziecko = rodzic + 1;
            }
            else
            {
                dziecko = rodzic;
            }
            if (tablica[dziecko] <= tablica[korzen])
                break;

            Zamiana(ref tablica[korzen], ref tablica[dziecko]);
            korzen = dziecko;
            rodzic = korzen * 2;
        }
    }
    return tablica;
}
int[] Sortowanie(int[] tablica)
{
    BudowanieKopca(tablica);
    WyswietlKopiec(tablica);
    RozbiorkaKopca(tablica);
    return tablica;
}

void WyswietlKopiec(int[] tab)
{
    int k = tab.Length / 2;
    for (int i = 1; i < tab.Length; i *= 2)
    {
        for (int j = i; j < (i * 2); j++)
        {
            for (int kk = k; kk >= 0; kk--)
            {
                Console.Write(" ");
            }

            if (j == tab.Length)
                break;
            Console.Write(tab[j] + " ");
            k /= 2;
        }
        Console.WriteLine();
    }
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
// https://eduinf.waw.pl/inf/alg/003_sort/0017.php