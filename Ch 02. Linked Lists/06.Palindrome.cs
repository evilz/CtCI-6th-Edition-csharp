using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ch_02.Linked_Lists
{
    public static class PalindromeExt
    {
        public static bool IsPalindrome(this LinkedList<char> source)
        {
            var mid = source.Count/2;

            var head = source.First;
            var tail = source.Last;

            for (int i = 0; i < mid; i++)
            {
                if (head == null || tail == null)
                {
                    return head == tail;
                }
                if(head.Value != tail.Value)
                    return false;

                head = head.Next;
                tail = tail.Previous;
            }

            return true;
        }
    }

    public class PalindromeTests
    {
        [TestCase("abcba", ExpectedResult = true)]
        [TestCase("abba",ExpectedResult = true)]
        [TestCase("abbc", ExpectedResult = false)]
        [TestCase("abca", ExpectedResult = false)]
        public bool Should_return_true_when_List_is_Palindrome(string input)
        {
            var list = new LinkedList<char>(input.ToCharArray());

            return list.IsPalindrome();
        }
    }
}
