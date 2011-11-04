using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseListBO<TO, T, IdT> : BaseBO<TO>, IListContract<TO, T, IdT>
		where TO : ListTO<T, IdT> 
		where T : class, IModel<IdT>
	{
		#region Constructor

		protected BaseListBO(IPresenter presenter) : base(presenter)
		{
		}

		#endregion

		#region Public Methods

//		public override TO To
//		{
//			get { return base.To; }
//		}

		/// <summary>
		/// List all MainModel's to the List
		/// </summary>
		public void FindAll()
		{
			Execute(DoFindAll, false);
		}

		public void Find()
		{
			Execute(DoFind, false);
		}

		#endregion

		#region Protected Virtual Methods

		protected virtual void DoFindAll()
		{
			To.List = Dao<T, IdT>.FindAll();
		}

		protected virtual void DoFind()
		{
//			To.CurrentModel = Dao<T, IdT>.FindByPrimaryKey(To.CurrentID);
			To.CurrentModel = Dao<T, IdT>.FindByPrimaryKey(To.CurrentModel.ID);
		}

		#endregion

	}
}
