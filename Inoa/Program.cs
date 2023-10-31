using Inoa.Configurations;
using Inoa.Configurations.Extensions;
using Inoa.Dominio.Entidades.Cotacoes;
using Inoa.ServicoExterno.Cotacoes;
using Inoa.ServicoExterno.Emails;
using Microsoft.Extensions.DependencyInjection;

class Program
{
	static async Task Main(string[] args)
	{
		var serviceCollection = new ServiceCollection();

		var configuration = ConfiguracaoFabrica.Criar();

		serviceCollection.AddConfigurationOptions(configuration);

		if (args.Length != 3)
		{
			Console.WriteLine("Informe os parâmetros 'Ativo', 'Preço de Venda' e 'Preço de Compra' (nesta ordem).");
			return;
		}

		string ativo = args[0];
		double precoVenda = double.Parse(args[1]);
		double precoCompra = double.Parse(args[2]);

		var cotacao = new Cotacao(ativo, precoVenda, precoCompra);

		while(Console.ReadKey().Key != ConsoleKey.Escape)
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