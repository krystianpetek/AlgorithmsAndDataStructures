namespace TravellingSalesmanProblem;

public class Configuration
{
    public string ConfigPath { get; init; }
    public string RoadPath { get; init; }
    public string OutputPath { get; init; }
    public DrawRange DrawRange { get; set; }
    public int NumberOfCities { get; set; }

    public override string ToString()
    {
        return $"Road length between cities: [{DrawRange.MinValue} - {DrawRange.MaxValue}]\n" +
            $"Number of cities to visit: {NumberOfCities}";
    }
}
