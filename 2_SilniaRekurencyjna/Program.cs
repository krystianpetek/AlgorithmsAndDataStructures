int Silnia(int n)
{
    if (n == 0)
        return 1;
    else
        return n * Silnia(n - 1);
}
Console.WriteLine(Silnia(5));