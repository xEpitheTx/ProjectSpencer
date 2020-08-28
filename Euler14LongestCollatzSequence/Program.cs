using System;
using System.Collections.Generic;

namespace Euler14LongestCollatzSequence
{
    /// <summary>
    /// a way to make this potentially faster is to throw out numbers that already are in a previous sequence
    /// Since 40 appears in 13s sequence, you know the sequence of 40 and that it is shorter than 13s.
    /// Since this is a lot of checks, it may not be faster at all and actually worse.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Which starting number, under one million, produces the longest chain?
            //n → n/2 (n is even)
            //n → 3n + 1(n is odd)
            //13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
            List<long> collatzeSequence = new List<long>();
            for (int i = 1000000; i > 0; i--)
            {
                List<long> newCollatzeSequence = ProcessCollatzSequence(i);
                if (newCollatzeSequence.Count > collatzeSequence.Count)
                {
                    collatzeSequence = newCollatzeSequence;
                }
            }
            Console.WriteLine(collatzeSequence[0]);
        }

        static bool IsEven(long numToCheck)
        {
            return numToCheck % 2 == 0;
        }

        static List<long> ProcessCollatzSequence(long startingNumber)
        {
            List<long> newCollatzSequence = new List<long>();
            long numberToProcess = startingNumber;
            newCollatzSequence.Add(numberToProcess);
            //do this until the result is 1
            while (numberToProcess > 1)
            {
                //check if starting number is even or odd
                if (IsEven(numberToProcess))
                {
                    //if number is even, the number is divided by two
                    numberToProcess = numberToProcess / 2;
                    //add the result to a list for later use of the collatz sequence
                    newCollatzSequence.Add(numberToProcess);
                }
                else
                {
                    //if number is odd, the number is multipled by 3 and 1 is added
                    numberToProcess = (numberToProcess * 3) + 1;
                    newCollatzSequence.Add(numberToProcess);
                }
            }
            return newCollatzSequence;
        }
    }
}

