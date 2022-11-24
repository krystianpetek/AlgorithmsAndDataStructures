namespace CubicEquatation;

public class Program
{
    public static void Main()
    {
        InputFromUser(out CubicEquatationParameters parameters);
        var cubicEquatation = new CubicEquatation(parameters);
        Console.WriteLine(cubicEquatation);
        cubicEquatation.Calculate();

        //// values for testing purposes
        // CubicEq(9, 8, 7, 6);
        // CubicEq(1, 0, 0, 0);
        // CubicEq(1, 3, 3, 1);
        // CubicEq(1, -6, 12, -8);
        // CubicEq(1, 9, 27, 27);
        // CubicEq(1, -6, 11, -6);
        // CubicEq(1, -1, -16, -20);
        // CubicEq(1, -2, -10, -25);
        // return;
    }

    public static void InputFromUser(out CubicEquatationParameters parameters)
    {
        try
        {
            Console.Write("Please enter the value higher than zero, ax^3: ");
            var a = double.Parse(Console.ReadLine());
            if (a <= 0)
            {
                Console.WriteLine("Wrong value, error!");
                Environment.Exit(1);
            }
            Console.Write("Please enter the value bx^2: ");
            var b = double.Parse(Console.ReadLine());
            Console.Write("Please enter the value cx: ");
            var c = double.Parse(Console.ReadLine());
            Console.Write("Please enter the value d: ");
            var d = double.Parse(Console.ReadLine());

            parameters = new CubicEquatationParameters(a, b, c, d);
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
