using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HASHIT___Hash_it_
{
    internal static class HashIt
    {
        internal static void Main()
        {
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var table = new SortedDictionary<int, string>();
                var n = int.Parse(Console.ReadLine());
                for (int j = 0; j < n; j++)
                {
                    var operation = Console.ReadLine();

                    switch (operation[0])
                    {
                        case 'A':
                            table.InsertKey(operation.Substring(4));
                            break;
                        case 'D':
                            table.DeleteKey(operation.Substring(4));
                            break;
                    }

                }

                Console.WriteLine(table.Count);
                foreach (var key in table)
                {
                    Console.WriteLine($"{key.Key}:{key.Value}");
                }
            }
        }
        internal static void InsertKey(this SortedDictionary<int, string> table, string value)
        {
            if (table.ContainsValue(value))
                return;

            var key = Hash(value);
            if (!table.ContainsKey(key))
                table.Add(key, value);
            else
                table.Add(table.OpenAddressingMethod(key), value);
        }

        internal static bool DeleteKey(this SortedDictionary<int, string> table, string value)
        {
            if (table.ContainsValue(value))
                table.Remove(table.FindIndex(value));

            var key = Hash(value);
            return table.Remove(key);

        }

        internal static int FindIndex(this SortedDictionary<int, string> table, string value)
        {
            var key = Hash(value);
            if (table.ContainsKey(key))
                return key;

            return table.OpenAddressingMethod(key);
        }


        private static int Hash(string value)
        {
            return h(value) % 101;
        }

        private static int h(string value)
        {
            var result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                result += value[i] * (i + 1);
            }
            return result * 19;
        }

        private static int OpenAddressingMethod(this SortedDictionary<int, string> table, int index)
        {
            for (int j = 1; j <= 19; j++)
            {
                int newIndex = (index + (j * j) + (23 * j)) % 101;
                if (!table.ContainsKey(newIndex))
                    return newIndex;
            }
            return -1;
        }
    }
}
