/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using System.ComponentModel;

namespace EvolutionNet.MVP.Core.Data.Definition
{
	/// <summary>
	/// Interface que define um modelo básico, representando o banco de dados em forma de objetos.
	/// </summary>
	/// <typeparam name="IdT">Tipo da Identity do modelo</typeparam>
	public interface IModel<IdT> : INotifyPropertyChanged
	{
		/// <summary>
		/// ID da instância
		/// </summary>
		IdT ID { get; set; }

		/// <summary>
		/// Define se o objeto é transient (deve ser criado) ou não (deve ser salvo). Calculado pela existência ou não de ID.
		/// </summary>
		bool IsTransient { get; }

		/*
		void Attach(IView<object> observer);
		void Detach(IView<object> observer);
		void Notify();
		*/
	}
}