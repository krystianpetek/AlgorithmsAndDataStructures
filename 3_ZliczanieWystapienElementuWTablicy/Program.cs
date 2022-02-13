int[] tablicaLiczb = new[] { 4, 1, 6, 1, 1 };
int iloscWystapien = 0;
Console.Write("Podaj szukaną wartość: ");
string? wartoscWprowadzona = Console.ReadLine();
bool check = int.TryParse(wartoscWprowadzona, out int szukana);
if(!check)
{
    Console.WriteLine("Wprowadzono nieprawidłową wartość.");
    return;
}
for(int i = 0;i< tablicaLiczb.Length;i++)
{
    Console.Write($"Czy wartość {szukana} jest równa {tablicaLiczb[i]}? ");
    if (szukana == tablicaLiczb[i])
    {
        Console.WriteLine("Tak! +1");
        iloscWystapien++;
    }
    else
    {
        Console.WriteLine("Nie.");
    }
}
Console.WriteLine($"Liczba {szukana} wystąpiła {iloscWystapien} razy.");

// http://www.algorytm.org/dla-poczatkujacych/zliczanie-wystapien-elementu-w-tablicy.html