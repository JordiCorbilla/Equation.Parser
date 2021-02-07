# Equation.Parser

.net 5 Simple Equation parser using the following rules

- Parsing multiple pharentesis 4 + (5 - 4)
- Multiplication and division are performed before addition or substraction 4 + (9 * 5) + (4 / 2)
  - Given the following equation: `(54 * 210 + 6) / 2 + 4 * 2`, the process is as follows:
  - (54 * 210 + 6) / 2 + 4 * 2 = (11340 + 6) / 2 + 4 * 2
  - 11346 / 2 + 4 * 2 = 5673 + 4 * 2
  - 5673 + 8 = 5681
  - Multiplication and division operations happen before any addition or substraction, and actions within pharentesis take prevalence.


## Sample test cases

There are several test cases that cover common scenarions that can be used with this library:

```c#
[TestCase("7 + 5 + (6 * 4 + (7 + 7 + 9) + (5 + 7) + 9) + (9 * 7 + 6 * 8)", 191)]
[TestCase("7 + (5 + (9 + 4) * (8 * 8 + 2 + 6 + 8) * (5 * 5) * 5 * 9)", 1170012)]
[TestCase("5 * 7 + 6 + (7 * 4 + (7 + 2 + 8 + 5) * 8 * 6 * (3 * 4 * 9 * 5)) + 9", 570318)]
[TestCase("(7 * 5 + 7 + (6 * 5) + 3 + 5) + 4 * 2 + ((5 + 2) + 5 * (6 + 7 + 4 * 8 * 6) + (8 * 4) + 5 * (2 + 5 * 8 + 6 + 2 * 8))", 1472)]
[TestCase("3 / 2 / 2 * 6 * 6 - 9", 18)]
[TestCase("(1 - 3) / (6 - 7) * 100", 200)]
```
