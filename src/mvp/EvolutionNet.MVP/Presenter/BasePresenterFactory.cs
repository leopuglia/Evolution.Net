/*
 * Created by: 
 * Created: quarta-feira, 12 de dezembro de 2007
 */

using EvolutionNet.MVP;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenterFactory : BaseFactory, IPresenterFactory
	{
		private const string TYPE_NAME_SOURCE = "{0}View";
		private const string TYPE_NAME_DEST = "{0}Presenter";

		public BasePresenter<TO, T, IdT> GetPresenter<TO, T, IdT>(IView view) 
			where TO : TO<T, IdT> 
			where T : Model<IdT>
		{
			return IoCHelper.InstantiateObj<BasePresenter<TO, T, IdT>>(TYPE_NAME_SOURCE, view.GetType(),
			                                                        TYPE_NAME_DEST, GetType(), view);
		}

		public BaseListPresenter<TO, T, IdT> GetListPresenter<TO, T, IdT>(IListView view) 
			where TO : ListTO<T, IdT> 
			where T : Model<IdT>
		{
			return IoCHelper.InstantiateObj<BaseListPresenter<TO, T, IdT>>(TYPE_NAME_SOURCE, view.GetType(),
																		TYPE_NAME_DEST, GetType(), view);
		}

/*
		public override void Initialize()
		{
			if (!isInitialized)
			{
//				FacadeAbstractFactory.Instance.Initialize();

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
//				FacadeAbstractFactory.Instance.Dispose();

				isDisposed = true;
			}
		}
*/
		
	}
	
}