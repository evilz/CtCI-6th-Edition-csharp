using NUnit.Framework;

namespace UniqueChar
{
    public static class StringHelper
    {
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
    }
}
