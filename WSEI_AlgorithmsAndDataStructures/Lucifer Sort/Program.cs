using System;
using System.Linq;

namespace LuciferSort;

class Program
{
    static void Main(string[] args)
    {
        int svs = int.Parse(Console.ReadLine());

        for (int i = 0; i < svs; i++)
        {
            int bks = int.Parse(Console.ReadLine());
            List<int> books = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int steps = LuciferSort(books);

            Console.WriteLine(steps);
        }
    }

    static int LuciferSort(List<int> books)
    {
        int steps = 0;

        while (!IsSorted(books))
        {
            int firstUnsorted = FindFirstUnsorted(books);

            steps += PickAndPlace(ref books, firstUnsorted);
        }
         
        return steps;
    }

    static bool IsSorted(List<int> books)
    {
        for (int i = 1; i < books.Count; i++)
        {
            if (books[i] < books[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static int FindFirstUnsorted(List<int> books)
    {
        for (int i = 0; i < books.Count - 1; i++)
        {
            if (books[i] > books[i + 1])
            {
                return i;
            }
        }
        return -1;
    }

    static int PickAndPlace(ref List<int> books, int firstUnsorted)
    {
        int book = books[firstUnsorted];
        books.RemoveAt(firstUnsorted);

        int left = 0;
        int right = books.Count - 1;
        int mid = (left + right) / 2;
        books.Insert(mid, book);
        if (books[mid] == 0)
        {
            books[mid] = book;
            return right - left;
        }
        else if (books[mid] > book)
        {
            right = mid;
        }
        else
        {
            left = mid + 1;
        }

        books[right] = book;
        return right - left + 1;
    }
}
