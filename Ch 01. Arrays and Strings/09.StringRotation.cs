using NUnit.Framework;

namespace ArraysAndStrings
{
    public static class StringRotation
    {
        public static bool IsRotationOf(this string source, string other)
        {
            var doubleString = source + source;
            return other.IsSubstring(doubleString);
        }
        
        private static bool IsSubstring(this string source, string other)
        {
           return other.Contains(source);
        }
    }

    public class StringRotationTests
    {
        [TestCase("waterbottle", "erbottlewat", ExpectedResult = true)]
        [TestCase("abcd", "cdab", ExpectedResult = true)]
        [TestCase("abcd", "acdb", ExpectedResult = false)]
        public bool Shoud_return_true_when_other_a_rotation_of_source(string source, string other)
        {
            return other.IsRotationOf(source);
        }
    }
}
