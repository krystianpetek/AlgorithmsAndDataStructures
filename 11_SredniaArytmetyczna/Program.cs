Console.WriteLine("Średnia arytmetyczna");
double wynik = 0;
Console.Write("Podaj ilość liczb: ");
int.TryParse(Console.ReadLine(), out int n);
int i = 0;
while (i < n)
{
    Console.Write("Podaj liczbę: ");
    int.TryParse(Console.ReadLine(), out int a);
    Console.Write($"{wynik} + {a} = ");
    wynik += a;
    Console.WriteLine($"{wynik}");
    i++;
}
Console.Write($"Średnia arytmetyczna: {wynik} / {n} = ");
wynik = wynik / n;
Console.Write($"{wynik}");