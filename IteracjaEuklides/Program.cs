using System;

namespace IteracjaEuklides
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj pierwszą liczbę");
            int pierwsza = Convert.ToInt32(Console.ReadLine());
            int druga = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(EuklidesOdejmowanie(pierwsza, druga));
            Console.WriteLine();
            Console.WriteLine(EuklidesModulo(pierwsza, druga));
        }
        static string EuklidesOdejmowanie(int wieksza, int mniejsza)
        {
            int a = wieksza;
            int b = mniejsza;
            int c;
            if (a == b)
            {
                return $"Wspólny dzielnik dla liczby {wieksza} i {mniejsza} to {a}";
            }

            if (b > a)
            {
                c = b;
                b = a;
                a = c;
            }

            while (true)
            {
                if (a == b)
                    break;

                c = a - b;
                if (c > b)
                {
                    a = c;
                }
                else
                {
                    a = b;
                    b = c;
                }
            }
            return $"(Odejmowanie) Wspólny dzielnik dla liczby {wieksza} i {mniejsza} to {a}";
        }

        static string EuklidesModulo(int wieksza, int mniejsza)
        {
            int a = wieksza;
            int b = mniejsza;
            int c;

            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            return $"(Reszta z dzielenia) Wspólny dzielnik dla liczby {wieksza} i {mniejsza} to {a}"; ;
        }
    }
}
