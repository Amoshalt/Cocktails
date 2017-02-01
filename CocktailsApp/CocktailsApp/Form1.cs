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
            cocktailsTB.Visible = false;
            cocktailsGridView.Visible = false;
        }

        private void listeDesCocktailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            affichageListCocktails();
        }
        private void affichageListCocktails()
        {
            cocktailsTB.Text = "";
            cocktailsLB.Text = "";
            cocktailsLB.Visible = true;
            cocktailsTB.Visible = true;
            cocktailsGridView.Visible = true;
            //Initialize the ObjectContext

            bdcockent = new isi_projet2_tardymartial_remondvictorEntities();
            var objectContext = ((IObjectContextAdapter)bdcockent).ObjectContext;
            var set = objectContext.CreateObjectSet<cocktail>();
            try
            {
                var cocktailQuery = from d in set
                                    select d.NOM_COCKTAIL;

                cocktailsGridView.ColumnCount = 1;
                cocktailsGridView.Columns[0].Name = "Nom";
                var repNomCock = ((ObjectQuery)cocktailQuery).Execute(MergeOption.AppendOnly);
                foreach (string nom in repNomCock)
                {
                    cocktailsGridView.Rows.Add(nom);
                    cocktailsTB.AppendText(" " + nom + "\n");
                    cocktailsLB.Text = cocktailsLB.Text + nom + " \n";
                }

                cocktailsGridView.AllowUserToDeleteRows = false;
                cocktailsGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
