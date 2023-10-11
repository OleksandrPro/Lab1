using Lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab1Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void AddVector_AddVectorWithCorrectData_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 1, 9, 7 });
            ISparseVector s2 = new SparseVector(new double[] { -2, 0, 4 });
            ISparseVector result = new SparseVector(new double[] { });
            ISparseVector expected = new SparseVector(new double[] { -1, 9, 11 });
            //Act
            result = s2.Add(s1);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddVector_AddEmptyVectors_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] {});
            ISparseVector s2 = new SparseVector(new double[] {});
            ISparseVector result = new SparseVector(new double[] { });
            ISparseVector expected = new SparseVector(new double[] {});
            //Act
            result = s2.Add(s1);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void AddVector_AddVectorWithWrongData_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 1, 9, 7 });
            ISparseVector s2 = new SparseVector(new double[] { -2, 0, 4, 8 });
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => s2.Add(s1));
        }
        [TestMethod()]
        public void AddVector_AddClassThatImplementsTheSameInterface_ThrowsInvalidCastExceptionForWrongType()
        {
            // Arrange
            SparseVector vector = new SparseVector();
            ISparseVector wrongArgument = new TestWrongCast();
            // Act and Assert
            Assert.ThrowsException<InvalidCastException>(() => vector.Add(wrongArgument));
        }
        [TestMethod()]
        public void SubtractVector_SubtractVectorWithCorrectData_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 1, 9, 7 });
            ISparseVector s2 = new SparseVector(new double[] { -2, 0, 4 });
            ISparseVector result = new SparseVector(new double[] { });
            ISparseVector expected = new SparseVector(new double[] { 3, 9, 3 });
            //Act
            result = s1.Subtract(s2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SubtractVector_SubtractEmptyVectors_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { });
            ISparseVector s2 = new SparseVector(new double[] { });
            ISparseVector result = new SparseVector(new double[] { });
            ISparseVector expected = new SparseVector(new double[] { });
            //Act
            result = s2.Subtract(s1);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SubtractVector_SubtractVectorWithWrongData_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 1, 9, 7 });
            ISparseVector s2 = new SparseVector(new double[] { -2, 0, 4, 8 });
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => s2.Add(s1));
        }
        public void SubtractVector_SubtractClassThatImplementsTheSameInterface_ThrowsInvalidCastExceptionForWrongType()
        {
            // Arrange
            SparseVector vector = new SparseVector();
            ISparseVector wrongArgument = new TestWrongCast();
            // Act and Assert
            Assert.ThrowsException<InvalidCastException>(() => vector.Add(wrongArgument));
        }
        [TestMethod()]
        public void Multiply_MultiplyByNumber_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 111, 222, 333 });
            ISparseVector result = new SparseVector(new double[] { });
            ISparseVector expected = new SparseVector(new double[] { 1110, 2220, 3330 });
            double number = 10;
            //Act
            result = s1.Multiply(number);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void Multiply_MultiplyEmptyVectorByNumber_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] {});
            ISparseVector result = new SparseVector(new double[] { });
            ISparseVector expected = new SparseVector(new double[] {});
            double number = 100;
            //Act
            result = s1.Multiply(number);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CalculateMagnitude_CalculateMagnitudeWithCorrectData_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 12, -5, 0 });
            double result = 0;
            double expected = 13;
            //Act
            result = s1.CalculateMagnitude();
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CalculateMagnitude_CalculateMagnitudeOfEmptyVector_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { });
            double result = 0;
            double expected = 0;
            //Act
            result = s1.CalculateMagnitude();
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CalculateDotProduct_CalculateDotProductWithCorrectData_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { -2, 0, 4 });
            ISparseVector s2 = new SparseVector(new double[] { 1, 9, 7 });
            double result = 0;
            double expected = 26;
            //Act
            result = s1.CalculateDotProduct(s2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CalculateDotProduct_CalculateDotProductOfEmptyVector_ReturnedResultIsCorrect()
        {
            ISparseVector s1 = new SparseVector(new double[] {});
            ISparseVector s2 = new SparseVector(new double[] {});
            double result = 0;
            double expected = 0;
            //Act
            result = s1.CalculateDotProduct(s2);
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void CalculateDotProduct_CalculateDotProductWithWrongData_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 1, 9, 7 });
            ISparseVector s2 = new SparseVector(new double[] { -2, 0, 4, 8 });
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => s2.CalculateDotProduct(s1));
        }
        [TestMethod()]
        public void CalculateDotProduct_CalculateDotProductWithClassThatImplementsTheSameInterface_ThrowsInvalidCastExceptionForWrongType()
        {
            // Arrange
            SparseVector vector = new SparseVector();
            ISparseVector wrongArgument = new TestWrongCast();
            // Act and Assert
            Assert.ThrowsException<InvalidCastException>(() => vector.CalculateDotProduct(wrongArgument));
        }
        [TestMethod()]
        public void Equals_CheckEmptyVectorsEquality_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] {});
            ISparseVector s2 = new SparseVector(new double[] {});
            bool result;
            //Act
            result = s1.Equals(s2);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void Equals_CheckEqualVectorsEquality_ReturnedResultIsCorrect()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 11, 12, 13 });
            ISparseVector s2 = new SparseVector(new double[] { 11, 12, 13 });
            bool result;
            //Act
            result = s1.Equals(s2);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void Equals_CheckVectorsEqualityWithWrongData_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            ISparseVector s1 = new SparseVector(new double[] { 11, 12, 13, 14 });
            ISparseVector s2 = new SparseVector(new double[] { 11, 12, 13 });
            bool result;
            //Act
            result = s1.Equals(s2);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void Equals_CheckVectorsEqualityWithClassThatImplementsTheSameInterface_ThrowsInvalidCastExceptionForWrongType()
        {
            // Arrange
            ISparseVector vector = new SparseVector();
            ISparseVector wrongArgument = new TestWrongCast();
            bool result;
            //Act
            result = vector.Equals(wrongArgument);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void ToString_ConvertionIntoString_ReturnedResultIsCorrect()
        {
            // Arrange
            ISparseVector s1 = new SparseVector(new double[] { 1, 0, 0, 0, 8, 0, 0, 0, 0, 0, -1, 0 });
            string result = string.Empty;
            string expected = "1 0 0 0 8 0 0 0 0 0 -1 0 ";
            //Act
            result = s1.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }       
    }
}
