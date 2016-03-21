using System.Collections.Generic;
using NUnit.Framework;

namespace Ch_02.Linked_Lists
{
    public static class RemoveDuplicatesExt
    {
        // O(n)
        public static void RemoveDuplicates<T>(this LinkedList<T> source)
        {
            if (source == null || source.Count == 0) return;
            
            var hashSet = new HashSet<T>();
            var current = source.First;

            while (current != null)
            {
                var value = current.Value;
                if (hashSet.Contains(value))
                {
                    var next = current.Next;
                    source.Remove(current);
                    current = next;
                    continue;
                }

                hashSet.Add(current.Value);
                current = current.Next;
            }
            
        }
    }


    public class RemoveDuplicatesTests
    {
        [Test]
        public void Should_remove_duplicated_values()
        {
            var source = new LinkedList<string>(new[] { "a", "b", "c", "d", "a", "c", "e" });
            var expected = new LinkedList<string>(new[] { "a", "b", "c", "d", "e" });

            source.RemoveDuplicates();

            Assert.That(source, Is.EqualTo(expected));
        }
    }
}
