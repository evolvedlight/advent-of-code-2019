using AdventOfCode.Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Test.Day4
{
    public class NumberGeneratorTest
    {
        private readonly ITestOutputHelper output;

        public NumberGeneratorTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(111111, true)]
        [InlineData(223450, false)]
        [InlineData(123789, false)]
        public void Examples(int number, bool expected)
        {
            Assert.Equal(expected, Password.Passes(number));
        }

        [Fact]
        public void Actual()
        {
            output.WriteLine($"Answer {Password.CalculateNumber(265275, 781584)}");
        }

        [Theory]
        [InlineData(112233, true)]
        [InlineData(123444, false)]
        [InlineData(111122, true)]
        [InlineData(111234, false)]
        [InlineData(111235, false)]
        [InlineData(111455, true)]
        [InlineData(112345, true)]
        [InlineData(112355, true)]
        public void Examples2(int number, bool expected)
        {
            Assert.Equal(expected, Password.Passes2(number));
        }

        [Fact]
        public void Actual2()
        {
            output.WriteLine($"Answer {Password.CalculateNumber2(265275, 781584)}");
        }
    }
}
