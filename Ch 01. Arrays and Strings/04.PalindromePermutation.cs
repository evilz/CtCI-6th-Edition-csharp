using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArraysAndStrings
{
    public static class PalindromePermutationExt
    {
        public static bool IsPalindromePermutation(this string source)
        {
            var cleanSource = source.ToLowerInvariant().Replace(" ", string.Empty);

            var groupByChar = cleanSource.GroupBy(c => c).ToDictionary(g => g.Key,g => g.Count());


            // odd
            var hasOddCountOfChar = cleanSource.Length % 2 == 1;

            if (hasOddCountOfChar)
            {
                var countOfOddChar = groupByChar.Count(pair => pair.Value%2 == 1);
                return countOfOddChar == 1;
            }

            // even
            return groupByChar.All(pair => pair.Value % 2 == 0);
        } 
    }

    public class PalindromePermutationTests
    {
        [TestCase("taco cat", ExpectedResult = true)]
        [TestCase("taco catt", ExpectedResult = false)]
        [TestCase("tactcoapapa", ExpectedResult = true)]
        public bool Should_Return_true_When_is_Palindrome_permutation(string input)
        {
            return input.IsPalindromePermutation();
        }
    }
}
