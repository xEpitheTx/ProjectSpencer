using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler11LargestProductInGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] productArray = CreateArray();
            int finalAnswer = Math.Max(CheckNumbersToRight(productArray), CheckNumbersToLeft(productArray));
            finalAnswer = Math.Max(finalAnswer, CheckNumbersUp(productArray));
            finalAnswer = Math.Max(finalAnswer, CheckNumbersDown(productArray));
            finalAnswer = Math.Max(finalAnswer, CheckNumbersDiagnolSWToNE(productArray));
            finalAnswer = Math.Max(finalAnswer, CheckNumbersDiagnolNWToSE(productArray));
            Console.WriteLine(finalAnswer);
        }

        static List<List<int>> CreateArray2()
        {
            string[] lines = File.ReadAllLines("euler11.dat");
            List<List<int>> grid = new List<List<int>>();
            foreach (string line in lines)
            {
                string[] splitString = line.Split(' ');
                List<int> row = new List<int>();
                foreach (string splitStr in splitString)
                {
                    row.Add(int.Parse(splitStr));
                }
                grid.Add(row);
            }
            return grid;
        }

        static List<List<int>> CreateArray3()
        {
            string[] lines = File.ReadAllLines("euler11.dat");
            List<List<int>> grid = new List<List<int>>();
            foreach (string line in lines)
            {
                List<int> row = new List<int>();
                foreach (string cell in line.Split())
                {
                    row.Add(int.Parse(cell));
                }
                grid.Add(row);
            }
            return grid;
        }

        static List<List<int>> CreateArray4()
        {
            string[] lines = File.ReadAllLines("euler11.dat");
            return lines.Select(line => line.Split().Select(a => int.Parse(a)).ToList()).ToList();
        }

        static string[,] CreateArray()
        {
            string[,] array = new string[20, 20];
            using (StreamReader sr = new StreamReader("euler11.dat"))
            {
                /// iterates over row at index 0, get's the 20 numbers at index 1,
                /// reads in next line, incremetns to next row at index 1 and repeats.
                for (int j = 0; j <= 19; j++)
                {
                    string oneLineOfFile = sr.ReadLine();
                    string[] currentNumbers = oneLineOfFile.Split(' ');

                    for (int i = 0; i <= 19; i++)
                    {
                        array[j, i] = currentNumbers[i];
                    }
                }
            }
            return array;
        }

        static int CheckNumbersToRight(string[,] stringArray)
        {
            int answerCheck = 1;
            int answer = 0;

            // go through all the rows
            for (int row = 0; row < 20; row++)
            {
                // go through all but the last 4 columns becasuse we need 4 numbers to multiply
                for (int column = 0; column <= 16; column++)
                {
                    //go through the set of four numbers from the starting column
                    for (int positionToMultiply = column; positionToMultiply <= column + 3; positionToMultiply++)
                    {
                        answerCheck = CalculateAnswerCheck(stringArray, column, positionToMultiply, answerCheck);
                    }
                    answer = CheckForLargerProduct(answer, answerCheck);
                    answerCheck = 1;
                }
            }
            return answer;
        }

        static int CheckNumbersToLeft(string[,] stringArray)
        {
            int answerCheck = 1;
            int answer = 0;
            // go through all the rows
            for (int row = 0; row < 20; row++)
            {
                //look at number in fourth position to start because we are looking backwards and need 4
                // numbers to multiply.
                for (int column = 4; column <= 16; column++)
                {
                    //go through the set of four numbers from the starting column backwards.
                    for (int positionToMultiply = column; positionToMultiply >= column - 3; positionToMultiply--)
                    {
                        answerCheck = CalculateAnswerCheck(stringArray, column, positionToMultiply, answerCheck);
                    }
                }
                answer = CheckForLargerProduct(answer, answerCheck);
            }
            return answer;
        }


        static int CheckNumbersUp(string[,] stringArray)
        {
            int answerCheck = 1;
            int answer = 0;
            //Start at the forth row, then go through remaining rows. Starts at row 4 because we need a set of 4
            // numbers in a column.
            for (int row = 3; row < 20; row++)
            {
                // go through each column
                for (int column = 0; column < 20; column++)
                {
                    //multiply the set of four numbers from the row up three rows.
                    for (int positionToMultiply = row; positionToMultiply >= row - 3; positionToMultiply--)
                    {
                        answerCheck = CalculateAnswerCheck(stringArray, positionToMultiply, column, answerCheck);
                    }
                }
                answer = CheckForLargerProduct(answer, answerCheck);
            }
            return answer;
        }

        static int CheckNumbersDown(string[,] stringArray)
        {
            int answerCheck = 1;
            int answer = 0;
            //go thorugh all the rows except the last four because we need a set of 4 numbers.
            for (int row = 0; row < 17; row++)
            {
                //go through every column but the last four because we need a set of 4 numbers
                for (int column = 0; column < 17; column++)
                {
                    //from the starting column, get a set of four numbers down.
                    for (int n = column; n <= column + 3; n++)
                    {
                        {
                            answerCheck = CalculateAnswerCheck(stringArray, n, column, answerCheck);
                        }
                    }
                    answer = CheckForLargerProduct(answer, answerCheck);
                }
            }
            return answer;
        }

        static int CheckNumbersDiagnolSWToNE(string[,] stringArray)
        {
            int answerCheck = 1;
            int answer = 0;
            //go through every rows except the first 4. 
            //start at fourth row, because we need a set of four numbers in a diagnol row going up.
            for (int row = 3; row < 20; row++)
            {
                //go through every column except for the last 4 because we need a set of four numbers at the end.
                for (int column = 0; column < 17; column++)
                {
                    //go through each row upwards
                    for (int n = row; n >= row - 3; n--)
                    {
                        //get the number from the next column and next row
                        int k = column;
                        answerCheck = CalculateAnswerCheck(stringArray, n, k, answerCheck);
                        k++;
                    }
                    answer = CheckForLargerProduct(answer, answerCheck);
                }
            }
            return answer;
        }
        /*
        static int SkiDiagnal(string[,] stringArray)
        {
            for (int row = 0; row <= 15; row++)
            {
                for (int col = 0; col <= 15; col++)
                {
                    var number = stringArray[row,  col]
                        * stringArray[row + 1, col + 1]
                        * stringArray[row + 2, col + 2]
                        * stringArray[row + 3, col + 3];
                }
            }
        }
        */

        static int CheckNumbersDiagnolNWToSE(string[,] stringArray)
        {
            int answerCheck = 1;
            int answer = 0;
            //go through each row but start at row 4 because we need a set of four numbers from the row up.
            for (int row = 0; row < 17; row++)
            {
                //go through each column but start at column 4 because we need a set of four numbers
                for (int column = 4; column < 20; column++)
                {
                    //from the starting row, get four numbers up.
                    for (int n = row; n <= row + 3; n++)
                    {
                        //from the starting column, get 4 numbers right.
                        int k = column;
                        answerCheck = CalculateAnswerCheck(stringArray, n, k, answerCheck);
                        k--;
                    }
                    answer = CheckForLargerProduct(answer, answerCheck);
                }
            }
            return answer;
        }


        static int CalculateAnswerCheck(string[,] stringArray, int a, int b, int answerCheck)
        {
            //multiplying by 0 should stop the iteration, the result is always 0.
            if (int.Parse(stringArray[a, b]) == 0)
            {
                return answerCheck = 0;
            }
            else
            {
                //finds the place in the array of row a, column b and turns the string into an int.
                answerCheck *= int.Parse(stringArray[a, b]);
            }
            return answerCheck;
        }

        static int CheckForLargerProduct(int answer, int answerCheck)
        {
            if (answer < answerCheck)
            {
                answer = answerCheck;
            }
            return answer;
        }
    }
}
