using System.Collections.Generic;
using NUnit.Framework;

namespace Ch_02.Linked_Lists
{
    public static class KthToLastExt
    {
        // O(n)
        public static IEnumerable<T> KthToLast<T>(this LinkedList<T> source, int k)
        {
            if (source == null || source.Count == 0) yield break;

            var length = source.Count;
            var currentNode = source.First;
            
            for (int i = 0; i < length - k; i++)
            {
                currentNode = currentNode.Next;
            }
           
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }

        }
    }


    public class KthToLastTests
    {
        [Test]
        public void Should_return_empty_when_k_is_0()
        {
            var source = new LinkedList<string>(new[] { "a", "b", "c", "d", "a", "c", "e" });
            var k = 0;

            var result = source.KthToLast(k);
            
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Should_return_k_last_element()
        {
            var source = new LinkedList<string>(new[] { "a", "b", "c", "d", "e" });
            var k = 3;

            var expected = new [] {  "c", "d", "e" };

            var result = source.KthToLast(k);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
