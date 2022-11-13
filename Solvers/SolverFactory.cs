using Solvers.Solvers;
using SudokuMain.Interfaces;

namespace Solvers
{
    public enum SolverType
    {
        WaveFunctionCollapse
    }
    public static class SolverFactory
    {
        
        public static ISudokuSolver GetSolver(SolverType type)
        {
            switch (type)
            {
                case SolverType.WaveFunctionCollapse:
                    return new WaveFunctionCollapse();
                default:
                    return new WaveFunctionCollapse();
            }
        }
    }
}