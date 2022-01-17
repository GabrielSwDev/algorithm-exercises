using Xunit;


namespace Algorithm.Entry.Src
{

    public class CenturyFromYear
    {

        [Theory]
        [InlineData(202, 3)]
        [InlineData(88, 1)]
        [InlineData(101, 2)]
        public void Execute(int years, int expected)
        {

            const ushort YEARS_IN_CENTURY = 100;

            var centuryFromYears = System.Math.Ceiling((double)years / YEARS_IN_CENTURY);

            Assert.Equal(expected, centuryFromYears);
        }

    }
}
