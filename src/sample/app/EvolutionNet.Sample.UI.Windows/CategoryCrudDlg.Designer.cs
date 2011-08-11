namespace EvolutionNet.Sample.UI.Windows
{
	partial class CategoryCrudDlg
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
			this.CategoryCrudView1 = new EvolutionNet.Sample.UI.Windows.CategoryCrudView();
			this.SuspendLayout();
			// 
			// CategoryCrudView1
			// 
			this.CategoryCrudView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CategoryCrudView1.Location = new System.Drawing.Point(0, 0);
			this.CategoryCrudView1.Name = "CategoryCrudView1";
			this.CategoryCrudView1.Size = new System.Drawing.Size(784, 471);
			this.CategoryCrudView1.TabIndex = 0;
			// 
			// CategoryCrudFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "CategoryCrudFrm";
			this.Text = "Category CRUD";
			this.Controls.Add(this.CategoryCrudView1);
			this.ResumeLayout(false);

		}

		#endregion

		private CategoryCrudView CategoryCrudView1;

	}
}