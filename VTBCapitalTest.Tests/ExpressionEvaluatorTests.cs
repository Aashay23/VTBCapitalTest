using System;
using FluentAssertions;
using Xunit;

namespace VTBCapitalTest.Tests
{
    public class ExpressionEvaluatorTest
    {
        [Fact]
        public void InValidInput()
        {
            Assert.Throws<Exception>(() => ExpressionEvaluator.Evaluate("(2+3"));
        }

        [Fact]
        public void ValidIntegerInput()
        {
            var result = ExpressionEvaluator.Evaluate("(2+3)");
            result.Should().Be(5);
        }
    }
}
