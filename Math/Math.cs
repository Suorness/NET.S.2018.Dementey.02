namespace MathAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>   ///Class providing mathematical algorithms. </summary>
    public class Math
    {
        #region private const
        private const int MaxCountBit = 31;
        private const int MinCountBit = 0;
        #endregion private const

        #region public method
        /// <summary>
        /// Inserts bits of the <paramref name="numberIn"/> starting from <paramref name="startPosition"/> 
        /// to <paramref name="endPosition"/> to the <paramref name="numberSourse"/>.
        /// </summary>
        /// <param name="numberSourse">First number.</param>
        /// <param name="numberIn"> Second number.</param>
        /// <param name="startPosition">Position from which the bits are taken.</param>
        /// <param name="endPosition">Position to which bits are taken.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// (<paramref name="startPosition"/> &lt; 0) || (<paramref name="startPosition"/> &gt; 31) 
        /// || (<paramref name="endPosition"/> &lt; 0) || (<paramref name="endPosition"/> &gt; 31).
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="startPosition"/> greater than <paramref name="endPosition"/>
        /// <returns>Number.</returns>
        public static int InsertNumber(int numberSourse, int numberIn, int startPosition, int endPosition)
        {
            if ((startPosition < MinCountBit) || (endPosition < MinCountBit))
            {
                throw new ArgumentOutOfRangeException("The bit position values must be positive");
            }

            if ((startPosition > MaxCountBit) || (endPosition > MaxCountBit))
            {
                throw new ArgumentOutOfRangeException("The bit positions must be less than {maxCountBit}");
            }

            if (startPosition > endPosition)
            {
                throw new ArgumentException("Start bit position cannot be greater than end position.");
            }

            int mask = ~0 << ((endPosition - startPosition == MaxCountBit) ? MaxCountBit : (endPosition - startPosition + 1));

            for (int i = 0; i < startPosition; i++)
            {
                mask = (mask << 1) + 1;
            }

            numberIn <<= startPosition;

            return (numberSourse & mask) | (numberIn & ~mask);
        }

        /// <summary>
        /// Finds the nearest largest integer that consists of digits of the original number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if source number is not positive.
        /// </exception>
        /// <returns>
        /// Nearest largest integer consisting of digits of the original number.
        /// Or -1 if a required number does not exist.
        /// </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            int result = -1;
            var numbers = number.ToString().ToCharArray();

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    var swapIndex = i;
                    for (int j = i; j < numbers.Length - 1; j++)
                    {
                        if ((numbers[swapIndex] >= numbers[j]) && (numbers[j] > numbers[i - 1]))
                        {
                            swapIndex = j;
                        }
                    }

                    var temp = numbers[i - 1];
                    numbers[i - 1] = numbers[swapIndex];
                    numbers[swapIndex] = temp;

                    Array.Sort(numbers, i, numbers.Length - i);
                    var successConversion = int.TryParse(new string(numbers), out result);
                    if (!successConversion)
                    {
                        result = -1;
                    }

                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the nearest largest integer that consists of digits of the original number.
        /// </summary>
        /// <param name="number">Number.</param>
        /// <param name="time"> Time spent on the operation.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if source number is not positive.
        /// </exception>
        /// <returns>
        /// Nearest largest integer consisting of digits of the original number.
        /// Or -1 if a required number does not exist.
        /// </returns>
        public static int FindNextBiggerNumber(int number, out TimeSpan time)
        {
            var watcher = Stopwatch.StartNew();
            var result = FindNextBiggerNumber(number);
            watcher.Stop();
            time = watcher.Elapsed;

            return result;
        }

        /// <summary>
        /// Filters the array, so that only numbers satisfying the predicate remain on the output.
        /// </summary>
        /// <param name="numbers">Numbers to search..</param>
        /// <param name="digit">Number for search.</param>
        /// <exception cref="ArgumentException">
        /// (<paramref name="digit"/> &lt; 0) || (<paramref name="digit"/> &gt; 9) 
        /// Throws when number to search for more than 9 or less 0.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throws when predicate or numbers are null.
        /// </exception>
        /// <returns>
        /// List of numbers containing the search character.
        /// </returns>
        public static List<int> FilterDigit(List<int> numbers, int digit)
        {
            if (ReferenceEquals(numbers, null))
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if ((digit > 9) || (digit < 0))
            {
                throw new ArgumentException(nameof(digit));
            }

            var resultList = new List<int>();

            foreach (var number in numbers)
            {
                if (number.ToString().Contains(digit.ToString()))
                {
                    resultList.Add(number);
                }
            }

            return resultList;
        }

        /// <summary>
        /// Calculates the root of the nth power from the number by the Newton method with a given epsilon. </summary>
        /// <param name="number">Source number</param>
        /// <param name="power">Power of root</param>
        /// <param name="epsilon">Accuracy</param>
        /// <exception cref="ArgumentException">
        /// Throws if power or accuracy is not positive, or
        /// number equals zero, or
        /// number is negative and power is even, or
        /// epsilon less then zero.</exception>
        /// <returns>
        /// The root of the nth power from the number</returns>
        public static double FindNthRoot(double number, int power, double epsilon = 0.01)
        {
            if (epsilon <= 0)
            {
                throw new ArgumentException(nameof(epsilon));
            }

            if (number < 0 && power % 2 == 0)
            {
                throw new ArgumentException(nameof(number));
            }

            if (power < 0)
            {
                throw new ArgumentException(nameof(power));
            }

            double x;
            double xi = number / power;

            do
            {
                x = xi;
                xi = GetNextIteration(number, x, power);
            }
            while (System.Math.Abs(xi - x) > epsilon);

            return System.Math.Round(xi, epsilon.ToString().Length - 2);
        }
        #endregion public method

        #region private method
        private static double GetNextIteration(double number, double x, int power)
        {
            return (1.0 / power) * (((power - 1) * x) + (number / System.Math.Pow(x, power - 1)));
        }
        #endregion private method
    }
}
