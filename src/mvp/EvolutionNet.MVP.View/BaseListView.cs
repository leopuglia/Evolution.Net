using System;
using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.Presenter;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.View;

namespace EvolutionNet.MVP.View
{
	public class BaseListView<TO, T, IdT> : IListView<TO, T, IdT> 
		where TO : IListTo<T, IdT>
		where T: IModel<IdT>
	{
		#region Variáveis Privadas

		private TO to;
		private IListPresenter<TO, T, IdT> presenter;

		#endregion

		#region Variáveis Protegidas

		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Propriedades Públicas

		/// <summary>
		/// Transfer Object, contém a referência ao To, que é criado automaticamente pelo framework.
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
		/// Presenter, contém a referência ao presenter da funcionalidade atual.
		/// </summary>
		public PresenterT GetPresenter<PresenterT>() where PresenterT : IListContract
		{
			return (PresenterT) presenter;
		}

		#endregion

		#region Construtor

		/// <summary>
		/// Construtor da classe, chama a inicialização.
		/// </summary>
		protected BaseListView()
		{
			DoInitialize();
		}

		#endregion

		#region Destrutor

		/// <summary>
		/// Destrutor da classe, chama o dispose.
		/// </summary>
		~BaseListView()
		{
			Dispose(false);
		}

		#endregion

		#region IView Members

		/// <summary>
		/// Realiza todas as inicializações necessárias.
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
					throw new ApplicationException("Não foi possível inicializar o PresenterAbstractFactory.", ex);
				}

				try
				{
					//Criando o facade por IoC
					presenter = PresenterAbstractFactory.Instance.GetListPresenter(this);
//					presenter.Initialize();
				}
				catch (Exception ex)
				{
					throw new ApplicationException("Não foi possível instanciar o Facade no Presenter.", ex);
				}
			}
		}

		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
		///</summary>
		public void Dispose()
		{
			Dispose(true);
		}

		#endregion

		#region Métodos Auxiliares

		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
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
						throw new ApplicationException("Não foi possível destruir o Presenter na View.", ex);
					}
				}

				try
				{
					PresenterAbstractFactory.Instance.Dispose();
				}
				catch (Exception ex)
				{
					throw new ApplicationException("Não foi possível destruir o PresenterAbstractFactory.", ex);
				}

				isDisposed = true;
			}
		}

		/// <summary>
		/// Método auxiliar para a realização da inicialização. Usado para não chamar um método virtual no construtor.
		/// </summary>
		private void DoInitialize()
		{
			Initialize();
		}

		#endregion

	}
}
