﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMain.Interfaces
{
    public interface ISudokuSolver
    {
        public ISudoku Sudoku { get; set; }
        public void Solve();
    }
}
