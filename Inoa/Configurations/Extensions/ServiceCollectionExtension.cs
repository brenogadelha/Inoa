﻿using Inoa.Dominio.Entidades.Ativos;
using Inoa.Infraestrutura;
using Inoa.Infraestrutura.Options;
using Inoa.ServicoExterno.Ativos;
using Microsoft.Extensions.Configuration;

namespace Inoa.Configurations.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static void AddConfigurationOptions()
		{
			var configuration = ConfiguracaoFabrica.Criar();

			var brapiApiDevOpcoes = configuration.GetSection("BrapiApiDev").Get<BrapiApiOptions>();
			var servidorSmtpOpcoes = configuration.GetSection("ServidorSmtp").Get<ServidorSmtpOptions>();

			var ativos = AtivoServicoExterno.ObterTodosAtivos(brapiApiDevOpcoes).Result;

			Ativo.SetarAtivos(ativos);
			AppSettings.SetarOpcoes(brapiApiDevOpcoes, servidorSmtpOpcoes);
		}
	}
}
