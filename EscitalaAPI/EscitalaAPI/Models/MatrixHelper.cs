using System;

namespace EscitalaAPI.Models
{
	public static class MatrixHelper
	{
		public static string[,] Transponer(string[,] matrix)
		{
			var rowLength = matrix.GetLength(0);
			var columnLength = matrix.GetLength(1);
			string[,] aux = new string[columnLength, rowLength];

			for (int row = 0; row < rowLength; row++)
			{
				for (int column = 0; column < columnLength; column++)
				{
					aux[column, row] = matrix[row, column];
				}
			}

			return aux;
		}

		public static string[,] CreateMatrix(string message, int length)
		{
			int rowLength = (int) (message.Length + length - 1) / length;

			string[,] matrix = new string[rowLength, length];

			int letterCount = 0;
			for (int row = 0; row < rowLength; row++)
			{
				for (int column = 0; column < length; column++)
				{
					if(letterCount < message.Length)
					{
						matrix[row, column] = message[letterCount].ToString();
						letterCount++;
					}
					else
					{
						matrix[row, column] = " ";
					}
				}
			}

			return matrix;
		}

		public static string FlatMatrix(string[,] transponderMatrix)
		{
			int rowLength = transponderMatrix.GetLength(0);
			int columnLength = transponderMatrix.GetLength(1);

			string result = string.Empty;
			
			for (int row = 0; row < rowLength; row++)
			{
				for (int col = 0; col < columnLength; col++)
				{
					result += transponderMatrix[row, col];
				}
			}

			return result;
		}
	}
}