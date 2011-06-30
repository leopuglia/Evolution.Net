using System;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Presenter;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class CategoryCrudView : BaseUCView, ICategoryCrudView
	{
		public object GridDataSource
		{
			get { return bindingSource.DataSource; }
			set { bindingSource.DataSource = value; }
		}

		public bool IsPostBack
		{
			get { return false; }
		}

//		public event CrudEventHandler AddNew;
		public event CrudEventHandler Save;
		public event CrudEventHandler Delete;
		public event CrudEventHandler Edit;
		public event CrudEventHandler Cancel;

		public CategoryCrudView()
		{
			InitializeComponent();

			// Do not create the presenter on visual studio design time, because it causes error
//			if (!IsVSDesigner)
//				new CategoryCrudPresenter(this);
		}

		private void CategoryCrudView_Load(object sender, EventArgs e)
		{
			// Do not create the presenter on visual studio design time, because it causes error
			if (!IsVSDesigner)
				new CategoryCrudPresenter(this);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (Edit != null)
				Edit(sender, new CrudEventArgs());
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (Edit != null)
				Edit(sender, new CrudEventArgs(bindingSource.Position));
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (Delete != null)
				Delete(sender, new CrudEventArgs(bindingSource.Position));
		}

		private void dataGridView1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
		{
			if (Edit != null && e.RowIndex > -1 && e.ColumnIndex > -1)
				Edit(sender, new CrudEventArgs(bindingSource.Position));
		}

	}
}
