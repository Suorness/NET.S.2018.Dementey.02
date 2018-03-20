namespace MathAlgorithm.NUTest
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Class test method FilterDigit
    /// </summary>
    public class FilterDigitTest
    {
        #region tests methods
        [TestCase(new int[] { 8, 16, 23, 42 }, 8, ExpectedResult = new int[] { 8 })]
        [TestCase(new int[] { 8, 18, 28, 48 }, 8, ExpectedResult = new int[] { 8, 18, 28, 48 })]
        [TestCase(new int[] { -18, 1, 2, 4 }, 8, ExpectedResult = new int[] { -18 })]
        [TestCase(new int[] { -18, 18, 18, 8 }, 8, ExpectedResult = new int[] { -18, 18, 18, 8 })]
        [TestCase(new int[] { 0, 0, 10, 300 }, 0, ExpectedResult = new int[] { 0, 0, 10, 300 })]
        public int[] FilterDigitTestCase(int[] numbers, int digit)
        {
            return MathAlgorithm.Math.FilterDigit(new List<int>(numbers), digit).ToArray();
        }

        [TestCase(new int[] { 8, 16, 23, 42 }, 5)]
        public void FilterDigit_EmptyListReturn(int[] numbers, int digit)
        {
            var result = MathAlgorithm.Math.FilterDigit(new List<int>(numbers), digit);

            Assert.IsEmpty(result);
        }

        [TestCase(null, 5)]
        public void FilterDigit_ThrowsArgumentNullException(List<int> numbers, int digit)
        {
            Assert.Throws<ArgumentNullException>(() =>
            MathAlgorithm.Math.FilterDigit(numbers, digit));
        }

        [TestCase(new int[] { 8, 16, 23, 42 }, -5)]
        [TestCase(new int[] { 8, 16, 23, 42 }, -15)]
        [TestCase(new int[] { 8, 16, 23, 42 }, 15)]
        public void FilterDigit_ThrowsArgumentException(int[] numbers, int digit)
        {
            Assert.Throws<ArgumentException>(() =>
            MathAlgorithm.Math.FilterDigit(new List<int>(numbers), digit));
        }
        #endregion tests methods
    }
}
