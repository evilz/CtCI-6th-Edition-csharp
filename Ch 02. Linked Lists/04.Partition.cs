using System.Collections.Generic;
using NUnit.Framework;

namespace Ch_02.Linked_Lists
{
    public static class PartitionExt
    {
        // O(n)
        public static LinkedList<int> PartitionOn(this LinkedList<int> source, int patitionValue)
        {
            if (source == null || source.Count == 0) return source;

            LinkedList<int> less = new LinkedList<int>();
            LinkedList<int> greater = new LinkedList<int>();
            
            var currentNode = source.First;

            /* Partition list */
            while (currentNode != null)
            {
                var next = currentNode.Next;
               
                if (currentNode.Value < patitionValue)
                {
                    less.AddLast(currentNode.Value);
                    
                }
                else
                {
                    greater.AddLast(currentNode.Value);
                }
                currentNode = next;
            }

            foreach (var item in greater)
            {
                less.AddLast(item);
            }
            return less;

        }
    }


    public class PartitionTests
    {
        [Test] public void Should_left_should_be_less_than_value_and_right_greater()
        {
            var source = new LinkedList<int>(new[] { 3,5,6,5,10,2,1});
            var expected = new LinkedList<int>(new[] { 3,6,5,10,2,1});

            var splitValue = 5;

            source.PartitionOn(splitValue);
            Assert.That(source, Is.EqualTo(expected));
        }

      
    }
}
