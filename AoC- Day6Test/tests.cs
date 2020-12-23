using Microsoft.VisualStudio.TestTools.UnitTesting;
using AoC;
using System.Collections.Generic;
using System.Linq;

namespace AoC__Day6Test
{


    [TestClass]
    public class Day22Test
    {
        [TestMethod]
        public void testReadData()
        {
            Day22 day22 = new Day22();
            day22.LoadData(Day22.TestData());
            Assert.AreEqual(5, day22.Player1.Count);
            Assert.AreEqual(5, day22.Player2.Count);
        }

        [TestMethod]
        public void testScore()
        {
            Day22 day22 = new Day22();
            day22.LoadData(Day22.TestData());
            while (day22.Compare())
            {

            }
            int score = day22.ScoreWinner();

            Assert.AreEqual(306, score);
        }

        [TestMethod]
        public void RealScore()
        {
            Day22 day22 = new Day22();
            day22.LoadData(Day22.RealData());
            while (day22.Compare())
            {

            }
            int score = day22.ScoreWinner();

            Assert.AreEqual(33400, score);
        }


    }



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


    [TestClass]
    public class Day4
    {
        [TestMethod]
        public void GetFourPassports()
        {
            List<string> TestData = AoC.Day4.TestData();
            List<List<string>> Passports = AoC.Day4.GetPassportsFromText(TestData);

            Assert.AreEqual(4, Passports.Count);
            var Requirements = AoC.Day4.GetRequiredFields();
            int GoodPassports = AoC.Day4.CountNaivelyGoodPassports(Passports, Requirements);
            Assert.AreEqual(2, GoodPassports);
        }

        [TestMethod]
        public void Part1()
        {
            List<string> TestData = AoC.Day4.RealData();
            List<List<string>> Passports = AoC.Day4.GetPassportsFromText(TestData);
            var Requirements = AoC.Day4.GetRequiredFields();
            int GoodPassports = AoC.Day4.CountNaivelyGoodPassports(Passports, Requirements);
            Assert.AreEqual(190, GoodPassports);
        }


        [TestMethod]
        public void CredentialChecker()
        {
            Assert.AreEqual(true, AoC.Day4.ValidateCredential("hgt:165cm"));
            Assert.AreEqual(false, AoC.Day4.ValidateCredential("hgt:195cm"));
            Assert.AreEqual(false, AoC.Day4.ValidateCredential("hgt:145cm"));
            Assert.AreEqual(true, AoC.Day4.ValidateCredential("hgt:70in"));
            Assert.AreEqual(false, AoC.Day4.ValidateCredential("hgt:58in"));
            Assert.AreEqual(false, AoC.Day4.ValidateCredential("hgt:77in"));
        }

        [TestMethod]
        public void Part2()
        {
            List<string> TestData = AoC.Day4.RealData();
            List<List<string>> Passports = AoC.Day4.GetPassportsFromText(TestData);
            int count = 0;
            foreach (List<string> Passport in Passports)
            {
                if (AoC.Day4.PassportValidator(Passport))
                {
                    count++;
                }
                else
                {

                }
            }
            Assert.AreEqual(121, count);
        }

    }

}
