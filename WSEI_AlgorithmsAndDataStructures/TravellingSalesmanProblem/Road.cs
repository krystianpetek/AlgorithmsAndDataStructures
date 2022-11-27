namespace TravellingSalesmanProblem;

public class Road
{
    private readonly int[,] cityLengthMatrix;

    public List<int> Cities { get; set; }
    public int RoadLength { get; set; }

    private int[] _roadValues { get; set; }

    public override string ToString()
    {
        return $"Road length: {RoadLength} through {Cities.Count} cities.";
    }

    public Road(int NumberOfCity, int[,] CityLengthMatrix)
    {
        Cities = new(Enumerable.Range(1, NumberOfCity));
        _roadValues = new int[NumberOfCity - 1];
        cityLengthMatrix = CityLengthMatrix;
        CalculateRoadLength();
    }

    public Road(Road previousRoad, int[,] CityLengthMatrix)
    {
        cityLengthMatrix = CityLengthMatrix;
        Cities = new List<int>(previousRoad.Cities);
        _roadValues = new int[previousRoad._roadValues.Length];
        Array.Copy(previousRoad._roadValues, _roadValues, previousRoad._roadValues.Length);
        ChangeRoad();
        CalculateRoadLength();
    }

    public void CalculateRoadLength()
    {
        try
        {
            for (int i = 1; i < Cities.Count - 1; i++)
            {
                int from = Cities[i - 1];
                int to = Cities[i];

                _roadValues[i - 1] = cityLengthMatrix[from - 1, to - 1];
                RoadLength += _roadValues[i - 1];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(_roadValues);
        }
    }

    public void ChangeRoad()
    {
        var from = Helper.RandomValue(new DrawRange(0, Cities.Count));
        var to = Helper.RandomValue(new DrawRange(0, Cities.Count - 1));
        (Cities[from], Cities[to]) = (Cities[to], Cities[from]);
    }
}
