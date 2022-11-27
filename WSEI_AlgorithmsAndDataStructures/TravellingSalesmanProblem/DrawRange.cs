namespace TravellingSalesmanProblem;

public class DrawRange
{
    public DrawRange(int MinValue, int MaxValue)
    {
        this.MinValue = MinValue;
        this.MaxValue = MaxValue;
    }

    public int MinValue { get; init; }
    public int MaxValue { get; init; }
}