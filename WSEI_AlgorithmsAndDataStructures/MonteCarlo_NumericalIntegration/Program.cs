namespace MonteCarlo_NumericalIntegration;
public class Program
{
    public static void Main()
    {
        InputFunctionValuesFromUser(out double[] functionParameters);
        InputScopesFromUser(out Value<double> X, out Value<double> Y);
     
        var settings = new Settings(X,Y,0.00001,0.000001);
        var numericalIntegration = new NumericalIntegration(settings);
        
        numericalIntegration.MonteCarlo(functionParameters);
        return;

        //// values for testing purposes
        //parameters = new double[] { 1, 1, 1, 3, 1, -0.5 };
        //parameters = new double[] { 5, 4, 5, 1, 3, -0.6 };
        //parameters = new double[] { 1, -1, -2, 0, 0.4, 2 };
        //parameters = new double[] {1,-1,-2,1,3,-0.6};
    }

    private static void InputFunctionValuesFromUser(out double[] functionParameters)
    {
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

        functionParameters = new double[] { a, b, c, d, e, f };
    }

    private static void InputScopesFromUser(out Value<double> X, out Value<double> Y)
    {
        Y = default;
        //X = new Value<double>(-2, 2);
        //return;
        
        Console.WriteLine("Please enter minimum value in X scope: ");
        double xMin = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter maximum value in X scope: ");
        double xMax = double.Parse(Console.ReadLine());
        if (xMin > xMax)
        {
            Console.WriteLine("Wrong values, minimum value is higher than maximum value");
            Environment.Exit(1);
        }
        X = new Value<double>(xMin, xMax);
        return;

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
