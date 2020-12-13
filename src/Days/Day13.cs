using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Days
{
    [Day(2020, 13)]
    public class Day13 : BaseDay
    {
        public override string PartOne(string input)
        {
            var l = input.Lines().ToArray();
            var mins = int.Parse(l[0]);
            var buses = l[1].Split(',').Where(a => a != "x").Select(a => int.Parse(a)).ToArray();
            var min = buses.Select(a => (a, ((int)(mins / a) + 1) * a - mins)).OrderBy(a => a.Item2).First();
            return (min.a * min.Item2).ToString();
        }

        public override string PartTwo(string input)
        {
            var l = input.Lines().ToArray();
            var buses = l[1].Split(',').Select((a, i) => (a, i)).Where(a => a.a != "x").Select(a => (index: a.i, bus: int.Parse(a.a), firstOffset: (int.Parse(a.a) * int.Parse(a.a) - a.i) % int.Parse(a.a))).ToArray();

            //start with highest bus number, since when we find a bus that a timestamp matches
            //we can increment our search by the bus number, and each subsequent bus number can 
            //be multiplied in. This allows our rate of search to increase very quickly
            var desc = buses.OrderByDescending(a => a.bus).ToArray();
            var lf = new List<(int index, int bus, int firstOffset)>(desc);
            BigInteger f = 1;
            for (BigInteger i = f; true; i += f)
            {
                if (i % lf[0].bus == lf[0].firstOffset)
                {
                    f *= lf[0].bus;
                    lf.RemoveAt(0);
                }
                if (lf.Count == 0)
                    return i.ToString();
            }

        }
    }
}
