using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MathMsUnitTest
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void InsertNumber_8insert15from0to0_9returned()
        {
            int numberSource = 8, numberIn = 15;
            int startPosition = 0, endPosition = 0;
            int expected = 9;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [TestMethod]
        public void InsertNumber_1insert1from0to0_1returned()
        {
            int numberSource = 1, numberIn = 1;
            int startPosition = 0, endPosition = 0;
            int expected = 1;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [TestMethod]
        public void InsertNumber_10insert8from3to4_2returned()
        {
            int numberSource = 10, numberIn = 8;
            int startPosition = 3, endPosition = 4;
            int expected = 2;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [TestMethod]
        public void InsertNumber_negative10insert8from3to4_negative26returned()
        {
            int numberSource = -10, numberIn = 8;
            int startPosition = 3, endPosition = 4;
            int expected = -26;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [TestMethod]
        public void InsertNumber_8insert15from3to8_negative120returned()
        {
            int numberSource = 8, numberIn = 15;
            int startPosition = 3, endPosition = 8;
            int expected = 120;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }




    }
}
