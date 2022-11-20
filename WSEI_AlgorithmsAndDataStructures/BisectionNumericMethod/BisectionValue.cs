namespace BisectionNumericMethod;

public class BisectionValue
{
    public double Left { get; set; }
    public double Middle { get; set; }
    public double Right { get; set; }
    public BisectionValue(double Left, double Middle, double Right)
    {
        this.Left = Left;
        this.Middle = Middle;
        this.Right = Right;
    }

    public BisectionValue()
    {
        Left = 0;
        Middle = 0;
        Right = 0;
    }

    public override string ToString()
    {
        return $"Value of f(0): {Right}";
    }
}