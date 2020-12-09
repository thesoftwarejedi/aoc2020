using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 8)]
    public class Day08 : BaseDay
    {
        public override string PartOne(string input)
        {
            var ops = input.Lines().Where(a=>a.Trim().Length > 0).Select((a,i)=>new Inst(i, a.Split(' ')[0], long.Parse(a.Split(' ')[1].Replace("+", "")))).ToArray();
            var used = new HashSet<long>();
            long acc = 0;
            long ptr = 0;
            while(true)
            {
                var op = ops[ptr];

                if (!used.Add(op.line))
                    break;

                switch (op.op)
                {
                    case "nop":
                        ptr++;
                        break;
                    case "acc":
                        acc += op.arg;
                        ptr++;
                        break;
                    case "jmp":
                        ptr += op.arg;
                        break;
                }
            }
            return acc.ToString();
        }

        public override string PartTwo(string input)
        {
            var ops = input.Lines().Where(a => a.Trim().Length > 0).Select((a, i) => new Inst(i, a.Split(' ')[0], long.Parse(a.Split(' ')[1].Replace("+", "")))).ToArray();

            long rep = 0;

            while (true)
            {
                long exec = 0;
                var used = new HashSet<long>();
                long acc = 0;
                long ptr = 0;
                bool replaced = false;
                while (true)
                {
                    //overflow
                    if (ptr > ops.Length)
                        break;

                    //success
                    if (ptr == ops.Length)
                        return acc.ToString();

                    var op = ops[ptr];

                    //inf loop
                    if (!used.Add(op.line))
                        break;

                    if (!replaced && exec >= rep)
                    {
                        replaced = true;
                        op = op with { op = op.op switch { "nop" => "jmp", "jmp" => "nop", _ => op.op } };
                        Log($"replaced line {exec}");
                    }

                    switch (op.op)
                    {
                        case "nop":
                            ptr++;
                            break;
                        case "acc":
                            acc += op.arg;
                            ptr++;
                            break;
                        case "jmp":
                            ptr += op.arg;
                            break;
                    }
                    exec++;
                }
                //nope
                rep++;
            }
        }
    }

    public record Inst(long line, string op, long arg);
}
