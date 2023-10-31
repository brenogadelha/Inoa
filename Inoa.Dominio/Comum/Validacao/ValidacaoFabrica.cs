using FluentValidation;

namespace Inoa.Dominio.Comum.Validacao
{
	public static class ValidacaoFabrica
	{
		public static void Validar<T>(T objeto, AbstractValidator<T> validador)
		{
			var validacaoResult = validador.Validate(objeto);

			if (!validacaoResult.IsValid)
			{
				string erro = string.Join(" ", validacaoResult.Errors);
				Console.WriteLine(erro);
				Environment.Exit(0);
			}
		}
	}
}
