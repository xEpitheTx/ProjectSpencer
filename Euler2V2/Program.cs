using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler2V2
{
    class Program
    {
        /// <summary>
        /// The equation to generate the Fibonacci sequence is a sub n = [Phi^2 - (epsilon)^2) / squareroot(5);
        /// Phi and epsilon are mirror images of (1 - sqrt(5)) / 2 and (1 + sqrt(5)) / 2. Also, n is controlled by a for loop
        /// to iterate through each number until n (the last fib number before the sum of 4million) is reached.
        /// This results in a fibonnaci sequence without having to add two terms together. However given my precision there is
        /// a small remainder to deal with.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            double answer = SumOfEvenFibonacciTerms(GenerateFibonacciSequence(4000000));
        }

        static List<double> GenerateFibonacciSequence(double threshold)
        {
            List<double> terms = new List<double>();
            //we start with 2 so we can look back to 1 instead of starting at 1 and looking back to 0.
            //Per restrictions, the sequence is 1,2,3,5 not 1,1,2,3,5.
            for (int n = 2; NextFibonacciSequenceTerm(n) < threshold; n++)
            {
                terms.Add(NextFibonacciSequenceTerm(n));
                Console.WriteLine(NextFibonacciSequenceTerm(n));
            }
            return terms;
        }

        static double SumOfEvenFibonacciTerms(List<double> terms)
        {
            double sumOfEvenFibonacciTerms = 0;
            //the pattern in a fibonacci sequence is every third int is even as seen by taking the first few terms
            //1,2,3,5,8,13,21,34. Assumption is the loop must start on the index 1 to grab term 2.
            for (int i = 1; i < terms.Count; i += 3)
            {
                sumOfEvenFibonacciTerms += terms[i];
            }
            return sumOfEvenFibonacciTerms;
        }

        static double PhiCalculation()
        {
            return (1 + Math.Sqrt(5)) / 2;
        }

        static double EpsilonCalculation()
        {
            return (1 - Math.Sqrt(5)) / 2;
        }

        static double NextFibonacciSequenceTerm(int n)
        {
            //Math floor takes care of the pesky precision problem with this golden rule equation
            return Math.Floor((Math.Pow(PhiCalculation(), n) - Math.Pow(EpsilonCalculation(), n)) / Math.Sqrt(5));
        }
    }
}
