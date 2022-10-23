//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//class ThorVsFrostGiants
//{
//    const int me = 100025;
//    const int MAX_LOG = 20;

//    static int[,] st = new int[me, MAX_LOG];

//    static int get(int l, int r, int n)
//    {
//        int s = 1;
//        for (int i = MAX_LOG; i >= 0; i--)
//        {
//            if (l + (1 << i) - 1 <= r)
//            {
//                s = s * st[l, i] % n;
//                l += 1 << i;
//            }
//        }
//        return s;
//    }

//    public static int Main()
//    {
//            var n = int.Parse(Console.ReadLine());
//            var a = new int[me];
//            var x =Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

//        for (int i = 1; i <= n; i++)
//            {
//            a[i] = int.Parse(x[i-1]);
//            }
//            for (int i = 1; i <= n; i++)
//            {
//                st[i, 0] = a[i] % n;
//            }
//            for (int j = 1; j < MAX_LOG; j++)
//            {
//                for (int i = 1; i + (1 << j) - 1 <= n; i++)
//                {
//                    st[i, j] = st[i, j - 1] * st[i + (1 << (j - 1)), j - 1] % n;
//                }
//            }

//            int ans = n + 1, pos = n + 1;

//            for (int i = 1; i <= n; i++)
//            {
//                if (get(i, n, n) != 0)
//                    continue;

//                int low = i, high = n, mid, best = n;

//                while (low <= high)
//                {
//                    mid = (low + high + 1) >> 1;

//                    if (get(i, mid, n) == 0)
//                    {
//                        best = mid;
//                        high = mid - 1;
//                    }

//                    else
//                    {
//                        low = mid + 1;
//                    }
//                }
//                if (best - i + 1 < ans)
//                {
//                    ans = best - i + 1;
//                    pos = i;
//                }
//            }
//            if (ans == n + 1)
//            {
//                Console.WriteLine(-1);
//            }
//            else
//                Console.WriteLine((pos - 1) + " " + (pos + (ans - 2)));

//            return 0;
//    }
//}

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
class ThorVsFrostGiants
{
    public struct Pair
    {
        public int First { get; set; }
        public int Second { get; set; }
    }

    const int MAX = 100000;
    static void Main()
    {
        var b = 0;
        var strength = Enumerable.Repeat(0, MAX).ToList();
        var d = Enumerable.Repeat(0, MAX).ToList();

        _ = int.TryParse(Console.ReadLine(), out int N);
        var army = Array.ConvertAll<string,int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries), x => int.Parse(x));

        var n = new Pair[10];
        int[,] window = new int[MAX, 10];

        for (int i = 2; i < MAX; i++)
        {
            for (int j = 2; i * j < MAX; i++)
            {
                strength[i * j] = 1;
            }
        }

        int a = 0;
        for (int i = 2; i < 1000; i++)
        {
            if (strength[i] == 0)
                d[a++] = i;
        }

        int s = N;
        while (s != 1)
        {
            for (int i = 0; i < a; i++)
            {
                if (s % d[i] == 0)
                {
                    n[b].First = d[i];
                    while (s % d[i] == 0)
                    {
                        n[b].Second++;
                        s /= d[i];
                    }
                    b++;
                }
            }
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < b; j++)
            {
                while (army[i] % n[j].First == 0)
                {
                    window[i, j]++;
                    army[i] /= n[j].First;
                }
            }
        }

        int h = 0, g = 0, r1 = 0, r2 = 0, l = MAX, check = 0, num;
        while (g < N)
        {
            num = 0;
            for (int i = 0; i < b; i++)
            {
                n[i].Second -= window[g, i];
            }
            for (int i = 0; i < b; i++)
            {
                if (n[i].Second <= 0) num++;
            }
            if (num == b)
            {
                check = 1;
                while (true)
                {
                    num = 0;
                    for (int i = 0; i < b; i++)
                    {
                        n[i].Second += window[h, i];
                    }
                    for (int i = 0; i < b; i++)
                    {
                        if (n[i].Second <= 0) num++;
                    }
                    if (num != b && g - h + 1 < l)
                    {
                        l = g - h + 1;
                        r1 = h;
                        r2 = g;
                    }
                    h++;
                    if (num != b)
                        break;
                }
            }
            g++;
        }
        if (check != 0)
        {
            Console.WriteLine($"{r1} {r2}");
            return;
        }
        Console.WriteLine("-1");

    }
}