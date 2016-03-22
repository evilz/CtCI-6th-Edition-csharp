using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ch_02.Linked_Lists
{
    public static class LoopDetection
    {
        public static LinkedListNode<int> FindLoopNode(this LinkedList<int> source)
        {
            // TODO
            return source.First;
        }
    }

    public class LoopDetectionTests
    {
        [Test]
        public void Should_return_loopNode_when_loops()
        {

            // IMPOSSIBLE IN .NET   LinkedList impl !!!
            // create new node

            var list = new LinkedList<int>(new []{1, 2, 3, 4});
            var loopNode = list.Last;

            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);
            list.AddLast(8);
            list.AddLast(9);

            list.AddLast(loopNode);

            var result = list.FindLoopNode();

            Assert.That(result, Is.EqualTo(loopNode));
        }   
    }
}
