using System;
using System.Linq;
using System.Numerics;

namespace Euler16PowerDigitSum
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
            /// What is the sum of the digits of the number 2^1000 ?
            /// </summary>

            //SumOfExponentialProduct(2, 1000);

            /*
            long math = 2;
            long addMe = 2;
            long answer = 2;
            for (int i = 0; i < 1000; i++)
            {
                math *= addMe;
                answer += addMe;
                addMe = math;
            }
            Console.WriteLine(answer);
            */
            SumOfExponentialProduct();
        }

        /*
        static void SumOfExponentialProduct(double @base, double power)
        {
            double answer = 0;
            double processedNumber = Math.Pow(@base, power);
            string numberFromToString = processedNumber.ToString("N5"); //0.00009
            string numberFromStringFormat = string.Format("{0:F5}", processedNumber);
            //string finalString = RemoveCharacters(numberFromStringFormat);
            foreach (string digit in numberFromStringFormat.Split())
            {
                answer += double.Parse(digit);
            }
        }
        */
        
        static void SumOfExponentialProduct()
        {
            string processedNumber = Math.Pow(2, 1000).ToString("0." + new string('#', 339));
           // string fullNumber = processedNumber.ToString("0." + new string('#', 339));
        }

        static string RemoveCharacters(string stringToProcess)
        {
            return new string(stringToProcess.Where(c => !stringToProcess.Contains('0')).ToArray());
        }
    }
}
