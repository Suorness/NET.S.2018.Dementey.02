namespace MathAlgorithm.NUTest
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Class test method FindNthRoot
    /// </summary>
    public class FindNthRootTest
    {
        #region test methods
        [TestCase(1, 5, 0.0000001)]
        [TestCase(4, 2, 0.00001)]
        [TestCase(27, 3, 0.00001)]
        [TestCase(0.001, 3, 0.00001)]
        [TestCase(-8, 1, 0.00001)]
        [TestCase(4, 2, 0.0001)]
        [TestCase(25, 5, 0.0001)]
        [TestCase(25, 2, 0.0001)]
        [TestCase(0.25, 5, 0.0001)]
        [TestCase(0.25, 25, 0.0001)]
        [TestCase(1, 5, 0.0001)]
        [TestCase(8, 3, 0.0001)]
        [TestCase(0.001, 3, 0.0001)]
        [TestCase(0.04100625, 4, 0.0001)]
        [TestCase(8, 3, 0.0001)]
        [TestCase(0.0279936, 7, 0.0001)]
        [TestCase(0.0063, 4, 0.1)]
        [TestCase(0.00646812, 9, 0.00000001)]
        [TestCase(0.0081, 4, 0.000000001)]
        public void FindNthRoot(double number, int power, double epsilon)
        {
            Assert.IsTrue((MathAlgorithm.Math.FindNthRoot(number, power, epsilon) - System.Math.Pow(number, 1.0 / power)) < epsilon);
        }

        [TestCase(5, 2, -0.01)]
        [TestCase(-4, 2, 0.00001)]
        [TestCase(5, -2, 0.01)]
        public void FindNthRoot_ThrowsArgumentException(double number, int power, double epsilon)
        {
            Assert.Throws<ArgumentException>(() => MathAlgorithm.Math.FindNthRoot(number, power, epsilon));
        }
        #endregion test methods
    }
}