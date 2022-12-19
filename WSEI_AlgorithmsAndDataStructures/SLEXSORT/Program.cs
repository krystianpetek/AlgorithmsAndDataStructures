﻿using System.Text;
using System;using System.Collections.Generic;using System.Linq;class C{static Func<string>D=>Console.ReadLine;static void Main(){int n=int.Parse(D());for(int i=n;i>0;i--){var g=D();List<string>l=new List<string>();for(int c=int.Parse(D());c>0;c--){l.Add(D());}l.Sort((x,y)=>{int p=x.Length;int q=y.Length;int j=0;int z=0;while(j<p&&j<q&&z==0){z=g.IndexOf(x.ElementAt(j))-g.IndexOf(y.ElementAt(j++));}return z!=0?z:p-q;});l.ForEach(x=>Console.WriteLine(x));D();}}}


class A
{
    Func<string> D => Console.ReadLine;
    void Magin()
    {
        int n = int.Parse(D());
        for (int i = n; i > 0; i--)
        {
            var g = D();
            List<string> l = new();
            for (int c = int.Parse(D()); c > 0; c--)
            {
                l.Add(D());
            }
            l.Sort((x, y) =>
            {
                int p = x.Length;
                int q = y.Length;
                int j = 0;
                int z = 0;
                while (j < p && j < q && z == 0)
                {
                    z = g.IndexOf(x.ElementAt(j)) - g.IndexOf(y.ElementAt(j++));
                }
                return z != 0 ? z : p - q;
            });
            l.ForEach(x => Console.WriteLine(x));
            D();
        }
    }
}

namespace SLEXSORT
{
    public class Program
    {
        public static void Mains(string[] args)
        {
            int n = InputOutputV1.ReadInt();
            int c;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = n; i > 0; i--)
            {
                string text = InputOutputV1.ReadString();
                List<string> list = new List<string>();
                for (c = InputOutputV1.ReadInt(); c > 0; c--)
                {
                    list.Add(InputOutputV1.ReadString());
                }
                list.Sort((x, y) =>
                {
                    int p = x.Length;
                    int q = y.Length;
                    int j = 0;
                    int z = 0;
                    while (j < p && j < q && z == 0)
                    {
                        z = text.IndexOf(x.ElementAt(j)) - text.IndexOf(y.ElementAt(j++));
                    }
                    return z != 0 ? z : p - q;
                });

                for (int j = 0; j < list.Count; j++)
                {
                    stringBuilder.AppendLine(list[j]);
                }
                stringBuilder.AppendLine();
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }

    #region Input Output Helper

    public static class InputOutputV1
    {
        private static System.IO.Stream _readStream = System.Console.OpenStandardInput();
        private static readonly System.IO.Stream _writeStream = System.Console.OpenStandardOutput();
        private const int BUFF_Size = 1 << 16;
        private static int _readIdx = 0, _bytesRead = 0, _writeIdx = 0, _inBuffSize = BUFF_Size, _outBuffSize = BUFF_Size;
        private static readonly byte[] _inBuff = new byte[_inBuffSize], _outBuff = new byte[_outBuffSize];
        public static bool ThrowErrorOnEof { get; set; } = false;

        public static void SetBuffSize(int n)
        {
            _inBuffSize = _outBuffSize = n;
        }

        public static void SetFilePath(string strPath)
        {
            strPath = System.IO.Path.GetFullPath(strPath);
            _readStream = new System.IO.FileStream(strPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
        }

        public static T ReadNumber<T>()
        {
            byte rb;
            while ((rb = GetByte()) < '-') ;

            var neg = false;
            if (rb == '-')
            {
                neg = true;
                rb = GetByte();
            }
            dynamic m = (T)System.Convert.ChangeType(rb - '0', typeof(T));
            while (true)
            {
                rb = GetByte();
                if (rb < '0') break;
                m = m * 10 + (rb - '0');
            }
            return neg ? -m : m;
        }

        public static int ReadInt()
        {
            byte readByte;
            while ((readByte = GetByte()) < '-') ;

            var neg = false;
            if (readByte == '-')
            {
                neg = true;
                readByte = GetByte();
            }
            var m = readByte - '0';
            while (true)
            {
                readByte = GetByte();
                if (readByte < '0') break;
                m = m * 10 + (readByte - '0');
            }
            return neg ? -m : m;
        }

        public static string ReadString()
        {
            return ReadString(' ');
        }

        public static string ReadString(string delimiter)
        {
            return ReadString(delimiter[0]);
        }

        public static string ReadString(char delimiter)
        {
            byte readByte;
            while ((readByte = GetByte()) <= delimiter) ;

            var sb = new System.Text.StringBuilder();
            do
            {
                sb.Append((char)readByte);
            } while ((readByte = GetByte()) > delimiter);

            return sb.ToString();
        }

        private static byte GetByte()
        {
            if (_readIdx >= _bytesRead)
            {
                _readIdx = 0;
                _bytesRead = _readStream.Read(_inBuff, 0, _inBuffSize);
                if (_bytesRead >= 1) return _inBuff[_readIdx++];

                if (ThrowErrorOnEof) throw new System.Exception("End Of Input");
                _inBuff[_bytesRead++] = 0;
            }
            return _inBuff[_readIdx++];
        }

        public static void WriteToBuffer(string s)
        {
            foreach (var b in System.Text.Encoding.ASCII.GetBytes(s))
            {
                if (_writeIdx == _outBuffSize) InternalFlush();
                _outBuff[_writeIdx++] = b;
            }
        }

        public static void WriteLineToBuffer(string s)
        {
            WriteToBuffer(s);
            if (_writeIdx == _outBuffSize) InternalFlush();
            _outBuff[_writeIdx++] = 10;
        }

        public static void WriteToBuffer(int c)
        {
            byte[] temp = new byte[10];
            int tempidx = 0;
            if (c < 0)
            {
                if (_writeIdx == _outBuffSize) InternalFlush(); _outBuff[_writeIdx++] = (byte)'-'; c = -c;
            }
            do
            {
                temp[tempidx++] = (byte)((c % 10) + '0');
                c /= 10;
            } while (c > 0);
            for (int i = tempidx - 1; i >= 0; i--)
            {
                if (_writeIdx == _outBuffSize) InternalFlush();
                _outBuff[_writeIdx++] = temp[i];
            }
        }

        public static void WriteLineToBuffer(int c)
        {
            WriteToBuffer(c);
            if (_writeIdx == _outBuffSize) InternalFlush();
            _outBuff[_writeIdx++] = 10;
        }

        private static void InternalFlush()
        {
            _writeStream.Write(_outBuff, 0, _writeIdx);
            _writeStream.Flush();
            _writeIdx = 0;
        }

        public static void Flush()
        {
            InternalFlush();
            //_readStream.Close();
            //_writeStream.Close();
            ThrowErrorOnEof = false;
        }
    }

    #endregion Input Output Helper
}