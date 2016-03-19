using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArraysAndStrings
{
    //Design an algorithm and write code to remove the duplicate characters in a string
    // without using any additional buffer.NOTE: One or two additional variables are fine.
    // An extra copy of the array is not.
    public static class RemoveDuplicateExt
    {
        public static char nullChar = (char) 257;

        // O(3n) => O(n)
        public static char[] RemoveDuplicateAsciiChar(this char[] source)
        {
            if(source == null) return source;

            var existingCharMap = new bool[127];

            // O(n)
            for (int i = 0; i < source.Length; i++)
            {
                var currentChar = source[i];
                if (existingCharMap[currentChar])
                {
                    source[i] = nullChar;
                }
                existingCharMap[currentChar] = true;
            }

            int j = 0;
            // O(n)
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != nullChar)
                {
                    source[j] = source[i];
                    j++;
                }
            }

            // ~O(n)
            for (; j < source.Length; j++)
            {
                source[j] = ' ';
            }

            return source;
            
        }
    }

    public class RemoveDuplicateTests
    {
        [TestCase("a", ExpectedResult = "a")]
        [TestCase("aa", ExpectedResult = "a ")]
        [TestCase("abcdab", ExpectedResult = "abcd  ")]
        [TestCase("abcdabe", ExpectedResult = "abcde  ")]
        public string RemoveDuplicate_test(string input)
        {
            return new string(input.ToCharArray().RemoveDuplicateAsciiChar());
        }

        [Test]
        public void RemoveDuplicate_should_return_null_when_input_is_null()
        {
            Assert.That(RemoveDuplicateExt.RemoveDuplicateAsciiChar(null),Is.Null);
        }
    }
}
