using EvolutionNet.MVP.Data.Access;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;
using log4net;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Base class for all Business Objects. Implements the IContract interface.
	/// </summary>
	/// <typeparam name="TO">Tranfer Object: used to transfer values between the layers</typeparam>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="IdT"></typeparam>
	public abstract class BaseReadBO<TO, T, IdT> : BaseBO<TO>, IReadContract<TO, T, IdT>
		where TO : ReadTO<T, IdT>
		where T : class, IModel<IdT>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseReadBO<TO, T, IdT>));

		#region Constructor

		protected BaseReadBO(IPresenter presenter) : base(presenter)
		{
		}

		#endregion

		#region Public Methods

//		public override TO To
//		{
//			get { return base.To; }
//		}

		/// <summary>
		/// Fetch the data of the MainModel from the To.ID
		/// </summary>
		public void Find()
		{
			Execute(DoFind, false);
		}

		#endregion

		#region Protected Virtual Methods

		/// <summary>
		/// Fetch the data of the MainModel from the To.ID
		/// </summary>
		protected virtual void DoFind()
		{
			To.CurrentModel = Dao<T, IdT>.FindByPrimaryKey(To.CurrentModel.ID);
		}

		#endregion

	}
}