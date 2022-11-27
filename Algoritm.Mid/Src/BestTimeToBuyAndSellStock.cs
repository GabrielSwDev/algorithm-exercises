using System;
using Xunit;

namespace Algoritm.Intermidiate.Src
{
    public class BestTimeToBuyAndSellStock
    {
        [Theory]
        [InlineData(new int[] { 10, 4, 11, 1, 5 }, 7)]
        [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        public void Execute(int[] input, int expected)
        {

            int min = int.MaxValue, max = int.MinValue, profit = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int pointer = input[i];
                //we got a new minimum so let reset max
                if (pointer < min)
                {
                    min = pointer;
                    max = 0;
                }
                else
                    max = Math.Max(pointer, max);
                
                if (max > min)
                {
                    profit = Math.Max(profit, CalculateProfit(min, max));
                }
            }

            int CalculateProfit(int min, int max) => max - min;
            Assert.Equal(expected, profit);
        }
    }
}
