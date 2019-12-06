using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day6
{
    public static class OrbitCalculator
    {
        public static int CalculateNumberOfOrbits(List<string> input)
        {
            var orbits = input.ToDictionary(i => i.Split(")")[1], i => i.Split(")")[0]);
            var orbitCount = 0;
            foreach (var planet in orbits.Keys.Distinct())
            {
                var tempPlanet = planet;
                while (orbits.ContainsKey(tempPlanet))
                {
                    orbitCount++;
                    tempPlanet = orbits[tempPlanet];
                }
            }
            return orbitCount;
        }

        public static int CalculatePathDistance(List<string> input)
        {
            var orbits = input.ToDictionary(i => i.Split(")")[1], i => i.Split(")")[0]);

            var youPath = CalculatePathToBase(orbits, "YOU");
            var sanPath = CalculatePathToBase(orbits, "SAN").ToHashSet();

            var youDistance = 0;
            var sanDistance = 0;
            foreach (var planet in youPath)
            {
                if (sanPath.Contains(planet))
                {
                    var basePlanet = planet;

                    var tempPlanet2 = "SAN";

                    while (orbits[tempPlanet2] != basePlanet)
                    {
                        tempPlanet2 = orbits[tempPlanet2];
                        sanDistance++;
                    }
                    return youDistance + sanDistance - 1;
                }
                youDistance++;
            }
            throw new Exception("Damn");   
        }

        public static List<string> CalculatePathToBase(Dictionary<string, string> orbits, string start)
        {
            var result = new List<string>();
            var tempPlanet = start;
            while (orbits.ContainsKey(tempPlanet))
            {
                result.Add(tempPlanet);
                tempPlanet = orbits[tempPlanet];
            }
            return result;
        }
    }
}
