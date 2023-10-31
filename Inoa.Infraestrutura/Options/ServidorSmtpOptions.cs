namespace Inoa.Infraestrutura.Options
{
	public class ServidorSmtpOptions
    {
		public string EmailRemetente { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string EmailDestinatario { get; set; } = string.Empty;
		public string Host { get; set; } = string.Empty;
		public int Port { get; set; }
	}
}
