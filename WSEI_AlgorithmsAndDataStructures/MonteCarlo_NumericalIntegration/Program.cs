namespace MonteCarlo_NumericalIntegration;
public class Program
{
    public static void Main()
    {

        //var functionParameters = new NumericalIntegrationParameters(new double[] { 1, -1, -2, 1, 3, -0.6 });

        //var settings = new Settings(new Value<double>(0, 1), new Value<double>(0, 0), 0.001, 0.000001);
        InputFunctionValuesFromUser(out NumericalIntegrationParameters functionParameters);
        InputScopesFromUser(out Settings settings);

        var numericalIntegration = new NumericalIntegration(settings);
        numericalIntegration.MonteCarlo(functionParameters);

        //// values for testing purposes
        //parameters = new double[] { 2, 5, 4, 5, 1.9, -0.6 };
        //parameters = new double[] { 1, -1, -2, 0, 0.4, 2 };
        //parameters = new double[] {1,-1,-2,1,3,-0.6};
    }

    private static void InputFunctionValuesFromUser(out NumericalIntegrationParameters functionParameters)
    {
        try
        {
            Console.Write("Please enter the value other than zero, ax^5: ");
            double a = double.Parse(Console.ReadLine());
            if (a == 0)
                throw new FormatException("Value of parameter 'a' must be other than 0");

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

            functionParameters = new NumericalIntegrationParameters(new double[] { a, b, c, d, e, f });
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
    private static void InputScopesFromUser(out Settings settings)
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

            Value<double> X = new(MinValue, MaxValue);
            Value<double> Y = default;

            settings = new Settings(X, Y, Delta, Epsilon);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Wrong value, error!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(ex.Message);
            Environment.Exit(-1);
            throw;
        }

        //Console.WriteLine("Please enter maximum allowed value in Y scope: ");
        //double yMax = double.Parse(Console.ReadLine());
        //if (yMax < 0)
        //{
        //    Console.WriteLine("Wrong value, maximum value in Y scope, must be higher than 0");
        //    Environment.Exit(1);
        //}

        //Console.WriteLine("Please enter minimum allowed value in Y scope (default is 0): ");
        //double yMin = double.Parse(Console.ReadLine());
        //Y = new Value<double>(yMin, yMax);
    }
}
