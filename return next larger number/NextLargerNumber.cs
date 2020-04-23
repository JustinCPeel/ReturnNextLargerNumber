using System;
using NUnit;
using NUnit.Framework;

namespace ReturnNextLargerNumber
{
	[TestFixture]
	public class NextLargerNumber
	{
		[Test]
		public void GivenNumber_12NextLargerNumber_ShouldReturn21()
		{
			//arrange
			var number = 12;

			//act
			var expected = 21;
			var actual = FindNextLargerNumber(number);

			//assert
			Assert.AreEqual(expected, actual);
		}

        [Test]
        public void GivenNumber_513NextLargerNumber_ShouldReturn531()
        {
            //arrange
            var number = 513;

            //act
            var expected = 531;
            var actual = FindNextLargerNumber(number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_2017NextLargerNumber_ShouldReturn2071()
        {
            //arrange
            var number = 2017;

            //act
            var expected = 2071;
            var actual = FindNextLargerNumber(number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_9NextLargerNumber_ShouldReturnNegative1()
        {
            //arrange
            var number = 9;

            //act
            var expected = -1;
            var actual = FindNextLargerNumber(number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_111NextLargerNumber_ShouldReturnNegative1()
        {
            //arrange
            var number = 111;

            //act
            var expected = -1;
            var actual = FindNextLargerNumber(number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenNumber_531NextLargerNumber_ShouldReturnNegative1()
        {
            //arrange
            var number = 531;

            //act
            var expected = -1;
            var actual = FindNextLargerNumber(number);

            //assert
            Assert.AreEqual(expected, actual);
        }

        private int FindNextLargerNumber(int number)
		{
            int[] digits = new int[10];

            int length = 0;
            while (number > 0)
            {
                digits[length++] = (number % 10);
                number /= 10;
            }

            Array.Reverse(digits, 0, length);

            int swapPos = -1;
            for (int i = length - 2; (i >= 0) && (swapPos == -1); i--)
                if (digits[i] < digits[i + 1]) swapPos = i;

            if (swapPos == -1) 
                return -1;

            int swapPos2 = -1;
            int min = int.MaxValue;
            for (int i = swapPos + 1; i < length; i++)
            {
                if ((digits[i] > digits[swapPos]) && (digits[i] < min))
                {
                    min = digits[i];
                    swapPos2 = i;
                }
            }

            int bTemp = digits[swapPos];
            digits[swapPos] = digits[swapPos2];
            digits[swapPos2] = bTemp;

            Array.Sort(digits, swapPos + 1, length - swapPos - 1);

            for (int i = 0; i < length; i++)
                number = number * 10 + digits[i];

            return number;
        }
	}
	
}
