using Inoa.Dominio.Dto;
using Inoa.Dominio.Dto.Cotacoes;
using Inoa.Infraestrutura;
using Newtonsoft.Json;

namespace Inoa.ServicoExterno.Cotacoes
{
    public static class CotacaoServicoExterno
	{
		public static async Task<double> ObterCotacao(string ativo)
		{
			string token = AppSettings.BrapiApi!.Token;
			string apiUrl = $"{AppSettings.BrapiApi!.UrlBase}{AppSettings.BrapiApi.ObterCotação.Replace("{ativo}", ativo)}?token={token}";

			using HttpClient client = new();
			HttpResponseMessage response = await client.GetAsync(apiUrl);

			if (!response.IsSuccessStatusCode)
			{
				var errorResponse = JsonConvert.DeserializeObject<ErrorResponseBrapiApi>(response.Content.ReadAsStringAsync().Result);

				Console.WriteLine($"Erro ao chamar a api para obter o valor da cotação {ativo}: {errorResponse!.Message}");
				Environment.Exit(0);
			}

			var content = response.Content.ReadAsStringAsync().Result;

			var result = JsonConvert.DeserializeObject<ResultCotacao>(response.Content.ReadAsStringAsync().Result);

			return result!.Results.Select(r => r.RegularMarketPrice).First();
		}
	}
}
