using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace к1.Classes
{
    public class Formula
    {
        char[] priority_operations = new char[] { '^', '/', '*', '-', '+' };
        public string formula = "";
        public string Error { get; private set; }
        private bool IsFormulaCorrect { get; set; }
        public Formula(string formula) 
        {
            this.formula = formula;
            Error = ChechFormula(this.formula);
            
        }
        public string ChechFormula(string formula)
        {
            string error = "";
            return error;
        }
        public double Result() 
        {
            return Simple_formula(formula);
        }
        public double Simple_formula(string formula)
        {
            var operations = new List<char>();
            var numbers = new List<double>();

            numbers =
                formula
                .Replace("-","+-")
                .Split(new char[] { '^', '/', '*', '+' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Convert.ToDouble(n))
                .ToList<double>();
            operations =
                formula
                .Split(new string[] { 
                    ",",
                    "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                    "-1", "-2", "-3", "-4", "-5", "-6", "-7", "-8", "-9", "-0"
                }, StringSplitOptions.RemoveEmptyEntries)
                .Select(op => op[0])
                .ToList<char>();
            foreach (var operation in priority_operations)
            {
                for (int i = operations.Count() - 1; i >= 0; i--)
                {
                    if (operations[i] == operation)
                    {
                        numbers[i] = Operation(operation, numbers[i], numbers[i + 1]);
                        numbers.RemoveAt(i + 1);
                        operations.RemoveAt(i);
                    }
                }
            }
            return numbers[0];
        }
        public double Operation(char operation, double firstNumber, double secondNumber)
        {
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    break;
                case '^':
                    result = Math.Pow(firstNumber, secondNumber);
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
