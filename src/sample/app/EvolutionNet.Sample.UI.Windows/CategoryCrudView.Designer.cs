using System.Windows.Forms;

namespace EvolutionNet.Sample.UI.Windows
{
	partial class CategoryCrudView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.productsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pictureImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSlowWork = new System.Windows.Forms.Button();
			this.nudSlowWorkTime = new System.Windows.Forms.NumericUpDown();
			this.lblSlowProcess = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSlowWorkTime)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.categoryNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.productsDataGridViewTextBoxColumn,
            this.pictureImageDataGridViewImageColumn});
			this.dataGridView1.DataSource = this.bindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(0, 33);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(784, 489);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// categoryNameDataGridViewTextBoxColumn
			// 
			this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
			this.categoryNameDataGridViewTextBoxColumn.HeaderText = "CategoryName";
			this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
			this.categoryNameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// productsDataGridViewTextBoxColumn
			// 
			this.productsDataGridViewTextBoxColumn.DataPropertyName = "Products";
			this.productsDataGridViewTextBoxColumn.HeaderText = "Products";
			this.productsDataGridViewTextBoxColumn.Name = "productsDataGridViewTextBoxColumn";
			this.productsDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// pictureImageDataGridViewImageColumn
			// 
			this.pictureImageDataGridViewImageColumn.DataPropertyName = "PictureImage";
			this.pictureImageDataGridViewImageColumn.HeaderText = "PictureImage";
			this.pictureImageDataGridViewImageColumn.Name = "pictureImageDataGridViewImageColumn";
			this.pictureImageDataGridViewImageColumn.ReadOnly = true;
			// 
			// bindingSource
			// 
			this.bindingSource.DataSource = typeof(EvolutionNet.Sample.Data.Definition.Category);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(4, 4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add...";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(86, 4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 3;
			this.btnEdit.Text = "Edit...";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(168, 4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSlowWork
			// 
			this.btnSlowWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSlowWork.Location = new System.Drawing.Point(560, 4);
			this.btnSlowWork.Name = "btnSlowWork";
			this.btnSlowWork.Size = new System.Drawing.Size(221, 23);
			this.btnSlowWork.TabIndex = 6;
			this.btnSlowWork.Text = "Run some slow process in background...";
			this.btnSlowWork.UseVisualStyleBackColor = true;
			this.btnSlowWork.Click += new System.EventHandler(this.btnSlowWork_Click);
			// 
			// nudSlowWorkTime
			// 
			this.nudSlowWorkTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nudSlowWorkTime.Location = new System.Drawing.Point(512, 7);
			this.nudSlowWorkTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.nudSlowWorkTime.Name = "nudSlowWorkTime";
			this.nudSlowWorkTime.Size = new System.Drawing.Size(42, 20);
			this.nudSlowWorkTime.TabIndex = 5;
			this.nudSlowWorkTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nudSlowWorkTime.ValueChanged += new System.EventHandler(this.nudSlowWorkTime_ValueChanged);
			// 
			// lblSlowProcess
			// 
			this.lblSlowProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSlowProcess.AutoSize = true;
			this.lblSlowProcess.Location = new System.Drawing.Point(409, 9);
			this.lblSlowProcess.Name = "lblSlowProcess";
			this.lblSlowProcess.Size = new System.Drawing.Size(97, 13);
			this.lblSlowProcess.TabIndex = 0;
			this.lblSlowProcess.Text = "Process Time (sec)";
			// 
			// CategoryCrudView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblSlowProcess);
			this.Controls.Add(this.nudSlowWorkTime);
			this.Controls.Add(this.btnSlowWork);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dataGridView1);
			this.Name = "CategoryCrudView";
			this.Load += new System.EventHandler(this.CategoryCrudView_Load);
			this.LoadComplete += new System.EventHandler(this.CategoryCrudView_LoadComplete);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudSlowWorkTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private BindingSource bindingSource;
		private Button btnAdd;
		private Button btnEdit;
		private Button btnDelete;
		private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn productsDataGridViewTextBoxColumn;
		private DataGridViewImageColumn pictureImageDataGridViewImageColumn;
		private Button btnSlowWork;
		private NumericUpDown nudSlowWorkTime;
		private Label lblSlowProcess;
	}
}
