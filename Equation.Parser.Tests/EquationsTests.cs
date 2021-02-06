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
        [TestCase("(9 * 6 * 5) + (7 + 2 + 4 * 7 + 8) * (3 * 6) + (9 + 7 + 3 * 7 + 4)", 1121)]
        [TestCase("4 + ((5 + 8 + 3) + 7 + 4 + 9 * 3) + 5 + 2 + 6", 71)]
        [TestCase("2 + 6 + 5 * (6 + (9 + 8 * 4 * 5 * 4) + 6 + 9) * (7 * 4 + 6 + 4 + 7) * 6", 904508)]
        [TestCase("((9 + 8 * 5 * 9 * 9 * 2) * 5) + 8 * 9", 32517)]
        [TestCase("9 * 7 * 5 + (8 + 4 + 3 * 5 + 2 * 6)", 354)]
        [TestCase("8 * 7 * 7 * 9 + (6 * 3 + 8 * 7 * 8 * (2 * 9))", 11610)]
        [TestCase("7 * (5 + (7 + 3 + 2 * 4 + 8)) * 8 * 3", 5208)]
        [TestCase("6 * (8 + 3) + ((7 * 9 + 7 * 8 * 9 * 8) + 3 * (9 * 7 + 3 * 7) + 3 * 6 * 7)", 4539)]
        [TestCase("7 + 6 * 7 * 4 * (4 * 2) + ((7 + 5 * 9 + 5 + 9) + 7 * 4 * 4 + 8)", 1537)]
        [TestCase("5 + 6 + 4 + 9 * 2 * (9 * 4 + (7 + 6 * 7) + (2 * 8 + 9 + 6) * 2 + 8)", 2805)]
        [TestCase("6 + 6 * 8 + 9 + (3 + 2 + 7 * 7 * (7 * 7 * 3 + 3 + 5 * 6) + 9)", 8897)]
        [TestCase("3 + 2 + 2 + 6 + 6 + 9", 28)]
        [TestCase("8 * 3 * (7 * 6 + 6 * 9 * 9 * 9)", 105984)]
        [TestCase("7 + 5 + (6 * 4 + (7 + 7 + 9) + (5 + 7) + 9) + (9 * 7 + 6 * 8)", 191)]
        [TestCase("7 + (5 + (9 + 4) * (8 * 8 + 2 + 6 + 8) * (5 * 5) * 5 * 9)", 1170012)]
        [TestCase("5 * 7 + 6 + (7 * 4 + (7 + 2 + 8 + 5) * 8 * 6 * (3 * 4 * 9 * 5)) + 9", 570318)]
        [TestCase("(7 * 5 + 7 + (6 * 5) + 3 + 5) + 4 * 2 + ((5 + 2) + 5 * (6 + 7 + 4 * 8 * 6) + (8 * 4) + 5 * (2 + 5 * 8 + 6 + 2 * 8))", 1472)]
        [TestCase("3 / 2 / 2 * 6 * 6 - 9", 18)]
        [TestCase("(1 - 3) / (6 - 7) * 100", 200)]
        public void TestEquationParsing(string equation, double result)
        {
            var solution = EquationParser.Solve(equation);
            Assert.AreEqual(result, solution);
        }
    }
}