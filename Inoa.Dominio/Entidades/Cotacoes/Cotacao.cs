using Inoa.Dominio.Comum.Validacao;
using Inoa.Dominio.Entidades.Cotacoes.Validacao;

namespace Inoa.Dominio.Entidades.Cotacoes
{
	public class Cotacao
    {
        public string Ativo { get; private set; } = string.Empty;
        public double PrecoVenda { get; private set; }
        public double PrecoCompra { get; private set; }

        public Cotacao(string ativo, double precoVenda, double precoCompra)
        {
            Ativo = ativo;
            PrecoVenda = precoVenda;
            PrecoCompra = precoCompra;

            ValidacaoFabrica.Validar(this, new CotacaoValidacao());
        }
    }
}