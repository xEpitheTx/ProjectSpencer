﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EulerUtils
{
    public static class EulerUtils
    {
        /// <summary>
        /// the upper limit of Divisor is the square root of Number. 
        /// Every other combo above that would multiply out to a larger number we don't care about
        /// </summary>
        /// <param name="i">number to check</param>
        /// <returns></returns>
        public static bool IsPrime(int i)
        {
            for (int n = 2; n <= Math.Sqrt(i); n++)
            {
                if (i % n == 0)
                {
                    return false;
                }
            }
            //Console.WriteLine(i);
            return true;
        }

        /// <summary>
        /// Sieve of Eratosthenes
        /// </summary>
        /// <param name="maxValueToCheck">the last number in a series that needs to be prime checked.</param>
        /// <returns>HashSet that contains only prime numbers from 2 to maxValue</returns>
        public static HashSet<int> PrimeNumbers(int maxValueToCheck)
        {
            HashSet<int> primeNumbers = new HashSet<int>();
            for (int i = 2; i < maxValueToCheck; i++)
            {
                primeNumbers.Add(i);
            }

            foreach (int numToCheck in primeNumbers)
            {

            }
            for (int i = 2; i < Math.Sqrt(maxValueToCheck); i++)
            {

            }
        }

        public static string ReverseNumberAsString(string toReverse)
        {
            char[] arr = toReverse.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static int CheckNumbersToRight(char[] myCharArray)
        {
            int answerCheck = 1;
            int answer = 0;
            for (int i = 0; i <= myCharArray.Length - 13; i++)
            {
                for (int n = i; n <= i + 12; n++)
                {
                    ///Convert.ToInto32 returns ascii, which is offset by 48 from the actual number.
                    if (Convert.ToInt32(myCharArray[n]) - 48 == 0)
                    {
                        break;
                    }
                    else
                    {
                        answerCheck *= Convert.ToInt32(myCharArray[n]) - 48;
                    }
                }
                if (answer < answerCheck)
                {
                    answer = answerCheck;
                }
                answerCheck = 1;
            }
            return answer;
        }
    }
}
