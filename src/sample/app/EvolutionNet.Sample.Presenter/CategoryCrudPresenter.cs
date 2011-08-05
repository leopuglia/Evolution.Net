using System;
using System.ComponentModel;
using EvolutionNet.MVP;
using EvolutionNet.MVP.Core.ProgressReporting;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.Sample.Presenter
{
	public class CategoryCrudPresenter : 
		BasePresenter<ICategoryCrudView, ICategoryCrudContract>, ICrudPresenter<CategoryCrudTO>, IListPresenter<Category>
	{
		#region Public Properties

		public CategoryCrudTO To
		{
			get { return Bo.To; }
		}

		#endregion

		#region Constructor

		public CategoryCrudPresenter(ICategoryCrudView view)
			: base(view)
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

			view.LoadComplete += view_LoadComplete;
		}

		#endregion

		#region Public Methods

		#region ICrudPresenter

		public void Add()
		{
			Bo.To.MainModel = new Category();
			Edit();
		}

		public void Edit()
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
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to edit values", ex);
			}
		}

		public void Save()
		{
			try
			{
				Bo.Save();

				View.HelperFactory.MessageHelper.ShowMessage("Success", "Values saved");
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to save values", ex);
			}
			finally
			{
				Bo.FindAll();
				View.BindableList = new SortableBindingList<Category>(Bo.To.List);
			}
		}

		public void Delete()
		{
			try
			{
				Bo.Delete();

				View.HelperFactory.MessageHelper.ShowMessage("Success", "Values deleted");
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to delete values", ex);
			}
			finally
			{
				Bo.FindAll();
				View.BindableList = new SortableBindingList<Category>(Bo.To.List);
			}
		}

		public void Cancel()
		{
/*
			try
			{
				CleanViewData();
			}
			catch (Exception ex)
			{
				View.HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to clean values", ex);
			}
*/
		}

		#endregion

		#region BackgroundWork

		// Tudo que acontece dentro desses métodos abaixo tá dentro de outra thread, portanto não pode alterar valores 
		public void SlowWork()
		{
			HelperFactory.BackgroundWorkerHelper.WorkerCanceled += BackgroundWorkerHelper_WorkerCanceled;
			Bo.ProgressHelper.ProgressReported += ProgressHelper_ProgressReported;

			Bo.SlowWork();
		}

		public void SlowWorkCompleted(RunWorkerCompletedEventArgs e)
		{
			//TODO: Implementar um ShowAtentionMessage ou ShowAlertMessage);
			if (e.Cancelled)
				HelperFactory.MessageHelper.ShowErrorMessage(MVPCommonMessages.Common_CaptionError, "The operation was cancelled by the user");
			else if (e.Error != null)
				HelperFactory.MessageHelper.ShowErrorMessage(MVPCommonMessages.Common_CaptionError, "The operation was aborted by an error", e.Error);
			else
				HelperFactory.MessageHelper.ShowMessage(MVPCommonMessages.CommonMessages_Common_CaptionSuccess, "Job Done");

		}

		#endregion

		#region Auxiliary

		public void SlowWorkTimeChanged()
		{
			HelperFactory.BackgroundWorkerHelper.Caption = "Slow Work";
			HelperFactory.BackgroundWorkerHelper.Text = string.Format("Working slowly... Run time expected: {0} seconds", To.SlowWorkTime);
		}

		#endregion

		#endregion

		#region Event Methods

		private void view_LoadComplete(object sender, EventArgs e)
		{
			SlowWorkTimeChanged();
		}

		private void BackgroundWorkerHelper_WorkerCanceled(object sender, EventArgs e)
		{
			Bo.ProgressHelper.Cancel();
		}

		private void ProgressHelper_ProgressReported(object sender, ProgressEventArgs e)
		{
			HelperFactory.BackgroundWorkerHelper.ReportProgress(e.ProgressPercentage);
//			bw.ReportProgress(e.ProgressPercentage);
		}

		#endregion

	}
}