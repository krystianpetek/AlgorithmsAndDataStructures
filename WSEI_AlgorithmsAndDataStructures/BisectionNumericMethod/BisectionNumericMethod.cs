namespace BisectionNumericMethod;

public class BisectionNumericMethod
{
    private Settings _settings;

    public BisectionNumericMethod(Settings settings) 
    {
        if (settings.MinValue > settings.MaxValue)
        {
            Console.WriteLine("Wrong parameters value.");
            return;
        }
        _settings = settings;
    }

    public void Bisection(double[] parameters)
    {
        var N = new BisectionArgument(_settings.MinValue, 0, _settings.MinValue + _settings.Delta);
        var nValue = new BisectionValue();


        while(N.Left < _settings.MaxValue)
        {
            N.Right = N.Left + _settings.Delta;
            nValue.Left = Horner(N.Left, parameters);
            nValue.Right = Horner(N.Right, parameters);
            
            if (nValue.Left * nValue.Right < 0)
            {
                N.NumberOfRoots++;
                while (true)
                {
                    N.Middle = (N.Left + N.Right) / 2;
                    if (Math.Abs(N.Left- N.Middle) < _settings.Precision)
                        break;

                    nValue.Middle = Horner(N.Middle, parameters);

                    if (Math.Abs(nValue.Middle) < _settings.Precision)
                        break;

                    if (nValue.Left * nValue.Middle < 0)
                        N.Right = N.Middle;
                    else
                    {
                        N.Left = N.Middle;
                        nValue.Left = nValue.Middle;
                    }
                }

                Console.WriteLine(_settings);
                Console.WriteLine(N);
                Console.WriteLine(nValue);
                Console.WriteLine();
            }
            N.Left += _settings.Delta;
        }
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
        return  result;
    }
}