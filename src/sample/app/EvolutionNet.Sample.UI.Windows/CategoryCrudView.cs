using System;
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

		#region Public Properties

//		public bool IsPostBack
//		{
//			get { return false; }
//		}

		public SortableBindingList<Category> BindableList
		{
			get { return bindingSource.DataSource as SortableBindingList<Category>; }
			set { bindingSource.DataSource = value; }
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
		}

		#endregion

		#region Event Methods

		private void CategoryCrudView_Load(object sender, EventArgs e)
		{
			// Do not create the presenter on visual studio design time, because it causes error
			if (!IsVSDesigner)
				presenter = new CategoryCrudPresenter(this);
		}

		private void CategoryCrudView_LoadComplete(object sender, EventArgs e)
		{
			presenter.LoadComplete();

			AjustDataGridRowHeightColumnWidth();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			presenter.Add();

			AjustDataGridRowHeightColumnWidth();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			presenter.To.MainModel = (Category)bindingSource.Current;
			presenter.Edit();

			AjustDataGridRowHeightColumnWidth();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			presenter.To.MainModel = (Category)bindingSource.Current;
			presenter.Delete();

			AjustDataGridRowHeightColumnWidth();
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
				presenter.To.MainModel = (Category)bindingSource.Current;
				presenter.Edit();
			}

			AjustDataGridRowHeightColumnWidth();
		}

		private void dataGridView1_Sorted(object sender, EventArgs e)
		{
			AjustDataGridRowHeightColumnWidth();
		}

		#endregion

		#region Visual Style (only for WinForms)

		private void AjustDataGridRowHeightColumnWidth()
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

			dataGridView1.Columns[4].Width = biggestWidth;

			dataGridView1.FirstDisplayedScrollingRowIndex = bindingSource.Position;
		}

		#endregion

	}
}
