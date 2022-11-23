using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CubicEquatation
{
    internal class Obsolete
    {
        public static void ComplexCE()
        {
            Console.WriteLine("Podaj ax^3");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj bx^2");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj cx");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj d");
            int d = int.Parse(Console.ReadLine());
            const int NRoots = 3;

            double SquareRootof3 = Math.Sqrt(3);
            // the 3 cubic roots of 1
            var CubicUnity = new List<Complex>(NRoots)
                { new Complex(1, 0),
                  new Complex(-0.5, -SquareRootof3 / 2.0),
                  new Complex(-0.5, SquareRootof3 / 2.0) };
            // intermediate calculations
            double DELTA = 18 * a * b * c * d
                         - 4 * b * b * b * d
                         + b * b * c * c
                         - 4 * a * c * c * c
                         - 27 * a * a * d * d;
            double DELTA0 = b * b - 3 * a * c;
            double DELTA1 = 2 * b * b * b
                          - 9 * a * b * c
                          + 27 * a * a * d;
            Complex DELTA2 = -27 * a * a * DELTA;

            Console.WriteLine("delta" + DELTA);
            Console.WriteLine("delta0" + DELTA0);
            Console.WriteLine("delta1" + DELTA1);
            Console.WriteLine("delta2" + DELTA2);
            Complex C = Complex.Pow((DELTA1 + Complex.Pow(DELTA2, 0.5)) / 2, 1 / 3.0);

            for (int i = 0; i < NRoots; i++)
            {
                Complex M = CubicUnity[i] * C;
                Complex Root = -1.0 / (3 * a) * (b + M + DELTA0 / M);
                Console.WriteLine();
                Console.WriteLine($"Root {i + 1}:");
                Console.WriteLine($"Real      {Root.Real:0.#####}");
                Console.WriteLine($"Imaginary {Root.Imaginary:0.#####}i");
            }
        }

        public static void Cardano(double a, double b, double c, double d)
        {
            //http://www.math.us.edu.pl/~pgladki/faq/node127.html
            // cardano patterns - incomplete

            double one = 1.0;
            double delta = (-4 * (c * c * c) * a + (c * c) * (b * b) +
                (18 * c * b * a * d) -
                (27 * (d * d) * (a * a)) -
                (4 * d * (b * b * b)));

            Console.WriteLine(delta);

            double x1 = (

                (1 * one / 3)
                *
                (Math.Cbrt(
                (
                    (9 * c * b * a) -
                    (27 * d * (a * a)) -
                    (2 * (b * b * b)) +
                    (3 * a * Math.Sqrt(-3 * delta))
                ) / (2 * (a * a * a)))
                )
                -
                (
                ((3 * c * a - (b * b))
                /
                ((3 * a * a) *
                Math.Cbrt(
                    (

                    (9 * c * b * a) -
                    (27 * d * (a * a)) -
                    (2 * (b * b * b)) +
                    (3 * a * Math.Sqrt(-3 * delta))

                    ) / (2 * a * a * a))
                    ))) -
                    (b / 3 * one * a));

            Console.WriteLine(x1);
        }
    }
}
