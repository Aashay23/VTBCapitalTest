using System;
namespace VTBCapitalTest
{
    public static class OperationEvaluator
    {
        public static bool IsOperator(this char expressionChar)
        {
            switch (expressionChar)
            {
                case '+':
                case '-':
                case '/':
                case '*':
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsNumeric(this char expressionChar)
        {
            return Char.IsDigit(expressionChar);
        }

        public static double Evaluate(char expChar, double firstOperand, double secondOperand)
        {
            switch (expChar)
            {
                case '+':
                    return (firstOperand + secondOperand);
                case '-':
                    return (firstOperand - secondOperand);
                case '*':
                    return (firstOperand * secondOperand);
                case '/':
                    if (secondOperand == 0.0) return 0.0;
                    return (firstOperand / secondOperand);
                default:
                    return 0;
            }
        }
    }
}
