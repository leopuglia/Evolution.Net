using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Classe base para os Facade's, respons�veis pela implementa��o das regras de neg�cios.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object, tipo do objeto de transfer�ncia de dados</typeparam>
	/// <typeparam name="T">MainModel, tipo da principal entidade (model) do m�dulo</typeparam>
	/// <typeparam name="IdT">Identity, tipo do ID do MainModel</typeparam>
    public abstract class BaseListFacade<TO, T, IdT> : BaseFacade<TO>, IListContract<TO, T, IdT>
		where TO : ListTO<T, IdT> 
		where T : class, IModel<IdT>
	{
//        private static readonly ILog log = LogManager.GetLogger(typeof(BaseListFacade<TO, T, IdT>));

		#region Constructor

        protected BaseListFacade(IPresenter presenter) : base(presenter)
		{
		}

		#endregion

		#region M�todos P�blicos (IContract Members)

		/// <summary>
		/// Lista todos os elementos do model
		/// </summary>
		public void FindAll()
		{
			DoFindAll();
		}

		#endregion

		#region Hooks Protegidos

		protected virtual void DoFindAll()
		{
			To.List = Dao<T, IdT>.FindAll();
		}

		#endregion

	}
}
