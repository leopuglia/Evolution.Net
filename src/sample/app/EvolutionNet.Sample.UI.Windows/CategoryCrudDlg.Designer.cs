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
			this.categoryCrudView1 = new EvolutionNet.Sample.UI.Windows.CategoryCrudView();
			this.SuspendLayout();
			// 
			// categoryCrudView1
			// 
			this.categoryCrudView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.categoryCrudView1.Location = new System.Drawing.Point(0, 0);
			this.categoryCrudView1.Name = "categoryCrudView1";
			this.categoryCrudView1.Size = new System.Drawing.Size(784, 471);
			this.categoryCrudView1.TabIndex = 0;
			// 
			// CategoryCrudFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "CategoryCrudFrm";
			this.Text = "Category CRUD";
			this.Controls.Add(this.categoryCrudView1);
			this.ResumeLayout(false);

		}

		#endregion

		private CategoryCrudView categoryCrudView1;

	}
}