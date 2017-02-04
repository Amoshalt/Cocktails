using System;
using System.Collections;
using System.Windows.Forms;

namespace CocktailsApp
{
    public partial class Form1 : Form
    {
        protected ListeCocktails m_lCocktails;
        protected Recherche m_recherche;
        protected ArrayList m_composants;


        public Form1()
        {
            Initialiser(new Recherche(), new ListeCocktails());
        }

        public Form1(Recherche r, ListeCocktails lc)
        {
            Initialiser(r,lc);
        }

        protected void Initialiser(Recherche r, ListeCocktails lc)
        {
            m_recherche = r;
            m_lCocktails = lc;
            m_composants = new ArrayList();
            InitializeComponent();
        }

        //Gestion des events

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
            AffichageCocktails();
        }

        private void RechercheEvent(object sender, EventArgs e)
        {
            AffichageRecherche();
        }

        private void CheckSoft(Object sender, EventArgs e)
        {
            m_recherche.ModifSoft(((CheckBox)sender).TabIndex);
        }

        private void CheckAlcool(Object sender, EventArgs e)
        {
            m_recherche.ModifAlcool(((CheckBox)sender).TabIndex);
        }

        private void RechercheClick(Object sender, EventArgs e)
        {
            this.AffichageResultatsRecherche(m_recherche.Valider());
        }

        private void AffichageCocktails()
        {
            //S'il y avait déjà qqc d'afficher, on l'efface
            Vider();
            //On recupere la liste de cocktail + ingrédients
            ArrayList cocktailsIngredients = m_lCocktails.getListeCI();
            //On recupere les noms de softs
            string[] softs = m_recherche.NomSoft();

            //On affiche les alcools
            //Parametres d'affichage
            int apx = 50, apy = 50, ecart = 30;
            m_composants.Add(new Label());
            Label cocktailsLB = (Label)m_composants[m_composants.Count - 1];
            cocktailsLB.Parent = this;
            cocktailsLB.Location = new System.Drawing.Point(apx, apy);
            cocktailsLB.Text = "";
            cocktailsLB.Visible = true;

            for(int i = 0; i< cocktailsIngredients.Count; i++)
            {
                ArrayList cock = ((ArrayList)cocktailsIngredients[i]);
                ArrayList cockAlcools = ((ArrayList)cock[1]);
                ArrayList cockSofts = ((ArrayList)cock[2]);

                cocktailsLB.Text = cocktailsLB.Text + (String)cock[0] + ": ";
                for( int j = 0; j < cockAlcools.Count; j++)
                {
                    cocktailsLB.Text = cocktailsLB.Text + ((alcool)cockAlcools[j]).NOM_ALCOOL + " ";
                    cocktailsLB.Width = cocktailsLB.Width + ecart;
                }
                cocktailsLB.Text = cocktailsLB.Text + "\n";
                cocktailsLB.Height = cocktailsLB.Height + ecart;
            }

        }


        private void AffichageRecherche()
        {
            //S'il y avait déjà qqc d'afficher, on l'efface
            Vider();
            //On recupere les noms des alcools 
            string[] alcools = m_recherche.NomAlcool();
            //On recupere les noms de softs
            string[] softs = m_recherche.NomSoft();

            //On affiche les alcools
            //Parametres d'affichage
            int apx = 50, apy = 50, ecart = 30;
            m_composants.Add(new Label());
            Label lAlcool = (Label)m_composants[m_composants.Count-1];
            //m_composants.Add(lAlcool);
            lAlcool.Text = "Alcools :";
            lAlcool.Parent = this;
            lAlcool.Location = new System.Drawing.Point(apx, apy);
            for (int i = 0; i < alcools.Length; i++)
            {
                int y = apy + ((i + 1) * ecart);
                //Ajout du label avec le nom de l'alcool
                Label lAl = new Label();
                m_composants.Add(lAl);
                lAl.Parent = this;
                lAl.Text = alcools[i];
                lAl.Location = new System.Drawing.Point(apx + 15, y);
                //Ajout de la Checkbox pour (de)selectionner l'alccol
                CheckBox cAl = new CheckBox();
                m_composants.Add(cAl);
                cAl.Parent = this;
                //On permet enregistre l'index pour retrouver a quel alcool la checkbox correspond par la suite
                cAl.TabIndex = i;
                cAl.Location = new System.Drawing.Point(apx, y - 5);
                //On s'assure que l'action soit transmise a la couche metier
                cAl.Click += new System.EventHandler(CheckAlcool);
            }

            //On affiche les softs
            //Parametres d'affichage
            int spx = 300, spy = 50;
            Label lSoft = new Label();
            m_composants.Add(lSoft);
            lSoft.Text = "Softs :";
            lSoft.Parent = this;
            lSoft.Location = new System.Drawing.Point(spx, spy);
            for (int i = 0; i < softs.Length; i++)
            {
                int y = spy + ((i + 1) * ecart);
                //Ajout du label avec le nom de l'alcool
                Label lSo = new Label();
                m_composants.Add(lSo);
                lSo.Parent = this;
                lSo.Text = softs[i];
                lSo.Location = new System.Drawing.Point(spx + 15, y);
                //Ajout de la Checkbox pour (de)selectionner l'alccol
                CheckBox cSo = new CheckBox();
                m_composants.Add(cSo);
                cSo.Parent = this;
                //On permet enregistre l'index pour retrouver a quel soft la checkbox correspond par la suite
                cSo.TabIndex = i;
                cSo.Location = new System.Drawing.Point(spx, y - 5);
                //On s'assure que l'action soit transmise a la couche metier
                cSo.Click += new System.EventHandler(CheckSoft);
            }


            //Bouton de validation
            Button bVal = new Button();
            m_composants.Add(bVal);
            bVal.Parent = this;
            bVal.Text = "Lancer la recherche";
            bVal.Size = new System.Drawing.Size(130, 23);
            bVal.Location = new System.Drawing.Point((this.Width - bVal.Size.Width) / 2, this.Height - 100);
            //On lance la recherche au click
            bVal.Click += new EventHandler(RechercheClick);
        }

        protected void AffichageResultatsRecherche(ArrayList cocktails)
        {
            //S'il y avait deja qqc on l'efface
            Vider();
            //Affichage des résultats
            //parametres d'affichage
            int py = 50, ecart = 30;
            Label lTitre = new Label();
            m_composants.Add(lTitre);
            lTitre.Text = "Cocktails disponibles :";
            lTitre.Parent = this;
            lTitre.Location = new System.Drawing.Point((this.Width - lTitre.Size.Width) / 2, py);
            for(int i = 0; i < cocktails.Count; i++)
            {
                int y = py + ((i + 1) * ecart);
                Label lCo = new Label();
                m_composants.Add(lCo);
                lCo.Text = cocktails[i].ToString();
                lCo.Parent = this;
                lCo.Location = new System.Drawing.Point((this.Width - lCo.Size.Width) / 2, y);
            }
        }

        //Fonction de nettoyage de l'écran
        protected void Vider()
        {
            for(int i = 0; i < m_composants.Count; i++)
            {
                if (this.Controls.Contains((Control)m_composants[i]))
                {
                    this.Controls.Remove((Control)m_composants[i]);
                    ((Control)m_composants[i]).Dispose();
                }
            }
            m_composants = new ArrayList();
            
        }

    }
}
