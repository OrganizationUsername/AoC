using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public static class Day5
    {

        public const int RowCount = 128;
        public const int ColumnCount = 8;

        public static List<string> RealData()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"AoC- Day 5.txt";
            return File.ReadAllLines(FilePath).ToList();
        }

        public static int GetRowID(string ID)
        {
            List<int> rows = Enumerable.Range(0, RowCount).ToList();
            for (int i = 0; i < 7; i++)
            {
                int count = rows.Count;
                if (ID[i].ToString() == "F")
                {
                    rows.RemoveRange((count + 1) / 2, count / 2);
                }
                else
                {
                    rows.RemoveRange(0, count / 2);
                }
            }
            return rows.First();
        }
        public static int GetColumnID(string ID)
        {
            List<int> rows = Enumerable.Range(0, ColumnCount).ToList();
            for (int i = 7; i < 10; i++)
            {
                int count = rows.Count;
                if (ID[i].ToString() == "L")
                {
                    rows.RemoveRange((count + 1) / 2, count / 2);
                }
                else
                {
                    rows.RemoveRange(0, count / 2);
                }
            }
            return rows.First();
        }

        public static int GetMaxSeatID(List<string> Lines)
        {
            return Lines.Max(x => GetSeatID(x));
        }

        public static int GetSeatID(string ID)
        {
            return GetRowID(ID) * 8 + GetColumnID(ID);
        }

    }
}
