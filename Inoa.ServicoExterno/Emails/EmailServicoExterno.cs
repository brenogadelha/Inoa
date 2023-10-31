using Inoa.Dominio.Entidades.Notificacoes;
using System.Net.Mail;
using System.Net;
using Inoa.Infraestrutura;

namespace Inoa.ServicoExterno.Emails
{
	public static class EmailServicoExterno
	{
		public static void EnviarEmail(string assunto, string corpo)
		{
			var notificacao = new Notificacao(AppSettings.ServidorSmtp!.EmailRemetente, AppSettings.ServidorSmtp!.EmailDestinatario, assunto, corpo);

			using SmtpClient smtpClient = new();
			smtpClient.Host = AppSettings.ServidorSmtp!.Host;
			smtpClient.Port = AppSettings.ServidorSmtp!.Port;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(AppSettings.ServidorSmtp!.UserName, AppSettings.ServidorSmtp!.Password);
			smtpClient.EnableSsl = true;

			using MailMessage email = new();

			email.From = new MailAddress(notificacao.EmailRemetente);
			email.To.Add(notificacao.EmailDestinatario);
			email.Subject = notificacao.Assunto;
			email.Body = notificacao.Corpo;

			try
			{
				smtpClient.Send(email);
				Console.WriteLine("E-mail enviado com sucesso!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Erro ao enviar o e-mail: {ex.Message}");
			}
		}
	}
}
