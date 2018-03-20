namespace MathAlgorithm.NUTest
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Class test method InsertNumberTest
    /// </summary>
    public class InsertNumberTest
    {
        #region test methods
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(1, 1, 0, 0, ExpectedResult = 1)]
        [TestCase(10, 8, 3, 4, ExpectedResult = 2)]
        [TestCase(-10, 8, 3, 4, ExpectedResult = -26)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(Int32.MaxValue, 0, 0, 31, ExpectedResult = 0)]
        public int InsertNumberTestCase(int numberSource, int numberIn, int startPosition, int endPosition)
        {
            return MathAlgorithm.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition);
        }

        [TestCase(5, 10, -5, 5)]
        [TestCase(5, 10, 5, -5)]
        [TestCase(5, 10, 5, 33)]
        public void InsertNumber_ThrowsArgumentOutOfRangeException(int numberSource, int numberIn, int startPosition, int endPosition)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            MathAlgorithm.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition));
        }

        [TestCase(5, 10, 7, 5)]
        public void InsertNumber_ThrowsArgumenException(int numberSource, int numberIn, int startPosition, int endPosition)
        {
            Assert.Throws<ArgumentException>(() =>
            MathAlgorithm.Math.InsertNumber(numberSource, numberIn, startPosition, endPosition));
        }
        #endregion test methods
    }
}
