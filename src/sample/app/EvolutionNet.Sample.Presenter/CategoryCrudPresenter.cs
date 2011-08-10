using System;
using EvolutionNet.MVP;
using EvolutionNet.MVP.Business.ProgressReporting;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View.BackgroundWork;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.Sample.Presenter
{
	public class CategoryCrudPresenter : 
		BaseCrudPresenter<ICategoryCrudView, ICategoryCrudContract, CategoryCrudTO, Category, int>, IBackgroundWork
	{
		private readonly IBackgroundWorkerHelper backgroundWorker;

		#region Constructor

		public CategoryCrudPresenter(ICategoryCrudView view) : base(view)
		{
			Bo.ProgressReported += Bo_ProgressReported;

			backgroundWorker = HelperFactory.GetBackgroundWorkerHelper();
			backgroundWorker.SuportsCancellation = Bo.SupportsCancellation;
			backgroundWorker.WorkerCanceled += BackgroundWorkerHelper_WorkerCanceled;
			backgroundWorker.WorkerError += BackgroundWorkerHelper_WorkerError;
			backgroundWorker.WorkerCompleted += BackgroundWorkerHelper_WorkerCompleted;
//			HelperFactory.BackgroundWorkerHelper.DoWorkDelegate += SlowWork;

			FindAll();

			To.SlowWorkTime = view.SlowWorkTime;
		}

		#endregion

		#region Public Methods

		public void LoadComplete()
		{
			RunSlowWork();
		}

		#region ICrudPresenter

		public override void FindAll()
		{
			try
			{
				Bo.FindAll();
				View.BindableList = new SortableBindingList<Category>(Bo.To.List);
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Could not initialize", ex);
			}

		}

		public override void Add()
		{
			Bo.To.MainModel = new Category();
			Edit();
		}

		public override void Edit()
		{
			try
			{
				ICategoryEditView categoryEditView =
					View.HelperFactory.RedirectHelper.CreateModalDialogView<ICategoryEditView>(View, Bo.To.MainModel);

				if (View.HelperFactory.RedirectHelper.ShowModalDialogView(categoryEditView, View))
				{
					Bo.To.MainModel = categoryEditView.Model;
					Save();
				}
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to edit value(s)", ex);
			}
		}

		public override void Save()
		{
			try
			{
				Bo.Save();

				View.HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) saved");
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to save value(s)", ex);
			}
			finally
			{
				Bo.FindAll();
				View.BindableList = new SortableBindingList<Category>(Bo.To.List);
			}
		}

		public override void Delete()
		{
			try
			{
				Bo.Delete();

				View.HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) deleted");
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to delete value(s)", ex);
			}
			finally
			{
				Bo.FindAll();
				View.BindableList = new SortableBindingList<Category>(Bo.To.List);
			}
		}

		public override void Clear()
		{
/*
			try
			{
				CleanViewData();
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to clean value(s)", ex);
			}
*/
		}

		#endregion

		#region BackgroundWork

		public void RunSlowWork()
		{
/*
			HelperFactory.BackgroundWorkerHelper.RunWorker(this);
			HelperFactory.BackgroundWorkerHelper.ShowProgressDialog(
				View, 
				"Slow Work", 
				string.Format("Working slowly... Run time expected: {0} seconds", To.SlowWorkTime));
*/
			backgroundWorker.RunWorkerWithProgressDialog(this, View,
				"Slow Work", string.Format("Working slowly... Run time expected: {0} seconds", To.SlowWorkTime));
		}

		// Tudo que acontece dentro desses métodos abaixo tá dentro de outra thread, portanto não pode alterar valores 
		public void DoBackgroundWork()
		{
			Bo.SlowWork();
		}

		#endregion

		#endregion

		#region Event Methods

		private void Bo_ProgressReported(object sender, ProgressEventArgs e)
		{
			backgroundWorker.ReportProgress(e.ProgressPercentage);
		}

		private void BackgroundWorkerHelper_WorkerCanceled(object sender, EventArgs e)
		{
			HelperFactory.MessageHelper.ShowErrorMessage(MVPCommonMessages.Common_CaptionError, "The operation was cancelled by the user");
		}

		private void BackgroundWorkerHelper_WorkerError(object sender, WorkerErrorEventArgs e)
		{
			HelperFactory.MessageHelper.ShowErrorMessage(MVPCommonMessages.Common_CaptionError, "The operation was aborted by an error", e.Error);
		}

		private void BackgroundWorkerHelper_WorkerCompleted(object sender, EventArgs e)
		{
			HelperFactory.MessageHelper.ShowMessage(MVPCommonMessages.CommonMessages_Common_CaptionSuccess, "Job Done");
		}

		#endregion

	}
}