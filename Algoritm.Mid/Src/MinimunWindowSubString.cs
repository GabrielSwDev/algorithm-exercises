using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algoritm.Intermidiate.Src
{
    /// <summary>
    /// We are given two strings—s and t. We have to find the smallest window substring of t. 
    /// The smallest window substring is the shortest sequence of characters in s that includes 
    /// all of the characters present in t. 
    /// The frequency of each character in this sequence should be greater than or equal 
    /// to the frequency of each character in t. The order of the characters does not matter here.
    /// </summary>
    public class MinimunWindowSubString
    {

        [Theory]
        [InlineData("ABCD", "ABC", "ABC")]
        [InlineData("ABXYZJKLSNFC", "ABC", "ABXYZJKLSNFC")]
        [InlineData("AAAAAAAAAAA", "A", "A")]
        public void Execute(string s, string t, string expected)
        {
            var targetDict = new Dictionary<char, int>();
            var windowDict = new Dictionary<char, int>();


            //build the window
            for (int i = 0; i < t.Length; i++)
            {
                if (targetDict.ContainsKey(t[i]))
                    targetDict[t[i]]++;
                else
                    targetDict.Add(t[i], 1);

                if (!windowDict.ContainsKey(t[i]))
                    windowDict.Add(t[i], 0);
            }

            int left = 0, right = 0;

            string result = string.Empty;
            while(right < s.Length)
            {

                var currentChar = s[right];

                if (windowDict.ContainsKey(currentChar))
                {
                    windowDict[currentChar]++;
                }

                if(!windowDict.Any(e => e.Value == 0) && CompareDict(windowDict, targetDict))
                {
                    currentChar = s[left];
                    if (windowDict.ContainsKey(currentChar))
                        windowDict[currentChar]--;

                    result = s.Substring(left, (right - left) + 1);

                    left++;
                    if(left > right)
                        right = left;
                }
                else
                    right++;
            }

            Assert.Equal(expected, result);
            
        }

        private bool CompareDict(Dictionary<char, int> dict1, Dictionary<char, int> dict2) {

            if (dict1 == dict2) return true;
            if ((dict1 == null) || (dict2 == null)) return false;
            if (dict1.Count != dict2.Count) return false;

            var valueComparer = EqualityComparer<int>.Default;

            foreach (var kvp in dict1)
            {
                int value2;
                if (!dict2.TryGetValue(kvp.Key, out value2)) return false;
                if (!valueComparer.Equals(kvp.Value, value2)) return false;
            }
            return true;

        }

    }
}
