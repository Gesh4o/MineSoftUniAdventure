namespace RotatingWalkMatrix.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RotatingWalkMatrix;

    [TestClass]
    public class WalkMatrixTests
    {
        [TestMethod]
        public void RotatingWalkMatrix_WithLengthSix_ShouldReturnProperCollection()
        {
            const int MatrixLength = 6;
            int[,] expectedMatrix = new int[,] 
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            int[,] actualMatrix = WalkInMatrixMain.BuildRotatingWalkMatrix(MatrixLength);

            CollectionAssert.AreEqual(expectedMatrix,actualMatrix, "Matrix is not rotated properly!");

        }

        [TestMethod]
        public void RotatingWalkMatrix_WithLengthFive_ShouldReturnProperCollection()
        {
            const int MatrixLength = 5;
            int[,] expectedMatrix = new int[,]
            {
                { 1, 13, 14, 15, 16 },
                { 12, 2, 21, 22, 17 },
                { 11, 23, 3, 20, 18 },
                { 10, 25, 24, 4, 19 },
                { 9, 8, 7, 6, 5 }
            };

            int[,] actualMatrix = WalkInMatrixMain.BuildRotatingWalkMatrix(MatrixLength);

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix, "Matrix is not rotated properly!");
        }

        [TestMethod]
        public void RotatingWalkMatrix_WithLengthTwo_ShouldReturnProperCollection()
        {
            const int MatrixLength = 2;
            int[,] expectedMatrix = new int[,]
            {
                { 1, 4 },
                { 3, 2 }
            };

            int[,] actualMatrix = WalkInMatrixMain.BuildRotatingWalkMatrix(MatrixLength);

            CollectionAssert.AreEqual(expectedMatrix, actualMatrix, "Matrix is not rotated properly!");
        }
    }
}
