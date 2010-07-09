using System;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenter<ViewT, ContractT> : IPresenter
		where ViewT : IView
		where ContractT : IContract
	{
		#region Variáveis Privadas

		private readonly ViewT view;
		private readonly ContractT facade;

		#endregion

		#region Propriedades Públicas

		protected ViewT View
		{
			get { return view; }
		}

		protected ContractT Facade
		{
			get { return facade; }
		}

		public IPathHelper PathHelper
		{
			get { return View.PathHelper; }
		}

		#endregion

		#region Construtores

		protected BasePresenter(ViewT view)
		{
			if (SessionScope.Current == null)
				new SessionScope(FlushAction.Never);

			facade = GetFacade();

			this.view = view;
			view.DoLoad();
		}

		#endregion

		#region Métodos Privados

		private ContractT GetFacade()
		{
			try
			{
				return AbstractIoCFactory<IBusinessFactory>.Instance.GetFromContract<ContractT>(this);
			}
			catch (Exception ex)
			{
				throw new MVPException("Error creating the ICrudContract implementation no Presenter.", ex);
			}
		}

		#endregion

	}
}
