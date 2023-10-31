using Inoa.Dominio.Comum.Validacao;
using Inoa.Dominio.Entidades.Notificacoes.Validacao;

namespace Inoa.Dominio.Entidades.Notificacoes
{
	public class Notificacao
    {
        public string EmailRemetente { get; private set; } = string.Empty;
        public string EmailDestinatario { get; private set; } = string.Empty;
        public string Assunto { get; private set; } = string.Empty;
        public string Corpo { get; private set; } = string.Empty;

        public Notificacao(string emailRemetente, string emailDestinatario, string assunto, string corpo)
        {
            EmailRemetente = emailRemetente;
            EmailDestinatario = emailDestinatario;
            Assunto = assunto;
            Corpo = corpo;

            ValidacaoFabrica.Validar(this, new NotificacaoValidacao());
        }
    }
}