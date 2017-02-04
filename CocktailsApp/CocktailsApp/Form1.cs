﻿using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

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
            this.Size = new Size(800, 500);
        }

        //Gestion des events

        private void fermer1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //cocktailsLB.Visible = false;
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
        
        private void RAZClick(Object sender, EventArgs e)
        {
            for(int i = 0; i < m_composants.Count; i++)
            {
                if (m_composants[i] is PanneauCB)
                {
                    ((PanneauCB)m_composants[i]).Decocher();
                }
            }
            m_recherche.Clean();
        }

        private void affichageListCocktails()
        {
            /*
            cocktailsLB.Text = "";
            cocktailsLB.Visible = true;
            */
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

            for (int i = 0; i < cocktailsIngredients.Count; i++)
            {
                ArrayList cock = ((ArrayList)cocktailsIngredients[i]);
                ArrayList cockAlcools = ((ArrayList)cock[1]);
                ArrayList cockSofts = ((ArrayList)cock[2]);

                cocktailsLB.Text = cocktailsLB.Text + (String)cock[0] + ": ";
                for (int j = 0; j < cockAlcools.Count; j++)
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

            //On affiche les alcools
            PanneauCB pAlcools = new PanneauCB(50, 50, 200, 300, "Alcools : ", m_recherche.NomAlcool(), m_recherche.ListeAlcools(), new EventHandler(CheckAlcool));
            pAlcools.Parent = this;
            m_composants.Add(pAlcools);

            //On affiche les softs
            PanneauCB pSofts = new PanneauCB(300, 50, 200, 300, "Softs : ", m_recherche.NomSoft(), m_recherche.ListeSofts(), new EventHandler(CheckSoft));
            //Panneau pSofts = new Panneau(300, 50, 200, 300, "Softs : ", m_recherche.NomSoft());
            pSofts.Parent = this;
            m_composants.Add(pSofts);


            //Bouton de validation
            Button bVal = new Button();
            m_composants.Add(bVal);
            bVal.Parent = this;
            bVal.Text = "Lancer la recherche";
            bVal.Size = new System.Drawing.Size(130, 23);
            bVal.Location = new System.Drawing.Point((this.Width / 3) - (bVal.Size.Width / 2), this.Height - 100);
            //On lance la recherche au click
            bVal.Click += new EventHandler(RechercheClick);

            //Bouton de remise a zero du tableau
            Button bRAZ = new Button();
            m_composants.Add(bRAZ);
            bRAZ.Parent = this;
            bRAZ.Text = "Tout Vider";
            bRAZ.Size = new System.Drawing.Size(80, 23);
            bRAZ.Location = new System.Drawing.Point((this.Width * 2 / 3) - (bVal.Size.Width / 2), this.Height - 100);
            //On decoche toutes les cases au click
            bRAZ.Click += new EventHandler(RAZClick);
        }

        protected void AffichageResultatsRecherche(ArrayList cocktails)
        {
            //S'il y avait deja qqc on l'efface
            Vider();
            //Affichage des résultats
            int taille = cocktails.Count;
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
                lCo.Size = new System.Drawing.Size(200, lCo.Height);
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
