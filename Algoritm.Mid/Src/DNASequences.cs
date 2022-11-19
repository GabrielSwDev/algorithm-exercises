using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algoritm.Mid.Src
{

    public class DNASequences
    {
        [Theory]
        [InlineData("AAAAACCCCCAAAAACCCCCC", 8, new string[] { "AAAACCCC", "AAAAACCC", "AAACCCCC" })]
        [InlineData("GGGGGGGGGGGGGGGGGGGGGGGGG", 12, new string[] { "GGGGGGGGGGGG" })]
        [InlineData("", 10, new string[] {})]
        public void Execute(string input, int k, string[] expected)
        {
            var result = new HashSet<string>();
            if (string.IsNullOrEmpty(input))
            {
                goto Assert;
            }
               

            var uniqueList = new HashSet<string>();
            var windowBuilder = new StringBuilder();

            //iterate & build the first window
            for (int i = 0; i < k; i++)
            {
                windowBuilder.Append(input[i]);
            }

            uniqueList.Add(windowBuilder.ToString());

            /*to build the remaining windows
             * remove the first char from previous window and add the nth char to the new one.
             */

            for (int i = k; i < input.Length; i++)
            {
                windowBuilder.Remove(0, 1);
                windowBuilder.Append(input[i]);

                if (!uniqueList.Contains(windowBuilder.ToString()))
                    uniqueList.Add(windowBuilder.ToString());
                else if(!result.Contains(windowBuilder.ToString()))
                    result.Add(windowBuilder.ToString());
            }

            Assert:
            result.Should().BeEquivalentTo(expected);
        }
    }
}
