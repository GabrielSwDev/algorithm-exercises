using System.Collections.Generic;
using Xunit;

namespace Algorithm.Entry.Src
{
    public class PairMatcher
    {

        /// <summary>
        /// Dado un string formado por (), [] y {}, escribe un programa que indique si los pares
        /// correspondientes son correctos.
        /// </summary>
        [Theory]
        [InlineData("[{()}]", true)]
        [InlineData("[(]}", false)]
        public void Execute(string str, bool expected)
        {

            bool result = true;
            var stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                var currentTag = str[i];
                if (IsCloseTag(currentTag) && stack.Count > 0)
                {
                    var openTag = stack.Pop();

                    if (!IsMatch(openTag, close: currentTag))
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    stack.Push(currentTag);
                }
            }

            Assert.Equal(result, expected);

        }

        private static bool IsMatch(char open, char close)
        {

            var result = false;
            switch (open)
            {
                case '{':
                    if (close == '}')
                        result = true;
                    break;

                case '[':
                    if (close == ']')
                        result = true;
                    break;

                case '(':
                    if (close == ')')
                        result = true;
                    break;
            }

            return result;
        }

        private static bool IsCloseTag(char c)
        {
            if (c == '[' || c == '(' || c == '{')
                return false;

            return true;
        }

    }
}
