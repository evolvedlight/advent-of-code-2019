using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day5
{
    public class IntCodeComputer
    {
        public static int Run(int[] program, int input) {
            var position = 0;
            int output = 0;
            while (program[position] != 99)
            {
                var instruction = program[position];
                int opCode = instruction % 100;
                var c = (instruction / 100) % 10;
                var b = (instruction / 1000) % 10;
                var a = (instruction / 10000) % 10;
                if (a == 1)
                {

                }
                switch (opCode)
                {
                    case 1:
                        program[program[position + 3]] = GetParam(c, position + 1, program) + GetParam(b, position + 2, program);
                        position += 4;
                        continue;
                    case 2:
                        program[program[position + 3]] = GetParam(c, position + 1, program) * GetParam(b, position + 2, program);
                        position += 4;
                        continue;
                    case 3:
                        program[program[position + 1]] = input;
                        position += 2;
                        continue;
                    case 4:
                        output = GetParam(c, position + 1, program);
                        position += 2;
                        continue;
                    case 5:
                        if (GetParam(c, position + 1, program) != 0)
                        {
                            position = GetParam(b, position + 2, program);
                        } 
                        else
                        {
                            position += 3;
                        }
                        continue;
                    case 6:
                        if (GetParam(c, position + 1, program) == 0)
                        {
                            position = GetParam(b, position + 2, program);
                        }
                        else
                        {
                            position += 3;
                        }
                        continue;
                    case 7:
                        if (GetParam(c, position + 1, program) < GetParam(b, position + 2, program))
                        {
                            program[program[position + 3]] = 1;
                        } 
                        else
                        {
                            program[program[position + 3]] = 0;
                        }
                        position += 4;
                        continue;
                    case 8:
                        if (GetParam(c, position + 1, program) == GetParam(b, position + 2, program))
                        {
                            program[program[position + 3]] = 1;
                        }
                        else
                        {
                            program[program[position + 3]] = 0;
                        }
                        position += 4;
                        continue;
                    default:
                        throw new ArgumentException($"cannot be opcode {opCode}");
                }
            }
            return output;
        }

        public static int GetParam(int param, int position, int[] program)
        {
            return param == 0 ? program[program[position]] : program[position];
        }


        public static int Assign2(int[] initialValues)
        {
            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    int[] values = (int[])initialValues.Clone();
                    
                    values[1] = noun;
                    values[2] = verb;

                    int count = 0;

                    while (values[count] != 99)
                    {
                        int opcode = values[count];

                        if (opcode == 1)
                        {
                            values[values[count + 3]] = values[values[count + 2]] + values[values[count + 1]];
                        }
                        else if (opcode == 2)
                        {
                            values[values[count + 3]] = values[values[count + 2]] * values[values[count + 1]];
                        }

                        count += 4;

                    }

                    if (values[0] == 19690720)
                    {
                        Console.WriteLine(100 * noun + verb);

                        return 100 * noun + verb;
                    }
                }
            }
            throw new Exception();
        }
    }
}
