using System.Linq;
using Xunit;

namespace Algorithm.Entry.Src
{
    public class ArrayRotationTest
    {

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 5, 1, 2, 3, 4 })]
        public void Rotate_Array(int[] array, int rotationQty, int[] expected)
        {
            var numCollection = array.ToList();

            while (rotationQty > 0)
            {
                var itemToRemoved = numCollection[0];
                numCollection.Remove(itemToRemoved);

                numCollection.Add(itemToRemoved);
                rotationQty--;
            }




            Assert.Equal(expected, numCollection);
        }


    }
}
