using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ch_02.Linked_Lists
{
    public static class SumListsExt
    {
        public static LinkedList<int> SumLists(this LinkedList<int> number1, LinkedList<int> number2)
        {
           
            var node1 = number1.Last;
            var node2 = number2.Last;
            var result = new LinkedList<int>();
            var carry = 0;
            while (true)
            {
                if (node1 == null && node2 == null && carry == 0)
                {
                    break;
                }

                var val1 = node1?.Value ?? 0;
                var val2 = node2?.Value ?? 0;

                var sum = val1 + val2 + carry;
                carry = sum / 10;
                result.AddFirst(sum%10);
                
                node1 = node1?.Previous;
                node2 = node2?.Previous;
            }
            return result;
        }
    }

    public class SumListsTests
    {
        [Test]
        public void Shoud_Sum_two_numbers()
        {
            var number1 = new LinkedList<int>(new []{  7,9,2,3});
            var number2 = new LinkedList<int>(new []{  2,1,9,8});

            var expected = new LinkedList<int>(new []{1,0,1,2,1});

            var result = number1.SumLists(number2);

            Assert.That(result, Is.EqualTo(expected));
        }
    }

}
