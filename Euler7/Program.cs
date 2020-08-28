using System;
using static EulerUtils.EulerUtils;
namespace Euler7
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            /// What is the 10 001st prime number ?
            /// </summary>
            int primesFoundCounter = 0;
            int answer = 0;
            {
                for (int i = 1; primesFoundCounter <= 10001; i++)
                {
                    if (IsPrime(i))
                    {
                        answer = i;
                        primesFoundCounter++;
                    }
                }
            }
            Console.WriteLine(answer);
        }
    }
}
