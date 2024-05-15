using System;
using System.Numerics;
using System.Xml;

namespace sem2lab10
{
  public class SquareMatrix
  {
    public int[,] matrix;
    public int size;

    public SquareMatrix()
    {
      Random random = new Random();
      size = random.Next(2, 10);
      matrix = new int[size, size];

      for (int RowIndex = 0; RowIndex < size; ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < size; ++ColumnIndex)
        {
          matrix[RowIndex, ColumnIndex] = random.Next(1, 10);
        }
      }
    }
    public SquareMatrix(int size)
    {
      this.size = size;
      Random random = new Random();
      matrix = new int[size, size];

      for (int RowIndex = 0; RowIndex < size; ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < size; ++ColumnIndex)
        {
          matrix[RowIndex, ColumnIndex] = random.Next(1, 10);
        }
      }
    }

    public class MatrixSizeException : Exception
    {
      public MatrixSizeException(string message) : base(message)
      {
      }
    }

    public class MatrixIndexException : Exception
    {
      public MatrixIndexException(string message) : base(message)
      {
      }
    }

    public static SquareMatrix operator +(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      SquareMatrix result = new SquareMatrix(matrix1.matrix.GetLength(0));

      for (int RowIndex = 0; RowIndex < matrix1.matrix.GetLength(0); ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < matrix1.matrix.GetLength(1); ++ColumnIndex)
        {
          result.matrix[RowIndex, ColumnIndex] = matrix1.matrix[RowIndex, ColumnIndex] + matrix2.matrix[RowIndex, ColumnIndex];
        }
      }

      return result;
    }

    public static SquareMatrix operator *(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      SquareMatrix resultMatrix = new SquareMatrix(matrix1.size);

      for (int matrix1RowIndex = 0; matrix1RowIndex < matrix1.size; ++matrix1RowIndex)
      {
        for (int matrix2ColumnIndex = 0; matrix2ColumnIndex < matrix2.size; ++matrix2ColumnIndex)
        {
          int currentPositionValue = 0;

          for (int partNumber = 0; partNumber < matrix1.size; ++partNumber)
          {
            currentPositionValue += matrix1.matrix[matrix1RowIndex, matrix2ColumnIndex];
          }

          resultMatrix.matrix[matrix1RowIndex, matrix2ColumnIndex] = currentPositionValue;
        }
      }

      return resultMatrix;
    }

    public static bool operator >(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      int count = 0;
      for (int RowIndex = 0; RowIndex < matrix1.matrix.GetLength(0); ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < matrix1.matrix.GetLength(1); ++ColumnIndex)
        {
          if (matrix1.matrix[RowIndex, ColumnIndex] > matrix2.matrix[RowIndex, ColumnIndex])
          {
            count++;
          }
        }
      }
      if (count > 2)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator <(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      int count = 0;
      for (int RowIndex = 0; RowIndex < matrix1.matrix.GetLength(0); ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < matrix1.matrix.GetLength(1); ++ColumnIndex)
        {
          if (matrix1.matrix[RowIndex, ColumnIndex] < matrix2.matrix[RowIndex, ColumnIndex])
          {
            count++;
          }
        }
      }
      if (count > 2)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator >=(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      int count = 0;
      for (int RowIndex = 0; RowIndex < matrix1.matrix.GetLength(0); ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < matrix1.matrix.GetLength(1); ++ColumnIndex)
        {
          if (matrix1.matrix[RowIndex, ColumnIndex] >= matrix2.matrix[RowIndex, ColumnIndex])
          {
            count++;
          }
        }
      }
      if (count > 1)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator <=(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      int count = 0;
      for (int RowIndex = 0; RowIndex < matrix1.matrix.GetLength(0); ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < matrix1.matrix.GetLength(1); ++ColumnIndex)
        {
          if (matrix1.matrix[RowIndex, ColumnIndex] <= matrix2.matrix[RowIndex, ColumnIndex])
          {
            count++;
          }
        }
      }
      if (count > 1)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator ==(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      if (matrix1.matrix.GetLength(0) > matrix2.matrix.GetLength(0))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static bool operator !=(SquareMatrix matrix1, SquareMatrix matrix2)
    {
      if (matrix1.matrix.GetLength(0) < matrix2.matrix.GetLength(0))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static implicit operator int[,](SquareMatrix matrix1)
    {
      return matrix1.matrix;
    }

    public static explicit operator int(SquareMatrix matrix1)
    {
      return matrix1.matrix.GetLength(0);
    }

    public static bool operator true(SquareMatrix matrix1)
    {
      return matrix1.size != 1;
    }

    public static bool operator false(SquareMatrix matrix1)
    {
      return matrix1.size == 1;
    }

    public SquareMatrix GetStepaMatrix(int row, int column)
    {
      SquareMatrix result = new SquareMatrix(size - 1);

      for (int columnIndex = 0; columnIndex < size - 1; ++columnIndex)
      {
        for (int rowIndex = 0; rowIndex < size - 1; ++rowIndex)
        {
          result.matrix[rowIndex, columnIndex] = columnIndex < column ?
              rowIndex < row ?
              matrix[rowIndex, columnIndex] :
              matrix[rowIndex + 1, columnIndex] :
              rowIndex < row ?
              matrix[rowIndex, columnIndex + 1] :
              matrix[rowIndex + 1, columnIndex + 1];

        }
      }

      return result;
    }

    public int FindDeterminant()
    {
      if (size == 2)
      {
        int determinant = matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
        return determinant;
      }

      int result = 0;

      for (int columnIndex = 0; columnIndex < size; ++columnIndex)
      {

        result += (columnIndex % 2 == 1 ? 1 : -1) * matrix[1, columnIndex] * GetStepaMatrix(1, columnIndex).FindDeterminant();
      }

      return result;
    }


    public SquareMatrix FindTransposed()
    {
      var result = new SquareMatrix(size);

      for (int rowIndex = 0; rowIndex < size; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < size; ++columnIndex)
        {
          result.matrix[rowIndex, columnIndex] = matrix[columnIndex, rowIndex];
        }
      }

      return result;
    }

    public SquareMatrix FindInversedMatrix()
    {
      var result = new SquareMatrix(size);

      if (size == 2)
      {
        result.matrix[0, 0] = -matrix[1, 1];
        result.matrix[0, 1] = matrix[1, 0];
        result.matrix[1, 0] = matrix[0, 1];
        result.matrix[1, 1] = -matrix[0, 0];

        Console.WriteLine(FindDeterminant());

        return result.FindTransposed();
      }

      for (int rowIndex = 0; rowIndex < size; ++rowIndex)
      {
        for (int collumnIndex = 0; collumnIndex < size; ++collumnIndex)
        {
          result.matrix[rowIndex, collumnIndex] = ((collumnIndex + rowIndex) % 2 == 0 ? 1 : -1) * GetStepaMatrix(rowIndex, collumnIndex).FindDeterminant();
        }
      }

      return result.FindTransposed();
    }

    public override string ToString()
    {
      string result = "";

      for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
      {
        for (int columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
        {
          result += $" {matrix[rowIndex, columnIndex]}  ";
        }
        result += "\n";
      }

      return result;
    }

    public override bool Equals(object otherObject)
    {
      bool result = false;

      if (otherObject is MatrixClone)
      {
        var currentObject = otherObject as MatrixClone;

        if (currentObject.ToString() == this.ToString())
        {
          result = true;
        }
      }

      return result;
    }

    public int CompareTo(SquareMatrix other)
    {
      if (other.matrix.GetLength(0) > 2)
      {
        return 1;
      }
      else
      {
        return 0;
      }
    }

    public override int GetHashCode()
    {
      Random random = new Random();
      int degree = random.Next(2, 10);
      int result = 1;

      for (int currentDegree = 1; currentDegree <= degree; ++currentDegree)
      {
        result *= size;
      }

      return random.Next(2, result);
    }

    public void PrintMatrix()
    {
      for (int RowIndex = 0; RowIndex < matrix.GetLength(0); ++RowIndex)
      {
        for (int ColumnIndex = 0; ColumnIndex < matrix.GetLength(1); ++ColumnIndex)
        {
          Console.Write(matrix[RowIndex, ColumnIndex] + " ");
        }
        Console.WriteLine();
      }
    }

  }

  class MatrixClone : SquareMatrix, ICloneable
  {
    public object Clone()
    {
      MatrixClone currentClone = new MatrixClone
      {
        size = this.size,
        matrix = this.matrix
      };
      return currentClone;
    }
  }

  static class Program
  {
    static void Main()
    {
      SquareMatrix matrix = new SquareMatrix(3);
      SquareMatrix matrix1 = new SquareMatrix(3);
      SquareMatrix matrix2 = new SquareMatrix(3);
      Console.WriteLine("First matrix");
      matrix1.PrintMatrix();
      Console.WriteLine("Second matrix");
      matrix2.PrintMatrix();
      Console.WriteLine();
      Console.WriteLine("There is no such thing as free will, user: ");
      Console.WriteLine("Make a choice, user: ");
      Console.WriteLine("1. +; 2. *; 3. <; 4. >; 5. <=; 6. >=;");
      Console.WriteLine("7. ==; 8. !=; 9. FindDeterminant;");
      Console.WriteLine("10. FindTransposed; 11. FindInversedMatrix");


      int userChoice = int.Parse(Console.ReadLine());

      switch (userChoice)
      {
        case 1:
          Console.WriteLine(matrix1 + matrix2);
          break;

        case 2:
          Console.WriteLine(matrix1 * matrix2);
          break;

        case 3:
          Console.WriteLine(matrix1 < matrix2);
          break;

        case 4:
          Console.WriteLine(matrix1 > matrix2);
          break;

        case 5:
          Console.WriteLine(matrix1 <= matrix2);
          break;

        case 6:
          Console.WriteLine(matrix1 >= matrix2);
          break;

        case 7:
          Console.WriteLine(matrix1 == matrix2);
          break;

        case 8:
          Console.WriteLine(matrix1 != matrix2);
          break;

        case 9:
          var determinant = matrix1.FindDeterminant();
          Console.WriteLine(determinant);
          break;

        case 10:
          var transposedMatrix = matrix1.FindTransposed();
          transposedMatrix.PrintMatrix();
          break;

        case 11:
          var InvertedMatrix = matrix1.FindInversedMatrix();
          InvertedMatrix.PrintMatrix();
          break;
      }

      Console.WriteLine("Press any key to close the app...");
      Console.ReadKey();
    }
  }
}
