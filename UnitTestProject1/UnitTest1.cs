using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using REG_MARK_LIB;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckMark_correctly()
        {
            string mark = "Е533ЕА152";
            bool actual = Calculation.CheckMark(mark);
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void CheckMark_NoCorrectly()
        {
            string mark = "У345AT000";
            bool actual = Calculation.CheckMark(mark);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void GetCombinationsCountInRange_NotCorrectly()
        {
            int exception = 150;
            string mark1 = "A001AA152";
            string mark2 = "A010AA152";
            int actual = Calculation.GetCombinationsCountInRange(mark1, mark2);
            Assert.IsTrue(exception != actual);
        }
        [TestMethod]
        public void GetNextMarkAfter_NoCorrectly()
        {
            string expected = "A006AA170";
            string mark = "A004AA170";
            string actual = Calculation.GetNextMarkAfter(mark);
            Assert.IsFalse(expected == actual);
        }
        [TestMethod]
        public void GetNextMarkAfter_ResultCorrectly()
        {
            string exception = "A006AA152";
            string prevMark = "A005AA152";
            string rangeStart = "A001AA152";
            string rangeEnd = "A800AB152";
            string actual = Calculation.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsTrue(exception == actual);
        }
        [TestMethod]
        public void GetNextMarkAfter_NotNull()
        {
            string mark = "A004AA170";
            string actual = Calculation.GetNextMarkAfter(mark);
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void GetNextMarkAfterInRange_NoResult()
        {
            string expected = "В115ВВ116";
            string actual = Calculation.GetNextMarkAfterInRange("ВoooВВ116", "В100ВВ116", "В130ВВ116");
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void GetCombinationsCountInRange_Result()
        {
            int expected = 85;
            int actual = Calculation.GetCombinationsCountInRange("В000ВВ152", "В085ВВ152");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCombinationsCountInRange_NoResult()
        {
            int expected = 95;
            int actual = Calculation.GetCombinationsCountInRange("В000ВВ152", "В085ВВ152");
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void CheckMark_CorrectlyType()
        {
            string mark = "А001АА152";
            bool actual = Calculation.CheckMark(mark);
            Assert.IsInstanceOfType(actual, typeof(bool));
        }
        [TestMethod]
        public void GetCombinationsCountInRange_Correctly()
        {
            int exception = 1008;
            string mark1 = "A001AA152";
            string mark2 = "A010AB152";
            int actual = Calculation.GetCombinationsCountInRange(mark1, mark2);
            Assert.AreEqual(exception, actual);
        }
        [TestMethod]
        public void GetNextMarkAfterInRange_NotCorrectlyRegion()
        {
            string exception = "out of stock";
            string prevMark = "A006AA777";
            string rangeStart = "A001AA155";
            string rangeEnd = "A800AB155";
            string actual = Calculation.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.AreEqual(exception, actual);
        }
        [TestMethod]
        public void CheckMark_NoCorrectlyRegion()
        {
            bool exception = false;
            string mark = "У345ЕT000";
            bool actual = Calculation.CheckMark(mark);
            Assert.AreEqual(exception, actual);
        }
        [TestMethod]
        public void GetNextMarkAfterInRange_NoCorrectly()
        {
            string exception = "out of stock";
            string prevMark = "A980AB777";
            string rangeStart = "A001AA777";
            string rangeEnd = "A800AB777";
            string actual = Calculation.GetNextMarkAfterInRange(prevMark, rangeStart, rangeEnd);
            Assert.IsTrue(exception == actual);
        }
        [TestMethod]
        public void GetNextMarkAfterInRange_NoResultCorrectly()
        {
            string expected = "В110аа152";
            string actual = Calculation.GetNextMarkAfterInRange("111111152", "В120аа152", "В130аа152");
            Assert.AreNotEqual(expected, actual);
        }

    }
}
