# Equation.Parser

Simple Equation parser using the following rules

- Parsing multiple pharentesis 4 + (5 - 4)
- Multiplication and division are performed before addition or substraction 4 + (9 * 5) + (4 / 2)
  - Given the following equation: `(54 * 210 + 6) / 2 + 4 * 2`, the process is as follows:
  - (54 * 210 + 6) / 2 + 4 * 2 = (11340 + 6) / 2 + 4 * 2
  - 11346 / 2 + 4 * 2 = 5673 + 4 * 2
  - 5673 + 8 = 5681
  - Multiplication and division operations happen before any addition or substraction, and actions within pharentesis take prevalence.


