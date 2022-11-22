using System.Reflection;

namespace MonteCarlo_NumericalIntegration;
public class Settings
{
    public Value<double> X { get; init; }
    public Value<double> Y { get; set; }
    public double Delta { get; init; }
    public double Precision { get; init; }

    public Settings(Value<double> X, Value<double> Y, double Delta = 0.001, double Precision = 0.000001)
    {
        this.X = X;
        this.Y = Y;
        this.Delta = Delta;
        this.Precision = Precision;
    }
    public override string ToString()
    {
        return $"X scope range from: {X.Minimum} to: {X.Maximum}\n" +
            $"Y scope range from: {Y.Minimum} to: {Y.Maximum}\n" +
            $"Delta: {Delta}\n" +
            $"Precision: {Precision}\n";
    }
}
