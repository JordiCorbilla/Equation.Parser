using System;
using Equation.Parser.Library;

namespace Equation.Parser.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EquationParser.Solve("(7 * 5 + 7 + (6 * 5) + 3 + 5) + 4 * 2 + ((5 + 2) + 5 * (6 + 7 + 4 * 8 * 6) + (8 * 4) + 5 * (2 + 5 * 8 + 6 + 2 * 8))"));
        }
    }
}
