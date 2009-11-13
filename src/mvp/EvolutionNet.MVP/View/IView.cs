/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;

namespace EvolutionNet.MVP.View
{
	/// <summary>
	/// Interface que define uma vis�o (view) b�sica a ser implementada por cada funcionalidade.
	/// </summary>
	public interface IView
	{
		/// <summary>
		/// Realiza todas as inicializa��es necess�rias.
		/// </summary>
		void DoLoad();
		void DoLoadComplete();

		string MapPath(string relFileName);
		string ResolveClientUrl(string relPath);
	}
}