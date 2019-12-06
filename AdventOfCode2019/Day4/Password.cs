using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day4
{
    public static class Password
    {
        public static int CalculateNumber(int min, int max)
        {
            var count = 0;
            for (int i = min; i < max; i++)
            {
                // two adjacent are the same
                if (Passes(i))
                {
                    count = count + 1;
                }
            }
            return count;
        }

        public static int CalculateNumber2(int min, int max)
        {
            var count = 0;
            for (int i = min; i < max; i++)
            {
                // two adjacent are the same
                if (Passes2(i))
                {
                    count = count + 1;
                }
            }
            return count;
        }

        public static bool Passes(int i)
        {
            var chars = i.ToString();
            var hasADouble = false;
            for (int j = 0; j < chars.Length - 1; j++)
            {
                if (chars[j] == chars[j + 1])
                {
                    hasADouble = true;
                }
                if (int.Parse(chars[j].ToString()) > int.Parse(chars[j + 1].ToString()))
                {
                    return false;
                }
            }
            return hasADouble;
        }

        public static bool Passes2(int i)
        {
            var chars = i.ToString();
            var hasADouble = false;
            for (int j = 0; j < chars.Length - 1; j++)
            {
                if (chars[j] == chars[j + 1])
                {
                    // Check sides
                    if ((j == 0 || chars[j - 1] != chars[j]) && (j + 1 == chars.Length - 1 || chars[j+1] != chars[j + 2]))
                    {
                        hasADouble = true;
                    }
                }
                if (int.Parse(chars[j].ToString()) > int.Parse(chars[j + 1].ToString()))
                {
                    return false;
                }
            }
            return hasADouble;
        }
    }
}
