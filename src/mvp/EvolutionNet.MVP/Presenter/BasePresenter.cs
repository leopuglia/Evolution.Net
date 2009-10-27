using System;
using Castle.ActiveRecord;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Contract;
using EvolutionNet.MVP.IoC;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.Presenter
{
	public abstract class BasePresenter<ViewT, ContractT> : IPresenter
		where ViewT : IView
		where ContractT : IBaseContract
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

		#endregion

		#region Construtores

		protected BasePresenter(ViewT view)
		{
			if (SessionScope.Current == null)
				new SessionScope(FlushAction.Never);

			facade = GetFacade();

			this.view = view;
			view.Initialize();
		}

		#endregion

		#region Métodos Privados

		private ContractT GetFacade()
		{
			try
			{
				return AbstractIoCFactory<IBaseFacadeFactory>.Instance.GetFromContract<ContractT>();
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Não foi possível instanciar o Facade no Presenter.", ex);
			}
		}

		#endregion

	}
}
