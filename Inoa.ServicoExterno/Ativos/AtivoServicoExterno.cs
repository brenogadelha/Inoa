using Inoa.Dominio.Dto;
using Inoa.Infraestrutura.Options;
using Newtonsoft.Json;

namespace Inoa.ServicoExterno.Ativos
{
	public static class AtivoServicoExterno
	{
		public static async Task<List<string>> ObterTodosAtivos(BrapiApiOptions brapiApiOptions)
		{
			string apiUrl = $"{brapiApiOptions.UrlBase}{brapiApiOptions.ObterAtivos}?token={brapiApiOptions.Token}";

			using HttpClient client = new();
			HttpResponseMessage response = await client.GetAsync(apiUrl);

			if (!response.IsSuccessStatusCode)
			{
				var errorResponse = JsonConvert.DeserializeObject<ErrorResponseBrapiApi>(response.Content.ReadAsStringAsync().Result);

				Console.WriteLine($"Erro ao chamar a api para obter os ativos: {errorResponse!.Message}");
				Environment.Exit(0);
			}

			var content = response.Content.ReadAsStringAsync().Result;

			var result = JsonConvert.DeserializeObject<ResultAtivos>(response.Content.ReadAsStringAsync().Result);

			return result!.Stocks;
		}
	}
}
