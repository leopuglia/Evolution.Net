namespace EvolutionNet.Sample.UI.Windows
{
	partial class CategoryEditDlg
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			EvolutionNet.Sample.Data.Definition.Category category1 = new EvolutionNet.Sample.Data.Definition.Category();
			this.categoryEditUC1 = new EvolutionNet.Sample.UI.Windows.CategoryEditUC();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.Location = new System.Drawing.Point(48, 16);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(154, 16);
			// 
			// pnlButtons
			// 
			this.pnlButtons.Location = new System.Drawing.Point(0, 274);
			this.pnlButtons.Size = new System.Drawing.Size(266, 51);
			// 
			// categoryEditUC1
			// 
			this.categoryEditUC1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.categoryEditUC1.Location = new System.Drawing.Point(0, 0);
			category1.CategoryName = "";
			category1.Description = "";
			category1.ID = 0;
			category1.Picture = null;
			category1.PictureImage = null;
			category1.Products = null;
			this.categoryEditUC1.Model = category1;
			this.categoryEditUC1.Name = "categoryEditUC1";
			this.categoryEditUC1.Size = new System.Drawing.Size(266, 274);
			this.categoryEditUC1.TabIndex = 1;
			// 
			// CategoryEditDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(266, 325);
			this.Controls.Add(this.categoryEditUC1);
			this.Name = "CategoryEditDlg";
			this.Text = "Category Edit";
			this.Controls.SetChildIndex(this.pnlButtons, 0);
			this.Controls.SetChildIndex(this.categoryEditUC1, 0);
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private CategoryEditUC categoryEditUC1;
	}
}
