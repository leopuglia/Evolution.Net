/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.Presenter;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Core.View
{
	/// <summary>
	/// Interface que define uma vis�o (view) b�sica a ser implementada por cada funcionalidade.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object, tipo do objeto de transfer�ncia de dados</typeparam>
	/// <typeparam name="T">MainModel, tipo da principal entidade (model) do m�dulo</typeparam>
	/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
	public interface IView<TO, T, IdT> : IDisposable 
		where TO : ITo<T, IdT> where T : IModel<IdT>
	{
		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao To, que � criado automaticamente pelo framework.
		/// </summary>
		TO To { get; /*set;*/ }

		/// <summary>
		/// Presenter, cont�m a refer�ncia ao presenter da funcionalidade atual.
		/// </summary>
		IPresenter<TO, T, IdT> Presenter { get; }

		/// <summary>
		/// Realiza todas as inicializa��es necess�rias.
		/// </summary>
		void Initialize();
		
//		IdT PersistentModelID { get; set; }
//		T TO { get; set; }
//		IdT GetParameterID();
//		void UpdateModel(T to);
//		void UpdateView(T to);
//		void ShowError(string message);
	}
}