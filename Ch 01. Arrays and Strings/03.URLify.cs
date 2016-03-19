using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
