namespace BisectionNumericMethod;

public class Program
{
    public static void Main()
    {
        var settings = new Settings();
        var bisectionMethod = new BisectionNumericMethod(settings);

        var parameters = new double[] { 1, 1, 1, 3, 1, -0.5 };

        // skipped reading value from std input for testing purposes
        bisectionMethod.Bisection(parameters);
        return;

        Console.WriteLine("Please enter: a * x^5");
        double a = double.Parse(Console.ReadLine());

        while (a == 0)
        {
            Console.WriteLine("Value of parameter 'a' must be other than 0");
            a = double.Parse(Console.ReadLine());
        }

        Console.WriteLine("Please enter: b * x^4");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter: c * x^3");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter: d * x^2");
        double d = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter: e * x");
        double e = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter: f");
        double f = double.Parse(Console.ReadLine());

        bisectionMethod.Bisection(new double[] { a, b, c, d, e, f });
    }
}