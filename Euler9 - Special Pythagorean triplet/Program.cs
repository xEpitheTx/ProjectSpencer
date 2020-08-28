﻿using System;

namespace Euler9___Special_Pythagorean_triplet
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
            /// a2 + b2 = c2
            ///For example, 32 + 42 = 9 + 16 = 25 = 52.
            ///There exists exactly one Pythagorean triplet for which a +b + c = 1000.
            ///Find the product abc.
            /// </summary>
            int answer = 0;
            for (int a = 1; a < 1000; a++)
            {
                for (int b = 2; b < 1000; b++)
                {
                    int c = 1000 - a - b;
                    if (a * a + b * b == c * c)
                    {
                        answer = a * b * c;
                        break;
                    }
                }
            }
            Console.WriteLine(answer);
        }
    }
}
