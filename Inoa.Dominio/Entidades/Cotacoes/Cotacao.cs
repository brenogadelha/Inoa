using Inoa.Dominio.Comum.Validacao;
using Inoa.Dominio.Entidades.Cotacoes.Validacao;

namespace Inoa.Dominio.Entidades.Cotacoes
{
	public class Cotacao
	{
		public string Ativo { get; private set; } = string.Empty;
		public double PrecoVenda { get; private set; }
		public double PrecoCompra { get; private set; }

		public Cotacao(string ativo, string precoVenda, string precoCompra)
		{
			Ativo = ativo;
			PrecoVenda = ConverterParaDouble(precoVenda, "Preço de Venda");
			PrecoCompra = ConverterParaDouble(precoCompra, "Preço de Compra");

			ValidacaoFabrica.Validar(this, new CotacaoValidacao());
		}

		private static double ConverterParaDouble(string valorDouble, string nomePropriedade)
		{
			try
			{
				return double.Parse(valorDouble);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Valor de {nomePropriedade} inválido: {ex.Message}");
				Environment.Exit(0);
				return 0.0;
			}
		}
	}
}