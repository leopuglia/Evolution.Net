/*
 * Created by: 
 * Created: quarta-feira, 12 de dezembro de 2007
 */

using EvolutionNet.MVP.Core;
using EvolutionNet.MVP.Core.Business;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.IoC;
using EvolutionNet.MVP.Core.Presenter;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenterFactory : BaseFactory, IPresenterFactory
	{
		private const string TYPE_NAME_SOURCE = "{0}View";
		private const string TYPE_NAME_DEST = "{0}Presenter";

		public IPresenter<TO, T, IdT> GetPresenter<TO, T, IdT>(IView<TO, T, IdT> view) where TO 
			: ITo<T, IdT> where T : IModel<IdT>
		{
			return IoCHelper.InstantiateObj<IPresenter<TO, T, IdT>>(TYPE_NAME_SOURCE, view.GetType(),
			                                                        TYPE_NAME_DEST, GetType(), view);
		}

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
		
	}
	
}