using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 1)]
    public class Day01 : BaseDay
    {
        public override string PartOne(string input)
        {
            var ints = input.Integers().ToArray();
            for (int i = 0; i < ints.Length; i++)
                for (int j = 0; j < ints.Length; j++)
                    if (i == j)
                        continue;
                    else if (ints[i] + ints[j] == 2020)
                        return (ints[i] * ints[j]).ToString();
            return "none";

            //return ints.SelectMany(a => ints.Select(b => (a, b))).Where(a => a.a + a.b == 2020).Select(a => a.a * a.b).First().ToString();
        }

        public override string PartTwo(string input)
        {
            var ints = input.Integers().ToArray();
            for (int i = 0; i < ints.Length; i++)
                for (int j = 0; j < ints.Length; j++)
                    for (int k = 0; k < ints.Length; k++)
                        if (i == j || j == k || i == k)
                            continue;
                        else if (ints[i] + ints[j] + ints[k] == 2020)
                            return (ints[i] * ints[j] * ints[k]).ToString();
            return "none";

            //return ints.SelectMany(a => ints.SelectMany(b => ints.Select(c => (a, b, c)))).Where(a => a.a + a.b + a.c == 2020).Select(a => a.a * a.b * a.c).First().ToString();
        }
    }
}
