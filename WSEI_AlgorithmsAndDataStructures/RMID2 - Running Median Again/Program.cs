using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RMID2
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            long t = long.Parse(Console.ReadLine());

            for (long i = 0; i < t; i++)
            {
                var maxHeap = new SortedSet<long>();
                var minHeap = new SortedSet<long>();

                long n;
                while ((n = FastIO.ReadInt()) != 0)
                {

                    if (n == -1)
                    {
                        long median;
                        if (maxHeap.Count == minHeap.Count)
                        {
                            median = maxHeap.Max;
                            maxHeap.Remove(median);
                        }
                        else
                        {
                            median = minHeap.Min;
                            minHeap.Remove(median);
                        }
                        stringBuilder.AppendLine($"{median}");
                    }
                    else
                    {
                        if (maxHeap.Count == 0 || n < maxHeap.Max)
                        {
                            maxHeap.Add(n);
                        }
                        else
                        {
                            minHeap.Add(n);
                        }

                        if (maxHeap.Count > minHeap.Count + 1)
                        {
                            long max = maxHeap.Max;
                            maxHeap.Remove(max);
                            minHeap.Add(max);
                        }
                        else if (minHeap.Count > maxHeap.Count + 1)
                        {
                            long min = minHeap.Min;
                            minHeap.Remove(min);
                            maxHeap.Add(min);
                        }
                    }
                }
                FastIO.Flush();
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }


    public static class FastIO
    {
        private const byte _null = (byte)'\0';
        private const byte _minusSign = (byte)'-';
        private const byte _zero = (byte)'0';
        private const int _inputBufferLimit = 8192;

        private static readonly Stream _inputStream = Console.OpenStandardInput();
        private static readonly byte[] _inputBuffer = new byte[_inputBufferLimit];
        private static int _inputBufferSize = 0;
        private static int _inputBufferIndex = 0;

        private static byte ReadByte()
        {
            if (_inputBufferIndex == _inputBufferSize)
            {
                _inputBufferIndex = 0;
                _inputBufferSize = _inputStream.Read(_inputBuffer, 0, _inputBufferLimit);
                if (_inputBufferSize == 0)
                    return _null;
            }

            return _inputBuffer[_inputBufferIndex++];
        }

        public static int ReadInt()
        {
            byte digit;
            do
            {
                digit = ReadByte();
            }
            while (digit < _minusSign);

            bool isNegative = digit == _minusSign;
            if (isNegative)
            {
                digit = ReadByte();
            }

            int result = isNegative ? -(digit - _zero) : (digit - _zero);
            while (true)
            {
                digit = ReadByte();
                if (digit < _zero) break;
                result = result * 10 + (isNegative ? -(digit - _zero) : (digit - _zero));
            }

            return result;
        }

        public static void Flush()
        {
            _inputStream.Flush();
            _inputStream.Close();
        }
    }
}