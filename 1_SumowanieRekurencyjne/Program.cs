int SumowanieRekurencja(int a, int b)
{
    if (a == 0)
        return b;
    else
    {
        return SumowanieRekurencja(--a, ++b);
    }
}

Console.WriteLine(SumowanieRekurencja(1000, 600));