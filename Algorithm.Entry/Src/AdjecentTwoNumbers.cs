using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Entry.Src
{
    public class AdjecentTwoNumbers
    {
        /// <summary>
        /// Find the two numbers that produce the highest product
        /// 7 and 3 produce the largest product = 21
        /// </summary>
        [Fact]
        public void Execute()
        {
            var arr = new List<int>() { 3, 6, -2, -5, 7, 3 };
            var result = arr[0] * arr[1];

            for (int i = 1; i < arr.Count - 1; i++)
            {
                result = Math.Max(result, (arr[i] * arr[i + 1]));
            }


            Assert.Equal(expected: 21, result);
        }
    }
}
