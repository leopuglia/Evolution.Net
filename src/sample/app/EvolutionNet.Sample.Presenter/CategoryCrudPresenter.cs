using System;
using EvolutionNet.MVP;
using EvolutionNet.MVP.Business.ProgressReporting;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.BackgroundWork;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.Sample.Presenter
{
	public class CategoryCrudPresenter : 
		BaseCrudListPresenter<ICategoryCrudView, ICategoryCrudContract, CategoryCrudTO, Category, int>, IBackgroundWork
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

			To.SlowWorkTime = view.SlowWorkTime;

			FindAll();

			if (view is IWebControl && ((IWebControl)view).IsPostBack)
				return;
			
			DataBind();
		}

		#endregion

		#region Public Methods

//		public void Load()
//		{
//			View.AdjustDataGridRowHeightColumnWidth();
//		}

		public void AfterLoadComplete()
		{
//			RunSlowWork();
			View.AdjustDataGridRowHeightColumnWidth();
		}

		public void Sorted()
		{
//			sort = View.Sort;
			View.AdjustDataGridRowHeightColumnWidth();
		}

		#region ICrudListPresenter

		public override void FindAll()
		{
			try
			{
				Bo.FindAll();
			}
			catch (Exception ex)
			{
				HelperFactory.MessageHelper.ShowErrorMessage("Error", "Could not list values", ex);
			}

		}

		private void DataBind()
		{
			View.BindableList = new SortableBindingList<Category>(To.List);
			if (View.Sort.SortOrder != PropertySortOrder.None)
				View.BindableList.Sort(View.Sort);

			View.CurrentPosition = View.BindableList.IndexOf(To.CurrentModel);

			View.AdjustDataGridRowHeightColumnWidth();
		}

		public override void Add()
		{
			try
			{
				To.CurrentModel = new Category();
				if (DoEdit())
				{
					FindAll();
					DataBind();

					HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) added");
				}
				else
				{
					View.AdjustDataGridRowHeightColumnWidth();
				}
			}
			catch (Exception ex)
			{
				HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to add value(s)", ex);
			}
			finally
			{
				Clear();
			}
		}

		public override void Edit()
		{
			try
			{
				if (View.CurrentList.Count <= 1)
				{
//					if (View.CurrentModel != null)
//						To.CurrentModel = View.CurrentModel;
					if (View.CurrentPosition > -1)
					{
						var bindableList = View.BindableList ?? new SortableBindingList<Category>(To.List);
						if (View.Sort.SortOrder != PropertySortOrder.None)
							bindableList.Sort(View.Sort);

						To.CurrentModel = bindableList[View.CurrentPosition];
					}
					else
					{
						HelperFactory.MessageHelper.ShowErrorMessage("Error", "No row was selected to edit");
					}

					if (DoEdit())
					{
						FindAll();
						DataBind();

						HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) edited");

						Clear();
					}
					else
					{
						View.AdjustDataGridRowHeightColumnWidth();
					}
				}
				else
				{
					HelperFactory.MessageHelper.ShowErrorMessage("Error", "Please select only one row to edit");
				}
			}
			catch (Exception ex)
			{
				HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to edit value(s)", ex);
			}
		}

		private bool DoEdit()
		{
			ICategoryEditView categoryEditView =
				HelperFactory.RedirectHelper.CreateModalDialogView<ICategoryEditView>(View, To.CurrentModel);

			if (HelperFactory.RedirectHelper.ShowModalDialogView(categoryEditView, View))
			{
				To.CurrentModel = categoryEditView.Model;
				Bo.Save();

//				HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) saved");

				return true;
			}
			
			categoryEditView.Model = To.CurrentModel;

			return false;
		}

		public override void Save()
		{
			try
			{
				To.CurrentID = View.CurrentModel.ID;
				To.CurrentModel = View.CurrentModel;

				if (To.CurrentID != 0)
				{
					Bo.Find();

					To.CurrentModel.CategoryName = View.CurrentModel.CategoryName;
					To.CurrentModel.Description = View.CurrentModel.Description;
					To.CurrentModel.PictureImage = View.CurrentModel.PictureImage;
				}

				Bo.Save();

				FindAll();
				DataBind();

				HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) saved");
			}
			catch (Exception ex)
			{
				HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to save value(s)", ex);
			}
			finally
			{
				Clear();
			}
		}

		public override void SaveList()
		{
			try
			{
				To.CurrentList = View.CurrentList;
				Bo.SaveList();

				HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) saved");

				FindAll();
				DataBind();
			}
			catch (Exception ex)
			{
				HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to save value(s)", ex);
			}
			finally
			{
				Clear();
			}
		}

		public override void Delete()
		{
			try
			{
//				To.CurrentModel = View.CurrentModel;
//				var position = View.CurrentPosition;
				if (View.CurrentList.Count <= 1)
				{
//					if (View.CurrentModel != null)
//						To.CurrentModel = View.CurrentModel;
					if (View.CurrentPosition > -1)
					{
						var bindableList = View.BindableList ?? new SortableBindingList<Category>(To.List);
						if (View.Sort.SortOrder != PropertySortOrder.None)
							bindableList.Sort(View.Sort);

						To.CurrentModel = bindableList[View.CurrentPosition];
					}
					else
					{
						HelperFactory.MessageHelper.ShowErrorMessage("Error", "No row was selected to delete");
					}

					Bo.Delete();

					FindAll();
					DataBind();

					HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) deleted");

//					View.CurrentPosition = position < View.BindableList.Count ? position : View.BindableList.Count - 1;
				}
				else
				{
					HelperFactory.MessageHelper.ShowErrorMessage("Error", "Please select only one row to delete");
				}
			}
			catch (Exception ex)
			{
				HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to delete value(s)", ex);
			}
			finally
			{
				Clear();
			}
		}

		public override void DeleteList()
		{
			try
			{
				To.CurrentList = View.CurrentList;
				var position = View.CurrentPosition;
				Bo.DeleteList();

				FindAll();
				DataBind();

				HelperFactory.MessageHelper.ShowMessage("Success", "Value(s) deleted");

				View.CurrentPosition = position < View.BindableList.Count ? position : View.BindableList.Count - 1;
			}
			catch (Exception ex)
			{
				HelperFactory.MessageHelper.ShowErrorMessage("Error", "Error trying to delete value(s)", ex);
			}
			finally
			{
				Clear();
			}
		}

		public override void Clear()
		{
//			View.CurrentModel = new Category();
//			To.CurrentModel = View.CurrentModel = new Category();
			View.Clear();
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