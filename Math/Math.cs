using System;

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


            int mask = ~0 << (endPosition - startPosition + 1);

            for (int i = 0; i < startPosition; i++)
            {
                mask = (mask << 1) + 1;
            }


            numberIn <<= startPosition;

            return (numberSourse & mask) | (numberIn & ~mask);
        }
    }
}
