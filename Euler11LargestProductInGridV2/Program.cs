using System;
using System.Collections.Generic;
using System.IO;

namespace Euler11LargestProductInGridV2
{
    class Program
    {
        const int gridOffset = 3;
        static void Main(string[] args)
        {
            List<List<int>> grid = CreateArray();
            FindLargestProductInGrid(grid);
        }

        static List<List<int>> CreateArray()
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
        
        static void FindLargestProductInGrid(List<List<int>> grid)
        {
            int finalAnswer = Math.Max(LargestProductToRight(grid), LargestProductToLeft(grid));
            finalAnswer = Math.Max(finalAnswer, LargestProductUp(grid));
            finalAnswer = Math.Max(finalAnswer, LargestProductDown(grid));
            finalAnswer = Math.Max(finalAnswer, LargestProductSWToNE(grid));
            finalAnswer = Math.Max(finalAnswer, LargestProductSEToNW(grid));
            Console.WriteLine(finalAnswer);
        }
        
        static int LargestProductToRight(List<List<int>> grid)
        {
            int largestProduct = 0;
            //go through each row
            for (int row = 0; row < grid.Count; row++)
            {
                //go through each column on the specific row, but stop on the forth to last because we need 4 numbers to process
                for (int column = 0; column < grid[row].Count - gridOffset; column++)
                {
                    //given the current column on the current row, find the product of four numbers
                    //starting at the current column, then 3 to the right.
                    int product = grid[row][column] * grid[row][column + 1]
                        * grid[row][column + 2] * grid[row][column + 3];
                    largestProduct = FindLargestProductOfFour(product, largestProduct);
                }
            }
            return largestProduct;
        }

        static int LargestProductToLeft(List<List<int>> grid)
        {
            int largestProduct = 0;
            //go through each row
            for (int row = 0; row < grid.Count; row++)
            {
                //go through each column except the first 3 because we need a set of four numbers
                for (int column = 3; column < grid[row].Count; column++)
                {
                    //given the current spot in the grid, calculate the product of this place and back each three numbers
                    int product = grid[row][column] * grid[row][column - 1]
                        * grid[row][column - 2] * grid[row][column - 3];
                    //Console.WriteLine(product);
                    largestProduct = FindLargestProductOfFour(product, largestProduct);
                }
            }
            return largestProduct;
        }

        static int LargestProductUp(List<List<int>> grid)
        {
            int largestProduct = 0;
            //go through each row starting at row 4 because we need 4 numbers above us
            for (int row = 3; row < grid.Count - gridOffset; row++)
            {
                //go through each column
                for (int column = 0; column < grid[row].Count; column++)
                {
                    //find the product of each number from starting position up the three row in the current column
                    int product = grid[row][column] * grid[row - 1][column] *
                        grid[row - 2][column] * grid[row - 3][column];
                    //Console.WriteLine(product);
                    largestProduct = FindLargestProductOfFour(product, largestProduct);
                }
            }
            return largestProduct;
        }

        static int LargestProductDown(List<List<int>> grid)
        {
            int largestProduct = 0;
            //go through each row, except for the last four because we need a set of four numbers in a column
            for (int row = 0; row < grid.Count - gridOffset; row++)
            {
                //go through each column
                for (int column = 0; column < grid[row].Count; column++)
                {
                    //find the product of the four numbers from your current column down three rows
                    int product = grid[row][column] * grid[row + 1][column]
                        * grid[row + 2][column] * grid[row + 3][column];
                    //Console.WriteLine(product);
                    largestProduct = FindLargestProductOfFour(product, largestProduct);
                }
            }
            return largestProduct;
        }

        static int LargestProductSWToNE(List<List<int>> grid)
        {
            int largestProduct = 0;
            //go through each row except the first three since we need four numbers
            for (int row = 3; row < grid.Count; row++)
            {
                //go through each column except the last three since we need four numbers
                for (int column = 0; column < grid.Count - gridOffset; column++)
                {
                    //calculate the product of the current spot then subtract 1 from row to go up, and add 1 to column to go right
                    int product = grid[row][column] * grid[row - 1][column + 1]
                        * grid[row - 2][column + 2] * grid[row - 3][column + 3];
                    largestProduct = FindLargestProductOfFour(product, largestProduct);
                }
            }
            return largestProduct;
        }

        static int LargestProductSEToNW(List<List<int>> grid)
        {
            int largestProduct = 0;
            //go through each row except the first three because we need a product of four numbers
            for (int row = 3; row < grid.Count; row++)
            {
                //go through each column except the first three because we need four numbers to process
                for (int column = 3; column < grid[row].Count - gridOffset; column++)
                {
                    //calculate the product of the current spot on the grid, 
                    //then subtract 1 from row to go up and subract 1 from column to go left
                    int product = grid[row][column] * grid[row - 1][column - 1]
                        * grid[row - 2][column - 2] * grid[row - 3][column - 3];
                    largestProduct = FindLargestProductOfFour(product, largestProduct);
                }
            }
            return largestProduct;
        }

        static int FindLargestProductOfFour(int product, int largestProduct)
        {
            if (product > largestProduct)
            {
                largestProduct = product;
            }
            return largestProduct;
        }
        static bool IsZeroProduct(List<List<int>> grid, int row, int column)
        {
            //make sure the value is not zero, if it is return 0
            return grid[row][column] == 0;
        }
    }
}
