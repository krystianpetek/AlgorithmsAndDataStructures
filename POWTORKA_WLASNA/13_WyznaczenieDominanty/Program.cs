List<int> T = new List<int>() { 1, 6, 7, 2, 1, 7, 4, 7, 3 }; // tablica liczb
//int[] T = new[] { 1, 4, 6, 5, 4, 1, 5, 4 }; // tablica liczb
List<int> L = new List<int>();
//int[] L = new int[T.Length]; // wartosci znalezione w tablicy
List<int> W = new List<int>();
//int[] W = new int[T.Length]; // ilość wystąpień wartości w tablicy

for (int i = 0; i < T.Count; i++)
{

    if (L.Contains(T[i]))
    {
        var index = L.IndexOf(T[i]);
        //var index = Array.IndexOf(L, T[i]);
        W[index]++;
    }
    else
    {
        L.Add(T[i]);
        //L[i] = T[i];
        W.Add(1);
        //W[i] = 1;
    }
}
int max = 0, indexMax = 0;
for (int i = 0; i < W.Count; i++)
{
    if (max < W[i])
    {
        max = W[i];
        indexMax = L[i];
    }
}

Console.WriteLine($"Dominanta = {indexMax} wystąpiła {max} razy.");

// http://www.algorytm.org/dla-poczatkujacych/wyznaczanie-dominanty-mody.html