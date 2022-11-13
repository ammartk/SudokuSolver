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
        }
        public void DisplaySudoku()
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    for(int k = 0; k < 9; k++)
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

        public bool HasWon()
        {
            throw new NotImplementedException();
        }

        public void SelectItem(int row, int col, SudokuItem item)
        {
            if((grid[row, col] & (int) item) != 0)
                grid[row, col] = (int)item;
            for (int i = 0; i < 9; i++)
            {
                if (i != row)
                    grid[i, col] &= ~((int)item);
                if (i != col)
                    grid[row, i] &= ~((int)item);
            }
            int startingCol = (col / 3) * 3;
            int startingRow = (row / 3) * 3;
            for (int i = startingRow; i < startingRow + 3; i++)
            {
                for (int j = startingCol; j < startingCol + 3; j++)
                {
                    if(i != row && j != col)
                        grid[i,j] &= ~((int)item);
                }
            }
        }
    }
}
