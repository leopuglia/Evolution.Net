using System;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenter<ViewT, ContractT> : IPresenter
		where ViewT : IView
		where ContractT : IContract
	{
		#region Variáveis Locais

		private readonly ViewT view;
		private readonly ContractT facade;

		#endregion

		#region Propriedades Locais

		protected ViewT View
		{
			get { return view; }
		}

		protected ContractT Facade
		{
			get { return facade; }
		}

		#endregion

		#region Propriedades Públicas

		public IPathHelper PathHelper
		{
			get { return View.PathHelper; }
		}
		
		#endregion

		#region Construtores

		protected BasePresenter(ViewT view)
		{
			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();

			facade = GetFacade();

			this.view = view;
		}

		#endregion

		#region Métodos Locais

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

	}
}
