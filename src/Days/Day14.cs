using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    [Day(2020, 14)]
    public class Day14 : BaseDay
    {
        public override string PartOne(string input)
        {
            var l = input.Lines().Where(a=>!string.IsNullOrWhiteSpace(a)).ToArray();
            var mem = new List<long>(Enumerable.Repeat(0L, 100000));
            var mask = string.Empty;
            foreach (var line in l)
            {
                if (line.StartsWith("mask"))
                {
                    mask = line.Split(' ')[2];
                    continue;
                }
                var m = Regex.Match(line, "mem\\[(\\d+)\\] = (\\d+)");
                var index = int.Parse(m.Groups[1].Value);
                var val = long.Parse(m.Groups[2].Value);
                var bin = Convert.ToString(val, 2).PadLeft(36, '0');
                bin = new string(bin.Select((a, i) => mask[i] == 'X' ? a : mask[i]).ToArray());
                val = Convert.ToInt64(bin, 2);
                mem[index] = val;
            }
            var a = mem.Sum();
            return a.ToString();
        }

        public override string PartTwo(string input)
        {
            var l = input.Lines().Where(a => !string.IsNullOrWhiteSpace(a)).ToArray();
            var mem = new Dictionary<long, long>();
            var mask = string.Empty;
            foreach (var line in l)
            {
                if (line.StartsWith("mask"))
                {
                    mask = line.Split(' ')[2];
                    continue;
                }
                var m = Regex.Match(line, "mem\\[(\\d+)\\] = (\\d+)");
                var index = int.Parse(m.Groups[1].Value);
                var val = long.Parse(m.Groups[2].Value);
                var bin = Convert.ToString(index, 2).PadLeft(36, '0');
                var memStr = new string(bin.Select((a, i) => mask[i] == '0' ? a : mask[i]).ToArray());
                //each 'X' in the mask branches the combinations
                IEnumerable<long> vals = Decode(memStr);
                //update all memory addresses with the value
                vals.ForEach(a => mem[a] = val);
            }
            var a = mem.Values.Sum();
            return a.ToString();
        }

        private IEnumerable<long> Decode(string memStr)
        {
            var s = new List<char[]>();
            //add initial cleared out string
            s.Add(Enumerable.Repeat('0', 36).ToArray());
            int i = 0;
            foreach (var c in memStr)
            {
                //update all strings in list with val of this bit
                if (c != 'X')
                    s.ForEach(a => a[i] = c);
                //update the one there with a 0, duplicate it, and update the dupe with a 1
                else
                {
                    //"ta add" interim list as not to modify collection being iterated
                    var ta = new List<char[]>();
                    foreach (var item in s)
                    {
                        item[i] = '0';
                        var n = item.Clone() as char[];
                        n[i] = '1';
                        ta.Add(n);
                    }
                    //add the new ones
                    s.AddRange(ta);
                }
                i++;
            }
            return s.Select(a => Convert.ToInt64(new string(a), 2));
        }
    }
}
