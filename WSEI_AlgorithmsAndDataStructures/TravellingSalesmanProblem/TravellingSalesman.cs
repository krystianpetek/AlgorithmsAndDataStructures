using System.Linq;
using System.Collections.Generic;
using System;
public class TravellingSalesman
{
    private DrawRange _drawRange { get; set; }
    private int _n { get; set; }
    private List<int> _cityList { get; init; }
    private int[,] cityRoad { get; set; }
    public TravellingSalesman(int N)
    {
        _n = N;
        _drawRange = new DrawRange(10, 99);
        _cityList = new(Enumerable.Range(0, N));
    }

    public void Work()
    {
        cityRoad = new int[_n, _n];
        for (int x = 0; x < cityRoad.GetLength(0); x++)
        {
            for (int y = 0; y < cityRoad.GetLength(1); y++)
            {
                if (x < y) cityRoad[x, y] = RandomValue(_drawRange);
                if (y > x) cityRoad[y, x] = cityRoad[x, y];
                System.Console.Write($"{cityRoad[x, y]}".PadLeft(3));
            }
            System.Console.WriteLine();
        }
    }

    private int RandomValue(DrawRange range)
    {
        Random random = new();
        int randomValue = random.Next(range.MinValue, range.MaxValue);
        return randomValue;
    }
}