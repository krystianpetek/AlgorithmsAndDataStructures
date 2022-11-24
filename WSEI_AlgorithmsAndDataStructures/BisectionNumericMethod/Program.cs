namespace BisectionNumericMethod;

public partial class Program
{
    public static void Main()
    {
        InputFromUser(out BisectionParameters parameters);
        SettingsFromUser(out Settings settings);

        var bisectionMethod = new BisectionNumericMethod(settings);
        bisectionMethod.Bisection(parameters.parameters);

        // for testing purposes
        //var parameters = new double[] { 1, 1, 1, 3, 1, -0.5 };
    }

    private static void InputFromUser(out BisectionParameters parameters)
    {
        try
        {
            Console.Write("Please enter the value higher than zero, ax^5: ");
            var a = double.Parse(Console.ReadLine());
            if (a <= 0)
                throw new FormatException("Value must be higher than zero");
            Console.Write("Please enter the value bx^4: ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("Please enter the value cx^3: ");
            var c = double.Parse(Console.ReadLine());
            Console.Write("Please enter the value dx^2: ");
            var d = double.Parse(Console.ReadLine());
            Console.Write("Please enter the value ex: ");
            var e = double.Parse(Console.ReadLine());
            Console.Write("Please enter the value f: ");
            var f = double.Parse(Console.ReadLine());
            parameters = new BisectionParameters(new double[] { a, b, c, d, e, f });
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong value, error!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ex.Message);
            Environment.Exit(-1);
            throw;
        }
    }

    private static void SettingsFromUser(out Settings settings)
    {
        try
        {
            Console.Write("Please enter a minimal value for X range: ");
            var MinValue = double.Parse(Console.ReadLine() ?? "0.0");

            Console.Write("Please enter a maximum value for X range: ");
            var MaxValue = double.Parse(Console.ReadLine() ?? "0.0");
            if (MaxValue < MinValue)
                throw new FormatException("Minimal value shouldn't be higher than maximum.");

            Console.Write("Please enter a delta value (accuracy for function calculation): ");
            var Delta = double.Parse(Console.ReadLine() ?? "0.001");

            Console.Write("Please enter a epsilon value (accuracy of the root calculation): ");
            var Epsilon = double.Parse(Console.ReadLine() ?? "0.000001");

            settings = new Settings(MinValue, MaxValue, Delta, Epsilon);
            Console.WriteLine(settings);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong value, error!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ex.Message);
            Environment.Exit(-1);
            throw;
        }
    }
}