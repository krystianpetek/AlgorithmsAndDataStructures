using System.Reflection.Metadata;
namespace CubicEquatation;

public class CubicEquatation
{
    public CubicEquatationParameters Values { get; init; }

    public CubicEquatation(CubicEquatationParameters parameters)
    {
        Values = parameters;
    }

    public override string ToString()
    {
        return $"\nCase: ({Values.a})x^3 + ({Values.b})x^2 + ({Values.c})x + ({Values.d}) = 0";
    }

    public void Calculate()
    {
        double w = -(Values.b / (3 * Values.a));
        double p = ((3 * Values.a * Math.Pow(w, 2)) + (2 * Values.b * w) + Values.c) * 1.0 / Values.a;
        double q = ((Values.a * (w * w * w)) + (Values.b * (w * w)) + (Values.c * w) + Values.d) * 1.0 / Values.a;
        double delta = ((q * q) / 4) + ((p * p * p) * 1.0 / 27);

        double u = Math.Cbrt(-(q / 2) + Math.Sqrt(delta));
        double v = Math.Cbrt(-(q / 2) - Math.Sqrt(delta));

        Console.WriteLine($"Delta: {delta}");
        if (delta > 0)
        {
            double x1_Real = u + v + w;

            double x2_Real = (((-1.0) / 2) * (u + v) + w);
            double x2_Imaginary = (Math.Sqrt(3) / 2) * (u - v);

            double x3_Real = (((-1.0) / 2) * (u + v) + w);
            double x3_Imaginary = -(Math.Sqrt(3) / 2) * (u - v);

            Console.WriteLine($"Result:\n" +
                $"x1 = {x1_Real:F6}\n" +
                $"x2 = {x2_Real:F6} + {x2_Imaginary:F6}i\n" +
                $"x3 = {x3_Real:F6} + {x3_Imaginary:F6}i\n");
        }
        else if (delta == 0)
        {
            double x1 = w - 2 * Math.Cbrt(q / 2);
            double x2 = w + Math.Cbrt(q / 2);

            Console.WriteLine($"Result:\n" +
                $"x1 = {x1:F6}\n" +
                $"x2 = {x2:F6}\n");
        }
        else if (delta < 0)
        {
            double phi = Math.Acos((3 * q) * 1.0 / (2 * p * Math.Sqrt(-(p / 3))));
            double x1 = w + 2 * Math.Sqrt(-(p / 3)) * Math.Cos(phi / 3);
            double x2 = w + 2 * Math.Sqrt(-(p / 3)) * Math.Cos((phi / 3) + (2.0 / 3.0 * Math.PI));
            double x3 = w + 2 * Math.Sqrt(-(p / 3)) * Math.Cos((phi / 3) + (4.0 / 3.0 * Math.PI));

            Console.WriteLine($"Result:\n" +
                $"x1 = {x1:F6}\n" +
                $"x2 = {x2:F6}\n" +
                $"x3 = {x3:F6}\n");
        }
    }
}