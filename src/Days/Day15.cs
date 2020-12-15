using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 15)]
    public class Day15 : BaseDay
    {
        public override string PartOne(string input)
        {
            // 7, 14, 0, 17, 11, 1, 2
            var l = input.Split(',').Select(a => long.Parse(a));
            var hs = new HashSet<long>(l);
            var ls = new LinkedList<long>(l.Reverse());
            long t = ls.Count;
            while (true)
            {
                t++;
                var v = ls.First.Value;
                var n = hs.Add(v);
                if (n)
                {
                    v = 0;
                } else
                {
                    ls.SelectWithIndex().Where(a => a.item == v).Take(2).Select(a => a.index).Deconstruct(out int first, out int second);
                    v = second - first;
                }
                ls.AddFirst(v);
                if (t == 2020)
                    return v.ToString();
            }
        }

        public override string PartTwo(string input)
        {
            // 7, 14, 0, 17, 11, 1, 2
            var l = input.Split(',').Select(a => long.Parse(a));
            var hs = new Dictionary<long, long>(l.Reverse().Skip(1).Reverse().SelectWithIndex().Select(a => new KeyValuePair<long, long>(a.item, a.index + 1)));
            var v = l.Last();
            long t = l.Count();
            while (true)
            {
                if (t == 30000000)
                    return v.ToString();

                var n = hs.TryGetValue(v, out var el);

                //speak
                hs.Remove(v);
                hs.Add(v, t);

                if (!n)
                    v = 0;
                else
                    v = t - el;

                //next
                t++;
            }
        }
    }
}
