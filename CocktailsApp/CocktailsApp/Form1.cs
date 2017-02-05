using System;
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
        protected ArrayList m_liste;

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

        //Lance la recherche d'un cocktail
        private void RechercheEvent(object sender, EventArgs e)
        {
            AffichageRecherche();
        }

        private void ajouterUnCocktailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AffichageAjouterCocktail();
        }

        //Modiifie la disponnibilité d'un soft via un event
        private void CheckSoft(Object sender, EventArgs e)
        {
            m_recherche.ModifSoft(((CheckBox)sender).TabIndex);
        }

        //Modiifie la disponnibilité d'un alcool via un event
        private void CheckAlcool(Object sender, EventArgs e)
        {
            m_recherche.ModifAlcool(((CheckBox)sender).TabIndex);
        }

        private void RechercheClick(Object sender, EventArgs e)
        {
            this.AffichageResultatsRecherche(m_recherche.Valider());
        }
        private void AjouterClick(Object sender, EventArgs e)
        {
            Vider();

        }

        //Decoche toutes les CheckBox
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

        //Affiche la fenetre detaillant un cocktail
        private void Detail(Object sender, EventArgs e)
        {
            int index = ((Label)sender).TabIndex;
            if((m_liste != null) && (m_liste.Count > index))
            {
                Description d = new Description((cocktail)m_liste[index], m_recherche);
                d.Show();
            }
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
            
            

            for (int i = 0; i < cocktailsIngredients.Count; i++)
            {
                m_composants.Add(new Label());
                Label NomCocktailsLB = (Label)m_composants[m_composants.Count - 1];
                NomCocktailsLB.Parent = this;
                NomCocktailsLB.Location = new System.Drawing.Point(apx, apy*(i+1));
                NomCocktailsLB.Text = "";
                NomCocktailsLB.Visible = true;

                ArrayList cock = ((ArrayList)cocktailsIngredients[i]);
                ArrayList cockAlcools = ((ArrayList)cock[1]);
                ArrayList cockSofts = ((ArrayList)cock[2]);
                
                NomCocktailsLB.Text = (String)cock[0] + ": ";
                NomCocktailsLB.Font = new Font("Times New Roman",10, FontStyle.Underline);
                NomCocktailsLB.AutoSize = true;

                m_composants.Add(new Label());
                Label AlcoolsLB = (Label)m_composants[m_composants.Count - 1];
                AlcoolsLB.Parent = this;
                AlcoolsLB.Location = new System.Drawing.Point(NomCocktailsLB.Location.X + ecart* 5, apy * (i + 1));
                AlcoolsLB.Text = "";
                AlcoolsLB.Visible = true;
                
                for (int j = 0; j < cockAlcools.Count; j++)
                {
                    AlcoolsLB.Text = AlcoolsLB.Text + ((alcool)cockAlcools[j]).NOM_ALCOOL + ", ";
                }
                AlcoolsLB.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                AlcoolsLB.AutoSize = true;

                m_composants.Add(new Label());
                Label SoftsLB = (Label)m_composants[m_composants.Count - 1];
                SoftsLB.Parent = this;
                SoftsLB.Location = new System.Drawing.Point(AlcoolsLB.Location.X + ecart * 10, apy * (i + 1));
                SoftsLB.Text = "";
                SoftsLB.Visible = true;
                

                for (int j = 0; j < cockSofts.Count; j++)
                {
                    SoftsLB.Text = SoftsLB.Text + ((soft)cockSofts[j]).NOM_SOFT + ", ";
                    
                }
                SoftsLB.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                SoftsLB.AutoSize = true;

            }
            
        }


        private void AffichageAjouterCocktail()
        {
            //S'il y avait déjà qqc d'afficher, on l'efface
            Vider();

            int w = 200,
                h = 300,
                m = 75;
            
            //TextBox nouveau cocktail
            m_composants.Add(new Label());
            Label lbCocktail = (Label)m_composants[m_composants.Count - 1];
            lbCocktail.Parent = this;
            lbCocktail.Location = new System.Drawing.Point((this.Width / 6) - (w / 2),50);
            lbCocktail.Text = "Nom Cocktail";
            lbCocktail.Visible = true;
            
            TextBox tbCocktail = new TextBox();
            m_composants.Add(tbCocktail);
            tbCocktail.Parent = this;
            tbCocktail.Size = new System.Drawing.Size(130, 23);
            tbCocktail.Location = new System.Drawing.Point((this.Width / 6), 50);


            //On affiche les alcools
            PanneauCBAjout pAlcools = new PanneauCBAjout((this.Width / 6) - (w / 2), m, w, h, "Alcools : ", m_recherche.NomAlcool(), m_recherche.ListeAlcools(), new EventHandler(CheckAlcool));
            pAlcools.Parent = this;
            m_composants.Add(pAlcools);

           

            //On affiche les softs
            PanneauCBAjout pSofts = new PanneauCBAjout((this.Width / 2) - (w / 2), m, w, h, "Softs : ", m_recherche.NomSoft(), m_recherche.ListeSofts(), new EventHandler(CheckSoft));
            //Panneau pSofts = new Panneau(300, 50, 200, 300, "Softs : ", m_recherche.NomSoft());
            pSofts.Parent = this;
            m_composants.Add(pSofts);

            //Bouton de validation
            Button bVal = new Button();
            m_composants.Add(bVal);
            bVal.Parent = this;
            bVal.Text = "Ajouter";
            bVal.Size = new System.Drawing.Size(130, 23);
            bVal.Location = new System.Drawing.Point((this.Width / 3) - (bVal.Size.Width / 2), this.Height - 100);
            
            
            
            //TextBox nouveau alcool

            //TextBox nouveau soft

            //On lance l'ajout au click
            bVal.Click += new EventHandler(AjouterClick);


        }

        private void AffichageRecherche()
        {
            //S'il y avait déjà qqc d'afficher, on l'efface
            Vider();

            int w = 200,
                h = 300,
                m = 50;
            //On affiche les alcools
            PanneauCB pAlcools = new PanneauCB((this.Width / 6) - (w / 2), m, w, h, "Alcools : ", m_recherche.NomAlcool(), m_recherche.ListeAlcools(), new EventHandler(CheckAlcool));
            pAlcools.Parent = this;
            m_composants.Add(pAlcools);

            //On affiche les softs
            PanneauCB pSofts = new PanneauCB((this.Width / 2) - (w / 2), m, w, h, "Softs : ", m_recherche.NomSoft(), m_recherche.ListeSofts(), new EventHandler(CheckSoft));
            pSofts.Parent = this;
            m_composants.Add(pSofts);

            //On prepare le panneau d'affichage des cocktails resultats de la recherche
            Panneau pCocktails = new Panneau((this.Width * 5 / 6) - (w / 2), m, w, h, "Cocktails : ", new string[0], null);
            pCocktails.Parent = this;
            m_composants.Add(pCocktails);


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
            //S'il y avait deja un panneau de resultats, on le recupere
            Panneau pCocktails = GetPanneau();
            if (pCocktails != null)
            {
                //On garde la liste en memoire
                m_liste = cocktails;
                //Affichage des résultats
                int taille = cocktails.Count;
                string[] liste = new string[taille];
                for (int i = 0; i < taille; i++)
                    liste[i] = ((cocktail)cocktails[i]).ToString();
                pCocktails.Donnees(liste, new EventHandler(Detail));
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

        protected Panneau GetPanneau()
        {
            for (int i = 0; i < m_composants.Count; i++)
            {
                if ((m_composants[i] is Panneau) && !(m_composants[i] is PanneauCB))
                {
                    return (Panneau)m_composants[i];
                }
            }
            return null;
        }

        
    }
}
