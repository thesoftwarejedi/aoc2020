using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    [Day(2020, 2)]
    public class Day02 : BaseDay
    {
        public override string PartOne(string input)
        {
            int count = 0;
            var lines = input.Lines();
            foreach (var line in lines)
            {
                var a = line.Split(' ').First();
                var b = int.Parse(a.Split('-')[0]);
                var c = int.Parse(a.Split('-')[1]);
                var d = line.Split(':')[0].Last();
                var cnt = line.Split(':')[1].Count(x => x == d);
                if (cnt >= b && cnt <= c)
                    count++;
            }
            return count.ToString();
        }

        public override string PartTwo(string input)
        {
            int count = 0;
            var lines = input.Lines();
            foreach (var line in lines)
            {
                var a = line.Split(' ').First();
                var b = int.Parse(a.Split('-')[0]);
                var c = int.Parse(a.Split('-')[1]);
                var d = line.Split(':')[0].Last();
                var cnt = line.Split(':')[1][b] == d;
                var cnt2 = line.Split(':')[1][c] == d;
                if ((cnt || cnt2) && !(cnt && cnt2))
                    count++;
            }
            return count.ToString();
        }
    }
}
