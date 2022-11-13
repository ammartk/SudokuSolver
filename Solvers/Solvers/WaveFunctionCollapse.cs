using SudokuMain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solvers.Solvers
{
    public class WaveFunctionCollapse : ISudokuSolver
    {
        public ISudoku Sudoku { get; set; }

        public void Solve()
        {
            throw new NotImplementedException();
        }
    }
}
