using System.Numerics;
namespace CubicEquatation;

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

        InputFromUser(out double[] parameters);
        CubicEq(parameters[0], parameters[1], parameters[2], parameters[3]);
    }

    private static void InputFromUser(out double[] parameters)
    {
        Console.WriteLine("Podaj ax^3");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj bx^2");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj cx");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj d");
        double d = double.Parse(Console.ReadLine());

        parameters = new double[] { a, b, c, d };
    }
}