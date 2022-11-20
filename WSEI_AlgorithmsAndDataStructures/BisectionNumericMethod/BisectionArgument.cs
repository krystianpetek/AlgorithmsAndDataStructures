namespace BisectionNumericMethod;

public class BisectionArgument
{
    public int NumberOfRoots { get; set; }
    public double Left { get; set; }
    public double Middle { get; set; }
    public double Right { get; set; }
    public BisectionArgument(double Left, double Middle, double Right)
    {
        this.Left = Left;
        this.Middle = Middle;
        this.Right = Right;
        NumberOfRoots = 0;
    }
    public override string ToString()
    {
        return $"Left argument: {Left}\n" +
            $"Middle argument: {Middle}\n" +
            $"Right argument: {Right}\n" +
            $"Which element of roots: {NumberOfRoots}";
    }
}