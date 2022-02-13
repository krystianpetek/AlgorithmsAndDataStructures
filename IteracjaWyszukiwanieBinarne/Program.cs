using System;

namespace IteracjaWyszukiwanieBinarne
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę aby sprawdzić czy należy do przedziału");
            int liczba = int.Parse(Console.ReadLine());
            int[] tablicaLiczb = new int[] { 10, 11, 60, 70, 90, 90, 100 };
            int wynik = WyszukiwanieBinarne(tablicaLiczb, liczba);
            if (wynik == -1)
                Console.WriteLine("Nie znaleziono liczby");
            else
                Console.WriteLine("Wynik jest na pozycji " + wynik);
        }

        private static int WyszukiwanieBinarne(int[] tablicaLiczb, int liczba)
        {
            Array.Sort(tablicaLiczb);

            int lewo = 0;
            int prawo = tablicaLiczb.Length - 1;
            int szukanyIndeks;

            while (lewo <= prawo)
            {
                szukanyIndeks = (lewo + prawo) / 2;

                if (tablicaLiczb[szukanyIndeks] == liczba)
                    return szukanyIndeks;

                if (tablicaLiczb[szukanyIndeks] > liczba)
                    prawo = szukanyIndeks - 1;
                else
                    lewo = szukanyIndeks + 1;
            }
            return -1;
        }
    }
}