using Inoa.Configurations;
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
			double valorCotacao = 0;

			if (args.Length != 3)
			{
				Console.WriteLine("Informe os parâmetros 'Ativo', 'Preço de Venda' e 'Preço de Compra' (nesta ordem).");
				return;
			}

			string ativo = args[0];
			string precoVenda = args[1];
			string precoCompra = args[2];

			var configuration = ConfiguracaoFabrica.Criar();
			ServiceCollectionExtension.AddConfigurationOptions(configuration);

			var cotacao = new Cotacao(ativo, precoVenda, precoCompra);

			while (true)
			{
				var valorCotacaoAtual = await CotacaoServicoExterno.ObterCotacao(cotacao.Ativo);

				if (valorCotacaoAtual != valorCotacao)
				{
					valorCotacao = valorCotacaoAtual;

					if (valorCotacaoAtual > cotacao.PrecoVenda)
						EmailServicoExterno.EnviarEmail($"Cotação {ativo} pronta para venda.", $"O valor da cotação {ativo} ({valorCotacaoAtual}) atingiu o valor estipulado para venda ({cotacao.PrecoVenda}).");

					if (valorCotacaoAtual < cotacao.PrecoCompra)
						EmailServicoExterno.EnviarEmail($"Cotação {ativo} pronta para Compra.", $"O valor da cotação {ativo} ({valorCotacaoAtual}) atingiu o valor estipulado para compra ({cotacao.PrecoCompra}).");

					Thread.Sleep(TimeSpan.FromSeconds(5));
				}
			}
		}
	}
}