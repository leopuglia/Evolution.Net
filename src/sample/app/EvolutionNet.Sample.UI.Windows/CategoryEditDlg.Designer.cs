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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryEditDlg));
			this.CategoryEditUC1 = new EvolutionNet.Sample.UI.Windows.CategoryEditUC();
			this.pnlButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(27, 16);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(133, 16);
			// 
			// pnlButtons
			// 
			this.pnlButtons.Location = new System.Drawing.Point(0, 313);
			this.pnlButtons.Size = new System.Drawing.Size(241, 51);
			// 
			// CategoryEditUC1
			// 
			this.CategoryEditUC1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CategoryEditUC1.Location = new System.Drawing.Point(0, 0);
			this.CategoryEditUC1.Model = ((EvolutionNet.Sample.Data.Definition.Category)(resources.GetObject("CategoryEditUC1.Model")));
			this.CategoryEditUC1.ModelID = 0;
			this.CategoryEditUC1.Name = "CategoryEditUC1";
			this.CategoryEditUC1.Size = new System.Drawing.Size(241, 313);
			this.CategoryEditUC1.TabIndex = 1;
			// 
			// CategoryEditDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(241, 364);
			this.Controls.Add(this.CategoryEditUC1);
			this.Name = "CategoryEditDlg";
			this.Text = "Category Edit";
			this.Controls.SetChildIndex(this.pnlButtons, 0);
			this.Controls.SetChildIndex(this.CategoryEditUC1, 0);
			this.pnlButtons.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private CategoryEditUC CategoryEditUC1;
	}
}
