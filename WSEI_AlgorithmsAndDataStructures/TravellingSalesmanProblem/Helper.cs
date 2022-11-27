using System.Text.Json;

namespace TravellingSalesmanProblem
{
    public static class Helper
    {
        public static int RandomValue(DrawRange range)
        {
            Random random = new();
            int randomValue = random.Next(range.MinValue, range.MaxValue);
            return randomValue;
        }

        public static bool ConfigurationIsChange(this Configuration config, Configuration compareConfig)
        {
            if (compareConfig?.NumberOfCities != config?.NumberOfCities ||
                compareConfig?.DrawRange.MinValue != config?.DrawRange.MinValue ||
                compareConfig?.DrawRange.MaxValue != config?.DrawRange.MaxValue)
                return false;
            return true;
        }

        public static async Task SaveTextToFile(string path, string content)
        {
            try
            {
                await File.WriteAllTextAsync(path, content);
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed while saving file!");
                Console.ForegroundColor = ConsoleColor.Gray;
                throw;
            }
        }

        public static async Task SaveRoad(List<Road> road, string outputPath, Result result)
        {
            try
            {
                using FileStream stream = new FileStream(".\\log.log", FileMode.OpenOrCreate);
                var resultByte = JsonSerializer.SerializeToUtf8Bytes<Result>(result);
                stream.Write(resultByte);
                stream.Close();
                var jsonByte = JsonSerializer.SerializeToUtf8Bytes<List<Road>>(road);
                await File.WriteAllBytesAsync(outputPath, jsonByte);
            }
            catch (IOException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed while saving file!");
                Console.ForegroundColor = ConsoleColor.Gray;
                throw;
            }
        }

        public static async Task SaveLastConfig(Configuration config)
        {
            var jsonByte = JsonSerializer.SerializeToUtf8Bytes<Configuration>(config);
            await File.WriteAllBytesAsync(config.ConfigPath, jsonByte);
        }
    }
}