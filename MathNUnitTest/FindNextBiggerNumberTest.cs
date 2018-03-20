namespace MathAlgorithm.NUTest
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Class test method FindNextBiggerNumber
    /// </summary>
    public class FindNextBiggerNumberTest
    {
        #region test methods
        [TestCase(13, ExpectedResult = 31)]
        [TestCase(1391, ExpectedResult = 1913)]
        [TestCase(63932, ExpectedResult = 69233)]
        [TestCase(849876543, ExpectedResult = 853446789)]
        [TestCase(301, ExpectedResult = 310)]
        [TestCase(int.MaxValue, ExpectedResult = -1)]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(300, ExpectedResult = -1)]

        public int FindNextBiggerNumberTestCase(int number)
        {
            return MathAlgorithm.Math.FindNextBiggerNumber(number);
        }

        [TestCase(-5)]
        [TestCase(-414)]
        public void FindNextBiggerNumber_ThrowsArgumentOutOfRangeException(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MathAlgorithm.Math.FindNextBiggerNumber(number));
        }
        #endregion test methods
    }
}