using System;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenter<ViewT, ContractT> : IPresenter
		where ViewT : IView
		where ContractT : IContract
	{
		#region Vari�veis Locais

		private readonly ViewT view;
		private readonly ContractT facade;

		#endregion

		#region Propriedades

		protected ViewT View
		{
			get { return view; }
		}

		protected ContractT Facade
		{
			get { return facade; }
		}

	    #endregion

		#region Construtores

		protected BasePresenter(ViewT view)
		{
//			if (SessionScope.Current == null)
//				new SessionScope(FlushAction.Never);

			facade = GetFacade();

			this.view = view;
			view.DoLoad();
		}

		#endregion

		#region M�todos Privados

		private ContractT GetFacade()
		{
			try
			{
				return AbstractIoCFactory<IBusinessFactory>.Instance.GetFromContract<ContractT>(this);
			}
			catch (Exception ex)
			{
				throw new MVPIoCException("Error creating the ICrudContract implementation no Presenter.", ex);
			}
		}

		#endregion

	    public IPathHelper PathHelper
	    {
            get { return View.PathHelper; }
	    }

/*
	    public IControlHelper ControlHelper
	    {
            get { return View.ControlHelper; }
	    }

	    public IMessageHelper MessageHelper
	    {
            get { return View.MessageHelper; }
	    }
*/
	}
}
