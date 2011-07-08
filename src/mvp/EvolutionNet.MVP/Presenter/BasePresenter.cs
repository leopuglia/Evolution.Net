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

		public IHelperFactory HelperFactory
		{
			get { return View.HelperFactory; }
		}
		
		#endregion

		#region Construtores

		protected BasePresenter(ViewT view)
		{
			//Todo: Retirei a chamada daqui, porque, de vez em quando, estava chamando mais de uma vez, apesar da instância da factory
//			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();

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
