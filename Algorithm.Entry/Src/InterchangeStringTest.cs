using System;
using System.Text;
using Xunit;

namespace Algorithm.Entry.Src
{
    public class InterchangeStringTest
    {
        [Theory]
        [InlineData("abc", "pqr", "apbqcr")]
        [InlineData("ab", "pqrs", "apbqrs")]
        [InlineData("abcd", "pq", "apbqcd")]
        public void Interchange_Two_Words(string word1, string word2, string expected)
        {
            var result = InterchangeWord.Execute(word1, word2);
            Assert.Equal(expected, result);
        }
    }

    public static class InterchangeWord
    {
        public static string Execute(string word1, string word2)
        {
            var biggestLength = Math.Max(word1.Length, word2.Length);
            var newWordBuilder = new StringBuilder();

            void AddLetterToTheBuilder(char? letter)
            {
                if (letter != null)
                    newWordBuilder.Append(letter);
            }

            for (int i = 0; i < biggestLength; i++)
            {
                AddLetterToTheBuilder(word1.GetLetter(i));
                AddLetterToTheBuilder(word2.GetLetter(i));

            }

            return newWordBuilder.ToString();
        }

        public static char? GetLetter(this string word, int index)
        {
            if ((index + 1) > word.Length)
                return null;

            return word[index];
        }
    }
}
