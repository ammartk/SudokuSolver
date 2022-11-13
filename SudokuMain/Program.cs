using Solvers;
using Solvers.Sudoku;
using SudokuMain.Interfaces;

ISudoku sudoku = new ConsoleSudoku();
sudoku.SelectItem(0, 0, SudokuItem.TWO);
sudoku.DisplaySudoku();