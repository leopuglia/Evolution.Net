using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Sample.Presenter;
using EvolutionNet.Sample.UI.Web.Base;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.Sample.UI.Web
{
	public partial class CategoryCrudView : BaseSampleView, ICategoryCrudView, IEditViewContainer<ICategoryEditView>
	{
		private const int StandardSlowWorkTime = 5;
		private CategoryCrudPresenter presenter;
		private PropertySortDirection sort
		{
			get
			{
				return ViewState["Sort"] == null
					? new PropertySortDirection() : (PropertySortDirection)ViewState["Sort"];
			}
			set { ViewState["Sort"] = value; }
		}

		#region Public Properties

		public int CurrentPosition
		{
			get { return ViewState["CurrentPosition"] == null ? -1 : (int)ViewState["CurrentPosition"]; }
			set { ViewState["CurrentPosition"] = value; }
		}

		public Category CurrentModel
		{
			get { return CategoryEditUC1.Model; }
			set { CategoryEditUC1.Model = value; }
		}

		public IList<Category> CurrentList
		{
//			get
//			{
//				var list = new List<Category>();
//				foreach (DataGridViewRow row in DataGridCategories.s)
//				{
//					list.Add(BindableList[row.Index]);
//				}
//
//				return list;
//			}
			get { return new List<Category>(); }
		}

		public SortableBindingList<Category> BindableList
		{
			get { return DataGridCategories.DataSource as SortableBindingList<Category>; }
			set
			{
				DataGridCategories.DataSource = value;
				DataGridCategories.DataBind();
			}
		}

		public PropertySortDirection Sort
		{
			get { return sort; }
		}

		public int SlowWorkTime
		{
			get { return string.IsNullOrEmpty(TxtSlowWorkTime.Text) ? StandardSlowWorkTime : int.Parse(TxtSlowWorkTime.Text); }
			set { TxtSlowWorkTime.Text = value.ToString(); }
		}

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			presenter = CategoryEditUC1.Presenter = new CategoryCrudPresenter(this);
		}

		protected void DataGridCategories_RowEditing(object sender, GridViewEditEventArgs e)
		{
			CurrentPosition = e.NewEditIndex;
			presenter.Edit();
		}

		protected void DataGridCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			CurrentPosition = e.RowIndex;
			presenter.Delete();
		}

		#region Métodos Públicos

		public void Clear()
		{
			CategoryEditUC1.Clear();
		}

		public void ShowModalDialog()
		{
			ModalPopupNew.Show();
		}

		public void HideModalDialog()
		{
			ModalPopupNew.Hide();
		}

		public void AdjustDataGridRowHeightColumnWidth()
		{
		}

		#endregion

		public ICategoryEditView EditView
		{
			get { return CategoryEditUC1; }
		}
	}
}