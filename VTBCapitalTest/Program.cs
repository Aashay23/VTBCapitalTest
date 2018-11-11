using System;
using System.Collections.Generic;
using System.Linq;

namespace VTBCapitalTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter expression to evaluate: ");
            var input = Console.ReadLine();
            var result = ExpressionEvaluator.Evaluate(input);
            Console.WriteLine("Expression result is: " + result);
        }
    }
}
