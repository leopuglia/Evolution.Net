using System;
using EvolutionNet.MVP.Core.ProgressReporting;
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
	public class BaseBO<TO> : IContract where TO : class, ITO
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseBO<TO>));

		#region Local Attributes

		private readonly TO to;
		private readonly IPresenter presenter;
		private readonly ProgressReportHelper progressHelper;

		protected bool isInitialized;
		protected bool isDisposed;

		#endregion

		#region Public Properties

		/// <summary>
		/// Contains the reference to the current Presenter, created via PresenterFactory
		/// </summary>
		public IPresenter Presenter
		{
			get { return presenter; }
		}

		/// <summary>
		/// Contains the reference to the current Transfer Object, created (automatically) on the facade
		/// </summary>
		public TO To
		{
			get { return to; }
		}

		public bool ReportsProgress
		{
			get { return progressHelper.ReportsProgress; }
			set { progressHelper.ReportsProgress = value; }
		}

		public ProgressReportHelper ProgressHelper
		{
			get { return progressHelper; }
		}

		#endregion

		#region Constructor

		protected BaseBO(IPresenter presenter)
		{
			// Sets the local reference to the Presenter
			this.presenter = presenter;

			// Initializes the ActiveRecord/NHibernate Session Scope
			DaoInitializer.Instance.InitializeSessionScope();

			progressHelper = new ProgressReportHelper();

			try
			{
				// Create the TO Instance. The BaseTO constructor is called, creating the Dao instance
				to = Activator.CreateInstance<TO>();
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error(CommonMessages.BaseFacade_Error001, ex);

				throw new MVPIoCException(CommonMessages.BaseFacade_Error001, ex);
			}

		}

		#endregion

	}
}