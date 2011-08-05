namespace EvolutionNet.Sample.UI.Windows
{
	partial class MainView
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabCategory = new System.Windows.Forms.TabPage();
			this.categoryCrudView1 = new EvolutionNet.Sample.UI.Windows.CategoryCrudView();
			this.tabControl1.SuspendLayout();
			this.tabCategory.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabCategory);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 498);
			this.tabControl1.TabIndex = 1;
			// 
			// tabCategory
			// 
			this.tabCategory.Controls.Add(this.categoryCrudView1);
			this.tabCategory.Location = new System.Drawing.Point(4, 22);
			this.tabCategory.Name = "tabCategory";
			this.tabCategory.Padding = new System.Windows.Forms.Padding(3);
			this.tabCategory.Size = new System.Drawing.Size(776, 472);
			this.tabCategory.TabIndex = 0;
			this.tabCategory.Text = "Category";
			this.tabCategory.UseVisualStyleBackColor = true;
			// 
			// categoryCrudView1
			// 
			this.categoryCrudView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.categoryCrudView1.Location = new System.Drawing.Point(3, 3);
			this.categoryCrudView1.Name = "categoryCrudView1";
			this.categoryCrudView1.Size = new System.Drawing.Size(770, 466);
			this.categoryCrudView1.TabIndex = 0;
			// 
			// MainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "MainView";
			this.Load += new System.EventHandler(this.MainView_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabCategory.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabCategory;
		private CategoryCrudView categoryCrudView1;
	}
}
