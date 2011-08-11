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
/*
			get { return bindingSource.Position; }
			set
			{
				bindingSource.Position = value;
				SetPosition();
			}
*/
			get { return ViewState["CurrentPosition"] == null ? -1 : (int)ViewState["CurrentPosition"]; }
			set { ViewState["CurrentPosition"] = value; }
		}

//		private Category currentModel;
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
//				foreach (DataGridViewRow row in dataGridView1.s)
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
			get { return dataGridView1.DataSource as SortableBindingList<Category>; }
			set
			{
				dataGridView1.DataSource = value;
				dataGridView1.DataBind();
			}
		}

		public PropertySortDirection Sort
		{
			get { return sort; }
		}

		//TODO: Implementar
		private int slowWorkTime;
		public int SlowWorkTime
		{
//			get { return (int)nudSlowWorkTime.Value; }
//			set { nudSlowWorkTime.Value = value; }
			get { return slowWorkTime; }
			set { slowWorkTime = value; }
		}

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			presenter = CategoryEditUC1.Presenter = new CategoryCrudPresenter(this);
		}

		protected void dataGridView1_RowEditing(object sender, GridViewEditEventArgs e)
		{
			CurrentPosition = e.NewEditIndex;
			presenter.Edit();
//			RowIndex = e.NewEditIndex;
//			if (Edit != null)
//				Edit(sender, new CrudEventArgs(RowIndex));
		}

		protected void dataGridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
			modalPopupNew.Show();
		}

		public void HideModalDialog()
		{
			modalPopupNew.Hide();
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