/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Core.Business
{
	public delegate void ActionDelegate();

	/// <summary>
	/// Essa interface representa a Facade básica, os métodos e propriedades que devem ser implementados.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
	/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
	/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
	public interface IFacade<TO, T, IdT> : IContract
		where TO : ITo<T, IdT>
		where T : IModel<IdT>
	{
		/// <summary>
		/// Transfer Object, contém a referência ao To, definido na View.
		/// </summary>
		TO To { get; }

		void Execute(ActionDelegate doAction);

	}
}