using System;
using System.Diagnostics.CodeAnalysis;

namespace Euler2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int sum = 4;
            int i = 2;
            int j = 4;
            while (i < 4000000)
            {
                int lastInt = sum;
                sum = sum + i;
                i = j;
                j = lastInt;
            }
            */
            /*
            int sum = 0;
            int j = 4;
            int i = 2;
            while (i < 4000000)
            {
                sum = sum + j + i;
                int nextInt = j + i;
                i = j;
                j = nextInt;
                //Console.Write(i);
                Console.Write($" {j} ");
            }
            Console.WriteLine(sum);
            */
            double sum = 0;
            for (double i = 0; i <= 4000000; i += 2)
            {
                double fibNumCheck = 5 * (i * i) + 4;
                double fibNumCheck2 = 5 * (i * i) - 4;
                double sr = Math.Sqrt(fibNumCheck);
                double sr2 = Math.Sqrt(fibNumCheck2);
                if (sr % 1 == 0 || sr2 % 1 == 0)
                {
                    sum = sum + i;
                    //Console.WriteLine(sum);
                }
            }
            Console.WriteLine(sum);
        }
    }
}
