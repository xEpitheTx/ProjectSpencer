using System;
using System.Collections.Generic;
using System.Linq;
using static EulerUtils.EulerUtils;
namespace Euler3LargestPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LargestPrimeNumber(600851475143));
        }

        static long LargestPrimeNumber(long factorToCheck)
        {
            HashSet<long> primeNumbers = new HashSet<long>();
            for (int n = 2; n <= Math.Sqrt(factorToCheck); n++)
            {
                if (factorToCheck % n != 0)
                {
                    primeNumbers.Add(factorToCheck);
                }
            }
            return primeNumbers.Last();
        }
    }
}
