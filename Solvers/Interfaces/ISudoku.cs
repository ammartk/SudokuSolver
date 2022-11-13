using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMain.Interfaces
{
    public enum SudokuItem
    {
        ONE = 1,        // 000000001
        TWO = 2,        // 000000010 
        THREE = 4,      // 000000100
        FOUR = 8,       // 000001000
        FIVE = 16,      // 000010000
        SIX = 32,       // 000100000
        SEVEN = 64,     // 001000000
        EIGHT = 128,    // 010000000
        NINE = 256,     // 100000000
    }
    public interface ISudoku
    {
        public bool ExistsInRow(int row, SudokuItem item);
        public bool ExistsInColumn(int col, SudokuItem item);
        public bool ExistsInBox(int box, SudokuItem item);
        public void SelectItem(int row, int col, SudokuItem item);
        public int GetItemAt(int row, int col);
        public int GetNumberOfDigits(int x, int y);
        public bool HasWon();
        public void DisplaySudoku();
    }
}
