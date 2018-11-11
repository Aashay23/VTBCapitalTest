using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VTBCapitalTest
{
    public class ExpressionEvaluator
    {
        public static double Evaluate(string expInput)
        {
            var cleanExpInput = expInput.Replace(" ", "");

            var openBraceCount = cleanExpInput.Count(ex => ex == '(');
            var closedBraceCount = cleanExpInput.Count(ex => ex == ')');

            if (openBraceCount != closedBraceCount) throw new Exception("Input expression is missing closing paranthesis");

            return ConvertToPostFix(cleanExpInput);
        }

        private static double ConvertToPostFix(string inputExp)
        {
            var infixExp = inputExp.ToCharArray();
            var expressionStack = new Stack<char>();
            var postfixExp = new StringBuilder();

            for (int i = 0; i < infixExp.Length; i++)
            {
                var expChar = infixExp[i];
                if (Char.IsNumber(expChar))
                {
                    postfixExp.Append(expChar);
                }
                else if (expChar.Equals('('))
                {
                    expressionStack.Push(expChar);
                }
                else if (expChar.Equals(')'))
                {
                    while (expressionStack.Count > 0 && !expressionStack.Peek().Equals('('))
                    {
                        postfixExp.Append(expressionStack.Pop());
                    }
                    expressionStack.Pop();
                }
                else
                {
                    if (expChar.IsOperator())
                    {
                        expressionStack.Push(expChar);
                    }
                    else
                    {
                        throw new Exception("Not an operator");
                    }
                }
            }

            while (expressionStack.Count > 0)
            {
                postfixExp.Append(expressionStack.Pop());
            }

            return EvaluatePostFix(postfixExp.ToString());
        }

        private static double EvaluatePostFix(string postfixInput)
        {
            var postfixExp = postfixInput.ToCharArray();
            var evaluationStack = new Stack<double>();

            for (int i = 0; i < postfixExp.Length; i++)
            {
                var expChar = postfixExp[i];
                if (Char.IsNumber(expChar))
                {
                    var operand = Char.GetNumericValue(expChar);
                    evaluationStack.Push(operand);
                }
                else
                {
                    var firstOperand = evaluationStack.Pop();
                    var secondOperand = evaluationStack.Pop();

                    var operationResult = OperationEvaluator.Evaluate(expChar, firstOperand, secondOperand);

                    evaluationStack.Push(operationResult);
                }
            }

            if (evaluationStack.Count == 1)
            {
               return evaluationStack.Pop();
            }
            else
            {
                throw new Exception("Error occured");
            }
        }


    }
}
