using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Day1
{
    public static class FuelCalculator
    {
        public static int Calculate(int mass)
        {
            return (int)Math.Floor(mass / 3m) - 2;
        }

        public static int CalculateIncludingItself(int mass)
        {
            var currentRequirement = Calculate(mass);
            var total = 0;
            while (currentRequirement > 0)
            {
                total += currentRequirement;
                var fuelNeeded = Calculate(currentRequirement);
                currentRequirement = fuelNeeded;
            }
            return total;
        }

        public static int CalculateIncludingItselfRecursive(int mass)
        {
            var fuelRequired = Calculate(mass);

            if (fuelRequired <= 0)
            {
                return 0;
            }
            else
            {
                return fuelRequired + CalculateIncludingItselfRecursive(fuelRequired);
            }
            
        }
    }
}
