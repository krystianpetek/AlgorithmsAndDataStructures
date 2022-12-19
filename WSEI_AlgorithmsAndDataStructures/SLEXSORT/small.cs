//using System;
//using System.Collections.Generic;
//using System.Linq;
//class B { static Func<string> D => Console.ReadLine; static void Main() { int n = int.Parse(D()); for (int i = n; i > 0; i--) { var g = D(); List<string> l = new List<string>(); for (int c = int.Parse(D()); c > 0; c--) { l.Add(D()); } l.Sort((x, y) => { int p = x.Length; int q = y.Length; int j = 0; int z = 0; while (j < p && j < q && z == 0) { z = g.IndexOf(x.ElementAt(j)) - g.IndexOf(y.ElementAt(j++)); } return z != 0 ? z : p - q; }); l.ForEach(x => Console.WriteLine(x)); D(); } } }
