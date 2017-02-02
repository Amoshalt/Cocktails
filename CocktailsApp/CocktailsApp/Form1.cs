using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CocktailsApp
{
    public partial class Form1 : Form
    {
        private isi_projet2_tardymartial_remondvictorEntities connexionBD;

        public Form1()
        {
            InitializeComponent();
        }

        private void fermer1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            cocktailsLB.Visible = false;
        }

        private void listeDesCocktailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            affichageListCocktails();
        }

        private void affichageListCocktails()
        {
            cocktailsLB.Text = "";
            cocktailsLB.Visible = true;


            
        }
    }
}
