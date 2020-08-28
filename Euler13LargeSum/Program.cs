using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Euler13LargeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Work out the first ten digits of the sum of the following one - hundred 50 - digit numbers.
            BigInteger largeSum = LoadData();
            SumOfFirstTenDigits(largeSum);
        }

        static BigInteger LoadData()
        {
            BigInteger largeSum = 0;
            string[] stringNumbers = File.ReadAllLines("euler13.dat");
            foreach (string line in stringNumbers)
            {
                largeSum += BigInteger.Parse(line);
            }
            return largeSum;
        }


        static void SumOfFirstTenDigits(BigInteger largeSum)
        {
            string sumString = largeSum.ToString();
            List<char> firstTen = new List<char>();
            firstTen = sumString.Skip(0).Take(10).ToList();
            foreach (char digit in firstTen)
            {
                Console.Write(digit);
            }
        }
    }
}