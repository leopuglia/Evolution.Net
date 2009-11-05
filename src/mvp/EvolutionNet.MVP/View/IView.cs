/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

namespace EvolutionNet.MVP.View
{
	/// <summary>
	/// Interface que define uma visão (view) básica a ser implementada por cada funcionalidade.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Transfer Object, contém a referência ao To, que é criado automaticamente pelo framework.
		/// </summary>
//		TO To { get; /*set;*/ }

		/// <summary>
		/// Realiza todas as inicializações necessárias.
		/// </summary>
		void Initialize();

		string MapPath(string relFileName);
		string ResolveClientUrl(string relPath);
//		string ResolveUrl(string relFileName);
	}
}