using System.Text.Json.Serialization;

namespace TravellingSalesmanProblem;

public class Result
{
    [JsonIgnore]
    public int AttemptsBetweenChangeRoad { get; set; }
    public int ResultAttemptCount { get; set; } = 0;
    public List<string> Logs { get; set; } = new();

    public override string ToString()
    {
        return $"Total number of attempts to find the shortest road: {ResultAttemptCount}";
    }
}