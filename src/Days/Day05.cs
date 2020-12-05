using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 5)]
    public class Day05 : BaseDay
    {
        public override string PartOne(string input)
        {
            var lines = input.Lines();
            var seats = new List<int>();
            foreach (var line in lines)
            {
                var rows = Enumerable.Range(0, 128).ToArray();
                var cols = Enumerable.Range(0, 8).ToArray();
                var i = line.Aggregate((rows, cols), ((int[] r, int[] c) i, char a) => a switch
                {
                    'F' => (i.r.Take(i.r.Length / 2).ToArray(), i.c),
                    'B' => (i.r.Skip(i.r.Length / 2).ToArray(), i.c),
                    'L' => (i.r, i.c.Take(i.c.Length / 2).ToArray()),
                    'R' => (i.r, i.c.Skip(i.c.Length / 2).ToArray())
                });
                int row = i.Item1[0];
                int col = i.Item2[0];
                var seat = row * 8 + col;
                seats.Add(seat);
            }
            var max = seats.Max();
            return max.ToString();
        }

        public override string PartTwo(string input)
        {
            var lines = input.Lines();
            var seats = new List<int>();
            foreach (var line in lines)
            {
                var rows = Enumerable.Range(0, 128).ToArray();
                var cols = Enumerable.Range(0, 8).ToArray();
                var i = line.Aggregate((rows, cols), ((int[] r, int[] c) i, char a) => a switch
                {
                    'F' => (i.r.Take(i.r.Length / 2).ToArray(), i.c),
                    'B' => (i.r.Skip(i.r.Length / 2).ToArray(), i.c),
                    'L' => (i.r, i.c.Take(i.c.Length / 2).ToArray()),
                    'R' => (i.r, i.c.Skip(i.c.Length / 2).ToArray())
                });
                int row = i.Item1[0];
                int col = i.Item2[0];
                var seat = row * 8 + col;
                seats.Add(seat);
            }
            seats.Sort();
            var ss = seats.ToArray();
            for (int i = 0; i < ss.Length-1; i++)
            {
                if (ss[i] + 1 != ss[i + 1])
                    return (ss[i] + 1).ToString();
            }
            throw new Exception("that sucks");
        }
    }
}
