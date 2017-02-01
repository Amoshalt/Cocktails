namespace CocktailsApp
{
    partial class Form1
    {
        private isi_projet2_tardymartial_remondvictorEntities bdcockent;
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
            this.cocktailsGridView = new System.Windows.Forms.DataGridView();
            this.cocktailsTB = new System.Windows.Forms.TextBox();
            this.cocktailsLB = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listeDesCocktailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.cocktailsGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cocktailsGridView
            // 
            this.cocktailsGridView.Location = new System.Drawing.Point(102, 12);
            this.cocktailsGridView.Name = "cocktailsGridView";
            this.cocktailsGridView.Size = new System.Drawing.Size(240, 150);
            this.cocktailsGridView.TabIndex = 3;
            // 
            // cocktailsTB
            // 
            this.cocktailsTB.Location = new System.Drawing.Point(141, 206);
            this.cocktailsTB.Name = "cocktailsTB";
            this.cocktailsTB.Size = new System.Drawing.Size(200, 20);
            this.cocktailsTB.TabIndex = 4;
            // 
            // cocktailsLB
            // 
            this.cocktailsLB.AutoSize = true;
            this.cocktailsLB.Location = new System.Drawing.Point(152, 251);
            this.cocktailsLB.Name = "cocktailsLB";
            this.cocktailsLB.Size = new System.Drawing.Size(0, 13);
            this.cocktailsLB.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesCocktailsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(454, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listeDesCocktailsToolStripMenuItem
            // 
            this.listeDesCocktailsToolStripMenuItem.Name = "listeDesCocktailsToolStripMenuItem";
            this.listeDesCocktailsToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.listeDesCocktailsToolStripMenuItem.Text = "Liste des Cocktails";
            this.listeDesCocktailsToolStripMenuItem.Click += new System.EventHandler(this.listeDesCocktailsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 395);
            this.Controls.Add(this.cocktailsLB);
            this.Controls.Add(this.cocktailsTB);
            this.Controls.Add(this.cocktailsGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cocktailsGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView cocktailsGridView;
        private System.Windows.Forms.TextBox cocktailsTB;
        private System.Windows.Forms.Label cocktailsLB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listeDesCocktailsToolStripMenuItem;
    }
}