using System.Text;

namespace MonteCarlo_NumericalIntegration;

public class CalculationResult
{
    public int AboveHits { get; set; }
    public int BelowHits { get; set;}
    public double[] functionParameters { get; set; }
    public double ValueOfFunction { get; set; }


    public CalculationResult(double[] functionParameters)
    {
        this.functionParameters = functionParameters;
    }

    private static string PrepareStringFunction(double[] functionParameters)
    {
        StringBuilder stringBuilder = new StringBuilder();
        int counter = functionParameters.Length;
        for (int i = 0; i < functionParameters.Length; i++)
        {
            counter--;
            if (counter is 0)
            {
                stringBuilder.Append($"+ ({functionParameters[i]})");
                continue;
            }

            if (i is 0)
            {
                stringBuilder.Append($"({functionParameters[i]})x^{counter} ");
                continue;
            }
         
            stringBuilder.Append($"+ ({functionParameters[i]})x^{counter} ");
        }
            return stringBuilder.ToString();
    }

    public override string ToString()
    {
        return $"Number of hits above function: {AboveHits}\n" +
            $"Number of hits below function: {BelowHits}\n" +
            $"Summary hits: {AboveHits + BelowHits}\n" +
            $"Result for function: {PrepareStringFunction(functionParameters)}\n" +
            $"The area under the graph: {ValueOfFunction}";
    }
}
