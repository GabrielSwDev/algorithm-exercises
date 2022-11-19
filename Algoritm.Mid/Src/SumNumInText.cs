using Xunit;
using System.Linq;

namespace Algoritm.Mid.Src
{
    public class SumNumInText
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("2,8, 1,3", 14)]
        [InlineData("1,7, ab,", 8)]
        public void Execute(string text, int expected)
        {
            var result = text.Trim().Split(",").Sum(n => ToNumber(n));

            int ToNumber(string str)
            {
                int.TryParse(str, out int castedNumber);
                return castedNumber;
            }

            Assert.Equal(expected, result);
        }
    }
}