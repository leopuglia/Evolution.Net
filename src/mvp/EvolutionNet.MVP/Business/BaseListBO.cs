using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	public class BaseListBO<TO, T, IdT> : BaseBO<TO>, IListContract<TO, T, IdT>
		where TO : ListTO<T, IdT> 
		where T : class, IModel<IdT>
	{
		#region Constructor

		protected BaseListBO(IPresenter presenter) : base(presenter)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// List all MainModel's to the List
		/// </summary>
		public void FindAll()
		{
			Execute(DoFindAll, false);
		}

		#endregion

		#region Protected Virtual Methods

		protected virtual void DoFindAll()
		{
			To.List = Dao<T, IdT>.FindAll();
		}

		#endregion

	}
}
