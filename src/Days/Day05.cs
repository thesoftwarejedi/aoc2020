using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    [Day(2020, 5)]
    public class Day05 : BaseDay
    {
        public override string PartOne(string input)
        {
            //one liner
            //return input.Lines().Select(a => Convert.ToInt32(new string(a.Select(b => (b & 4) > 0 ? '1' : '0').ToArray()), 2)).Max().ToString();

            return input
                .Lines() //ext method, splits on newline
                .Select(a => //map each line
                    Convert.ToInt32( //create an int from a string
                        new string(a.Select(b => (b & 4) >  0 ? '0' : '1').ToArray()) //create binary char array based on the 4s bit of the char
                        , 2) //string is provided in base 2
                    )
                .Max() //get the max int
                .ToString(); //return as string

        }

        public override string PartTwo(string input)
        {
            int[] seats;
            //one liner, eh, cheating to back reference array
            //return (seats = input.Lines().Select(a => Convert.ToInt32(new string(a.Select(b => (b & 4) > 0 ? '1' : '0').ToArray()), 2)).OrderBy(a=>a).ToArray()).SelectWithIndex.Where(a => a.item + 1 != seats[a.index + 1]).Select(a => a.item + 1).First().ToString();

            return (seats = //cheat with inline variable
                input
                .Lines() //ext method, splits on newline
                .Select(a => //map each line
                    Convert.ToInt32( //create an int from a string
                        new string(a.Select(b => (b & 4) > 0 ? '0' : '1').ToArray()) //create binary char array based on the 4s bit of the char
                        , 2) //string is provided in base 2
                    )
                .OrderBy(a => a) //sort
                .ToArray() //store array
                ) //close inline variable
                .SelectWithIndex() //extension method for ((a, i) => (a, i)) 
                .Where(a => a.item + 1 != seats[a.index + 1]) //where a seat is missing
                .Select(a => a.item + 1) //get the missing seat
                .First() //first one (only one?!)
                .ToString(); //as a string



            /*
             * 
             * original logic I used in parts one and two
             * 
            var lines = input.Lines();
            var seats = new List<int>();
            foreach (var line in lines)
            {
                var rows = Enumerable.Range(0, 128).ToArray();
                var cols = Enumerable.Range(0, 8).ToArray();
                var i = line.Aggregate((rows, cols), ((int[] r, int[] c) i, char a) => a switch
                {
                    'F' => (i.r.Take(i.r.Length / 2).ToArray(), i.c),
                    'B' => (i.r.Skip(i.r.Length / 2).ToArray(), i.c),
                    'L' => (i.r, i.c.Take(i.c.Length / 2).ToArray()),
                    'R' => (i.r, i.c.Skip(i.c.Length / 2).ToArray())
                });
                int row = i.Item1[0];
                int col = i.Item2[0];
                var seat = row * 8 + col;
                seats.Add(seat);
            }
            seats.Sort();
            var ss = seats.ToArray();
            for (int i = 0; i < ss.Length - 1; i++)
            {
                if (ss[i] + 1 != ss[i + 1])
                    return (ss[i] + 1).ToString();
            }
            throw new Exception("that sucks");
        }
            */
        }
    }
}