using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class IntCodeComputer
    {
        private readonly List<int> _program;
        private int _position;
        private List<int> _outputs = new List<int>();
        private List<int> _inputs = new List<int>();

        public IntCodeComputer(List<int> program)
        {
            _program = program;
            _position = 0;
        }

        public List<int> Run(List<int> inputs)
        {
            _inputs.AddRange(inputs);
            while (_program[_position] != 99)
            {
                RunStep();
            }
            return _outputs;
        }

        public void AddInput(int input)
        {
            _inputs.Add(input);
        }

        public (int output, bool isFinished99) RunUntilAnOutputOrExit(int input)
        {
            _inputs.Add(input);
            var prevOutputNumber = _outputs.Count();
            while (_program[_position] != 99 && _outputs.Count == prevOutputNumber)
            {
                RunStep();
            }
            if (_program[_position] == 99)
            {
                return (_outputs.Last(), true);
            }
            else
            {
                return (_outputs.Last(), false);
            }
        }

        public void RunStep()
        {
            var instruction = _program[_position];
            int opCode = instruction % 100;
            var c = (instruction / 100) % 10;
            var b = (instruction / 1000) % 10;
            var a = (instruction / 10000) % 10;

            switch (opCode)
            {
                case 1:
                    _program[_program[_position + 3]] = GetParam(c, _position + 1) + GetParam(b, _position + 2);
                    _position += 4;
                    return;
                case 2:
                    _program[_program[_position + 3]] = GetParam(c, _position + 1) * GetParam(b, _position + 2);
                    _position += 4;
                    return;
                case 3:
                    _program[_program[_position + 1]] = _inputs[0];
                    _inputs = _inputs.Skip(1).ToList();
                    _position += 2;
                    return;
                case 4:
                    _outputs.Add(GetParam(c, _position + 1));
                    _position += 2;
                    return;
                case 5:
                    if (GetParam(c, _position + 1) != 0)
                    {
                        _position = GetParam(b, _position + 2);
                    }
                    else
                    {
                        _position += 3;
                    }
                    return;
                case 6:
                    if (GetParam(c, _position + 1) == 0)
                    {
                        _position = GetParam(b, _position + 2);
                    }
                    else
                    {
                        _position += 3;
                    }
                    return;
                case 7:
                    if (GetParam(c, _position + 1) < GetParam(b, _position + 2))
                    {
                        _program[_program[_position + 3]] = 1;
                    }
                    else
                    {
                        _program[_program[_position + 3]] = 0;
                    }
                    _position += 4;
                    return;
                case 8:
                    if (GetParam(c, _position + 1) == GetParam(b, _position + 2))
                    {
                        _program[_program[_position + 3]] = 1;
                    }
                    else
                    {
                        _program[_program[_position + 3]] = 0;
                    }
                    _position += 4;
                    return;
                default:
                    throw new ArgumentException($"cannot be opcode {opCode}");
            }
        }

        public int GetParam(int param, int position)
        {
            return param == 0 ? _program[_program[position]] : _program[position];
        }
    }
}
