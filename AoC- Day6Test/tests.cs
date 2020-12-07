using Microsoft.VisualStudio.TestTools.UnitTesting;
using AoC;
using System.Collections.Generic;
using System.Linq;

namespace AoC__Day6Test
{
    [TestClass]
    public class tests
    {
        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(11, AoC.Day6.Part1(AoC.Day6.TestData()));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(6, AoC.Day6.Part2(AoC.Day6.TestData()));
        }
    }

    [TestClass]
    public class Day5
    {
        [TestMethod]
        public void RowTest()
        {
            Assert.AreEqual(44, AoC.Day5.GetRowID("FBFBBFFRLR"));
        }

        [TestMethod]
        public void ColumnTest()
        {
            Assert.AreEqual(5, AoC.Day5.GetColumnID("FBFBBFFRLR"));
        }

        [TestMethod]
        public void SeatNumberTest1()
        {
            Assert.AreEqual(357, AoC.Day5.GetSeatID("FBFBBFFRLR"));
            Assert.AreEqual(567, AoC.Day5.GetSeatID("BFFFBBFRRR"));
            Assert.AreEqual(119, AoC.Day5.GetSeatID("FFFBBBFRRR"));
            Assert.AreEqual(820, AoC.Day5.GetSeatID("BBFFBBFRLL"));
        }

        [TestMethod]
        public void Part1()
        {
            List<string> Lines = AoC.Day5.RealData();
            int maxResult = Lines.Max(x => AoC.Day5.GetSeatID(x));
            Assert.AreEqual(883, maxResult);
        }

        [TestMethod]
        public void MinID()
        {
            List<string> Lines = AoC.Day5.RealData();
            int minResult = Lines.Min(x => AoC.Day5.GetSeatID(x));
            Assert.AreEqual(85, minResult);
            List<int> Numbers = Lines.Select(x => AoC.Day5.GetSeatID(x)).Distinct().ToList(); ;
            int maxResult = Lines.Max(x => AoC.Day5.GetSeatID(x));
            int Missing = Enumerable.Range(minResult, maxResult + 1).Except(Numbers).First();
            Assert.AreEqual(532, Missing);
        }
    }
}
