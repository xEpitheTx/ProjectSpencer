using System;

namespace Euler6
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// The sum of the squares of the first ten natural numbers is,
            /// The square of the sum of the first ten natural numbers is,
            /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is .
            /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
            /// </summary>
            int sumOfSquares = 1;
            int squareOfSums = 1;
            for (int i = 2; i <= 100; i++)
            {
                sumOfSquares += i * i;
            }
            for (int i = 2; i <= 100; i++)
            {
                squareOfSums += i;
            }
            squareOfSums *= squareOfSums;
            Console.WriteLine(squareOfSums - sumOfSquares);
        }
    }
}
