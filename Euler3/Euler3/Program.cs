using System;
using static EulerUtils.EulerUtils;
namespace Euler3
{
    //how to make this faster. You never have to check numbers divisible by 5 at least
    class Program
    {
        const double SQUAREROOT_OF_EVALUATION_NUMBER = 775147;
        static void Main(string[] args)
        {
            int largestPrimeFactor = 0;
            for (int i = 1; i < SQUAREROOT_OF_EVALUATION_NUMBER; i += 2)
            {
                if (IsPrime(i) && 600851475143 % i == 0)
                {
                    largestPrimeFactor = i;
                    //Console.WriteLine(largestPrimeFactor);
                }
            }
            Console.WriteLine($"The largest Prime factor is: {largestPrimeFactor}");
        }
    }
}

