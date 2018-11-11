using FluentAssertions;
using Xunit;

namespace VTBCapitalTest.Tests
{
    public class ExpressionEvaluatorTest
    {
        [Fact]
        public void InValidInput()
        {
            try
            {
                var result = ExpressionEvaluator.Evaluate("(2+3");
            }
            catch (System.Exception ex)
            {
                ex.Should().Be("Input expression is missing closing paranthesis");
            }

        }

        [Fact]
        public void ValidIntegerInput()
        {
            var result = ExpressionEvaluator.Evaluate("(2+3)");
            result.Should().Be(5);
        }
    }
}
