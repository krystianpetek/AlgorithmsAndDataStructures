int[] tablicaLiczb = { 1000, 33, 123, 10, 1, 12442, 99, 111 };
Console.Write($"Tablica liczb przed sortowaniem: [");
Wypisz(tablicaLiczb);

int[] tablicaLiczbPoSortowaniu = new int[tablicaLiczb.Length];
tablicaLiczb.CopyTo(tablicaLiczbPoSortowaniu, 0);
Sortowanie(0, tablicaLiczbPoSortowaniu.Length - 1);

Console.Write($"Tablica liczb po sortowaniu: [");
Wypisz(tablicaLiczbPoSortowaniu);

void Sortowanie(int poczatek, int koniec)
{
    int poczatekMlodszy = poczatek;
    int koniecMlodszy = ((poczatek + koniec) / 2);
    int poczatekStarszy = (poczatek + koniec) / 2 + 1;
    int koniecStarszy = koniec;
    if (poczatek < koniec)
    {
        Sortowanie(poczatekMlodszy, koniecMlodszy);
        Sortowanie(poczatekStarszy, koniecStarszy);
        Scalanie(poczatek, koniec);
    }
}

void Scalanie(int poczatek, int koniec)
{
    int[] tabPomoc = new int[tablicaLiczbPoSortowaniu.Length];
    for (int i = 0; i <= koniec; i++)
    {
        tabPomoc[i] = tablicaLiczbPoSortowaniu[i];
    }
    int poczatekMlodszy = poczatek;
    int koniecMlodszy = (poczatek + koniec) / 2;
    int poczatekStarszy = (poczatek + koniec) / 2 + 1;
    int koniecStarszy = koniec;
    int licznik = poczatek;

    while (poczatekMlodszy <= koniecMlodszy && poczatekStarszy <= koniecStarszy)
    {
        if (tabPomoc[poczatekMlodszy] < tabPomoc[poczatekStarszy])
        {
            tablicaLiczbPoSortowaniu[licznik] = tabPomoc[poczatekMlodszy];
            licznik++;
            poczatekMlodszy++;
        }
        else
        {
            tablicaLiczbPoSortowaniu[licznik] = tabPomoc[poczatekStarszy];
            licznik++;
            poczatekStarszy++;
        }
    }
    while (poczatekMlodszy <= koniecMlodszy)
    {
        tablicaLiczbPoSortowaniu[licznik] = tabPomoc[poczatekMlodszy];
        licznik++;
        poczatekMlodszy++;
    }
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

// http://www.algorytm.org/algorytmy-sortowania/sortowanie-przez-scalanie-mergesort.html