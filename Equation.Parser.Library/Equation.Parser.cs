using System.Collections.Generic;

namespace Equation.Parser.Library
{
    public class EquationParser
    {
        private readonly Dictionary<string, double> _solutions;
        public static double Solve(string equation)
        {
            return new EquationParser().ParseEquation(equation);
        }

        public EquationParser()
        {
            _solutions = new Dictionary<string, double>();
        }

        public double ParseEquation(string s)
        {
            var resolve = "";
            var start = false;
            var processing = s;
            while (processing.Contains("("))
            {
                foreach (var digit in processing)
                {
                    if (start)
                    {
                        resolve += digit;
                    }

                    switch (digit)
                    {
                        case '(' when !start:
                            start = true;
                            break;
                        case '(' when true:
                            resolve = "";
                            break;
                        case ')' when start:
                            {
                                start = false;
                                var equation = resolve.Replace(")", "");
                                var num = SimpleSolver(equation);
                                if (!_solutions.ContainsKey(equation))
                                    _solutions.Add(equation, num);
                                resolve = "";
                                break;
                            }
                    }
                }

                foreach (var (key, value) in _solutions)
                {
                    var replace = $"({key})";
                    processing = processing.Replace(replace, value.ToString());
                }

                _solutions.Clear();
            }

            return SimpleSolver(processing);
        }

        public double SimpleSolver(string equation)
        {
            var numbers = equation.Split(" ");
            double accumulator = double.Parse(numbers[0]);
            bool sum = false;
            bool mul = false;
            bool sub = false;
            bool div = false;
            for (var i = 1; i < numbers.Length; i++)
            {
                if (mul)
                {
                    accumulator *= double.Parse(numbers[i]);
                    mul = false;
                }

                if (div)
                {
                    accumulator /= double.Parse(numbers[i]);
                    div = false;
                }

                if (sum)
                {
                    accumulator += double.Parse(numbers[i]);
                    sum = false;
                }

                if (sub)
                {
                    accumulator -= double.Parse(numbers[i]);
                    sub = false;
                }

                switch (numbers[i])
                {
                    case "*":
                        mul = true;
                        break;
                    case "+":
                        sum = true;
                        break;
                    case "-":
                        sub = true;
                        break;
                    case "/":
                        div = true;
                        break;
                }
            }

            return accumulator;
        }
    }
}
