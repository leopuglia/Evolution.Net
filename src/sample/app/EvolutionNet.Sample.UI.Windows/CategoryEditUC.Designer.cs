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
			this.label1 = new System.Windows.Forms.Label();
			this.txtCategoryName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnBrowsePicture = new System.Windows.Forms.Button();
			this.imgPicture = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgPicture)).BeginInit();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.txtCategoryName);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.txtDescription);
			this.flowLayoutPanel1.Controls.Add(this.label3);
			this.flowLayoutPanel1.Controls.Add(this.btnBrowsePicture);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 172);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Category Name";
			// 
			// txtCategoryName
			// 
			this.txtCategoryName.Location = new System.Drawing.Point(8, 21);
			this.txtCategoryName.Name = "txtCategoryName";
			this.txtCategoryName.Size = new System.Drawing.Size(177, 20);
			this.txtCategoryName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Description";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(8, 60);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(225, 62);
			this.txtDescription.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 125);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Picture";
			// 
			// btnBrowsePicture
			// 
			this.btnBrowsePicture.Location = new System.Drawing.Point(8, 141);
			this.btnBrowsePicture.Name = "btnBrowsePicture";
			this.btnBrowsePicture.Size = new System.Drawing.Size(75, 23);
			this.btnBrowsePicture.TabIndex = 5;
			this.btnBrowsePicture.Text = "Browse...";
			this.btnBrowsePicture.UseVisualStyleBackColor = true;
			this.btnBrowsePicture.Click += new System.EventHandler(this.btnBrowsePicture_Click);
			// 
			// imgPicture
			// 
			this.imgPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.imgPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.imgPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.imgPicture.Location = new System.Drawing.Point(11, 178);
			this.imgPicture.Name = "imgPicture";
			this.imgPicture.Size = new System.Drawing.Size(222, 146);
			this.imgPicture.TabIndex = 7;
			this.imgPicture.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Image Files (*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|All files (*.*)|*.*";
			this.openFileDialog1.FilterIndex = 0;
			// 
			// CategoryEditUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.imgPicture);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "CategoryEditUC";
			this.Size = new System.Drawing.Size(247, 337);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgPicture)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCategoryName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnBrowsePicture;
		private System.Windows.Forms.PictureBox imgPicture;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}
