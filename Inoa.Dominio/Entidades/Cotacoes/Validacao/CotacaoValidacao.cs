using FluentValidation;
using Inoa.Dominio.Entidades.Ativos;

namespace Inoa.Dominio.Entidades.Cotacoes.Validacao
{
	public class CotacaoValidacao : AbstractValidator<Cotacao>
    {        
        private readonly List<string> ativos = Ativo.Ativos;

        public CotacaoValidacao()
        {
            RuleFor(x => x.Ativo).NotEmpty()
                .WithMessage("É obrigatório informar o Ativo a ser monitorado.");

            RuleFor(x => x.PrecoVenda).NotEmpty()
                .WithMessage("É obrigatório informar o valor estipulado para venda.");

            RuleFor(x => x.PrecoCompra).NotEmpty()
                .WithMessage("É obrigatório informar o valor estipulado para compra.");

            RuleFor(x => x.Ativo).Must(x => ativos.Contains(x.ToUpperInvariant()))
                .WithMessage("Ativo inválido.");
        }
    }
}
