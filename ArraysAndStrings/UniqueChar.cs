using System.Linq;
using NUnit.Framework;

namespace ArraysAndStrings
{
    /// <summary>
    /// Determine if a string has all unique characters. What if  you can not use additional data structures?
    /// </summary>
    public static class UniqueChar
    {
        // O(n)
        public static bool HasUniqueChar(this string source)
        {
            var existingChar = new bool[char.MaxValue];

            foreach (var c in source)
            {
                if (existingChar[c]) return false;
                existingChar[c] = true;
            }
            return true;
        }

        // O(n lg2(n))
        public static bool HasUniqueCharByOrdering(this string source)
        {
            var orderedSource = source.OrderBy(c => c).ToArray();
            for (int i = 0; i < orderedSource.Length - 1; i++)
            {
                if (orderedSource[i] == orderedSource[i + 1]) return false;
            }
            return true;
        }

        public static bool HasUniqueLowerChar(this string source)
        {
            var existingChar = 0;

            foreach (var c in source)
            {
                var charBitIndex = 1 << (c - 'a');

                if ((existingChar & charBitIndex) > 0) return false;
                existingChar |= charBitIndex;
            }
            return true;
        }

    }

    public class UniqueCharTests
    {
        [Test]
        public void Should_be_true_when_string_is_empty()
        {
            Assert.That(string.Empty.HasUniqueChar,Is.True);
        }

        [TestCase("aaaa",ExpectedResult = false)]
        [TestCase("abcd",ExpectedResult = true)]
        [TestCase("abcda",ExpectedResult = false)]
        public bool HasUniqueChar_test(string input)
        {
            return input.HasUniqueChar();
        }

        [TestCase("aaaa", ExpectedResult = false)]
        [TestCase("abcd", ExpectedResult = true)]
        [TestCase("abcda", ExpectedResult = false)]
        public bool HasUniqueCharByOrdering_test(string input)
        {
            return input.HasUniqueCharByOrdering();
        }

        [TestCase("aaaa", ExpectedResult = false)]
        [TestCase("abcd", ExpectedResult = true)]
        [TestCase("abcda", ExpectedResult = false)]
        public bool HasUniqueLowerChar_test(string input)
        {
            return input.HasUniqueLowerChar();
        }
    }

}
