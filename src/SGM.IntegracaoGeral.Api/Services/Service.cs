using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SGM.IntegracaoGeral.Api.Services
{
	public abstract class Service
	{
		protected StringContent ObterStringContent(object dado)
		{
			string jsonSerializado = JsonSerializer.Serialize(dado);

			var conteudo = new StringContent(jsonSerializado, Encoding.UTF8, "application/json");

			return conteudo;
		}

		protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage response)
		{
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};

			string content = await response.Content.ReadAsStringAsync();

			var deserializado = JsonSerializer.Deserialize<T>(content, options);

			return deserializado;
		}

	}
}
