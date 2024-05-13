using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    sem2lab10.SquareMatrix matrix1 = new sem2lab10.SquareMatrix(2);
    sem2lab10.SquareMatrix matrix2 = new sem2lab10.SquareMatrix(2);
    [TestMethod]
    public void TestMethodCompareTo()
    {
      var actualResult = matrix1.CompareTo(matrix2);
      Assert.AreEqual(0, actualResult);
    }

    [TestMethod]
    public void TestMethodEquals()
    {
      var actualResult = matrix1.Equals(matrix2);
      Assert.AreEqual(false, actualResult);
    }

    [TestMethod]
    public void TestMethodFindDeterminant()
    {
      var actualResult = matrix1.FindDeterminant();
      Assert.IsInstanceOfType(actualResult, typeof(int));
    }

    [TestMethod]
    public void TestMethodFindInversedMatrix()
    {
      var actualResult = matrix1.FindInversedMatrix();
      Assert.IsInstanceOfType(actualResult, typeof(sem2lab10.SquareMatrix));
    }

    [TestMethod]
    public void TestMethodFindTransposed()
    {
      var actualResult = matrix1.FindTransposed();
      Assert.IsInstanceOfType(actualResult, typeof(sem2lab10.SquareMatrix));
    }

    [TestMethod]
    public void TestMethodGetHashCode()
    {
      var actualResult = matrix1.GetHashCode();
      Assert.IsInstanceOfType(actualResult, typeof(int));
    }

    [TestMethod]
    public void TestMethodGetStepaMatrix()
    {
      var actualResult = matrix1.GetStepaMatrix(1, 1);
      Assert.IsInstanceOfType(actualResult, typeof(sem2lab10.SquareMatrix));
    }

    [TestMethod]
    public void TestMethodPrintMatrix()
    {
      matrix1.PrintMatrix();
    }

    [TestMethod]
    public void TestMethodToString()
    {
      var actualResult = matrix1.ToString();
      Assert.IsInstanceOfType(actualResult, typeof(string));
    }

    [TestMethod]
    public void TestMethodEqualOverload()
    {
      var actualResult = matrix1 == matrix2;
      Assert.AreEqual(false, actualResult);
    }

    [TestMethod]
    public void TestMethodNotEqualOverload()
    {
      var actualResult = matrix1 != matrix2;
      Assert.AreEqual(false, actualResult);
    }

    [TestMethod]
    public void TestMethodMoreOverload()
    {
      var actualResult = matrix1 > matrix2;
      Assert.AreEqual(false, actualResult);
    }

    [TestMethod]
    public void TestMethodLessOverload()
    {
      var actualResult = matrix1 < matrix2;
      Assert.AreEqual(false, actualResult);
    }

    [TestMethod]
    public void TestMethodMoreEqualOverload()
    {
      var actualResult = matrix1 >= matrix2;
      Assert.AreEqual(true, actualResult);
    }

    [TestMethod]
    public void TestMethodLessEqualOverload()
    {
      var actualResult = matrix1 <= matrix2;
      Assert.AreEqual(true, actualResult);
    }

    [TestMethod]
    public void TestMethodAdditionOverload()
    {
      var actualResult = matrix1 + matrix2;
      Assert.IsInstanceOfType(actualResult, typeof(sem2lab10.SquareMatrix));
    }

    [TestMethod]
    public void TestMethodMultiplicationOverload()
    {
      var actualResult = matrix1 * matrix2;
      Assert.IsInstanceOfType(actualResult, typeof(sem2lab10.SquareMatrix));
    }
  }
}



