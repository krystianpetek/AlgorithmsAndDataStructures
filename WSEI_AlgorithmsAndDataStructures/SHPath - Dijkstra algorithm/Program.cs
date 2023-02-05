namespace SHPath___Dijkstra_algorithm;

public static class Program
{
    static void Main(string[] args)
    {
        try
        {
            _ = int.TryParse(Console.ReadLine(), out int numberOfTests);

            for (int i = 0; i < numberOfTests; i++)
            {
                _ = int.TryParse(Console.ReadLine(), out int numberOfCities);

                IDictionary<string, City> cities = new Dictionary<string, City>();
                for (int j = 0; j < numberOfCities; j++)
                {
                    string cityName = Console.ReadLine();
                    _ = int.TryParse(Console.ReadLine(), out int numberOfNeighbors);
                    
                    City city = new City {
                        Name = cityName,
                        Index = j,
                        Neighbors = new List<Neighbor>()
                    };

                    cities.Add(cityName, city);

                    for (int k = 0; k < numberOfNeighbors; k++)
                    {
                        string[] neighborInput = Console.ReadLine().Split();
                        int neighborIndex = int.Parse(neighborInput[0]) - 1;
                        int neighborCost = int.Parse(neighborInput[1]);
                        city.Neighbors.Add(new Neighbor(neighborIndex, neighborCost));
                    }
                }

                _ = int.TryParse(Console.ReadLine(), out int numberOfPathToFind);

                for (int l = 0; l < numberOfPathToFind; l++)
                {
                    string[] sourceDestCities = Console.ReadLine().Split();
                    string sourceCity = sourceDestCities[0];
                    string destinationCity = sourceDestCities[1];

                    int[] citiesDistance = Dijkstra(cities[sourceCity].Index, cities);

                    Console.WriteLine(citiesDistance[cities[destinationCity].Index]);
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    static int[] Dijkstra(int sourceIndex, IDictionary<string, City> cities)
    {
        int numCities = cities.Count;
        int[] distances = Enumerable.Repeat(int.MaxValue, numCities).ToArray();
        distances[sourceIndex] = 0;

        HashSet<int> processed = new HashSet<int>();
        while (processed.Count < numCities)
        {
            int closestCity = -1;
            int closestDistance = int.MaxValue;
            for (int i = 0; i < numCities; i++)
            {
                if (!processed.Contains(i) && distances[i] < closestDistance)
                {
                    closestCity = i;
                    closestDistance = distances[i];
                }
            }

            processed.Add(closestCity);
            City city = cities.Values.First(c => c.Index == closestCity);
            foreach (Neighbor neighbor in city.Neighbors)
            {
                int newDistance = distances[closestCity] + neighbor.Cost;
                if (newDistance < distances[neighbor.CityIndex])
                {
                    distances[neighbor.CityIndex] = newDistance;
                }
            }
        }

        return distances;
    }
}

public class City
{
    public string Name { get; set; }
    public int Index { get; set; }
    public List<Neighbor> Neighbors { get; set; }
}

public class Neighbor
{
    public int CityIndex { get; set; }
    public int Cost { get; set; }

    public Neighbor(int cityIndex, int cost)
    {
        CityIndex = cityIndex;
        Cost = cost;
    }
}