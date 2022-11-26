public class Program
{
    public static void Main()
    {
        int N = 20;
        var travellingSalesman = new TravellingSalesman(N);
        travellingSalesman.DoWork();
        return;

        // InputFromUser(out int N);

    }
    private static void InputFromUser(out int N)
    {
        try
        {
            Console.Write("Please enter the number of the city\nN: ");
            bool tryParse = int.TryParse(Console.ReadLine(), out N);
            if (!tryParse || N >= 100)
            {
                Console.WriteLine("Wrong value, error!");
                Environment.Exit(1);
            }
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
