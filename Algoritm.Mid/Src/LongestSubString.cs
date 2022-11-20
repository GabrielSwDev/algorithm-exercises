using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algoritm.Intermidiate.Src
{
    /// <summary>
    /// Given a string, inputString find the longest substring without repeating characters,
    /// and return the length of that longest substring.
    /// </summary>
    public class LongestSubString
    {
        [Theory]
        [InlineData("abcdbea", 5)]
        [InlineData("aaaaaaaa", 1)]
        [InlineData("abccabcabcc", 1)]

        public void Execute(string s, int expected)
        {
            //start with 2 pointers & 1 hash 
            //only move right p until you got a repeated letter
            //pull out from hash the char in left pointer

            HashSet<char> counter = new();
            int left = 0, right = 0;
            int result = 0;

            if (string.IsNullOrEmpty(s))
            {
                 result = 0;
                goto Exit;
            }


            while (right < s.Length)
            {
                var current = s[right];

                if (!counter.Contains(current))
                {
                    counter.Add(current);
                    right++;
                }
                else
                {
                    current = s[left];
                    counter.Remove(current);
                    left++;
                }

                result = Math.Max(result, counter.Count);
            }

           

            Exit:
            Assert.Equal(expected, result);
        }

    }
}
