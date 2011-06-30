namespace EvolutionNet.MVP.View
{
	public interface IPathHelper
	{
		/// <summary>
		/// Descobre o caminho f�sico de um path virtual. Por exemplo: GetPhysicalPath("~/Teste.aspx") retorna
		/// "C:\\Inetpub\\wwwroot\\Teste\Teste.aspx". Em uma aplica��o windows retorna o caminho completo do path,
		/// baseado na localiza��o do arquivo execut�vel.
		/// </summary>
		/// <param name="virtualPath">Path virtual</param>
		/// <returns>Caminho f�sico</returns>
		string GetPhysicalPath(string virtualPath);

		/// <summary>
		/// Descobre o caminho absoluto de um path virtual. Por exemplo: GetAbsolutePath("~/Teste.aspx") retorna
		/// "/Teste/Teste.aspx". Em uma aplica��o windows retorna o caminho relativo do arquivo em rela��o ao execut�vel.
		/// </summary>
		/// <param name="virtualPath"></param>
		/// <returns></returns>
		string GetAbsolutePath(string virtualPath);
	}
}