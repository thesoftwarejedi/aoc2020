using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Days
{
    [Day(2020, 10)]
    public class Day10 : BaseDay
    {
        public override string PartOne(string input)
        {
            var l = input.Longs().Append(0);
            var ll = l.Append(l.Max() + 3).OrderBy(a => a).ToArray();

            var s1 = 0L;
            var s2 = 0L;

            for (int i = 1; i < ll.Length; i++)
            {
                switch (ll[i] - ll[i - 1])
                {
                    case 1:
                        s1++;
                        break;
                    case 3:
                        s2++;
                        break;
                    default:
                        break;
                }
            }

            return (s1 * s2).ToString();
        }

        public override string PartTwo(string input)
        {
            var l = input.Longs().Append(0);
            var max = l.Max() + 3;
            var ll = l.Append(max).OrderBy(a => a).ToArray();

            var aa = new long[ll.Length];
            aa[0] = 1;
            for (int i = 1; i < ll.Length; i++)
                for (int j = 1; j < 4; j++)
                    if ((i - j) >= 0 && ll[i] - ll[i - j] <= 3)
                        aa[i] += aa[i - j];

            return aa.Last().ToString();
        }

        /*
        public override string PartTwo(string input)
        {
            var l = input.Longs().Append(0);
            var max = l.Max() + 3;
            var ll = l.Append(max).OrderBy(a => a).ToArray();

            WalkTree(ll);
            return _s_m.ToString();
        }

        private static long _s_m = 0L;

        private static void WalkTree(long[] ll)
        {
            if (ll.Length == 1)
            {
                _s_m++;
                return;
            }
            for (int i = 1; i < 4; i++)
            {
                if (i < ll.Length)
                    if (ll[i] <= (ll[0] + 3))
                    {
                        WalkTree(ll.Skip(i).ToArray());
                    }
            }
        }
        */
    }
}
