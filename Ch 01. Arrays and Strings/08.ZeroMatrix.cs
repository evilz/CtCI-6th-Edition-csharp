using System.Linq;
using NUnit.Framework;

namespace ArraysAndStrings
{
    public static class ZeroMatrix
    {
        public static void SetZeroRowCol(this int[,] source)
        {
            var height = source.GetLength(0);
            var width = source.GetLength(1);

            var zeroPoints = (  from x in Enumerable.Range(0, width)
                                from y in Enumerable.Range(0, height)
                                where source[y, x] == 0
                                select new {x, y})
                                .ToArray();

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (zeroPoints.Any(arg => arg.x == x || arg.y == y))
                    {
                        source[y, x] = 0;
                    }
                }
            }
        }
    }

    public class ZeroMatrixTests
    {
        [Test]
        public void Should_set_all_row_cell_to_0_when_row_contains_0()
        {
            var matrix = new int[,]
            {
                {4, 0, 6}
            };

            var expected = new int[,]
            {
                {0, 0, 0}
            };

            matrix.SetZeroRowCol();

            Assert.That(matrix, Is.EqualTo(expected));
        }

        [Test]
        public void Should_set_all_Col_cell_to_0_when_col_contains_0()
        {
            var matrix = new int[,]
            {
                {4},
                {0},
                {6}
            };

            var expected = new int[,]
            {
                {0},
                {0},
                {0}
            };

            matrix.SetZeroRowCol();

            Assert.That(matrix, Is.EqualTo(expected));
        }

        [Test]
        public void Should_set_all_Col_and_row_cell_to_0_when_contains_0()
        {
            var matrix = new int[,]
            {
               {1,2,3},
               {4,0,6 },
               {7,8,9 }
            };

            var expected = new int[,]
            {
                {1,0,3},
               {0,0,0 },
               {7,0,9 }
            };

            matrix.SetZeroRowCol();

            Assert.That(matrix, Is.EqualTo(expected));
        }
    }
}
