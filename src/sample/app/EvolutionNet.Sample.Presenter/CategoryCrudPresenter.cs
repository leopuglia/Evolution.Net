using System;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Presenter
{
	public class CategoryCrudPresenter : BasePresenter<ICategoryCrudView, ICategoryCrudContract>
	{
//		private SortableBindingList<Category> list;

		public CategoryCrudPresenter(ICategoryCrudView view)
			: base(view)
		{
			try
			{
				DoInit(view);
			}
			catch (Exception ex)
			{
				View.MessageHelper.ShowErrorMessage("Error", "Could not initialize", ex.Message);
			}
		}

		#region Métodos de Inicialização

		protected virtual void DoInit(ICrudView view)
		{
//			view.AddNew += view_AddNew;
			view.Save += view_Save;
			view.Delete += view_Delete;
			view.Edit += view_Edit;
			view.Cancel += view_Cancel;

			DoFindAll();
			BindGrid(!view.IsPostBack);
		}

		#endregion

        #region Métodos de Eventos

/*
		protected void view_AddNew(object sender, CrudEventArgs e)
		{
			ICategoryEditView categoryEditView =
				View.RedirectHelper.CreateModalDialogView<ICategoryEditView>(View, Facade.To.MainModel);

			if (View.RedirectHelper.ShowModalDialogView(categoryEditView, View))
			{
				Facade.To.MainModel = categoryEditView.Model;
				view_Save(sender, e);
			}
		}
*/

		protected void view_Save(object sender, CrudEventArgs e)
        {
            try
            {
                DoSave();
                CleanViewData();

                View.MessageHelper.ShowMessage("Success", "Values saved");
            }
            catch (Exception ex)
            {
//                View.ShowModalDialog();
                View.MessageHelper.ShowErrorMessage("Error", "Error trying to save values", ex.Message);
            }
            finally
            {
                DoFindAll();
                BindGrid(true);
            }
        }

		protected void view_Delete(object sender, CrudEventArgs e)
        {
            try
            {
                Facade.To.MainModel = Facade.To.List[e.RowIndex];
                DoDelete();

                View.MessageHelper.ShowMessage("Success", "Values deleted");
            }
            catch (Exception ex)
            {
				View.MessageHelper.ShowErrorMessage("Error", "Error trying to delete values", ex.Message);
            }
            finally
            {
                CleanViewData();
                DoFindAll();
                BindGrid(true);
            }
        }

		protected void view_Edit(object sender, CrudEventArgs e)
        {
            try
            {
				Facade.To.MainModel = e.RowIndex == -1 ? new Category() : Facade.To.List[e.RowIndex];

				ICategoryEditView categoryEditView =
					View.RedirectHelper.CreateModalDialogView<ICategoryEditView>(View, Facade.To.MainModel);

				if (View.RedirectHelper.ShowModalDialogView(categoryEditView, View))
				{
					Facade.To.MainModel = categoryEditView.Model;
					view_Save(sender, e);
				}
			}
            catch (Exception ex)
            {
				View.MessageHelper.ShowErrorMessage("Error", "Error trying to edit values", ex.Message);
            }
        }

		protected void view_Cancel(object sender, CrudEventArgs e)
        {
            try
            {
                CleanViewData();
//                View.HideModalDialog();
            }
            catch (Exception ex)
            {
				View.MessageHelper.ShowErrorMessage("Error", "Error trying to clean values", ex.Message);
            }
        }

        #endregion

        #region Métodos Locais

        protected virtual void DoSave()
        {
            Facade.Save();
        }

        protected virtual void DoDelete()
        {
            Facade.Delete();
        }

        protected virtual void DoFindAll()
        {
            Facade.FindAll();

//        	list = new SortableBindingList<Category>(Facade.To.List);
        }

        protected virtual void BindGrid(bool bindGrid)
        {
			if (bindGrid)
				View.GridDataSource = Facade.To.List;
//                View.GridDataSource = list;
        }

        protected virtual void CleanViewData()
        {
//            View.Nome = string.Empty;
//            View.Descricao = string.Empty;
//            View.RowIndex = -1;
        }

        #endregion

	}
}