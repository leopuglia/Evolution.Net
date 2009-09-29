/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.Presenter;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Core.Business
{
	/// <summary>
	/// Define uma interface da instância da AbstractFactory, para a criação de Facades. 
	/// Deverá ser implementada no módulo de negócios.
	/// </summary>
	public interface IFacadeFactory : IFactory
	{
		/// <summary>
		/// Método que retorna um facaded a partir de um presenter, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="presenter">Presenter, objeto que representa a apresentação</param>
		/// <returns>Retorna o facade correspondente ao presenter</returns>
		IFacade<TO, T, IdT> GetFacade<TO, T, IdT>(IPresenter<TO, T, IdT> presenter)
			where TO : ITo<T, IdT>
			where T : IModel<IdT>;

		/// <summary>
		/// Método que retorna um facaded a partir de um presenter, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="presenter">Presenter, objeto que representa a apresentação</param>
		/// <returns>Retorna o facade correspondente ao presenter</returns>
		IListFacade<TO, T, IdT> GetListFacade<TO, T, IdT>(IListPresenter<TO, T, IdT> presenter)
			where TO : IListTo<T, IdT>
			where T : IModel<IdT>;

	}

}