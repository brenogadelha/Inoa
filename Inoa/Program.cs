using Inoa.Configurations.Extensions;
using Inoa.Dominio.Entidades.Cotacoes;
using Inoa.ServicoExterno.Cotacoes;
using Inoa.ServicoExterno.Emails;

namespace Inoa
{
	class Program
	{
		static async Task Main(string[] args)
		{
			if (args.Length != 3)
			{
				Console.WriteLine("Informe os parâmetros 'Ativo', 'Preço de Venda' e 'Preço de Compra' (nesta ordem).");
				return;
			}

			double valorCotacao = 0;
			string ativo = args[0];
			string precoVenda = args[1];
			string precoCompra = args[2];

			ServiceCollectionExtension.AddConfigurationOptions();

			var cotacao = new Cotacao(ativo, precoVenda, precoCompra);

			while (true)
			{
				valorCotacao = await MonitorarCotacao(valorCotacao, ativo, cotacao);

				Thread.Sleep(TimeSpan.FromSeconds(5));
			}
		}

		private static async Task<double> MonitorarCotacao(double valorCotacao, string ativo, Cotacao cotacao)
		{
			var valorCotacaoAtual = await CotacaoServicoExterno.ObterCotacao(cotacao.Ativo);

			if (valorCotacaoAtual != valorCotacao)
			{
				valorCotacao = valorCotacaoAtual;

				if (valorCotacaoAtual > cotacao.PrecoVenda)
					EmailServicoExterno.EnviarEmail($"Cotação {ativo.ToUpper()} pronta para venda.", $"O valor da cotação {ativo.ToUpper()} ({valorCotacaoAtual}) atingiu o valor estipulado para venda (maior que {cotacao.PrecoVenda}).", "Venda");

				if (valorCotacaoAtual < cotacao.PrecoCompra)
					EmailServicoExterno.EnviarEmail($"Cotação {ativo.ToUpper()} pronta para Compra.", $"O valor da cotação {ativo.ToUpper()} ({valorCotacaoAtual}) atingiu o valor estipulado para compra (menor que {cotacao.PrecoCompra}).", "Compra");
			}

			return valorCotacao;
		}
	}
}