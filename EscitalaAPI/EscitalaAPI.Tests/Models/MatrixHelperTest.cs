using EscitalaAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EscitalaAPI.Tests.Models
{
	[TestClass]
	public class MatrixHelperTest
	{
		[TestMethod]
		public void GivenAMatrix5x4_Transponder_ShouldReturn4x5Matrix()
		{
			string[,] matrix = {
				{"D", "e", "v", "o"},
				{"f", "f", " ", "s"},
				{"e", " ", "p", "u"},
				{"s", "o", " ", "A"},
				{"T", "R", " ", " "}
			};

			var result = MatrixHelper.Transponer(matrix);

			Assert.IsNotNull(result);
			Assert.AreEqual(4, result.GetLength(0));
			Assert.AreEqual(5, result.GetLength(1));

			Assert.AreEqual("D", result[0, 0]);
			Assert.AreEqual("f", result[0, 1]);
			Assert.AreEqual("e", result[0, 2]);
			Assert.AreEqual("s", result[0, 3]);
			Assert.AreEqual("T", result[0, 4]);

			Assert.AreEqual("e", result[1, 0]);
			Assert.AreEqual("f", result[1, 1]);
			Assert.AreEqual(" ", result[1, 2]);
			Assert.AreEqual("o", result[1, 3]);
			Assert.AreEqual("R", result[1, 4]);

			Assert.AreEqual("v", result[2, 0]);
			Assert.AreEqual(" ", result[2, 1]);
			Assert.AreEqual("p", result[2, 2]);
			Assert.AreEqual(" ", result[2, 3]);
			Assert.AreEqual(" ", result[2, 4]);

			Assert.AreEqual("o", result[3, 0]);
			Assert.AreEqual("s", result[3, 1]);
			Assert.AreEqual("u", result[3, 2]);
			Assert.AreEqual("A", result[3, 3]);
			Assert.AreEqual(" ", result[3, 4]);
		}

		[TestMethod]
		public void GivenAMatrix4x5_Transponder_ShouldReturn5x4Matrix()
		{
			string[,] matrix = {
				{"D", "f", "e", "s", "T"},
				{"e", "f", " ", "o", "R"},
				{"v", " ", "p", " ", " "},
				{"o", "s", "u", "A", " "}
			};

			var result = MatrixHelper.Transponer(matrix);

			Assert.IsNotNull(result);
			Assert.AreEqual(5, result.GetLength(0));
			Assert.AreEqual(4, result.GetLength(1));

			Assert.AreEqual("D", result[0, 0]);
			Assert.AreEqual("e", result[0, 1]);
			Assert.AreEqual("v", result[0, 2]);
			Assert.AreEqual("o", result[0, 3]);

			Assert.AreEqual("f", result[1, 0]);
			Assert.AreEqual("f", result[1, 1]);
			Assert.AreEqual(" ", result[1, 2]);
			Assert.AreEqual("s", result[1, 3]);

			Assert.AreEqual("e", result[2, 0]);
			Assert.AreEqual(" ", result[2, 1]);
			Assert.AreEqual("p", result[2, 2]);
			Assert.AreEqual("u", result[2, 3]);

			Assert.AreEqual("s", result[3, 0]);
			Assert.AreEqual("o", result[3, 1]);
			Assert.AreEqual(" ", result[3, 2]);
			Assert.AreEqual("A", result[3, 3]);

			Assert.AreEqual("T", result[4, 0]);
			Assert.AreEqual("R", result[4, 1]);
			Assert.AreEqual(" ", result[4, 2]);
			Assert.AreEqual(" ", result[4, 3]);
		}

		[TestMethod]
		public void GivenAMessageRequest_CreateMatrix_ShouldReturnMatrix5x4()
		{
			MessageRequest request = new MessageRequest
			{
				Message = "Devoff se puso ATR",
				Length = 4
			};

			var result = MatrixHelper.CreateMatrix(request.Message, request.Length);

			Assert.IsNotNull(result);
			Assert.AreEqual(5, result.GetLength(0));
			Assert.AreEqual(4, result.GetLength(1));

			Assert.AreEqual("D", result[0, 0]);
			Assert.AreEqual("e", result[0, 1]);
			Assert.AreEqual("v", result[0, 2]);
			Assert.AreEqual("o", result[0, 3]);

			Assert.AreEqual("f", result[1, 0]);
			Assert.AreEqual("f", result[1, 1]);
			Assert.AreEqual(" ", result[1, 2]);
			Assert.AreEqual("s", result[1, 3]);

			Assert.AreEqual("e", result[2, 0]);
			Assert.AreEqual(" ", result[2, 1]);
			Assert.AreEqual("p", result[2, 2]);
			Assert.AreEqual("u", result[2, 3]);
			
			Assert.AreEqual("s", result[3, 0]);
			Assert.AreEqual("o", result[3, 1]);
			Assert.AreEqual(" ", result[3, 2]);
			Assert.AreEqual("A", result[3, 3]);

			Assert.AreEqual("T", result[4, 0]);
			Assert.AreEqual("R", result[4, 1]);
			Assert.AreEqual(" ", result[4, 2]);
			Assert.AreEqual(" ", result[4, 3]);
		}

		[TestMethod]
		public void GivenA4x5Matrix_FlatMatrix_ShouldReturnProperString()
		{
			string[,] matrix = {
				{"D", "f", "e", "s", "T"},
				{"e", "f", " ", "o", "R"},
				{"v", " ", "p", " ", " "},
				{"o", "s", "u", "A", " "}
			};

			var result = MatrixHelper.FlatMatrix(matrix);

			Assert.IsNotNull(result);
			Assert.AreEqual("DfesTef oRv p  osuA ", result);
		}
	}
}
