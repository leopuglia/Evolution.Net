using System;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenter<ViewT, ContractT> : IPresenter
		where ViewT : IView
		where ContractT : IContract
	{
		#region Variáveis Locais

		private readonly ViewT view;
		private readonly ContractT bo;

		#endregion

		#region Propriedades Locais

		protected ViewT View
		{
			get { return view; }
		}

		[Obsolete]
		protected ContractT Facade
		{
			get { return bo; }
		}

		protected ContractT Bo
		{
			get { return bo; }
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
			// TODO: Retirei a chamada daqui, porque, de vez em quando, estava chamando mais de uma vez, apesar da instância da factory
//			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();

			bo = GetBO();

			this.view = view;
		}

		#endregion

		#region Métodos Locais

		private ContractT GetBO()
		{
			try
			{
				return AbstractIoCFactory<IBusinessFactory>.Instance.GetFromContract<ContractT>(this);
			}
			catch (Exception ex)
			{
				throw new MVPIoCException("Error creating the ICrudListContract implementation no Presenter.", ex);
			}
		}

		#endregion

	}
}
