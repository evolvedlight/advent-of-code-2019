using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day2
{
    public class IntCodeComputer
    {
        public static int[] Run(int[] input) {
            var position = 0;

            while (input[position] != 99)
            {
                switch (input[position])
                {
                    case 1:
                        input[input[position + 3]] = input[input[position + 1]] + input[input[position + 2]];
                        position += 4;
                        continue;
                    case 2:
                        input[input[position + 3]] = input[input[position + 1]] * input[input[position + 2]];
                        position += 4;
                        continue;
                }
            }
            return input;
        }
    }
}
