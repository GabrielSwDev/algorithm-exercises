using System;
using Xunit;

namespace Algoritm.Intermidiate.Src
{
    public class MinimunSubArray
    {
        [Theory]
        [InlineData(new int[] { 2, 3, 1, 2, 4, 3 }, 7, 2)]
        [InlineData(new int[] { 1, 4, 4 }, 4, 1)]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 11, 0)]
        public void Execute(int[] input, int target, int expected)
        {
            int sum = 0, left = 0, right = 0;
            int result = int.MaxValue;

            while (right < input.Length)
            {
                var current = input[right];
                sum += current;

                if (sum == target)
                    result = Math.Min((right - left) + 1, result);

                while (sum >= target)
                {
                    current = input[left];
                    sum -= current;
                    left++;

                    if (sum == target)
                        result = Math.Min((right - left) + 1, result);
                }

                right++;
            }

            if (result == int.MaxValue)
                result = 0;

            Assert.Equal(expected, result); 
        }
    }
}
