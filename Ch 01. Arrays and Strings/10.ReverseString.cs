using NUnit.Framework;

namespace ArraysAndStrings
{
    // Write code to reverse a C-Style String. (C-String means that “abcd” is represented as
    // five characters, including the null character.)
    public static class ReverseStringExt
    {
        public static string ReverseString(this string source)
        {
            char[] sourceAsArray = source.ToCharArray();
            for (int i = 0, j = sourceAsArray.Length - 1; i <= j; i++, j--)
            {
                var tmp = sourceAsArray[j];
                sourceAsArray[j] = sourceAsArray[i];
                sourceAsArray[i] = tmp;
            }
            return new string(sourceAsArray);
        }
    }

    public class ReverseStringTest
    {
        [TestCase("",ExpectedResult = "")]
        [TestCase("a",ExpectedResult = "a")]
        [TestCase("ab",ExpectedResult = "ba")]
        [TestCase("abc",ExpectedResult = "cba")]
        [TestCase("Fizz",ExpectedResult = "zziF")]
        public string ReverseString_Test(string source)
        {
            return source.ReverseString();
        }
    }
}
