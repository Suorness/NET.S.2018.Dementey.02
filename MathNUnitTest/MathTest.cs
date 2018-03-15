using NUnit.Framework;
using System;

namespace MathNUnitTest
{
    public class InsertNumberTest
    {

        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(1, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(10, 8, 3, 4, ExpectedResult = 2)]
        [TestCase(-10, 8, 3, 4, ExpectedResult = -26)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(Int32.MaxValue, 0, 0, 31, ExpectedResult = 0)]
        public int InsertNumberTestCase(int numberSource, int numberIn, int startPosition, int endPosition)
        {
            return Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);
        }



        [TestCase(5, 10, -5, 5)]
        [TestCase(5, 10, 5, -5)]
        [TestCase(5, 10, 5, 33)]
        public void InsertNumber_ThrowsArgumentOutOfRangeException(int numberSource, int numberIn, int startPosition, int endPosition)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition));
        }


        [TestCase(5, 10, 7, 5)]

        public void InsertNumber_ThrowsArgumenException(int numberSource, int numberIn, int startPosition, int endPosition)
        {
            Assert.Throws<ArgumentException>(() => Math.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition));

        }

    }

    public class FindNextBiggerNumberTest
    {
        [TestCase(13, ExpectedResult = 31)]
        [TestCase(1391, ExpectedResult = 1913)]
        [TestCase(63932, ExpectedResult = 69233)]
        [TestCase(849876543, ExpectedResult = 853446789)]
        [TestCase(301, ExpectedResult = 310)]
        [TestCase(Int32.MaxValue, ExpectedResult = -1)]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(300, ExpectedResult = -1)]
        
        public int FindNextBiggerNumberTestCase(int number)
        {
            return Math.Math.FindNextBiggerNumber(number);
        }


        [TestCase(-5)]
        [TestCase(-414)]
        public void FindNextBiggerNumber_ThrowsArgumentOutOfRangeException(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.Math.FindNextBiggerNumber(number));
        }

    }
}
