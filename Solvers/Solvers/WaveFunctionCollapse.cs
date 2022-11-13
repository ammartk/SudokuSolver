using Solvers.Sudoku;
using SudokuMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Solvers
{
    public class WaveFunctionCollapse : ISudokuSolver
    {
        public ISudoku Sudoku { get; set; }

        public WaveFunctionCollapse()
        {
            Sudoku = new ConsoleSudoku();
        }
        public void Solve()
        {
            while (FindAndSelectItem())
            {
                Sudoku.DisplaySudoku();
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
            Sudoku.DisplaySudoku();
        }

        public bool FindAndSelectItem()
        {
            int x = -1, y = -1;
            int minimumNumberOfDigits = 10;
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    int value = Sudoku.GetNumberOfDigits(i, j);
                    if(minimumNumberOfDigits > value && value != 1)
                    {
                        x = i;
                        y = j;
                        minimumNumberOfDigits = value;
                    }
                }
            }
            if(x != -1 && y != -1)
            {
                int value = Sudoku.GetItemAt(x, y);
                List<SudokuItem> items = new List<SudokuItem>();
                for(int i = 0; i < 9; i++)
                {
                    SudokuItem item = (SudokuItem)(1 << i);
                    if((value & (int)item)!= 0)
                        items.Add(item);
                }
                var random = new Random();
                Sudoku.SelectItem(x, y, items[random.Next(items.Count)]);
                return true;
            }
            return false;
        }
    }
}
