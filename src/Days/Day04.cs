using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    [Day(2020, 4)]
    public class Day04 : BaseDay
    {
        public override string PartOne(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.None).ToArray();
            long valid = 0;
            var pass = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (pass.ContainsKey("byr")
                        && pass.ContainsKey("iyr")
                        && pass.ContainsKey("eyr")
                        && pass.ContainsKey("hgt")
                        && pass.ContainsKey("hcl")
                        && pass.ContainsKey("ecl")
                        //miss cid ok
                        && pass.ContainsKey("pid"))
                    {
                        valid++;
                    }
                    pass.Clear();
                }
                else
                {
                    var parts = line.Split(" ");
                    foreach (var part in parts)
                        pass.Add(part.Split(':')[0], part.Split(':')[1]);
                }
            }
            return valid.ToString();
        }

        public override string PartTwo(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.None).Concat(new[] { "" }).ToArray();
            long valid = 0;
            var pass = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (pass.ContainsKey("byr")
                        && pass.ContainsKey("iyr")
                        && pass.ContainsKey("eyr")
                        && pass.ContainsKey("hgt")
                        && pass.ContainsKey("hcl")
                        && pass.ContainsKey("ecl")
                        //miss cid ok
                        && pass.ContainsKey("pid"))
                    {
                        try
                        {
                            int i = int.Parse(pass["byr"]);
                            if (!(1920 <= i && i <= 2002))
                                throw new Exception("byr - " + pass["byr"]);

                            i = int.Parse(pass["iyr"]);
                            if (!(2010 <= i && i <= 2020))
                                throw new Exception("iyr - " + pass["iyr"]);

                            i = int.Parse(pass["eyr"]);
                            if (!(2020 <= i && i <= 2030))
                                throw new Exception("eyr - " + pass["eyr"]);

                            string s = null;
                            var m = Regex.Match(pass["hgt"], "^\\d\\d\\d?(cm|in)$");
                            if (!m.Success)
                                throw new Exception("hgt - " + pass["hgt"]);
                            if (m.Groups[1].Value == "cm")
                            {
                                s = pass["hgt"].Split("c")[0];
                                i = int.Parse(s);
                                if (!(150 <= i && i <= 193))
                                    throw new Exception("hgt-cm - " + pass["hgt"]);
                            }
                            else
                            {
                                s = pass["hgt"].Split("i")[0];
                                i = int.Parse(s);
                                if (!(59 <= i && i <= 76))
                                    throw new Exception("hgt-in - " + pass["hgt"]);
                            }

                            if (!(new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(pass["ecl"])))
                                throw new Exception("ecl - " + pass["ecl"]);

                            m = Regex.Match(pass["hcl"], "^#[0-9a-f]{6}$");
                            if (!m.Success)
                                throw new Exception("hcl" + pass["hcl"]);

                            m = Regex.Match(pass["pid"], "^\\d{9}$");
                            if (!m.Success)
                                throw new Exception("pid - " + pass["pid"]);


                            valid++;

                            Log("OK:");
                            Log(pass["byr"]);
                            Log(pass["iyr"]);
                            Log(pass["eyr"]);
                            Log(pass["hgt"]);
                            Log(pass["hcl"]);
                            Log(pass["ecl"]);
                            Log(pass["pid"]);
                            Log("---");

                        }
                        catch (Exception ex)
                        {
                            Log(ex.Message);
                        }
                    }
                    pass.Clear();
                }
                else
                {
                    var parts = line.Split(" ");
                    foreach (var part in parts)
                        pass.Add(part.Split(':')[0], part.Split(':')[1]);
                }
            }
            return valid.ToString();
        }
    }
}
