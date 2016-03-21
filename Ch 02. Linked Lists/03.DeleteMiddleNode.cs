using System.Collections.Generic;
using NUnit.Framework;

namespace Ch_02.Linked_Lists
{
    public static class DeleteMiddleNodeExt
    {
        // O(n)
        public static void DeleteMiddleNode<T>(this LinkedList<T> source)
        {
            if (source == null || source.Count == 0) return;

            if (source.Count%2 == 0) return;

            var middle = source.Count/2;
            var currentNode = source.First;
            for (int i = 0; i < middle; i++)
            {
                currentNode = currentNode.Next;
            }

            source.Remove(currentNode);

        }
    }


    public class DeleteMiddleNodeTests
    {
        [Test] public void Should_return_delete_middle_when_length_is_odd()
        {
            var source = new LinkedList<string>(new[] { "a", "b", "c", "b", "a"});
            var expected = new LinkedList<string>(new[] { "a", "b", "b", "a"});

            source.DeleteMiddleNode();
            Assert.That(source, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_delete_middle_when_length_is_odd_for_big_source()
        {
            var source = new LinkedList<string>(new[] { "a", "b", "c","d","e","f","g","f","e","d","c", "b", "a" });
            var expected = new LinkedList<string>(new[] { "a", "b", "c", "d", "e", "f", "f", "e", "d", "c", "b", "a" });

            source.DeleteMiddleNode();
            Assert.That(source, Is.EqualTo(expected));
        }

        [Test]
        public void Should_return_empty_list_when_length_is_one_()
        {
            var source = new LinkedList<string>(new[] { "a" });
            
            source.DeleteMiddleNode();
            Assert.That(source, Is.Empty);
        }

        [Test]
        public void Should_return_source_when_length_is_even()
        {
            var source = new LinkedList<string>(new[] { "a", "b", "c", "b", "a" });
          
            source.DeleteMiddleNode();
            Assert.That(source, Is.EqualTo(source));
        }


    }
}
