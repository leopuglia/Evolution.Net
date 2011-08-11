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
//		private IList<Category> currentList;
		private PropertySortDirection sort;

		#region Public Properties

//		public bool IsPostBack
//		{
//			get { return false; }
//		}

		public int CurrentPosition
		{
			get { return bindingSource.Position; }
			set
			{
				bindingSource.Position = value;
				SetPosition();
			}
		}

		public Category CurrentModel
		{
			get { return (Category) bindingSource.Current; }
			//TODO: Adicionei isso aqui só pra ficar de acordo com as necessidades da web. Verificar!
			set { CurrentPosition = CurrentList.IndexOf(value); }
		}

		public IList<Category> CurrentList
		{
			get
			{
				var list = new List<Category>();
				foreach (DataGridViewRow row in dataGridView1.SelectedRows)
				{
					list.Add(BindableList[row.Index]);
				}

				return list;
			}
		}

		public SortableBindingList<Category> BindableList
		{
			get { return bindingSource.DataSource as SortableBindingList<Category>; }
			set { bindingSource.DataSource = value; }
		}

		public PropertySortDirection Sort
		{
			get
			{
				return sort;
/*
				if (dataGridView1.SortOrder == SortOrder.None || dataGridView1.SortedColumn == null)
				{
					return new PropertySortDirection();
				}

				return new PropertySortDirection(
					dataGridView1.SortedColumn.DataPropertyName, 
					dataGridView1.SortOrder == SortOrder.Ascending 
						? PropertySortOrder.Ascending 
						: PropertySortOrder.Descending);
*/
			}
		}

		public int SlowWorkTime
		{
			get { return (int)nudSlowWorkTime.Value; }
			set { nudSlowWorkTime.Value = value; }
		}

		#endregion

		#region Constructor

		public CategoryCrudView()
		{
			InitializeComponent();

//			if (!IsVSDesigner)
//				presenter = new CategoryCrudPresenter(this);
		}

		#endregion

		#region Event Methods

		private void CategoryCrudView_Load(object sender, EventArgs e)
		{
			// Do not create the presenter on visual studio design time, because it causes error
			if (!IsVSDesigner)
				presenter = new CategoryCrudPresenter(this);

//			presenter.Load();
		}

		private void CategoryCrudView_AfterLoadComplete(object sender, EventArgs e)
		{
			presenter.AfterLoadComplete();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
//			presenter.To.CurrentModel = (Category)bindingSource.Current;
//			presenter.To.CurrentList = currentList;
			presenter.Add();

//			AdjustDataGridRowHeightColumnWidth();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
//			presenter.To.CurrentModel = (Category)bindingSource.Current;
//			presenter.To.CurrentList = currentList;
			presenter.Edit();

//			AdjustDataGridRowHeightColumnWidth();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
/*
			presenter.To.CurrentModel = (Category)bindingSource.Current;
			presenter.Delete();
*/
//			presenter.To.CurrentList = currentList;
			presenter.DeleteList();

//			AdjustDataGridRowHeightColumnWidth();
		}

		private void btnSlowWork_Click(object sender, EventArgs e)
		{
			presenter.RunSlowWork();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && e.ColumnIndex > -1)
			{
//				presenter.To.Position = bindingSource.Position;
//				presenter.To.CurrentModel = (Category)bindingSource.Current;
//				presenter.To.CurrentList = currentList;
				presenter.Edit();
			}

//			AdjustDataGridRowHeightColumnWidth();
		}

		private void dataGridView1_Sorted(object sender, EventArgs e)
		{
			sort = new PropertySortDirection(
				dataGridView1.SortedColumn.DataPropertyName,
				dataGridView1.SortOrder == SortOrder.Ascending
					? PropertySortOrder.Ascending
					: PropertySortOrder.Descending);
			presenter.Sorted();
//			sort = new PropertySortDirection(dataGridView1.SortedColumn.DataPropertyName, dataGridView1.SortOrder == SortOrder.Ascending);
//			AdjustDataGridRowHeightColumnWidth();
		}

		#endregion

		#region Visual Style (only for WinForms)

		public void AdjustDataGridRowHeightColumnWidth()
		{
			// I've left this method here intentionally, since a web app need different treatment
			// TODO: Refactor this method to the Presenter after creating the web view
			int biggestWidth = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
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

			var column = dataGridView1.Columns["colPictureImage"];
			if (column != null)
			{
				column.Width = biggestWidth;
			}

			SetPosition();
		}

		public void Clear()
		{
		}

		private void SetPosition()
		{
			if (bindingSource.Position >= 0)
			{
				dataGridView1.FirstDisplayedScrollingRowIndex = bindingSource.Position;
				dataGridView1.Focus();
			}
		}

		#endregion

	}
}
