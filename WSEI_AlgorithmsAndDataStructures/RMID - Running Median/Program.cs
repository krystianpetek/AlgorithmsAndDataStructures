using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        StringBuilder stringBuiler = new StringBuilder();
        List<int> list = new List<int>();
        bool flag = false;

        while (true)
        {
            int readline = FastIO.ReadInt();
            //string readLine1 = Console.ReadLine();
            //if (string.IsNullOrEmpty(readLine1)) break;
            //var readline = int.Parse(readLine1);

            if (readline == 13 || readline == 10 || readline == 32)
            {
                if (flag)
                    break;

                flag = true;
                continue;
            }
            else
                flag = false;

            if (readline == -1)
            {
                //Calculate(list);
                if (list.Count % 2 == 0)
                {
                    stringBuiler.AppendLine(list[(list.Count / 2) - 1].ToString());
                    list.RemoveAt((list.Count / 2) - 1);
                }
                else
                {
                    stringBuiler.AppendLine(list[(list.Count / 2)].ToString());
                    list.RemoveAt((list.Count / 2));
                }
                continue;
            }

            if (readline == 0)
            {
                stringBuiler.AppendLine();
                list.Clear();
                _ = Console.ReadLine();

                continue;
            }

            list.Add(readline);
        }
        Console.WriteLine(stringBuiler.ToString().Trim());
    }
    static void Calculate(List<int?> list) => list.ForEach(x => { Console.Write($"{x} "); });
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
            if (digit == 13 || digit == 32)
            {
                //digit = ReadByte();
                //if (digit == 13)
                    return digit;
            }
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
}