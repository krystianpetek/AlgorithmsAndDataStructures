using System.Linq;
using System.Collections.Generic;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Buffers.Text;

namespace TravellingSalesmanProblem;

public class TravellingSalesman
{
    private Configuration Config { get; set; }
    private int[,] CityLengthMatrix { get; init; }
    private Road? ParentRoad { get; set; }
    private Road? InitialRoad { get; set; }
    private Road? ChildRoad { get; set; }

    public TravellingSalesman(int N, DrawRange range)
    {
        Config = new Configuration()
        {
            ConfigPath = ".\\config.json",
            RoadPath = ".\\road.txt",
            OutputPath = ".\\output.txt",
            DrawRange = range,
            NumberOfCities = N
        };
        CityLengthMatrix = new int[N, N];
    }

    public async Task StartAsync()
    {
        await CheckSavedConfiguration();
        await ReadRoadBetweenCities();

        InitialRoad = new Road(Config.NumberOfCities, CityLengthMatrix);
        ParentRoad = new Road(InitialRoad, CityLengthMatrix);
        var result = new Result()
        {
            AttemptsBetweenChangeRoad = 10000,
            ResultAttemptCount = 0,
        };

        Console.WriteLine ($"Initial road has {InitialRoad.RoadLength} meters.");
        result.Logs.Add($"Initial road has {InitialRoad.RoadLength} meters.");
        int Attempts = result.AttemptsBetweenChangeRoad;
        while (result.AttemptsBetweenChangeRoad > 0)
        {
            result.ResultAttemptCount++;
            ChildRoad = new Road(ParentRoad, CityLengthMatrix);
            if (ChildRoad?.RoadLength < ParentRoad.RoadLength)
            {
                result.Logs.Add($"Found shorter road: {ChildRoad.RoadLength} meters in {Attempts - result.AttemptsBetweenChangeRoad} attempts.");
                Console.WriteLine($"Found shorter road: {ChildRoad.RoadLength} meters in {Attempts - result.AttemptsBetweenChangeRoad} attempts.");
                result.AttemptsBetweenChangeRoad = 10000;
                ParentRoad = ChildRoad;
            }
            if (ChildRoad?.RoadLength == ParentRoad.RoadLength)
                result.AttemptsBetweenChangeRoad--;

        }
        await Helper.SaveRoad( new List<Road>() { InitialRoad, ParentRoad }, Config.OutputPath, result);

        Console.WriteLine("\nSummary result:");
        Console.WriteLine(Config);
        Console.WriteLine($"First road: {InitialRoad}");
        Console.WriteLine($"Last road: {ParentRoad}");
        Console.WriteLine(result);
    }

    private async Task ReadRoadBetweenCities()
    {
        try
        {
            if (File.Exists(Config.RoadPath))
            {
                var data = await File.ReadAllTextAsync(Config.RoadPath);
                var lines = data.Split("\n");

                if (CityLengthMatrix.GetLength(0) != lines.Length - 1)
                {
                    await GenerateRoadBetweenCities();
                    return;
                }

                for (int x = 0; x < CityLengthMatrix.GetLength(0); x++)
                {
                    var line = lines[x].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for (int y = 0; y < CityLengthMatrix.GetLength(1); y++)
                    {
                        CityLengthMatrix[x, y] = int.Parse(line[y]);
                    }
                }
                return;
            }
            await GenerateRoadBetweenCities();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private static void Display(int[,] matrix)
    {
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                System.Console.Write($"{matrix[x, y]}".PadLeft(3));
            }
            System.Console.WriteLine();
        }
    }

    private async Task GenerateRoadBetweenCities()
    {
        try
        {
            StringBuilder builder = new();
            for (int x = 0; x < CityLengthMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < CityLengthMatrix.GetLength(1); y++)
                {
                    if (x < y) CityLengthMatrix[x, y] = Helper.RandomValue(Config.DrawRange);
                    if (y > x) CityLengthMatrix[y, x] = CityLengthMatrix[x, y];

                    builder.Append($"{CityLengthMatrix[x, y]} ");
                }
                builder.AppendLine();
            }
            await Helper.SaveTextToFile(Config.RoadPath, builder.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task CheckSavedConfiguration()
    {
        try
        {
            if (File.Exists(Config.ConfigPath))
            {
                using FileStream openStream = File.OpenRead(Config.ConfigPath);
                Configuration? config = await JsonSerializer.DeserializeAsync<Configuration>(openStream);

                if (Config.ConfigurationIsChange(config))
                {
                    Config.DrawRange = config.DrawRange;
                    Config.NumberOfCities = config.NumberOfCities;
                    await Helper.SaveLastConfig(Config);
                }
                return;
            }
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed in checking/reading configuration!");
            Console.ForegroundColor = ConsoleColor.Gray;
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}