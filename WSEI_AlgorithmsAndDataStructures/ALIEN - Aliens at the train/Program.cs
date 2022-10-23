using System;

public class Alien
{
    static string MinPeopleAtAlienTrace(int[] array, long At, long Bt)
    {
        long _currentSummaryPeopleAtStation = 0;
        long _currentStation = 0;

        long _stationCounter = 0;
        long _summaryPeople = 0;

        for (long i = 0; i < At; i++)
        {
            _currentSummaryPeopleAtStation += array[i];
            long _lastStation = i;

            while(_currentSummaryPeopleAtStation > Bt)
            {
                _currentSummaryPeopleAtStation -= array[_currentStation];
                _currentStation++;
            }

            if (_stationCounter < (_lastStation - _currentStation))
            {
                _summaryPeople = _currentSummaryPeopleAtStation;
                _stationCounter = _lastStation - _currentStation;
            }
            else if ((_stationCounter == (_lastStation - _currentStation)) && _summaryPeople > _currentSummaryPeopleAtStation)
            {
                _summaryPeople = _currentSummaryPeopleAtStation;
            }
        }

        return $"{_summaryPeople} {_stationCounter+1}";
    }

    public static void Main()
    {
        if (!int.TryParse(Console.ReadLine(), out int T))
            return;

        for (int i = 0; i < T; i++)
        {
            var secondLine = Console.ReadLine().Split(" ");
            long.TryParse(secondLine[0], out long At);
            long.TryParse(secondLine[1], out long Bt);

            var thirdLine = Console.ReadLine().Split(" ");

            var convertedArray = Array.ConvertAll<string, int>(thirdLine, str => int.Parse(str));

            Console.WriteLine(MinPeopleAtAlienTrace(convertedArray, At, Bt));
        }
    }
}