using System;
using System.Diagnostics;

namespace Math
{
    public class Math
    {
        public static int InsertNumber(int numberSourse, int numberIn, int startPosition, int endPosition)
        {
            const int maxCountBit = sizeof(int) * 8 - 1;
            const int minCountBit = 0;

            if ((startPosition < minCountBit) || (endPosition < minCountBit))
            {
                throw new ArgumentOutOfRangeException("The bit position values must be positive");
            }

            if ((startPosition > maxCountBit) || (endPosition > maxCountBit))
            {
                throw new ArgumentOutOfRangeException("The bit positions must be less than {maxCountBit}");
            }

            if (startPosition > endPosition)
            {
                throw new ArgumentException("Start bit position cannot be greater than end position.");
            }

            int mask = ~0 << ((endPosition - startPosition == maxCountBit) ? maxCountBit : (endPosition - startPosition + 1));

            for (int i = 0; i < startPosition; i++)
            {
                mask = (mask << 1) + 1;
            }

            numberIn <<= startPosition;

            return (numberSourse & mask) | (numberIn & ~mask);
        }

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
                    var successConversion = Int32.TryParse(new string(numbers), out result);
                    if (!successConversion)
                    {
                        result = -1;
                    }
                    break;
                }
            }

            return result;
        }

        public static int FindNextBiggerNumber(int number, out TimeSpan time)
        {
            var watcher = Stopwatch.StartNew();
            var result = FindNextBiggerNumber(number);
            watcher.Stop();
            time = watcher.Elapsed;
            
            return result;
            
        }


    }
}
