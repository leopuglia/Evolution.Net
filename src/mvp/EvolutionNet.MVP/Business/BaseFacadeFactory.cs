/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using EvolutionNet.MVP;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseFacadeFactory : BaseFactory, IFacadeFactory
	{
		private const string TYPE_NAME_SOURCE = "{0}Presenter";
		private const string TYPE_NAME_DEST = "{0}Facade";

		/// <summary>
		/// M�todo que retorna um facade a partir de um presenter, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transfer�ncia de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do m�dulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="presenter">Presenter, objeto que representa a apresenta��o</param>
		/// <returns>Retorna o facade correspondente ao presenter</returns>
		public BaseFacade<TO, T, IdT> GetFacade<TO, T, IdT>(BasePresenter<TO, T, IdT> presenter)
			where TO : TO<T, IdT>
			where T : Model<IdT>
		{
			return IoCHelper.InstantiateObj<BaseFacade<TO, T, IdT>>(TYPE_NAME_SOURCE, presenter.GetType(),
																 TYPE_NAME_DEST, GetType());
		}

		public BaseListFacade<TO, T, IdT> GetListFacade<TO, T, IdT>(BaseListPresenter<TO, T, IdT> presenter)
			where TO : ListTO<T, IdT>
			where T : Model<IdT>
		{
			return IoCHelper.InstantiateObj<BaseListFacade<TO, T, IdT>>(TYPE_NAME_SOURCE, presenter.GetType(),
																	 TYPE_NAME_DEST, GetType());
		}

/*
		/// <summary>
		/// Realiza a inicializa��o b�sica de um m�dulo, na implementa��o da Factory.
		/// </summary>
		public override void Initialize()
		{
			if (!isInitialized)
			{
//				DaoAbstractFactory.Instance.Initialize();

				isInitialized = true;
			}
		}

		///<summary>
		/// Realiza a libera��o de recursos alocados pelo objeto.
		///</summary>
		public override void Dispose()
		{
			if (!isDisposed)
			{
//				DaoAbstractFactory.Instance.Dispose();

				isDisposed = true;
			}
		}
*/

	}
	
}