/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

namespace EvolutionNet.MVP.View
{
	/// <summary>
	/// Interface que define uma vis�o (view) b�sica a ser implementada por cada funcionalidade.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao To, que � criado automaticamente pelo framework.
		/// </summary>
//		TO To { get; /*set;*/ }

		/// <summary>
		/// Realiza todas as inicializa��es necess�rias.
		/// </summary>
		void Initialize();

		string MapPath(string relFileName);
		string ResolveClientUrl(string relPath);
//		string ResolveUrl(string relFileName);
	}
}