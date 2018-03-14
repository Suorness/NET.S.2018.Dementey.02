using System;
using NUnit.Framework;

namespace MathNUnitTest
{
    public class MathTest
    {
        [Test]
        public void InsertNumber_8insert15from0to0_9returned()
        {
            int numberSource = 8, numberIn = 15;
            int startPosition = 0, endPosition = 0;
            int expected = 9;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [Test]
        public void InsertNumber_1insert1from0to0_1returned()
        {
            int numberSource = 1, numberIn = 1;
            int startPosition = 0, endPosition = 0;
            int expected = 1;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [Test]
        public void InsertNumber_10insert8from3to4_2returned()
        {
            int numberSource = 10, numberIn = 8;
            int startPosition = 3, endPosition = 4;
            int expected = 2;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [Test]
        public void InsertNumber_negative10insert8from3to4_negative26returned()
        {
            int numberSource = -10, numberIn = 8;
            int startPosition = 3, endPosition = 4;
            int expected = -26;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [Test]
        public void InsertNumber_8insert15from3to8_120returned()
        {
            int numberSource = 8, numberIn = 15;
            int startPosition = 3, endPosition = 8;
            int expected = 120;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [Test]
        public void InsertNumber_0insert0from0to0_0returned()
        {
            int numberSource = 0, numberIn = 0;
            int startPosition = 0, endPosition = 0;
            int expected = 0;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [Test]
        public void InsertNumber_MaxValueinsert0from0to0_31returned()
        {
            int numberSource = Int32.MaxValue, numberIn = 0;
            int startPosition = 0, endPosition = 31;
            int expected = 0;

            int resultValue = Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);

            Assert.AreEqual(resultValue, expected);
        }

        [Test]
        public void InsertNumber_5insert10fromNegative5to5_ArgumentOutOfRangeExceptionReturned()
        {
            int numberSource = 5, numberIn = 10;
            int startPosition = -5, endPosition = 5;

            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition));
        }

        [Test]
        public void InsertNumber_5insert10from5toNegative5_ArgumentOutOfRangeExceptionReturned()
        {
            int numberSource = 5, numberIn = 10;
            int startPosition = 5, endPosition = -5;

            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition));


        }

        [Test]
        public void InsertNumber_5insert10from7to5_ArgumentExectionReturned()
        {
            int numberSource = 5, numberIn = 10;
            int startPosition = 7, endPosition = 5;

            Assert.Throws<ArgumentException>(() => Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition));

        }
    }
}
