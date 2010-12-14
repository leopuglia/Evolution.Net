namespace EvolutionNet.Sample.UI.Windows
{
    partial class CategoriesCrudFrm
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
            this.categoriesCrudView1 = new EvolutionNet.Sample.UI.Windows.CategoriesCrudView();
            this.SuspendLayout();
            // 
            // categoriesCrudView1
            // 
            this.categoriesCrudView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesCrudView1.Location = new System.Drawing.Point(0, 0);
            this.categoriesCrudView1.Name = "categoriesCrudView1";
            this.categoriesCrudView1.Size = new System.Drawing.Size(784, 522);
            this.categoriesCrudView1.TabIndex = 0;
            // 
            // CategoriesCrudFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 522);
            this.Controls.Add(this.categoriesCrudView1);
            this.Name = "CategoriesCrudFrm";
            this.Text = "CategoriesCrudFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private CategoriesCrudView categoriesCrudView1;
    }
}