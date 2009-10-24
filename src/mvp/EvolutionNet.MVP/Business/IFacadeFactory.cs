/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Define uma interface da inst�ncia da AbstractFactory, para a cria��o de Facades. 
	/// Dever� ser implementada no m�dulo de neg�cios.
	/// </summary>
	public interface IFacadeFactory : IFactory
	{
		/// <summary>
		/// M�todo que retorna um facaded a partir de um presenter, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transfer�ncia de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do m�dulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="presenter">Presenter, objeto que representa a apresenta��o</param>
		/// <returns>Retorna o facade correspondente ao presenter</returns>
		BaseFacade<TO, T, IdT> GetFacade<TO, T, IdT>(BasePresenter<TO, T, IdT> presenter) 
			where TO : TO<T, IdT> 
			where T : Model<IdT>;

		/// <summary>
		/// M�todo que retorna um facaded a partir de um presenter, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transfer�ncia de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do m�dulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="presenter">Presenter, objeto que representa a apresenta��o</param>
		/// <returns>Retorna o facade correspondente ao presenter</returns>
		BaseListFacade<TO, T, IdT> GetListFacade<TO, T, IdT>(BaseListPresenter<TO, T, IdT> presenter)
			where TO : ListTO<T, IdT>
			where T : Model<IdT>;

	}

}