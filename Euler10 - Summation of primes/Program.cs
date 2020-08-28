using System;
using static EulerUtils.EulerUtils;
namespace Euler10___Summation_of_primes
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
            /// Find the sum of all the primes below two million.
            /// </summary>
            /// 
            System.Numerics.BigInteger answer = 0;
            ///1 is not prime, starting at 2
            for (int i = 2; i < 2000000; i++)
            {
                if (IsPrime(i))
                {
                    answer += i;
                }
            }
            Console.WriteLine(answer);
        }
    }
}