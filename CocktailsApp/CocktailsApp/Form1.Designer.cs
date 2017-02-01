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
            ((System.ComponentModel.ISupportInitialize)(this.cocktailsGridView)).BeginInit();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 395);
            this.Controls.Add(this.cocktailsLB);
            this.Controls.Add(this.cocktailsTB);
            this.Controls.Add(this.cocktailsGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cocktailsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView cocktailsGridView;
        private System.Windows.Forms.TextBox cocktailsTB;
        private System.Windows.Forms.Label cocktailsLB;
    }
}