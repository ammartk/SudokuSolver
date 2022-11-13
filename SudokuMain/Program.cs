using Solvers;
using Solvers.Sudoku;
using SudokuMain.Interfaces;

ISudokuSolver solver = SolverFactory.GetSolver(SolverType.WaveFunctionCollapse);
solver.Solve();