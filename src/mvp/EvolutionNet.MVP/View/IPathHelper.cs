namespace EvolutionNet.MVP.View
{
	public interface IPathHelper
	{
		/// <summary>
		/// Descobre o caminho físico de um path virtual. Por exemplo: GetPhysicalPath("~/Teste.aspx") retorna
		/// "C:\\Inetpub\\wwwroot\\Teste\Teste.aspx". Em uma aplicação windows retorna o caminho completo do path,
		/// baseado na localização do arquivo executável.
		/// </summary>
		/// <param name="virtualPath">Path virtual</param>
		/// <returns>Caminho físico</returns>
		string GetPhysicalPath(string virtualPath);

		/// <summary>
		/// Descobre o caminho absoluto de um path virtual. Por exemplo: GetAbsolutePath("~/Teste.aspx") retorna
		/// "/Teste/Teste.aspx". Em uma aplicação windows retorna o caminho relativo do arquivo em relação ao executável.
		/// </summary>
		/// <param name="virtualPath"></param>
		/// <returns></returns>
		string GetAbsolutePath(string virtualPath);
	}
}