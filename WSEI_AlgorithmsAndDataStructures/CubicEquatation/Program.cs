﻿using System.Numerics;

class CubicEquatation
{
    private static void CubicEq(double a, double b, double c, double d)
    {
        Console.WriteLine($"Case: {a}x^3 + {b}x^2 + {c}x + {d} = 0");
        if (a <= 0)
            return;

        double w = -(b / (3 * a));
        double p = ((3 * a * Math.Pow(w, 2)) + (2 * b * w) + c) / a;
        double q = ((a * (w * w * w)) + (b * (w * w)) + (c * w) + d) / a;
        double delta = ((q * q) / 4) + ((p * p * p) / 27);

        double u = Math.Cbrt(-(q / 2) + Math.Sqrt(delta));
        double v = Math.Cbrt(-(q / 2) - Math.Sqrt(delta));

        if (delta > 0)
        {
            double x1Real = u + v + w;

            double x2Real = (((-1.0) / 2) * (u + v) + w);
            double x2Imaginary = (Math.Sqrt(3) / 2) * (u - v);

            double x3Real = (((-1.0) / 2) * (u + v) + w);
            double x3Imaginary = -(Math.Sqrt(3) / 2) * (u - v);

            Console.WriteLine($"x1 = {x1Real:F6}\n" +
                $"x2 = {x2Real:F6} + {x2Imaginary:F6}i\n" +
                $"x3 = {x3Real:F6} + {x3Imaginary:F6}i\n");
        }
        else if (delta == 0)
        {
            double x1 = w - 2 * Math.Cbrt(q / 2);
            double x2 = w + Math.Cbrt(q / 2);
            Console.WriteLine($"x1 = {x1:F6}\n" +
                $"x2 = {x2:F6}\n");
        }
        else if (delta < 0)
        {
            double phi = Math.Acos((3 * q) * 1.0 / (2 * p * Math.Sqrt(-(p / 3))));
            double x1 = w + 2 * Math.Sqrt(-(p / 3)) * Math.Cos(phi / 3);
            double x2 = w + 2 * Math.Sqrt(-(p / 3)) * Math.Cos((phi / 3) + (2.0 / 3.0 * Math.PI));
            double x3 = w + 2 * Math.Sqrt(-(p / 3)) * Math.Cos((phi / 3) + (4.0 / 3.0 * Math.PI));
            Console.WriteLine($"x1 = {x1:F6}\n" +
                $"x2 = {x2:F6}\n" +
                $"x3 = {x3:F6}\n");
        }
    }

    public static void Main()
    {
        CubicEq(9,8,7,6);
        CubicEq(1, 0, 0, 0);
        CubicEq(1, 3, 3, 1);
        CubicEq(1, -6, 12, -8);
        CubicEq(1, 9, 27, 27);
        CubicEq(1, -6, 11, -6);
        CubicEq(1, -1, -16, -20);
        CubicEq(1, -2, -10, -25);
        return;

        Console.WriteLine("Podaj ax^3");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj bx^2");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj cx");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj d");
        double d = double.Parse(Console.ReadLine());
        CubicEq(a, b, c, d);
    }

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