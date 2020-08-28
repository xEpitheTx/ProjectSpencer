using System;
using System.Security.Cryptography.X509Certificates;
using static EulerUtils.EulerUtils;
namespace Euler4
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
            /// Find the largest palindrome made from the product of two 3 - digit numbers.
            /// </summary>
            int largestPalindrome = 0;
            for (int i = 100; i < 999; i++)
            {
                for (int n = 100; n < 999; n++)
                {
                    if ((i * n).ToString() == ReverseNumberAsString((i * n).ToString()) && largestPalindrome < (i * n))
                    {
                        largestPalindrome = i * n;
                    }
                }
            }
            Console.WriteLine(largestPalindrome);
        }
}
}
