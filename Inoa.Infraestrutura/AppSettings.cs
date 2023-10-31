using Inoa.Infraestrutura.Options;

namespace Inoa.Infraestrutura
{
	public static class AppSettings
	{
		public static BrapiApiOptions? BrapiApi { get; private set; }
		public static ServidorSmtpOptions? ServidorSmtp { get; private set; }

		public static void SetarOpcoes(BrapiApiOptions brapiApi,
			ServidorSmtpOptions servidorSmtp)
		{
			BrapiApi = brapiApi;
			ServidorSmtp = servidorSmtp;
		}
	}
}
