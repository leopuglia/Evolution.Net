/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using EvolutionNet.MVP.Core;
using EvolutionNet.MVP.Core.Business;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.IoC;
using EvolutionNet.MVP.Core.Presenter;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseFacadeFactory : BaseFactory, IFacadeFactory
	{
		private const string TYPE_NAME_SOURCE = "{0}Presenter";
		private const string TYPE_NAME_DEST = "{0}Facade";

		/// <summary>
		/// Método que retorna um facaded a partir de um presenter, pela nomenclatura.
		/// </summary>
		/// <typeparam name="TO">Tranfer Object, tipo do objeto de transferência de dados</typeparam>
		/// <typeparam name="T">MainModel, tipo da principal entidade (model) do módulo</typeparam>
		/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
		/// <param name="presenter">Presenter, objeto que representa a apresentação</param>
		/// <returns>Retorna o facade correspondente ao presenter</returns>
		public IFacade<TO, T, IdT> GetFacade<TO, T, IdT>(IPresenter<TO, T, IdT> presenter) 
			where TO : ITo<T, IdT> 
			where T : IModel<IdT>
		{
			return IoCHelper.InstantiateObj<IFacade<TO, T, IdT>>(TYPE_NAME_SOURCE, presenter.GetType(),
																 TYPE_NAME_DEST, GetType());
		}

		public IListFacade<TO, T, IdT> GetListFacade<TO, T, IdT>(IListPresenter<TO, T, IdT> presenter) 
			where TO : IListTo<T, IdT> 
			where T : IModel<IdT>
		{
			return IoCHelper.InstantiateObj<IListFacade<TO, T, IdT>>(TYPE_NAME_SOURCE, presenter.GetType(),
																	 TYPE_NAME_DEST, GetType());
		}

		/// <summary>
		/// Realiza a inicialização básica de um módulo, na implementação da Factory.
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
		/// Realiza a liberação de recursos alocados pelo objeto.
		///</summary>
		public override void Dispose()
		{
			if (!isDisposed)
			{
//				DaoAbstractFactory.Instance.Dispose();

				isDisposed = true;
			}
		}
	}
	
}