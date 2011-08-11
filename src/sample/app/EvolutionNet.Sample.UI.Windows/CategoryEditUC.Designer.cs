namespace EvolutionNet.Sample.UI.Windows
{
	partial class CategoryEditUC
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.LblCategoryName = new System.Windows.Forms.Label();
			this.TxtCategoryName = new System.Windows.Forms.TextBox();
			this.LblDescription = new System.Windows.Forms.Label();
			this.TxtDescription = new System.Windows.Forms.TextBox();
			this.LblPicture = new System.Windows.Forms.Label();
			this.BtnBrowsePicture = new System.Windows.Forms.Button();
			this.ImgPicture = new System.Windows.Forms.PictureBox();
			this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImgPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.LblCategoryName);
			this.flowLayoutPanel1.Controls.Add(this.TxtCategoryName);
			this.flowLayoutPanel1.Controls.Add(this.LblDescription);
			this.flowLayoutPanel1.Controls.Add(this.TxtDescription);
			this.flowLayoutPanel1.Controls.Add(this.LblPicture);
			this.flowLayoutPanel1.Controls.Add(this.BtnBrowsePicture);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 172);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// LblCategoryName
			// 
			this.LblCategoryName.AutoSize = true;
			this.LblCategoryName.Location = new System.Drawing.Point(8, 5);
			this.LblCategoryName.Name = "LblCategoryName";
			this.LblCategoryName.Size = new System.Drawing.Size(80, 13);
			this.LblCategoryName.TabIndex = 0;
			this.LblCategoryName.Text = "Category Name";
			// 
			// TxtCategoryName
			// 
			this.TxtCategoryName.Location = new System.Drawing.Point(8, 21);
			this.TxtCategoryName.Name = "TxtCategoryName";
			this.TxtCategoryName.Size = new System.Drawing.Size(177, 20);
			this.TxtCategoryName.TabIndex = 1;
			// 
			// LblDescription
			// 
			this.LblDescription.AutoSize = true;
			this.LblDescription.Location = new System.Drawing.Point(8, 44);
			this.LblDescription.Name = "LblDescription";
			this.LblDescription.Size = new System.Drawing.Size(60, 13);
			this.LblDescription.TabIndex = 2;
			this.LblDescription.Text = "Description";
			// 
			// TxtDescription
			// 
			this.TxtDescription.Location = new System.Drawing.Point(8, 60);
			this.TxtDescription.Multiline = true;
			this.TxtDescription.Name = "TxtDescription";
			this.TxtDescription.Size = new System.Drawing.Size(225, 62);
			this.TxtDescription.TabIndex = 3;
			// 
			// LblPicture
			// 
			this.LblPicture.AutoSize = true;
			this.LblPicture.Location = new System.Drawing.Point(8, 125);
			this.LblPicture.Name = "LblPicture";
			this.LblPicture.Size = new System.Drawing.Size(40, 13);
			this.LblPicture.TabIndex = 4;
			this.LblPicture.Text = "Picture";
			// 
			// BtnBrowsePicture
			// 
			this.BtnBrowsePicture.Location = new System.Drawing.Point(8, 141);
			this.BtnBrowsePicture.Name = "BtnBrowsePicture";
			this.BtnBrowsePicture.Size = new System.Drawing.Size(75, 23);
			this.BtnBrowsePicture.TabIndex = 5;
			this.BtnBrowsePicture.Text = "Browse...";
			this.BtnBrowsePicture.UseVisualStyleBackColor = true;
			this.BtnBrowsePicture.Click += new System.EventHandler(this.BtnBrowsePicture_Click);
			// 
			// ImgPicture
			// 
			this.ImgPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ImgPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ImgPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ImgPicture.Location = new System.Drawing.Point(11, 178);
			this.ImgPicture.Name = "ImgPicture";
			this.ImgPicture.Size = new System.Drawing.Size(222, 146);
			this.ImgPicture.TabIndex = 7;
			this.ImgPicture.TabStop = false;
			// 
			// OpenFileDialog1
			// 
			this.OpenFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*";
			this.OpenFileDialog1.FilterIndex = 0;
			// 
			// CategoryEditUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ImgPicture);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "CategoryEditUC";
			this.Size = new System.Drawing.Size(247, 337);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImgPicture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label LblCategoryName;
		private System.Windows.Forms.TextBox TxtCategoryName;
		private System.Windows.Forms.Label LblDescription;
		private System.Windows.Forms.TextBox TxtDescription;
		private System.Windows.Forms.Label LblPicture;
		private System.Windows.Forms.Button BtnBrowsePicture;
		private System.Windows.Forms.PictureBox ImgPicture;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
	}
}
