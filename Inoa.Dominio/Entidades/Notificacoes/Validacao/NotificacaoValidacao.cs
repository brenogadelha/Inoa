using FluentValidation;
using FluentValidation.Validators;

namespace Inoa.Dominio.Entidades.Notificacoes.Validacao
{
	public class NotificacaoValidacao : AbstractValidator<Notificacao>
    {
        public NotificacaoValidacao()
        {
            RuleFor(x => x.EmailDestinatario).NotEmpty()
                .WithMessage("É obrigatório informar o Email do Destinatário.");

            RuleFor(x => x.EmailDestinatario)
                .MaximumLength(320).WithMessage("E-mail do Destinatário não pode passar de 320 caracteres.");

            RuleFor(x => x.EmailRemetente)
                .MaximumLength(320).WithMessage("E-mail do Remetente não pode passar de 320 caracteres.");

            RuleFor(x => x.EmailRemetente).NotEmpty()
                .WithMessage("É obrigatório informar o Email do Remetente.");

            RuleFor(x => x.Assunto).NotEmpty()
                .WithMessage("É obrigatório informar o Assunto do Email.");

            RuleFor(x => x.Corpo).NotEmpty()
                .WithMessage("Corpo do email não pode ser vazio.");

            RuleFor(x => x.EmailDestinatario).EmailAddress(EmailValidationMode.Net4xRegex).Unless(x => string.IsNullOrEmpty(x.EmailDestinatario))
                .WithMessage("E-mail de Destinatário inválido.");

            RuleFor(x => x.EmailRemetente).EmailAddress(EmailValidationMode.Net4xRegex).Unless(x => string.IsNullOrEmpty(x.EmailRemetente))
                .WithMessage("E-mail de Remetente inválido.");
        }
    }
}
