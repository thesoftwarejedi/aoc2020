using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 6)]
    public class Day06 : BaseDay
    {
        public override string PartOne(string input)
        {
            var l = input.Split('\n', '\r').ToArray();
            var groups = l.GetLineGroups(a => a == "").ToArray();
            var ss = groups.Select(a =>
            {
                var asd = a.SelectMany(b => b).ToArray();
                var qwe = asd.Distinct().ToArray();
                var c = qwe.Count();
                return c;
            });
            var gg = ss.Sum();
            return gg.ToString();
        }

        public override string PartTwo(string input)
        {
            var l = input.Split('\n', '\r').ToArray();
            var groups = l.GetLineGroups(a => a == "").ToArray();
            var ss = groups.Select(a =>
            {
                var asd = a.Aggregate((a, b) => new string(a.Intersect(b).ToArray())).Distinct();
                var c = asd.Count();
                return c;
            });
            var gg = ss.Sum();
            return gg.ToString();
        }
    }
}
