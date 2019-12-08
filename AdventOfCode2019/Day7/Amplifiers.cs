using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day7
{
    public class Amplifiers
    {
        public static int Run(int[] sequence, int[] program)
        {
            var currentAnswer = 0;
            for (int i = 0; i < 5; i++)
            {
                var computer = new IntCodeComputer(program.ToList());
                currentAnswer = computer.Run(new List<int> { sequence[i], currentAnswer })[0];
            }
            return currentAnswer;
        }

        public static int FindBest(int[] program)
        {
            var maxNum = 0;
            int[] maxList = new int[0];

            var permulations = Permute(new List<int> { 0, 1, 2, 3, 4, });
            
            var programCopy = (int[])program.Clone();
            
            foreach (var seq in permulations)
            {
                var seq2 = seq.ToArray();
                var thisRun = Run(seq2, programCopy);
                if (thisRun > maxNum)
                {
                    maxNum = thisRun;
                    maxList = seq2;
                }
            }
            
            return maxNum;
        }

        public static int Run2(int[] sequence, int[] program)
        {
            var programList = program.ToList();
            var isRunning = true;

            var amplifiers = new Dictionary<int, IntCodeComputer>();

            for (int a = 0; a < 5; a++)
            {
                amplifiers[a] = new IntCodeComputer(programList.ToList());
                amplifiers[a].AddInput(sequence[a]);
            }

            int i = 0;
            var passedThroughInput = 0;
            var hasOneQuit = false;
            while (isRunning)
            {
                var amplifier = i % 5;
                var runResult = amplifiers[amplifier].RunUntilAnOutputOrExit(passedThroughInput);
                if (runResult.isFinished99)
                {
                    hasOneQuit = true;
                }
                if (hasOneQuit == true && amplifier == 4)
                {
                    return runResult.Item1;
                }
                passedThroughInput = runResult.Item1;
                i++;
            }
            throw new Exception("Nope");
        }

        public static int FindBest2(int[] program)
        {
            var maxNum = 0;
            int[] maxList = new int[0];

            var permulations = Permute(new List<int> { 5, 6, 7, 8, 9 });

            var programCopy = (int[])program.Clone();

            foreach (var seq in permulations)
            {
                var seq2 = seq.ToArray();
                var thisRun = Run2(seq2, programCopy);
                if (thisRun > maxNum)
                {
                    maxNum = thisRun;
                    maxList = seq2;
                }
            }

            return maxNum;
        }

        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                yield break;
            }

            var list = sequence.ToList();

            if (!list.Any())
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var startingElementIndex = 0;

                foreach (var startingElement in list)
                {
                    var index = startingElementIndex;
                    var remainingItems = list.Where((e, i) => i != index);

                    foreach (var permutationOfRemainder in Permute(remainingItems))
                    {
                        yield return Concat(startingElement, permutationOfRemainder);
                    }

                    startingElementIndex++;
                }
            }
        }

        private static IEnumerable<T> Concat<T>(T firstElement, IEnumerable<T> secondSequence)
        {
            yield return firstElement;
            if (secondSequence == null)
            {
                yield break;
            }

            foreach (var item in secondSequence)
            {
                yield return item;
            }
        }
    }
}
