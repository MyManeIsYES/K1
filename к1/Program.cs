using System;

namespace к1
{
    internal class Program
    {
        static string ChechFormula(string formula) 
        {
            string error = "";
            return error;
        }
        static List<double> f1(string formula) 
        {
            var mas=new List<double>();
            foreach (var c in formula.Split(new char[] { '(', ')', '^', '*', '/', '+', '-' }, StringSplitOptions.RemoveEmptyEntries)) 
            {
                mas.Add(Convert.ToDouble(c));
            }
            return mas;
        }
        static double? Simple_formula(string formula) 
        {
            double? result = null;
            var operations = new List<char>();
            var numbers=new List<double>();
            numbers = 
                formula
                .Split(new char[] { '^', '*', '/', '+', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Convert.ToDouble(n))
                .ToList<double>();
            operations = 
                formula
                .Split(new char[] { ',', '1', '2', '3', '4', '5', '6', '7', '8', '9','0' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(op => op[0])
                .ToList<char>();
            var priority_operations = new char[] { '^', '/', '*', '-', '+' };



            return result;
        }
        static double? Operation(char operation,double firstNumber, double secondNumber) 
        {
            double? result = null;
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
                    if (secondNumber!=0) 
                    {
                        result = firstNumber / secondNumber;
                    }
                    break;
                case '^':
                    result =Math.Pow(firstNumber,  secondNumber);
                    break;
                default:
                    break;
            }
            return result;
        }
        static void Main(string[] args)
        {
            //23,32/(3,23)*((123^32+1)/(2))+1
            //23,32/3,23*(123^32+1)/2+1
            string formula ="1+3^4,4*32-4/54";
            Console.WriteLine(Simple_formula(formula));
            //formula = Console.ReadLine().Trim();
            /*foreach(var s in f1(formula)) 
            {
                Console.WriteLine(s);
            }*/
        }
    }
}