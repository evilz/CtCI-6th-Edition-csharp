using System.Linq;
using NUnit.Framework;

namespace ArraysAndStrings
{
    // Write a method to decide if two strings are anagrams or not.
    public static class AreAnagramsExt
    {
        // O(2n lg(n) )
        public static bool IsAnagramOf(this string s1, string s2)
        {
            if (s1 == null) { return s2 == null; }
            if (s1.Length != s2.Length) { return false; }

            var sortedS1 = s1.OrderBy(c => c).ToArray();
            var sortedS2 = s1.OrderBy(c => c).ToArray();

            for (int i = 0; i < sortedS1.Length; i++)
            {
                if (sortedS1[i] != sortedS2[i])
                { return false; }
            }
            return true;
        }

        // O(127 + n)
        public static bool IsAnagramOfAscii(this string s1, string s2)
        {
            if (s1 == null) { return s2 == null; }
            if (s1.Length != s2.Length) { return false; }
            
            var s1Letter = new int[127]; // <= bad toooooooo big
            var s2Letter = new int[127];
            
            for (int i = 0; i < s1.Length; i++)
            {
                s1Letter[s1[i]]++; 
                s2Letter[s2[i]]++;
            }

            for (var i = 0; i < s1Letter.Length; i++) // <= always 127 times
            {
                if (s1Letter[i] != s2Letter[i])
                {
                    return false;
                }
            }


            return true;
        }
    }

    public class AreAnagramsTests
    {
        [TestCase("mary", "army", ExpectedResult = true)]
        [TestCase("mary", "ay", ExpectedResult = false)]
        [TestCase(null, null, ExpectedResult = true)]
        public bool AreAnagrams_test(string s1, string s2)
        {
            return s1.IsAnagramOf(s2);
        }

        [TestCase("mary", "army", ExpectedResult = true)]
        [TestCase("mary", "ay", ExpectedResult = false)]
        [TestCase(null, null, ExpectedResult = true)]
        public bool AreAnagrams2_test(string s1, string s2)
        {
            return s1.IsAnagramOfAscii(s2);
        }

    }
}
