using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler1V2UsingPEDAC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumMultiples(FindMultiples(1000, 3, 5)));
        }

        static HashSet<int> FindMultiples(int target, int factor1, int factor2)
        {
            HashSet<int> multiples = new HashSet<int>();
            for (int i = 1; i < target; i++)
            {
                if (i % factor1 == 0 || i % factor2 == 0)
                {
                    multiples.Add(i);
                }
            }
            return multiples;
        }

        static int SumMultiples(HashSet<int> multiples)
        {
            int sumOfMultiples = 0;
            foreach (int multiple in multiples)
            {
                sumOfMultiples += multiple;
            }
            return sumOfMultiples;
        }
    }
}
