namespace Inoa.Infraestrutura.Options
{
	public class BrapiApiOptions
    {
		public string UrlBase { get; set; } = string.Empty;
		public string ObterCotação { get; set; } = string.Empty;
		public string ObterAtivos { get; set; } = string.Empty;
		public string Token { get; set; } = string.Empty;
	}
}
