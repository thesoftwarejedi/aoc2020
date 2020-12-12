using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 12)]
    public class Day12 : BaseDay
    {
        public override string PartOne(string input)
        {
            var l = input.Lines().Where(a => !string.IsNullOrWhiteSpace(a));
            Point p = new Point();
            Direction f = Direction.Right;
            var np = l.Aggregate(p, (a, b) =>
            {
                if (b[0] == 'R')
                {
                    var d = int.Parse(new string(b.Skip(1).ToArray()));
                    while (d > 0)
                    {
                        d -= 90;
                        f = f.TurnRight();
                    }
                    return a;
                }
                else if (b[0] == 'L')
                {
                    var d = int.Parse(new string(b.Skip(1).ToArray()));
                    while (d > 0)
                    {
                        d -= 90;
                        f = f.TurnLeft();
                    }
                    return a;
                }
                else
                {
                    return a.Move(b[0] switch { 'N' => Direction.Up, 'E' => Direction.Right, 'S' => Direction.Down, 'W' => Direction.Left, 'F' => f }, int.Parse(new string(b.Skip(1).ToArray())));
                }
            });
            return p.ManhattanDistance(np).ToString();
        }

        public override string PartTwo(string input)
        {
            var l = input.Lines().Where(a => !string.IsNullOrWhiteSpace(a));
            Point p = new Point();
            Point w = new Point(10, 1);
            var np = l.Aggregate(p, (a, b) =>
            {
                if (b[0] == 'R')
                {
                    var d = int.Parse(new string(b.Skip(1).ToArray()));
                    w = w.RotateAround(a, d);
                    return a;
                }
                else if (b[0] == 'L')
                {
                    var d = int.Parse(new string(b.Skip(1).ToArray())) * -1;
                    w = w.RotateAround(a, d);
                    return a;
                }
                else if (b[0] == 'F')
                {
                    var dx = w.X - a.X;
                    var dy = w.Y - a.Y;

                    var c = int.Parse(new string(b.Skip(1).ToArray()));

                    w = new Point(w.X + dx * c, w.Y + dy * c);
                    return new Point(a.X + dx * c, a.Y + dy * c);
                }
                else
                {
                    w = w.Move(b[0] switch { 'N' => Direction.Up, 'E' => Direction.Right, 'S' => Direction.Down, 'W' => Direction.Left }, int.Parse(new string(b.Skip(1).ToArray())));
                    return a;
                }
            });
            return p.ManhattanDistance(np).ToString();
        }
    }
}
