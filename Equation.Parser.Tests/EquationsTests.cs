using Equation.Parser.Library;
using NUnit.Framework;

namespace Equation.Parser.Tests
{
    [TestFixture]
    public class EquationsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("4 + 5", 9)]
        [TestCase("4 - 5", -1)]
        [TestCase("4 / 5", 0.8)]
        [TestCase("4 * 5", 20)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 3208)]
        [TestCase("(54 * 210 + 6) / 2 + 4 * 2", 5681)]
        public void TestEquationParsing(string equation, double result)
        {
            var solution = EquationParser.Solve(equation);
            Assert.AreEqual(result, solution);
        }
    }
}