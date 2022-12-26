//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Threading;
//using System.Diagnostics;
//using System.IO;
//using System.Numerics;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int T = int.Parse(Console.ReadLine());
//            while (T-- > 0)
//            {
//                int M, N;
//                string[] line = Console.ReadLine().Split();
//                M = int.Parse(line[0]);
//                N = int.Parse(line[1]);
//                Data[] arr = new Data[M * N];
//                Data[] arr2 = new Data[M * N];
//                for (int i = 0; i < M; i++)
//                {
//                    line = Console.ReadLine().Split();
//                    for (int j = 0; j < N; j++)
//                    {
//                        int idx = i * N + j;
//                        arr[idx].v = double.Parse(line[j]);
//                        arr[idx].r = i + 1;
//                        arr[idx].c = j + 1;
//                    }
//                }

//                int tn = N;
//                while (N < M * N)
//                {
//                    int j;
//                    for (j = 0; j + N < M * N; j += 2 * N)
//                        Merge(arr, arr2, j, j + N, j + N, j + 2 * N);
//                    if (j < M * N && j + N >= M * N)
//                        Merge(arr, arr2, j - 2 * N, j, j, M * N);
//                    N *= 2;
//                }
//                for (int i = 0; i < M * N; i++) Console.Write(arr[i].r + "," + arr[i].c + " ");
//                Console.WriteLine();
//            }
//        }

//        static void Merge(Data[] arr, Data[] arr2, int st1, int ed1, int st2, int ed2)
//        {
//            int j = 0, st = st1;
//            while (st1 < ed1 && st2 < ed2)
//            {
//                if (arr[st1].v > arr[st2].v ||
//                    (arr[st1].v == arr[st2].v && arr[st1].r < arr[st2].r) ||
//                    (arr[st1].v == arr[st2].v && arr[st1].r == arr[st2].r && arr[st1].c < arr[st2].c))
//                {
//                    arr2[j++] = arr[st1++];
//                }
//                else
//                {
//                    arr2[j++] = arr[st2++];
//                }
//            }
//            while (st1 < ed1) arr2[j++] = arr[st1++];
//            while (st2 < ed2) arr2[j++] = arr[st2++];
//            for (int k = 0; k < j; k++) arr[st + k] = arr2[k];
//        }
//    }
//}

//struct Data
//{
//    public double v;
//    public int r, c;
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class ProblemSet
{
    public int MemberPosition { get; set; }
    public int ProblemPosition { get; set; }
    public double Score { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        StringBuilder builder = new StringBuilder();
        int T = int.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            List<ProblemSet> problemSets = new List<ProblemSet>();
            for (int j = 0; j < M; j++)
            {
                double[] scores = Array.ConvertAll(Console.ReadLine().Trim().Split(), double.Parse);
                for (int k = 0; k < N; k++)
                {
                    problemSets.Add(new ProblemSet { MemberPosition = j, ProblemPosition = k, Score = scores[k] });
                }
            }

            problemSets = problemSets.OrderByDescending(x => x.Score)
                                    .ThenBy(x => x.MemberPosition)
                                    .ThenBy(x => x.ProblemPosition)
                                    .ToList();

            foreach (ProblemSet problemSet in problemSets)
            {
                builder.Append($"{problemSet.MemberPosition + 1},{problemSet.ProblemPosition + 1}");
            }
        }
        Console.Write(builder.ToString());
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
            //if (digit == 13 || digit == 32)
            //{
                //digit = ReadByte();
                //if (digit == 13)
                //return digit;
            //}
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