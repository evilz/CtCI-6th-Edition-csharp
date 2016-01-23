using System.Linq;
using Microsoft.SqlServer.Server;
using NUnit.Framework;

namespace UniqueChar
{
    public static class StringHelper
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
        

        // O(n log2(n))
        public static bool HasUniqueCharByOrdering(this string source)
        {
           var orderedSource = source.OrderBy(c => c).ToArray();
            for (int i = 0; i < orderedSource.Length -1; i++)
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
                var i = 1 << (c - 'a');

                if ((existingChar & i) > 0) return false;
                existingChar |= i;
            }
            return true;
        }
    }


    public class StringHelperTests
    {
        [TestCase("abcdefghij",true)]
        [TestCase("aa",false)]
        [TestCase("abcdefghijabcdefghij", false)]
        public void HasUniqueChar_Tests(string source,bool expected)
        {
            Assert.That(source.HasUniqueChar(), Is.EqualTo(expected));
        }

        [TestCase("abcdefghij", true)]
        [TestCase("aa", false)]
        [TestCase("abcdefghijabcdefghij", false)]
        public void HasUniqueLowerChar_Tests(string source, bool expected)
        {
            Assert.That(source.HasUniqueLowerChar(), Is.EqualTo(expected));
        }


        [TestCase("abcdefghij", true)]
        [TestCase("aa", false)]
        [TestCase("abcdefghijabcdefghij", false)]
        public void HasUniqueCharByOrdering_Tests(string source, bool expected)
        {
            Assert.That(source.HasUniqueCharByOrdering, Is.EqualTo(expected));
        }
    }
}
