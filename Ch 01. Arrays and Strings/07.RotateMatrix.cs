using NUnit.Framework;

namespace ArraysAndStrings
{
    // Given an image represented by an NxN matrix, where each pixel in the image is 4
    // bytes, write a method to rotate the image by 90 degrees.Can you do this in place?
    public static class RotateMatrixExt
    {
        public static void Rotate<T>(this T[][] matrix)
        {
            var size = matrix.Length;
            for (int layer = 0; layer < size/2; ++layer)
            {
                int first = layer;
                int last = size - 1 - layer;
                for (int i = first; i < last; ++i)
                {
                    int offset = i - first;
                    T top = matrix[first][i]; // save top
                    // left -> top
                    matrix[first][i] = matrix[last - offset][first];

                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];

                    // top -> right
                    matrix[i][last] = top; // right <- saved top
                }
            }
        }
    }

    public class RotateMatrixTexts
        {
        [Test]
        public void Should_Return_rotated_matrix_by_90_Clockwise()
        {
            var matrix = new int[3][];
            matrix[0] = new[] { 1, 2, 3 };
            matrix[1] = new[] { 4, 5, 6 };
            matrix[2] = new[] { 7, 8, 9 };

            var expexcted = new int[3][];
            expexcted[0] = new[] { 7, 4, 1 };
            expexcted[1] = new[] { 8, 5, 2 };
            expexcted[2] = new[] { 9, 6, 3 };

            matrix.Rotate();

            // Assert
            Assert.That(matrix, Is.EqualTo(expexcted));
        }

        [Test]
        public void Should_Return_rotated_matrixOddSize_by_90_Clockwise()
        {
            var matrix = new int[4][];
            matrix[0] = new[] { 1, 2, 3, 4 };
            matrix[1] = new[] { 5, 6, 7, 8 };
            matrix[2] = new[] { 9, 10,11,12 };
            matrix[3] = new[] { 13,14,15,16 };

            var expexcted = new int[4][];
            expexcted[0] = new[] { 13, 9, 5, 1 };
            expexcted[1] = new[] { 14,10, 6, 2 };
            expexcted[2] = new[] { 15,11, 7, 3};
            expexcted[3] = new[] { 16,12, 8, 4};

            matrix.Rotate();

            // Assert
            Assert.That(matrix, Is.EqualTo(expexcted));
        }
        }
    }
