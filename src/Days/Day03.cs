using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 3)]
    public class Day03 : BaseDay
    {
        public override string PartOne(string input)
        {
            var lines = input.Lines().ToArray();
            var map = lines.Select(a => a.Cycle());
            int x = 0;
            int y = 0;
            var dx = 3;
            var dy = 1;
            int hit = 0;
            while ((y += dy) < lines.Length)
            {
                x += dx;
                if (map.Skip(y).First().Skip(x).First() == '#')
                    hit++;
            }
            return hit.ToString();
        }

        public override string PartTwo(string input)
        {
            var a = Go(input, 1, 1);
            a *= Go(input, 3, 1);
            a *= Go(input, 5, 1);
            a *= Go(input, 7, 1);
            a *= Go(input, 1, 2);

            return a.ToString();
        }

        private static long Go(string input, int dx, int dy)
        {
            var lines = input.Lines().ToArray();
            var map = lines.Select(a => a.Cycle());
            int x = 0;
            int y = 0;
            long hit = 0;
            while ((y += dy) < lines.Length)
            {
                x += dx;
                if (map.Skip(y).First().Skip(x).First() == '#')
                    hit++;
            }
            return hit;
        }
    }
}
