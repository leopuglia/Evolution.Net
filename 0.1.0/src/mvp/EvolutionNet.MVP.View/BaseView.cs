using System;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.Presenter;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.View;

namespace EvolutionNet.MVP.View
{
	public abstract class BaseView<TO, T, IdT> : IView<TO, T, IdT> 
		where TO : ITo<T, IdT>
		where T: IModel<IdT>
	{
		#region Vari�veis Privadas

		private TO to;
		private IPresenter<TO, T, IdT> presenter;

		#endregion

		#region Vari�veis Protegidas

		protected bool isInitialized = false;
		protected bool isDisposed = false;

		#endregion

		#region Propriedades P�blicas

		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao To, que � criado automaticamente pelo framework.
		/// </summary>
		public TO To
		{
			get
			{
//				if (to == null)
//					presenter = PresenterAbstractFactory.Instance.GetPresenter<TO, T, IdT>(this);

				return to;
			}
			set { to = value; }
		}

		/// <summary>
		/// Presenter, cont�m a refer�ncia ao presenter da funcionalidade atual.
		/// </summary>
		public IPresenter<TO, T, IdT> Presenter
		{
			get
			{
//				if (presenter == null)
//					presenter = PresenterAbstractFactory.Instance.GetPresenter<TO, T, IdT>(this);

				return presenter;
			}
		}

		#endregion

		#region Construtor

		/// <summary>
		/// Construtor da classe, chama a inicializa��o.
		/// </summary>
		public BaseView()
		{
			DoInitialize();
		}

		#endregion

		#region Destrutor

		/// <summary>
		/// Destrutor da classe, chama o dispose.
		/// </summary>
		~BaseView()
		{
			Dispose(false);
		}

		#endregion

		#region IView Members

		/// <summary>
		/// Realiza todas as inicializa��es necess�rias.
		/// </summary>
		public virtual void Initialize()
		{
			if (!isInitialized)
			{
				try
				{
					PresenterAbstractFactory.Instance.Initialize();
				}
				catch (Exception ex)
				{
					throw new ApplicationException("N�o foi poss�vel inicializar o PresenterAbstractFactory.", ex);
				}

				try
				{
					//Criando o facade por IoC
					presenter = PresenterAbstractFactory.Instance.GetPresenter(this);
//					presenter.Initialize();
				}
				catch (Exception ex)
				{
					throw new ApplicationException("N�o foi poss�vel instanciar o Facade no Presenter.", ex);
				}
			}
		}

		///<summary>
		/// Realiza a libera��o de recursos alocados pelo objeto.
		///</summary>
		public void Dispose()
		{
			Dispose(true);
		}

		#endregion

		#region M�todos Auxiliares

		///<summary>
		/// Realiza a libera��o de recursos alocados pelo objeto.
		///</summary>
		/// <param name="disposing">Informa se o dispose foi chamado explicitamente ou pelo destrutor</param>
		protected virtual void Dispose(bool disposing)
		{
			if (! isDisposed)
			{
				if (disposing)
				{
					try
					{
						presenter.Dispose();
					}
					catch (Exception ex)
					{
						throw new ApplicationException("N�o foi poss�vel destruir o Presenter na View.", ex);
					}
				}

				try
				{
					PresenterAbstractFactory.Instance.Dispose();
				}
				catch (Exception ex)
				{
					throw new ApplicationException("N�o foi poss�vel destruir o PresenterAbstractFactory.", ex);
				}

				isDisposed = true;
			}
		}

		/// <summary>
		/// M�todo auxiliar para a realiza��o da inicializa��o. Usado para n�o chamar um m�todo virtual no construtor.
		/// </summary>
		private void DoInitialize()
		{
			Initialize();
		}

		#endregion

	}
}
