using SudokuMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Sudoku
{
    public class ConsoleSudoku : ISudoku
    {
        private int[,] grid = new int[9, 9];
        public ConsoleSudoku()
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    grid[i, j] = 511;
                }
            }
            SetupRandomSudokuState();
        }
        public void SetupRandomSudokuState()
        {
            for(int i = 0; i < 10; i++)
            {
                var Random = new Random();
                int x = Random.Next(9);
                int y = Random.Next(9);
                int value = Random.Next(9);
                SelectItem(x, y, (SudokuItem)(1 << value));
            }
        }
        public void DisplaySudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int digits = GetNumberOfDigits(i, j);
                    if(digits == 1)
                    {

                        for (int k = 0; k < 9; k++)
                        {
                            if ((grid[i, j] & (1 << k)) != 0)
                                Console.Write(k + 1 + " ");
                        }
                    }
                    else
                    {
                        Console.Write("-");
                    }
                    Console.Write("\t");
                }
                Console.WriteLine("");
            }
        }
        public void DisplaySudokuCustom()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if ((grid[i, j] & (1 << k)) != 0)
                            Console.Write(k + 1 + " ");
                    }
                    Console.Write("\t");
                }
                Console.WriteLine("");
            }
        }
        public bool ExistsInBox(int box, SudokuItem item)
        {
            bool exists = false;
            int startingCol = (box % 3) * 3;
            int startingRow = (box / 3) * 3;
            for(int i = startingRow; i < startingRow + 3; i++)
            {
                for(int j = startingCol; j < startingCol + 3; j++)
                {
                    if (grid[i, j] == (int)item)
                        exists = true;
                }
            }
            return exists;
        }

        public bool ExistsInColumn(int col, SudokuItem item)
        {
            bool exists = false;
            for(int i = 0; i < 9; i++)
            {
                if (grid[i, col] == (int)item)
                    exists = true;
            }
            return exists;
        }
        public int GetNumberOfDigits(int x, int y)
        {
            int count = 0;
            int value = GetItemAt(x, y);
            for (int i = 0; i < 9; i++)
            {
                if ((value & (1 << i)) != 0)
                    count++;
            }
            return count;
        }
        public bool ExistsInRow(int row, SudokuItem item)
        {
            bool exists = false;
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == (int)item)
                    exists = true;
            }
            return exists;
        }

        public int GetItemAt(int row, int col)
        {
            return grid[row, col];
        }

        public bool HasWon()
        {
            throw new NotImplementedException();
        }

        public void SelectItem(int row, int col, SudokuItem item)
        {
            if((grid[row, col] & (int) item) != 0)
                grid[row, col] = (int)item;
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            
            for (int i = 0; i < 9; i++)
            {

                if (i != row)
                {
                    int numberOfDigits = GetNumberOfDigits(i, col);
                    if(numberOfDigits != 1)
                        grid[i, col] &= ~((int)item);
                    if (numberOfDigits != 1 && GetNumberOfDigits(i, col) == 1)
                    {
                        list.Add(new Tuple<int, int>(i, col));
                    }
                }

                if (i != col)
                {
                    int numberOfDigits = GetNumberOfDigits(row, i);
                    if (numberOfDigits != 1)
                        grid[row, i] &= ~((int)item);
                    if (numberOfDigits != 1 && GetNumberOfDigits(row, i) == 1)
                    {
                        list.Add(new Tuple<int, int>(row, i));
                    }
                }
                
            }
            int startingCol = (col / 3) * 3;
            int startingRow = (row / 3) * 3;
            for (int i = startingRow; i < startingRow + 3; i++)
            {
                for (int j = startingCol; j < startingCol + 3; j++)
                {
                    if(i != row && j != col)
                    {
                        int numberOfDigits = GetNumberOfDigits(i, j);
                        if (numberOfDigits != 1)
                            grid[i,j] &= ~((int)item);
                        if (numberOfDigits != 1 && GetNumberOfDigits(i, j) == 1)
                        {
                            list.Add(new Tuple<int, int>(i, j));
                        }
                    }
                }
            }
            foreach(var val in list)
            {
                SelectItem(val.Item1, val.Item2, (SudokuItem)grid[val.Item1, val.Item2]);
            }
        }
    }
}
