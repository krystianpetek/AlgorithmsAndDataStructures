int[] tablicaLiczb = { 1000, 33, 123, 10, 1, 12442, 99, 111 };
Console.Write($"Tablica liczb przed sortowaniem: [");
Wypisz(tablicaLiczb);
var tablicaLiczbPoSortowaniu = Sortowanie(tablicaLiczb, 0, tablicaLiczb.Length - 1);
Console.Write($"Tablica liczb po sortowaniu: [");
Wypisz(tablicaLiczbPoSortowaniu);

int[] Sortowanie(int[] tablica, int lewo, int prawo)
{
    int pivot = tablica[prawo];

    int wskaznikLewy = lewo;
    int wskaznikPrawy = prawo - 1;

    while (true)
    {
        while (tablica[wskaznikLewy] < pivot && wskaznikLewy <= wskaznikPrawy)
        {
            wskaznikLewy++;
        }
        while (tablica[wskaznikPrawy] > pivot && wskaznikLewy <= wskaznikPrawy)
        {
            wskaznikPrawy--;
        }
        if (wskaznikLewy <= wskaznikPrawy)
        {
            Zamiana(ref tablica[wskaznikLewy], ref tablica[wskaznikPrawy]);
        }
        else
        {
            Zamiana(ref tablica[wskaznikLewy], ref tablica[prawo]);
            break;
        }
    }
    if (lewo < wskaznikPrawy) Sortowanie(tablica, lewo, wskaznikPrawy);
    if (wskaznikLewy < prawo) Sortowanie(tablica, wskaznikLewy, prawo);

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
// http://www.algorytm.org/algorytmy-sortowania/sortowanie-szybkie-quicksort.html