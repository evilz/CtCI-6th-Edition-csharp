using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArraysAndStrings
{
    public static class OneAwayExt
    {
        public static bool IsOneAwayFrom(this string source, string other)
        {
			var hasOneInsertFrom = source.HasOneInsertOrDeleteFrom(other);
            var hasOneChange = source.HasOneChangeFrom(other);
            
			return hasOneInsertFrom ^ hasOneChange;
        }

        public static bool HasOneChangeFrom(this string source, string other)
        {
			if(source.Length != other.Length) { return false;}

            var changDetected = false;
			for (int i = 0; i < source.Length; i++)
            {
                if (source[i] != other[i])
                {
                    if (changDetected) { return false;}
                    changDetected = true;
                }
            }
            return changDetected;
        }

        public static bool HasOneInsertOrDeleteFrom(this string source, string other)
        {
            if (source.Length > other.Length)
            {
                return other.HasOneInsertOrDeleteFrom(source);
            }

            var index1 = 0;
            var index2 = 0;

            while (index1 < source.Length && index2 < other.Length)
            {
                if (source[index1] != other[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }
                    index2++;
                }
                else {
                    index1++;
                    index2++;
                }
            }
            return true;

        }
    }

    public class OneAwayTests
    {
		[TestCase("pale","ple", ExpectedResult = true)]
		[TestCase("pales","pale", ExpectedResult = true)]
		[TestCase("pale","bale", ExpectedResult = true)]
		[TestCase("pale","bake", ExpectedResult = false)]
        public bool Should_return_true_when_exactly_one_change(string source,string other)
        {
            return source.IsOneAwayFrom(other);
        }
    }
}
