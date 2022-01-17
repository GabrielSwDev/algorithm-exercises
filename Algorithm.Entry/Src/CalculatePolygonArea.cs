using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithm.Entry.Src
{
    /// <summary>
    /// Below we will define an n-interesting polygon. Your task is to find the area of a polygon for a given n.
    //A 1-interesting polygon is just a square with a side of length 1. An n-interesting polygon is obtained
    //by taking the n - 1-interesting polygon and appending 1-interesting polygons to its rim,
    //side by side.You can see the 1-, 2-, 3- and 4-interesting polygons in the picture below.
    /// </summary>
    public class CalculatePolygonArea
    {

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 5)]
        [InlineData(3, 13)]
        [InlineData(4, 25)]
        [InlineData(5, 41)]
        public void Execute(int n, int expected)
        {
            /*
             n1 = 1,
             n2 = 1 + 4 
             n3 = 4 + 9
             pattern = previous value powen 2 + n power 2
             */

            var result = Convert.ToInt32(Math.Pow(n - 1, 2) + Math.Pow(n, 2));

            Assert.Equal(expected, result);
        }

    }
}
