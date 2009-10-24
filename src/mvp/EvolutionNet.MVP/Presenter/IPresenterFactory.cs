/*
 * Created by: 
 * Created: quarta-feira, 12 de dezembro de 2007
 */

using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	/// <summary>
	/// Define uma interface da instância da AbstractFactory, para a criação de Presenters. 
	/// Deverá ser implementada no módulo de apresentação (presenter).
	/// </summary>
	public interface IPresenterFactory : IFactory
	{
		/// <summary>
		/// Método que retorna um presenter a partir de uma view, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="view">View, objeto que representa a visão</param>
		/// <returns>Retorna o presenter correspondente à view</returns>
		BasePresenter<TO, T, IdT> GetPresenter<TO, T, IdT>(IView view)
			where TO : TO<T, IdT>
			where T : Model<IdT>;

		/// <summary>
		/// Método que retorna um presenter a partir de uma view, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="view">View, objeto que representa a visão</param>
		/// <returns>Retorna o presenter correspondente à view</returns>
		BaseListPresenter<TO, T, IdT> GetListPresenter<TO, T, IdT>(IListView view)
			where TO : ListTO<T, IdT>
			where T : Model<IdT>;

	}

}