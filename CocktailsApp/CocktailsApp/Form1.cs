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

            connexionBD = new isi_projet2_tardymartial_remondvictorEntities();
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<cocktail>();
            try
            {
                var requete = from d in table
                              select d.NOM_COCKTAIL;

                cocktailsGridView.ColumnCount = 1;
                cocktailsGridView.Columns[0].Name = "Nom";
                var repNomCock = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
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
                MessageBox.Show("E1 : " + ex.GetBaseException().Message);
            }
            var table2 = contexteBD.CreateObjectSet<soft>();
            try
            {
                var requete = from t in table2
                              select t.NOM_SOFT;

                var nums = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);

                foreach(string num in nums)
                {
                    Console.WriteLine("" + num);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("E2 : " + ex.GetBaseException().Message);
            }
        }
    }
}
