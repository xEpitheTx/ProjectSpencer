using System;
using System.Numerics;
namespace Euler15LatticePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
            /// How many such routes are there through a 20×20 grid ? 
            /// here's some math stuff to learn http://mathforum.org/advanced/robertd/manhattan.html
            /// every possible square grid has to touch n * 2 sides of a square where n is the size of a grid side.
            /// Algorithm for unique permutations is x!/(x/2)!(x/2)! where x is n from above.
            /// </summary>

            BigInteger answer = NumberOfRoutes(20);
            Console.WriteLine(answer);
        }

        static BigInteger NumberOfRoutes(int lengthOfOneSide)
        {
            BigInteger numerator = 1;
            BigInteger denominator = 1;
            BigInteger answer = 0;
            //find the numerator in the equation by multiplying itself by each number smaller than it until 1
            for (int i = lengthOfOneSide * 2; i > 1; i--)
            {
                numerator *= i;
            }
            //find one side of the denominator by dividing the number by 2 and iterating down to 1
            for (int i = (lengthOfOneSide * 2) / 2; i > 1; i--)
            {
                denominator *= i;
            }
            //divide the numerator by the denominator*denominator
            answer = numerator / (denominator * denominator);
            return answer;
        }
    }
}
