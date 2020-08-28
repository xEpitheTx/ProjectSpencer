using System;
using System.IO;
using System.Numerics;
using static EulerUtils.EulerUtils;

namespace Euler8___Largest_Product_in_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Gets the 1000 number from file and stores it. BigInt is the only thing I found to be able to parse this string.
            //BigInteger myBigInt = BigInteger.Parse(File.ReadAllText("euler8.dat"));
            BigInteger answerCheck = 1;
            BigInteger answer = 0;
            string myString = File.ReadAllText("euler8.dat");
            char[] myCharArray = myString.ToCharArray();
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
            Console.WriteLine(answer);
            /*
            for (int i = 0; i < myCharArray.Length; i++)
            {
                if (i <= 12)
                {
                    answerCheck *= Convert.ToInt32(myCharArray[i]);
                }
                else
                {
                    answerCheck = (answerCheck / Convert.ToInt32(myCharArray[i - 13]) * Convert.ToInt32(myCharArray[i]));
                }
                if (answerCheck > answer)
                {
                    answer = answerCheck;
                }
            }
            */

            /*
            int iterationCounter = 0;
            while (iterationCounter <= 999)
            {
                for (int i = 0; i < i + 12 && i <= 999; i++)
                {
                    answerCheck *= Convert.ToInt32(myCharArray[i]);
                    iterationCounter++;
                }
                if (answer < answerCheck)
                {
                    answer = answerCheck;
                }
                answerCheck = 1;
            */
        }
    }
}
