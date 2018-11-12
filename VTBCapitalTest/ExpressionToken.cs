using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VTBCapitalTest
{
    public class ExpressionToken
    {
        public ExpressionToken()
        {
        }

        public static void Tokenize(string expression)
        {
            var expressionStack = new Stack<string>();

            var expToEvaluate = expression.Split(" ");

            for (int i = 0; i < expToEvaluate.Length; i++)
            {
                var expChar = expToEvaluate[i];

                if(expChar.Substring(0, 1).Equals("("))
                {
                    expressionStack.Push(expChar.Substring(0, 1));
                }
                if (expChar.Substring(expChar.Length - 1, 1).Equals(")"))
                {
                    expressionStack.Push(expChar.Substring(expChar.Length - 1, 1));
                }
                if (Regex.IsMatch(expChar, "^([0-9]+)(\\.[0-9]+)?$"))
                {

                }
            }
        }
    }
}
