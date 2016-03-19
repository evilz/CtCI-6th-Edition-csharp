using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArraysAndStrings
{
    public static class StringCompressionExt
    {
        public static string CompressLowerCase(this string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            source = source.Trim().ToLowerInvariant();
            var dest = new StringBuilder();

            var lastChar = source[0];
            var count = 0;
            foreach (var c in source)
            {
				if (lastChar != c)
                {
                    dest.AppendFormat("{0}{1}", lastChar, count);
                    lastChar = c;
                    count = 1;
                }
                else
                {
                    count++;
                }
            }
            dest.AppendFormat("{0}{1}", lastChar, count);

            return dest.Length < source.Length ? dest.ToString() : source;
        }
    }


    public class StringCompressionTest
    {
        [TestCase("  aaa   ", ExpectedResult = "a3")]
        public string Should_trim_source(string input)
        {
            return input.CompressLowerCase();
        }


        [TestCase("aa", ExpectedResult = "aa")]
        public string Should_return_source_when_compressed_is_not_less(string input)
        {
            return input.CompressLowerCase();
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase((string)null, ExpectedResult = "")]
        public string Should_return_empty_when_null_or_empty(string input)
        {
            return input.CompressLowerCase();
        }

        [TestCase("aabcccccaaa", ExpectedResult="a2b1c5a3")]
        public string Should_count_each_group_of_char(string input)
		{
		    return input.CompressLowerCase();
		}
    }
}
