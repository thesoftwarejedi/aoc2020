using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 11)]
    public class Day11 : BaseDay
    {
        public override string PartOne(string input)
        {
            var cg = input.CreateCharGrid();

            int i = 0;
            while (true)
            {
                var chg = false;
                var ncg = cg.Clone((x, y, c) =>
                {
                    var item = new Point(x, y);
                    var n = cg.GetNeighbors(item.X, item.Y, true).ToArray();

                    if (c == 'L')
                        if (!n.Any(a => a == '#'))
                        {
                            chg = true;
                            return '#';
                        }

                    if (c == '#')
                        if (n.Count(a => a == '#') >= 4)
                        {
                            chg = true;
                            return 'L';
                        }

                    return c;
                }) as char[,];

                Log(ncg.GetString());
                if (!chg)
                    return ncg.GetString().Where(a => a == '#').Count().ToString();

                cg = ncg;

                i++;
            }

        }

        public override string PartTwo(string input)
        {
            var cg = input.CreateCharGrid();

            int i = 0;
            while (true)
            {
                var chg = false;
                var ncg = cg.Clone((x, y, c) =>
                {
                    var item = new Point(x, y);
                    var n = cg.GetNeighborsMatchingInAllDirections(item.X, item.Y, a => a != '.').ToArray();

                    if (c == 'L')
                        if (!n.Any(a => a == '#'))
                            return '#';

                    if (c == '#')
                        if (n.Count(a => a == '#') >= 5)
                            return 'L';

                    return c;
                }) as char[,];

                Log(ncg.GetString());
                if (ncg.GetString() == cg.GetString())
                    return ncg.GetString().Where(a => a == '#').Count().ToString();

                cg = ncg;

                i++;
            }
        }
    }
}
