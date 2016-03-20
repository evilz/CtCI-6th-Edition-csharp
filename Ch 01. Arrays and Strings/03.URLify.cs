using NUnit.Framework;

namespace ArraysAndStrings
{
    public static class URLifyExt
    {
        // Assume string has sufficient free space at the end
        public static void URLify(this char[] str, int trueLength)
        {
            var spaceCount = 0;
            for (var i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            var index = trueLength + spaceCount * 2;
            if (trueLength < str.Length)
            {
                str[trueLength] = '\0';
            }

            for (var i = trueLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else {
                    str[index - 1] = str[i];
                    index--;
                }
            }
        }

        public static string UrlifySpace(this string input)
        {
            if (input == null) return null;

            const string replacer = "%20";
            const char replaced = ' ';
            var newLength = input.Length;

            foreach (var c in input)
            {
                if (c == replaced)
                {
                    newLength += replacer.Length - 1;
                }
            }

            var newStringContent = new char[newLength];

            for (int i = 0, j = 0; i < input.Length; i++)
            {
                if (input[i] == replaced)
                {
                    for (int k = 0; k < replacer.Length; k++)
                    {
                        newStringContent[j] = replacer[k];
                        j++;
                    }
                }
                else
                {
                    newStringContent[j] = input[i];
                    j++;
                }

            }

            return new string(newStringContent);
        }
    }

    public class URLifyExtTests
    {
        [TestCase("Mr John Smith    ", ExpectedResult = "Mr%20John%20Smith")]
        public string Should_replace_space_by_percent20(string input)
        {
            var arr = input.ToCharArray();
            arr.URLify(input.Trim().Length);
            return new string(arr);
        }

        [TestCase("abc", "abc")]
        [TestCase("ab c", "ab%20c")]
        [TestCase(" ", "%20")]
        [TestCase(null, null)]
        public void Should_Replace_space_by_percent20(string input, string expected)
        {
            Assert.That(input.UrlifySpace(), Is.EqualTo(expected));
        }
    }
}
