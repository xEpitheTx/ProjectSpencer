using System;
using System.Collections.Generic;

namespace Euler5
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
            /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20 ?
            /// </summary>
            int counter = 2521;
            int smallestPositiveNumber = 0;
            bool passedAllChecks = false;
            while (!passedAllChecks)
            {
                for (int i = 2; i <= 20; i++)
                {
                    if (counter % i == 0)
                    {
                        passedAllChecks = true;
                    }
                    else
                    {
                        passedAllChecks = false;
                        break;
                    }
                    smallestPositiveNumber = counter;
                }
                counter++;
            }
            Console.WriteLine(smallestPositiveNumber);
        }
    }
}
