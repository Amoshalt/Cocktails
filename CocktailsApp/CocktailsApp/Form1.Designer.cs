namespace CocktailsApp
{
    partial class Form1
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
            this.cocktailsLB = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listeDesCocktailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechercheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnCocktailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cocktailsLB
            // 
            this.cocktailsLB.AutoSize = true;
            this.cocktailsLB.Location = new System.Drawing.Point(59, 40);
            this.cocktailsLB.Name = "cocktailsLB";
            this.cocktailsLB.Size = new System.Drawing.Size(0, 13);
            this.cocktailsLB.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesCocktailsToolStripMenuItem,
            this.rechercheToolStripMenuItem,
            this.ajouterUnCocktailToolStripMenuItem});
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
            // rechercheToolStripMenuItem
            // 
            this.rechercheToolStripMenuItem.Name = "rechercheToolStripMenuItem";
            this.rechercheToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.rechercheToolStripMenuItem.Text = "Recherche";
            this.rechercheToolStripMenuItem.Click += new System.EventHandler(this.RechercheEvent);
            // 
            // ajouterUnCocktailToolStripMenuItem
            // 
            this.ajouterUnCocktailToolStripMenuItem.Name = "ajouterUnCocktailToolStripMenuItem";
            this.ajouterUnCocktailToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.ajouterUnCocktailToolStripMenuItem.Text = "Ajouter un Cocktail";
            this.ajouterUnCocktailToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnCocktailToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 395);
            this.Controls.Add(this.cocktailsLB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cocktailsLB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listeDesCocktailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechercheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnCocktailToolStripMenuItem;
    }
}