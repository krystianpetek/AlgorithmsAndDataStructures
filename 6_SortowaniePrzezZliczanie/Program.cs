int[] tablicaLiczb = { 1000, 33, 123, 10, 1, 12442, 99, 111 };
Console.Write($"Tablica liczb przed sortowaniem: [");
Wypisz(tablicaLiczb);
var tablicaLiczbPoSortowaniu = Sortowanie(tablicaLiczb);
Console.Write($"Tablica liczb po sortowaniu: [");
Wypisz(tablicaLiczbPoSortowaniu);

int[] Sortowanie(int[] tablica)
{
    int min = Minimum(tablica);
    int max = Maksimum(tablica);
    int[] tablicaLicznikowa = new int[(max - min) + 2];
    for(int i = 0;i<tablica.Length;i++)
    {
        tablicaLicznikowa[tablica[i]]++;
    }
    
    int index = 0;
    for(int i = 0;i<tablicaLicznikowa.Length;i++)
    {
        if (tablicaLicznikowa[i] == 0)
            continue;
        
        for(int j = tablicaLicznikowa[i];j>0;j--)
        {
            tablica[index] = i;
            index++;
        }
    }
    return tablica;
}

int Minimum(int[] tablica)
{
    int minimum = tablica[0];
    for(int i = 0;i< tablica.Length;i++)
    {
        if (tablica[i] < minimum)
            minimum = tablica[i];
    }
    return minimum;
}
int Maksimum(int[] tablica)
{
    int maksimum = tablica[0];
    for(int i = 0;i< tablica.Length;i++)
    {
        if (tablica[i] > maksimum)
            maksimum = tablica[i];
    }
    return maksimum;
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

// http://www.algorytm.org/algorytmy-sortowania/sortowanie-przez-zliczanie-countingsort.html
// https://binarnie.pl/sortowanie-przez-zliczanie/