using Xunit;

namespace Algorithm.Entry.Src
{
    public class BinarySearch
    {

        [Theory]
        [InlineData(new[] { 1, 8, 9, 12, 22, 55 }, 22, 4)]
        public void Execute(int[] arr, int target, int expected)
        {
            var result = DoBinarySearch(arr, 0, arr.Length, target);

            static int DoBinarySearch(int[] arr, int l, int r, int target)
            {
                if (r < 1)
                    return -1;

                var mid = l + (r - 1) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                }

                if (arr[mid] > target)
                    return DoBinarySearch(arr, l, mid - 1, target);


                return DoBinarySearch(arr, mid + 1, r, target);
            }


            Assert.Equal(expected, result);
        }
    }
}
