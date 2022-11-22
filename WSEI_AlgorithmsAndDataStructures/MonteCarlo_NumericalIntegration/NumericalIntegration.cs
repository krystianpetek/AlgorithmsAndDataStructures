using System.Diagnostics.Metrics;

namespace MonteCarlo_NumericalIntegration;

internal class NumericalIntegration
{
    public Settings Settings { get; set; }

    public NumericalIntegration(Settings settings) => Settings = settings;

    public void MonteCarlo(double[] functionParameters)
    {
        CalculationResult result = new(functionParameters);

        // first calculating value scope of function
        Settings.Y = CalculateY(Settings,functionParameters);
        Console.WriteLine(Settings);

        (double currentX, double maximumX) = Settings.X;

        while (currentX < maximumX)
        {
            var valueOfFunction = Horner(currentX, functionParameters);
            var randomValue = RandomValue(Settings.Y);

            if (randomValue > valueOfFunction)
                result.BelowHits++;
            else
                result.AboveHits++;

            currentX += Settings.Delta;
        }

        result.ValueOfFunction = (result.BelowHits * (Settings.X.Maximum - Settings.X.Minimum) * Settings.Y.Maximum) / (result.BelowHits + result.AboveHits);
                
        Console.WriteLine(result);
    }

    private void ShowDetailsAboutValuesOfFunction(double currentX, double valueOfFunction, ref int delta)
    {
        delta++;
        if(delta == 100)
        {
            Console.WriteLine("current x: " + currentX + " value of function: " + valueOfFunction);
            delta = 0;
        }
    }

    private double RandomValue(Value<double> drawRange)
    {
        Random random = new();
        double randomValue = random.NextDouble() * drawRange.Maximum;
        return randomValue;
    }

    private Value<double> CalculateY(Settings settings, double[] parameters)
    {
        double currentMaximum = 0;

        var point = settings.X.Minimum;
        while(point < Settings.X.Maximum)
        {
            var valueOfFunction = Horner(point, parameters);
            if(valueOfFunction > currentMaximum)
            {
                currentMaximum = valueOfFunction;
            }
            point += settings.Delta;
        }
        return new Value<double>(0, currentMaximum);
    }

    private double Horner(double x, params double[] parameters)
    {
        double result;
        result = parameters[0] * x;
        for (int i = 1; i < (parameters.Length - 1); i++)
        {
            result += parameters[i];
            result *= x;
        }
        result += parameters[^1];
        return result;
    }
}