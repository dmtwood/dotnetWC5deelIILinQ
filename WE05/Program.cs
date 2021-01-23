using System;
using System.Linq;

namespace WE05
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var grootsteDrie = numbers.OrderByDescending(x => x).Take(3);
            var som = numbers.Sum();
            var gemiddelde = numbers.Average();
            var evenGetallen = numbers.Where(x => x % 2 == 0);

            Console.WriteLine(string.Join(" ", grootsteDrie));
            Console.WriteLine(som);
            Console.WriteLine(gemiddelde);
            Console.WriteLine(string.Join(" ", evenGetallen));
        }
    }
}
