using System.Linq;
using NUnit.Framework;

namespace ArraysAndStrings
{
    /// <summary>
    /// Check if one string is a permutation of another one
    /// </summary>
    public static class CheckPermutation
    {
        // O(3n lg(n))
        public static bool IsPermutationOf_sort(this string source, string other)
        {
            if (source.Length != other.Length) { return false; }

            var sortedSource = source.OrderBy(c => c).ToArray();
            var sortedOther = other.OrderBy(c => c).ToArray();
            for (int i = 0; i < source.Length; i++)
            {
                if (sortedSource[i] != sortedOther[i])
                    return false;
            }
            return true;

        }

        // O(3n)
        public static bool IsPermutationOf(this string source, string other)
        {
            if (source.Length != other.Length) { return false; }

            var charMap = new int[char.MaxValue];

            foreach (var c in source)
            {
                charMap[c]++;
            }

            foreach (var c in other)
            {
                charMap[c]--;
            }

            return charMap.All(i => i == 0);
        }
    }

    public class IsPermutationTests
    {
        [Test]
        public void Should_be_true_when_string_is_empty()
        {
            Assert.That(string.Empty.IsPermutationOf_sort(string.Empty), Is.True);
            Assert.That(string.Empty.IsPermutationOf(string.Empty), Is.True);
        }

        [TestCase("apple", "papel", ExpectedResult = true)]
        [TestCase("carrot", "tarroc", ExpectedResult = true)]
        [TestCase("hello", "llloh", ExpectedResult = false)]
        public bool IsPermutationOf_sort_test(string input,string other)
        {
            return input.IsPermutationOf_sort(other);
        }

        [TestCase("apple", "papel", ExpectedResult = true)]
        [TestCase("carrot", "tarroc", ExpectedResult = true)]
        [TestCase("hello", "llloh", ExpectedResult = false)]
        public bool IsPermutationOf_test(string input, string other)
        {
            return input.IsPermutationOf(other);
        }
    }
}
