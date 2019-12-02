using AdventOfCode.Day2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode.Test.Day2
{
    public class IntCodeComputerTest
    {
        private readonly ITestOutputHelper output;

        public IntCodeComputerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 0, 0, 99 }, new int[] { 2, 0, 0, 0, 99 })]
        [InlineData(new int[] { 2, 3, 0, 3, 99 }, new int[] { 2, 3, 0, 6, 99 })]
        [InlineData(new int[] { 2, 4, 4, 5, 99, 0 }, new int[] { 2, 4, 4, 5, 99, 9801 })]
        [InlineData(new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 })]
        public void Example1(int[] input, int[] output)
        {
            Assert.Equal(output, IntCodeComputer.Run(input));
        }

        [Fact]
        public void Exercise1()
        {
            var input = new int[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 5, 19, 23, 1, 13, 23, 27, 1, 6, 27, 31, 2, 31, 13, 35, 1, 9, 35, 39, 2, 39, 13, 43, 1, 43, 10, 47, 1, 47, 13, 51, 2, 13, 51, 55, 1, 55, 9, 59, 1, 59, 5, 63, 1, 6, 63, 67, 1, 13, 67, 71, 2, 71, 10, 75, 1, 6, 75, 79, 1, 79, 10, 83, 1, 5, 83, 87, 2, 10, 87, 91, 1, 6, 91, 95, 1, 9, 95, 99, 1, 99, 9, 103, 2, 103, 10, 107, 1, 5, 107, 111, 1, 9, 111, 115, 2, 13, 115, 119, 1, 119, 10, 123, 1, 123, 10, 127, 2, 127, 10, 131, 1, 5, 131, 135, 1, 10, 135, 139, 1, 139, 2, 143, 1, 6, 143, 0, 99, 2, 14, 0, 0 };
            input[1] = 12;
            input[2] = 2;
            output.WriteLine(string.Join(", ", IntCodeComputer.Run(input)));
        }

        [Fact]
        public void Exercise2()
        {
            // Brute force it
            for (var noun = 0; noun < 100; noun++)
            { 
                for (var verb = 0; verb < 100; verb++)
                {
                    var input = new int[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 5, 19, 23, 1, 13, 23, 27, 1, 6, 27, 31, 2, 31, 13, 35, 1, 9, 35, 39, 2, 39, 13, 43, 1, 43, 10, 47, 1, 47, 13, 51, 2, 13, 51, 55, 1, 55, 9, 59, 1, 59, 5, 63, 1, 6, 63, 67, 1, 13, 67, 71, 2, 71, 10, 75, 1, 6, 75, 79, 1, 79, 10, 83, 1, 5, 83, 87, 2, 10, 87, 91, 1, 6, 91, 95, 1, 9, 95, 99, 1, 99, 9, 103, 2, 103, 10, 107, 1, 5, 107, 111, 1, 9, 111, 115, 2, 13, 115, 119, 1, 119, 10, 123, 1, 123, 10, 127, 2, 127, 10, 131, 1, 5, 131, 135, 1, 10, 135, 139, 1, 139, 2, 143, 1, 6, 143, 0, 99, 2, 14, 0, 0 };
                    input[1] = noun;
                    input[2] = verb;

                    var memoryAtEnd = IntCodeComputer.Run(input);
                    if (memoryAtEnd[0] == 19690720)
                    {
                        output.WriteLine($"Found it: noun: {noun}. Verb: {verb}. Answer {100 * noun + verb}");
                    }
                }
            }
        }
    }
}
