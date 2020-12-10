using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 9)]
    public class Day09 : BaseDay
    {
        public override string PartOne(string input)
        {
            var l = input.Longs().ToArray();
            var p = l.Select((a, i) => (a, i)).Where(a => a.i >= 25).Select(a => (a.a, l.Skip(a.i - 25).Take(25).ToArray().GetCombinations(2).ToArray()));
            var a = p.Where(a => !a.Item2.Any(b => b.Sum() == a.a)).First();

            return a.ToString();
        }

        public override string PartTwo(string input)
        {
            long ans = 133015568L;

            var l = input.Longs().ToArray();

            Random r = new Random();
            while (true)
            {
                var r1 = r.Next(l.Length - 1);
                var r2 = r.Next(r1 + 1, l.Length);
                var sum = l.Skip(r1).Take(r2 - r1 + 1).Sum();
                if (sum == ans)
                {
                    Log($"{r1} to {r2} is {l[r1]} to {l[r2]} = {sum}");
                    var range = l.Skip(r1).Take(r2 - r1).ToArray();
                    return (range.Min() + range.Max()).ToString();
                }
            }
        }
    }
}
