namespace Inoa.Dominio.Entidades.Ativos
{
	public static class Ativo
	{
		public static List<string> Ativos { get; private set; } = new List<string>();

		public static void SetarAtivos(List<string> ativos) => Ativos = ativos;
	}
}
