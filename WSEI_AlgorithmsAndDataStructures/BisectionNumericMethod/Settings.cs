namespace BisectionNumericMethod;
public record class Settings(double MinValue = -1000, double MaxValue = 1000, double Delta = 0.001, double Epsilon = 0.000001)
{
    public override string ToString()
    {
        return $"\nSettings parameters:\n" +
            $"X scope range from: {MinValue} to: {MaxValue}\n" +
        $"Delta: {Delta}\n" +
        $"Epsilon: {Epsilon}\n";
    }
}