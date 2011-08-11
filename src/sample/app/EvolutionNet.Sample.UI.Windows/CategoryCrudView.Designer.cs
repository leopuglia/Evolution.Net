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
			this.DataGridCategory = new System.Windows.Forms.DataGridView();
			this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColPictureImage = new System.Windows.Forms.DataGridViewImageColumn();
			this.BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.BtnAdd = new System.Windows.Forms.Button();
			this.BtnEdit = new System.Windows.Forms.Button();
			this.BtnDelete = new System.Windows.Forms.Button();
			this.BtnSlowWork = new System.Windows.Forms.Button();
			this.NumericSlowWorkTime = new System.Windows.Forms.NumericUpDown();
			this.LblSlowWorkTime = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGridCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericSlowWorkTime)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGridCategory
			// 
			this.DataGridCategory.AllowUserToAddRows = false;
			this.DataGridCategory.AllowUserToDeleteRows = false;
			this.DataGridCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DataGridCategory.AutoGenerateColumns = false;
			this.DataGridCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColCategoryName,
            this.ColDescription,
            this.ColPictureImage});
			this.DataGridCategory.DataSource = this.BindingSource1;
			this.DataGridCategory.Location = new System.Drawing.Point(0, 33);
			this.DataGridCategory.Name = "DataGridCategory";
			this.DataGridCategory.ReadOnly = true;
			this.DataGridCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DataGridCategory.Size = new System.Drawing.Size(784, 489);
			this.DataGridCategory.StandardTab = true;
			this.DataGridCategory.TabIndex = 0;
			this.DataGridCategory.Sorted += new System.EventHandler(this.DataGridView1_Sorted);
			this.DataGridCategory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
			// 
			// ColID
			// 
			this.ColID.DataPropertyName = "ID";
			this.ColID.HeaderText = "ID";
			this.ColID.MinimumWidth = 30;
			this.ColID.Name = "colID";
			this.ColID.ReadOnly = true;
			this.ColID.Width = 50;
			// 
			// ColCategoryName
			// 
			this.ColCategoryName.DataPropertyName = "CategoryName";
			this.ColCategoryName.HeaderText = "Category Name";
			this.ColCategoryName.MinimumWidth = 120;
			this.ColCategoryName.Name = "colCategoryName";
			this.ColCategoryName.ReadOnly = true;
			this.ColCategoryName.Width = 150;
			// 
			// ColDescription
			// 
			this.ColDescription.DataPropertyName = "Description";
			this.ColDescription.HeaderText = "Description";
			this.ColDescription.MinimumWidth = 200;
			this.ColDescription.Name = "colDescription";
			this.ColDescription.ReadOnly = true;
			this.ColDescription.Width = 300;
			// 
			// ColPictureImage
			// 
			this.ColPictureImage.DataPropertyName = "PictureImage";
			this.ColPictureImage.HeaderText = "Image";
			this.ColPictureImage.MinimumWidth = 100;
			this.ColPictureImage.Name = "colPictureImage";
			this.ColPictureImage.ReadOnly = true;
			// 
			// BindingSource1
			// 
			this.BindingSource1.DataSource = typeof(EvolutionNet.Sample.Data.Definition.Category);
			// 
			// BtnAdd
			// 
			this.BtnAdd.Location = new System.Drawing.Point(4, 4);
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.Size = new System.Drawing.Size(75, 23);
			this.BtnAdd.TabIndex = 1;
			this.BtnAdd.Text = "Add...";
			this.BtnAdd.UseVisualStyleBackColor = true;
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// BtnEdit
			// 
			this.BtnEdit.Location = new System.Drawing.Point(86, 4);
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.Size = new System.Drawing.Size(75, 23);
			this.BtnEdit.TabIndex = 2;
			this.BtnEdit.Text = "Edit...";
			this.BtnEdit.UseVisualStyleBackColor = true;
			this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
			// 
			// BtnDelete
			// 
			this.BtnDelete.Location = new System.Drawing.Point(168, 4);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.Size = new System.Drawing.Size(75, 23);
			this.BtnDelete.TabIndex = 3;
			this.BtnDelete.Text = "Delete";
			this.BtnDelete.UseVisualStyleBackColor = true;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// BtnSlowWork
			// 
			this.BtnSlowWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSlowWork.Location = new System.Drawing.Point(560, 4);
			this.BtnSlowWork.Name = "BtnSlowWork";
			this.BtnSlowWork.Size = new System.Drawing.Size(221, 23);
			this.BtnSlowWork.TabIndex = 6;
			this.BtnSlowWork.Text = "Run some slow process in background...";
			this.BtnSlowWork.UseVisualStyleBackColor = true;
			this.BtnSlowWork.Click += new System.EventHandler(this.BtnSlowWork_Click);
			// 
			// NumericSlowWorkTime
			// 
			this.NumericSlowWorkTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NumericSlowWorkTime.Location = new System.Drawing.Point(512, 7);
			this.NumericSlowWorkTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.NumericSlowWorkTime.Name = "NumericSlowWorkTime";
			this.NumericSlowWorkTime.Size = new System.Drawing.Size(42, 20);
			this.NumericSlowWorkTime.TabIndex = 5;
			this.NumericSlowWorkTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// LblSlowWorkTime
			// 
			this.LblSlowWorkTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LblSlowWorkTime.AutoSize = true;
			this.LblSlowWorkTime.Location = new System.Drawing.Point(409, 9);
			this.LblSlowWorkTime.Name = "LblSlowWorkTime";
			this.LblSlowWorkTime.Size = new System.Drawing.Size(97, 13);
			this.LblSlowWorkTime.TabIndex = 4;
			this.LblSlowWorkTime.Text = "Process Time (sec)";
			// 
			// CategoryCrudView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.LblSlowWorkTime);
			this.Controls.Add(this.NumericSlowWorkTime);
			this.Controls.Add(this.BtnSlowWork);
			this.Controls.Add(this.BtnDelete);
			this.Controls.Add(this.BtnEdit);
			this.Controls.Add(this.BtnAdd);
			this.Controls.Add(this.DataGridCategory);
			this.Name = "CategoryCrudView";
			this.Load += new System.EventHandler(this.CategoryCrudView_Load);
			this.AfterLoadComplete += new System.EventHandler(this.CategoryCrudView_AfterLoadComplete);
			((System.ComponentModel.ISupportInitialize)(this.DataGridCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericSlowWorkTime)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView DataGridCategory;
		private BindingSource BindingSource1;
		private Button BtnAdd;
		private Button BtnEdit;
		private Button BtnDelete;
		private Button BtnSlowWork;
		private NumericUpDown NumericSlowWorkTime;
		private Label LblSlowWorkTime;
		private DataGridViewTextBoxColumn ColID;
		private DataGridViewTextBoxColumn ColCategoryName;
		private DataGridViewTextBoxColumn ColDescription;
		private DataGridViewImageColumn ColPictureImage;
	}
}
