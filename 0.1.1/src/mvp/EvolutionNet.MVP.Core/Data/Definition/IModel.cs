/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System.ComponentModel;

namespace EvolutionNet.MVP.Core.Data.Definition
{
	/// <summary>
	/// Interface que define um modelo b�sico, representando o banco de dados em forma de objetos.
	/// </summary>
	/// <typeparam name="IdT">Tipo da Identity do modelo</typeparam>
	public interface IModel<IdT> : INotifyPropertyChanged
	{
		/// <summary>
		/// ID da inst�ncia
		/// </summary>
		IdT ID { get; set; }

		/// <summary>
		/// Define se o objeto � transient (deve ser criado) ou n�o (deve ser salvo). Calculado pela exist�ncia ou n�o de ID.
		/// </summary>
		bool IsTransient { get; }

		/*
		void Attach(IView<object> observer);
		void Detach(IView<object> observer);
		void Notify();
		*/
	}
}