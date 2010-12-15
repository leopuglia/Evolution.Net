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
			this.categoryEditView1 = new EvolutionNet.Sample.UI.Windows.CategoryEditView();
			this.SuspendLayout();
			// 
			// categoryEditView1
			// 
			this.categoryEditView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.categoryEditView1.Location = new System.Drawing.Point(0, 0);
			this.categoryEditView1.Name = "categoryEditView1";
			this.categoryEditView1.Size = new System.Drawing.Size(583, 461);
			this.categoryEditView1.TabIndex = 1;
			// 
			// CategoryEditDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(583, 512);
			this.Controls.Add(this.categoryEditView1);
			this.Name = "CategoryEditDlg";
			this.Text = "Category Edit";
			this.Controls.SetChildIndex(this.categoryEditView1, 0);
			this.ResumeLayout(false);

		}

		#endregion

		private CategoryEditView categoryEditView1;
	}
}
