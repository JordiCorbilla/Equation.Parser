//MIT License

//Copyright (c) 2020-2021 Jordi Corbilla

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System.Collections.Generic;

namespace Equation.Parser.Library
{
    public class EquationParser
    {
        private readonly Dictionary<string, double> _equationsSolutionCache;
        private readonly Dictionary<string, double> _operationCache;
        public static double Solve(string equation)
        {
            return new EquationParser().ParseEquation(equation);
        }

        public EquationParser()
        {
            _equationsSolutionCache = new Dictionary<string, double>();
            _operationCache = new Dictionary<string, double>();
        }

        public double ParseEquation(string equation)
        {
            var resolve = "";
            var start = false;
            var processing = equation;
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
                                var subEquation = resolve.Replace(")", "");
                                if (!_equationsSolutionCache.ContainsKey(subEquation))
                                {
                                    var num = ComplexSolver(subEquation);
                                    _equationsSolutionCache.Add(subEquation, num);
                                }

                                resolve = "";
                                break;
                            }
                    }
                }

                foreach (var (key, value) in _equationsSolutionCache)
                {
                    var replace = $"({key})";
                    processing = processing.Replace(replace, value.ToString());
                }

                _equationsSolutionCache.Clear();
            }

            return ComplexSolver(processing);
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

        public double ComplexSolver(string equation)
        {
            //1 + 2 * 3 + 4 * 5 + 6
            //1 * 2 + 3
            var resolve = equation;

            while (resolve.Contains("*")|| resolve.Contains("/"))
            {
                var numbers = resolve.Split(" ");
                double left = -1;
                double right = -1;
                var mulFound = false;
                var divFound = false;

                foreach (var t in numbers)
                {
                    if (mulFound && right == -1 && t != "+" && t != "*" && t != "-" && t != "/")
                    {
                        right = double.Parse(t);

                        if (!_operationCache.ContainsKey($"{left} * {right}"))
                        {
                            double calc = left * right;
                            _operationCache.Add($"{left} * {right}", calc);
                        }
                    }

                    if (divFound && right == -1 && t != "+" && t != "*" && t != "-" && t != "/")
                    {
                        right = double.Parse(t);

                        if (!_operationCache.ContainsKey($"{left} / {right}"))
                        {
                            double calc = left / right;
                            _operationCache.Add($"{left} / {right}", calc);
                        }
                    }

                    if (left == -1 && t != "+" && t != "*" && t != "-" && t != "/")
                        left = double.Parse(t);

                    switch (t)
                    {
                        case "+":
                        case "-":
                            left = -1;
                            break;
                        case "*":
                            mulFound = true;
                            break;
                        case "/":
                            divFound = true;
                            break;
                    }
                }

                foreach (var (key, value) in _operationCache)
                {
                    var replace = $"{key}";
                    resolve = resolve.Replace(replace, value.ToString());
                    if (!resolve.Contains("*") && !resolve.Contains("/"))
                        break;
                }

                _operationCache.Clear();
            }

            return SimpleSolver(resolve);
        }
    }
}
