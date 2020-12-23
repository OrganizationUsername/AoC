using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class Day22
    {
        public List<int> Player1 = new List<int>();
        public List<int> Player2 = new List<int>();
        public static List<string> TestData()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"AoC- Day 22- Test Data.txt";
            return File.ReadAllLines(FilePath).ToList();
        }

        public static List<string> RealData()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"AoC- Day 22.txt";
            return File.ReadAllLines(FilePath).ToList();
        }

        public bool Compare()
        {
            if (Player1.Count == 0 || Player2.Count == 0)
            {
                return false;
            }
            else
            {
                if (Player1.First() > Player2.First())
                {
                    Player1.Add(Player1.First());
                    Player1.Add(Player2.First());
                }
                else
                {
                    Player2.Add(Player2.First());
                    Player2.Add(Player1.First());
                }
                Player1.RemoveAt(0);
                Player2.RemoveAt(0);
                return true;
            }
        }

        public int ScoreWinner()
        {
            List<int> result = (Player1.Count == 0) ? Player2.ToList() : Player1.ToList();
            int counter = 0;
            int val = 0;
            while (result.Count > 0)
            {
                counter++;
                val += result[result.Count - 1] * counter;
                result.RemoveAt(result.Count - 1);
            }
            return val;
        }

        public void LoadData(List<string> data)
        {

            bool PlayOne = true;
            foreach (var line in data)
            {
                if (line.Contains("Player 2:"))
                {
                    PlayOne = false;
                }
                if (int.TryParse(line, out int result))
                {
                    if (PlayOne)
                    {
                        Player1.Add(result);
                    }
                    else
                    {
                        Player2.Add(result);
                    }
                }
            }
        }
    }
}
