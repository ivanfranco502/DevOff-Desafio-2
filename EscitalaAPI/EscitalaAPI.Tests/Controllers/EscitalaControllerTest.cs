using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscitalaAPI.Controllers;
using EscitalaAPI.Models;
using Newtonsoft.Json;

namespace EscitalaAPI.Tests.Controllers
{
	[TestClass]
	public class EscitalaControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			EscitalaController controller = new EscitalaController();

			// Act
			string result = controller.Index();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Everything is working fine", result);
		}

		[TestMethod]
		public void Cifrar()
		{
			// Arrange
			EscitalaController controller = new EscitalaController();

			MessageRequest request = new MessageRequest
			{
				Message = "Devoff se puso ATR",
				Length = 4
			};

			// Act
			var response = controller.Cifrar(JsonConvert.SerializeObject(request));

			// Assert
			Assert.IsNotNull(response);
			Assert.AreEqual("DfesTef oRv p  osuA ", response);
		}

		[TestMethod]
		public void Descifrar()
		{
			// Arrange
			EscitalaController controller = new EscitalaController();

			MessageRequest request = new MessageRequest
			{
				Message = "DfesTef oRv p  osuA ",
				Length = 5
			};

			// Act
			var response = controller.Descifrar(JsonConvert.SerializeObject(request));

			// Assert
			Assert.IsNotNull(response);
			Assert.AreEqual("Devoff se puso ATR  ", response);
		}
	}
}
