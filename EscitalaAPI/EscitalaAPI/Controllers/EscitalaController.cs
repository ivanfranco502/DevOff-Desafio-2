using System.Drawing.Drawing2D;
using System.Web.Http;
using EscitalaAPI.Models;
using Newtonsoft.Json;

namespace EscitalaAPI.Controllers
{
	public class EscitalaController : ApiController
	{
		// GET api/escitala
		public string Index()
		{
			return "Everything is working fine";
		}

		// POST api/escitala
		public string Cifrar([FromBody] string value)
		{
			MessageRequest messageRequest = JsonConvert.DeserializeObject<MessageRequest>(value);

			var matrix = MatrixHelper.CreateMatrix(messageRequest.Message, messageRequest.Length);
			
			var transponsedMatrix = MatrixHelper.Transponer(matrix);
			
			return MatrixHelper.FlatMatrix(transponsedMatrix);
		}

		// POST api/escitala
		public string Descifrar([FromBody] string value)
		{
			MessageRequest messageRequest = JsonConvert.DeserializeObject<MessageRequest>(value);

			var matrix = MatrixHelper.CreateMatrix(messageRequest.Message, messageRequest.Length);
			
			var transposedMatrix = MatrixHelper.Transponer(matrix);

			return MatrixHelper.FlatMatrix(transposedMatrix);
		}
	}
}
