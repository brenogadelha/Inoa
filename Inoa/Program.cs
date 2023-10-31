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

			while (Console.ReadKey().Key != ConsoleKey.Escape)
			{
				var valorCotacao = await CotacaoServicoExterno.ObterCotacao(cotacao.Ativo);

				if (valorCotacao > cotacao.PrecoVenda)
					EmailServicoExterno.EnviarEmail("Aconselhamento para Venda", $"O valor da cotação B3 ({valorCotacao}) atingiu o valor estipulado para venda.");

				if (valorCotacao < cotacao.PrecoCompra)
					EmailServicoExterno.EnviarEmail("Aconselhamento para Compra", $"O valor da cotação B3 ({valorCotacao}) atingiu o valor estipulado para compra.");

				Thread.Sleep(TimeSpan.FromSeconds(5));
			}
		}
	}
}