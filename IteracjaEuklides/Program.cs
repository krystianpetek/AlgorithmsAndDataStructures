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
            Console.WriteLine(Euklides(pierwsza, druga));
        }
        static string Euklides(int wieksza, int mniejsza)
        {
            int pierwsza = wieksza;
            int druga = mniejsza;
            if (wieksza == mniejsza)
            {
                return $"Wspólny dzielnik dla liczby {pierwsza} i {druga} to {wieksza}";
            }

            if (mniejsza > wieksza)
            {
                var temp = mniejsza;
                mniejsza = wieksza;
                wieksza = temp;
            }

            while (true)
            {
                if (wieksza == mniejsza)
                    break;

                var tempWhile = wieksza - mniejsza;
                if (tempWhile > mniejsza)
                {
                    wieksza = tempWhile;
                }
                else
                {
                    wieksza = mniejsza;
                    mniejsza = tempWhile;
                }
            }
            return $"Wspólny dzielnik dla liczby {pierwsza} i {druga} to {wieksza}";
        }
    }
}
