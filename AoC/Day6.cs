using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class Day6
    {
        public static List<string> TestData()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"AoC- Day 6- Test Data.txt";
            return File.ReadAllLines(FilePath).ToList();
        }

        public static List<string> RealData()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"AoC- Day 6.txt";
            return File.ReadAllLines(FilePath).ToList();
        }

        public static int Part1(List<string> lines)
        {
            lines.Add("");
            int count = 0;
            List<char> GroupCharacters = new List<char>();
            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    count += GroupCharacters.Count();
                    GroupCharacters = new List<char>();
                }
                else
                {
                    List<char> x = line.ToCharArray().ToList();
                    GroupCharacters.AddRange(x);
                    GroupCharacters = GroupCharacters.Distinct().ToList();
                }
            }
            return count;
        }

        public static int Part2(List<string> lines)
        {
            lines.Add("");
            int count = 0;
            List<char> GroupCharacters = new List<char>();
            bool inGroup = false;
            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    int increment = GroupCharacters.Distinct().Count(); ;
                    count += increment;
                    GroupCharacters = new List<char>();
                    inGroup = false;
                }
                else
                {
                    List<char> x = line.ToCharArray().ToList();
                    if (GroupCharacters.Count == 0 && !inGroup)
                    {
                        GroupCharacters.AddRange(x);
                        inGroup = true;
                    }
                    else
                    {
                        GroupCharacters = GroupCharacters.Where(z => x.Contains(z)).ToList();
                    }
                }
            }
            return count;
        }

    }
}
