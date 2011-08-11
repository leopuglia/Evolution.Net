using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Sample.Presenter;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class CategoryCrudView : BaseUCView, ICategoryCrudView
	{
		private CategoryCrudPresenter presenter;
		private PropertySortDirection sort;

		#region Public Properties

		public int CurrentPosition
		{
			get { return BindingSource1.Position; }
			set
			{
				BindingSource1.Position = value;
				SetPosition();
			}
		}

		// This item, when set, updates the CurrentPosition, for the presenter to be compatible with the equivalent web view
		public Category CurrentModel
		{
			get { return (Category) BindingSource1.Current; }
			set { CurrentPosition = CurrentList.IndexOf(value); }
		}

		public IList<Category> CurrentList
		{
			get
			{
				var list = new List<Category>();
				foreach (DataGridViewRow row in DataGridCategory.SelectedRows)
				{
					list.Add(BindableList[row.Index]);
				}

				return list;
			}
		}

		public SortableBindingList<Category> BindableList
		{
			get { return BindingSource1.DataSource as SortableBindingList<Category>; }
			set { BindingSource1.DataSource = value; }
		}

		public PropertySortDirection Sort
		{
			get { return sort; }
		}

		public int SlowWorkTime
		{
			get { return (int)NumericSlowWorkTime.Value; }
			set { NumericSlowWorkTime.Value = value; }
		}

		#endregion

		#region Constructor

		public CategoryCrudView()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Methods

		private void CategoryCrudView_Load(object sender, EventArgs e)
		{
			// Do not create the presenter on visual studio design time, because it causes error
			if (!IsVSDesigner)
				presenter = new CategoryCrudPresenter(this);
		}

		private void CategoryCrudView_AfterLoadComplete(object sender, EventArgs e)
		{
			presenter.AfterLoadComplete();
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			presenter.Add();
		}

		private void BtnEdit_Click(object sender, EventArgs e)
		{
			presenter.Edit();
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			presenter.DeleteList();
		}

		private void BtnSlowWork_Click(object sender, EventArgs e)
		{
			presenter.RunSlowWork();
		}

		private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && e.ColumnIndex > -1)
			{
				presenter.Edit();
			}
		}

		private void DataGridView1_Sorted(object sender, EventArgs e)
		{
			sort = new PropertySortDirection(
				DataGridCategory.SortedColumn.DataPropertyName,
				DataGridCategory.SortOrder == SortOrder.Ascending
					? PropertySortOrder.Ascending
					: PropertySortOrder.Descending);
			presenter.Sorted();
		}

		#endregion

		#region Public Methods

		// Implemented void, since the CategoryEditView is a dialog, the clear method should be on it
		public void Clear()
		{
		}

		#endregion

		#region Visual Style (only for WinForms)

		public void AdjustDataGridRowHeightColumnWidth()
		{
			// I've left this method here intentionally, since a web app doesn't need this treatment
			int biggestWidth = 0;
			foreach (DataGridViewRow row in DataGridCategory.Rows)
			{
				if (row.Index < BindableList.Count && BindableList[row.Index].PictureImage != null)
				{
					row.Height = BindableList[row.Index].PictureImage.Height;
					if (biggestWidth < BindableList[row.Index].PictureImage.Width)
					{
						biggestWidth = BindableList[row.Index].PictureImage.Width;
					}
				}
			}

			var column = DataGridCategory.Columns["ColPictureImage"];
			if (column != null)
			{
				column.Width = biggestWidth;
			}

			SetPosition();
		}

		#endregion

		#region Local Auxiliary Methods

		private void SetPosition()
		{
			if (BindingSource1.Position >= 0)
			{
				DataGridCategory.FirstDisplayedScrollingRowIndex = BindingSource1.Position;
				DataGridCategory.Focus();
			}
		}

		#endregion

	}
}
