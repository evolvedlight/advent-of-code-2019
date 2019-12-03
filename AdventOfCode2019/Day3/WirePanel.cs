using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AdventOfCode.Day3
{
    public static class WirePanel
    {
        public static int GetClosestShortestDistanceMatch(List<string> wire1, List<string> wire2)
        {
            var wire1Positions = new HashSet<PointWithDistance>();
            var currentPosition = new PointWithDistance(0, 0, 0);
            wire1Positions.Add(currentPosition);
            var crossPoints = new List<PointWithWire1AndWire2Distance>();

            foreach (var instruction in wire1)
            {
                var direction = instruction[0];
                var length = int.Parse(instruction.Substring(1));
                switch(direction)
                {
                    case 'R':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new PointWithDistance(currentPosition.x, currentPosition.y + 1, currentPosition.stepsFromStart + 1);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                    case 'L':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new PointWithDistance(currentPosition.x, currentPosition.y - 1, currentPosition.stepsFromStart + 1);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                    case 'U':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new PointWithDistance(currentPosition.x + 1, currentPosition.y, currentPosition.stepsFromStart + 1);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                    case 'D':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new PointWithDistance(currentPosition.x - 1, currentPosition.y, currentPosition.stepsFromStart + 1);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                }
            }

            currentPosition = new PointWithDistance(0, 0, 0);
            foreach (var instruction in wire2)
            {
                var direction = instruction[0];
                var length = int.Parse(instruction.Substring(1));
                
                switch (direction)
                {
                    case 'R':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new PointWithDistance(currentPosition.x, currentPosition.y + 1, currentPosition.stepsFromStart + 1);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                var match = wire1Positions.Single(x => x.Equals(currentPosition));
                                crossPoints.Add(new PointWithWire1AndWire2Distance(currentPosition.x, currentPosition.y, match.stepsFromStart, currentPosition.stepsFromStart));
                            }
                        }
                        continue;
                    case 'L':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new PointWithDistance(currentPosition.x, currentPosition.y - 1, currentPosition.stepsFromStart + 1);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                var match = wire1Positions.Single(x => x.Equals(currentPosition));
                                crossPoints.Add(new PointWithWire1AndWire2Distance(currentPosition.x, currentPosition.y, match.stepsFromStart, currentPosition.stepsFromStart));
                            }
                        }
                        continue;
                    case 'U':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new PointWithDistance(currentPosition.x + 1, currentPosition.y, currentPosition.stepsFromStart + 1);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                var match = wire1Positions.Single(x => x.Equals(currentPosition));
                                crossPoints.Add(new PointWithWire1AndWire2Distance(currentPosition.x, currentPosition.y, match.stepsFromStart, currentPosition.stepsFromStart));
                            }
                        }
                        continue;
                    case 'D':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new PointWithDistance(currentPosition.x - 1, currentPosition.y, currentPosition.stepsFromStart + 1);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                var match = wire1Positions.Single(x => x.Equals(currentPosition));
                                crossPoints.Add(new PointWithWire1AndWire2Distance(currentPosition.x, currentPosition.y, match.stepsFromStart, currentPosition.stepsFromStart));
                            }
                        }
                        continue;
                }
                
            }
            return crossPoints.Min(p => Math.Abs(p.W1D) + Math.Abs(p.W2D));
        }

        public static int GetClosestManhattanMatch(List<string> wire1, List<string> wire2)
        {
            var wire1Positions = new HashSet<Point>();
            var currentPosition = new Point(0, 0);
            wire1Positions.Add(currentPosition);
            var crossPoints = new List<Point>();

            foreach (var instruction in wire1)
            {
                var direction = instruction[0];
                var length = int.Parse(instruction.Substring(1));
                switch (direction)
                {
                    case 'R':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new Point(currentPosition.x, currentPosition.y + 1);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                    case 'L':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new Point(currentPosition.x, currentPosition.y - 1);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                    case 'U':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new Point(currentPosition.x + 1, currentPosition.y);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                    case 'D':
                        for (int i = 1; i <= length; i++)
                        {
                            var newPosition = new Point(currentPosition.x - 1, currentPosition.y);
                            wire1Positions.Add(newPosition);
                            currentPosition = newPosition;
                        }
                        continue;
                }
            }

            currentPosition = new Point(0, 0);
            foreach (var instruction in wire2)
            {
                var direction = instruction[0];
                var length = int.Parse(instruction.Substring(1));

                switch (direction)
                {
                    case 'R':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new Point(currentPosition.x, currentPosition.y + 1);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                crossPoints.Add(currentPosition);
                            }
                        }
                        continue;
                    case 'L':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new Point(currentPosition.x, currentPosition.y - 1);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                crossPoints.Add(currentPosition);
                            }
                        }
                        continue;
                    case 'U':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new Point(currentPosition.x + 1, currentPosition.y);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                crossPoints.Add(currentPosition);
                            }
                        }
                        continue;
                    case 'D':
                        for (int i = 1; i <= length; i++)
                        {
                            currentPosition = new Point(currentPosition.x - 1, currentPosition.y);
                            if (wire1Positions.Contains(currentPosition))
                            {
                                crossPoints.Add(currentPosition);
                            }
                        }
                        continue;
                }

            }
            return crossPoints.Min(p => Math.Abs(p.x) + Math.Abs(p.y));
        }
    }

    internal class PointWithWire1AndWire2Distance : Point
    {
        public int W1D { get; }
        public int W2D { get; }

        public PointWithWire1AndWire2Distance(int x, int y, int w1d, int w2d) : base (x, y)
        {
            W1D = w1d;
            W2D = w2d;
        }

        public override string ToString()
        {
            return $"Point {x}, {y}. W1D: {W1D}. W2D: {W2D}";
        }
    }

    internal class PointWithDistance : Point, IEquatable<PointWithDistance>
    {
        public int stepsFromStart { get; set; }

        public PointWithDistance(int x, int y, int stepsFromStart) : base (x, y)
        {
            this.stepsFromStart = stepsFromStart;
        }

        public bool Equals([AllowNull] PointWithDistance other)
        {
            return other != null &&
                   x == other.x &&
                   y == other.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static bool operator ==(PointWithDistance left, PointWithDistance right)
        {
            return EqualityComparer<Point>.Default.Equals(left, right);
        }

        public static bool operator !=(PointWithDistance left, PointWithDistance right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Point {x}, {y}. D: {stepsFromStart}";
        }
    }

    internal class Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x { get; set; }
        public int y { get; set; }
        

        public bool Equals([AllowNull] Point other)
        {
            return other != null &&
                   x == other.x &&
                   y == other.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static bool operator ==(Point left, Point right)
        {
            return EqualityComparer<Point>.Default.Equals(left, right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Point {x}, {y}";
        }
    }
}
