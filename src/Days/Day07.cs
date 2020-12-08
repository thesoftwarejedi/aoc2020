using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    [Day(2020, 7)]
    public class Day07 : BaseDay
    {

        BagInfo[] gg;
        public override string PartOne(string input)
        {
            var l = input.Lines();
            var cl = l.Select(a => (Regex.Match(a, "^(.*) bags contain.*$").Groups[1].Value, a)).ToArray();
            gg = cl.Select(a => new BagInfo(color: a.Value, carries: Regex.Matches(a.a, "(\\d+) ([\\w\\d\\s]+) bag").Select(b => new Bags(count: int.Parse(b.Groups[1].Value), color: b.Groups[2].Value)).ToArray())).ToArray();

            var cc = gg.Where(a => CanHold(a.color, "shiny gold")).ToArray();

            return cc.Count().ToString();
        }

        private bool CanHold(string bagColor, string holdWhat)
        {
            var c = gg.First(a => a.color == bagColor);
            if (c.carries.Any(a => a.color == bagColor))
                return true;
            foreach (var item in c.carries)
                if (item.color == holdWhat)
                    return true;
                else if (CanHold(item.color, holdWhat))
                    return true;
            return false;
        }

        private long Contains(string bagColor)
        {
            long cnt = 0;
            var c = gg.First(a => a.color == bagColor);
            Log($"{bagColor}: {c.carries.Length}");
            foreach (var item in c.carries)
            {
                cnt += item.count;
                cnt += item.count * Contains(item.color);
            }
            return cnt;
        }

        public override string PartTwo(string input)
        {
            var l = input.Lines();
            var cl = l.Select(a => (Regex.Match(a, "^(.*) bags contain.*$").Groups[1].Value, a)).ToArray();
            gg = cl.Select(a => new BagInfo(color: a.Value, carries: Regex.Matches(a.a, "(\\d+) ([\\w\\d\\s]+) bag").Select(b => new Bags(count: int.Parse(b.Groups[1].Value), color: b.Groups[2].Value)).ToArray())).ToArray();

            long c = Contains("shiny gold");
            return c.ToString();
        }
    }

    public record Bags(int count, string color);
    public record BagInfo(string color, Bags[] carries);
}
