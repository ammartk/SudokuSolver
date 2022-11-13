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
        public int[,] _grid { get {
                _grid ??= new int[9, 9];
                return _grid;
            }
            set { _grid = value; }
        }
        public bool ExistsInRow(int row, SudokuItem item);
        public bool ExistsInColumn(int col, SudokuItem item);
        public bool ExistsInBox(int box, SudokuItem item);
    }
}
