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
        protected AjoutSoft m_ajoutSoft;
        protected AjoutAlcool m_ajoutAlcool;
        protected ArrayList m_composants;
        protected ArrayList m_liste;
        protected int prev = 0;
        protected String nomCocktail;
        protected AjouterCocktail m_aCocktail;

        public Form1()
        {
            Initialiser(new Recherche(), new ListeCocktails(), new AjouterCocktail(), new AjoutSoft(), new AjoutAlcool());
        }

        public Form1(Recherche r, ListeCocktails lc, AjouterCocktail ac, AjoutSoft ajs, AjoutAlcool aja)
        {
            Initialiser(r,lc,ac, ajs, aja);
        }

        protected void Initialiser(Recherche r, ListeCocktails lc, AjouterCocktail ac, AjoutSoft ajs, AjoutAlcool aja)
        {
            m_recherche = r;
            m_lCocktails = lc;
            m_aCocktail = ac;
            m_ajoutSoft = ajs;
            m_ajoutAlcool = aja;
            m_composants = new ArrayList();
            InitializeComponent();
            this.Size = new Size(800, 500);
            m_composants.Add(label1);
            m_composants.Add(pbCocktails);
        }

        private void quitterAccueil()
        {
            label1.Visible = false;
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
            quitterAccueil();
            AffichageCocktails();
        }

        //Lance la recherche d'un cocktail
        private void RechercheEvent(object sender, EventArgs e)
        {
            quitterAccueil();
            AffichageRecherche();
        }

        private void ajouterUnCocktailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quitterAccueil();
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
            m_aCocktail.AddCocktail(m_recherche.Valider());
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

        //Page d'ajout d'un soft
        private void AddSoft(Object sender, EventArgs e)
        {
            AffAjoutSoft();
        }

        //Modification du nom du soft
        private void ModAddSof(Object sender, EventArgs e)
        {
            m_ajoutSoft.Nom(((TextBox)sender).Text);
        }

        //Ajout du cocktail
        private void ValAjoutSoft(Object s, EventArgs e)
        {
            if (m_ajoutSoft.Valider())
                MessageBox.Show("Le soft a bien ete ajoute.");
            else MessageBox.Show("Ce soft existe deja.");
        }

        //Page d'ajout d'un soft
        private void AddAlcool(Object sender, EventArgs e)
        {
            AffAjoutAlcool();
        }

        //Modification du nom du soft
        private void ModAddAlc(Object sender, EventArgs e)
        {
            m_ajoutAlcool.Nom(((TextBox)sender).Text);
        }

        private void ModDegAlcool(Object sender, EventArgs e)
        {
            string str = ((TextBox)sender).Text;
            if (str != "")
            {
                bool test = true;
                bool change = false;
                string bis = "";
                //On verifie qu'il n'y a que des chiffres
                for (int i = 0; (i < str.Length) && test; i++)
                {
                    if (test = (str[i] >= '0') && (str[i] <= '9') && (i < 3))
                        bis += str[i];
                }
                change = !test;
                //On enleve tous les 0 en debut de nombre
                while((bis != "") && (bis[0] == '0'))
                {
                    string temp = "";
                    for (int i = 1; i < bis.Length; i++)
                        temp += bis[i];
                    bis = temp;
                    change = true;
                }
                if (test)
                {
                    int d = int.Parse(str);
                    if(d > 100)
                    {
                        test = false;
                        bis = "100";

                    }
                    else if(d > 0)
                        m_ajoutAlcool.Degre(d);
                }
                //On affiche une valeur valide dans la TextBox
                if(change)
                {
                    ((TextBox)sender).Text = bis;
                    ((TextBox)sender).SelectionStart = bis.Length;
                    ((TextBox)sender).SelectionLength = 0;
                }
            }
        }

        //Ajout du cocktail
        private void ValAjoutAlcool(Object s, EventArgs e)
        {
            MessageBox.Show(m_ajoutAlcool.Valider());
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
                NomCocktailsLB.Location = new Point(apx, apy*(i+1));
                NomCocktailsLB.Text = "";
                NomCocktailsLB.Visible = true;

                ArrayList cock = ((ArrayList)cocktailsIngredients[i]);
                ArrayList cockAlcools = ((ArrayList)cock[1]);
                ArrayList cockSofts = ((ArrayList)cock[2]);
                
                NomCocktailsLB.Text = (String)cock[0] + ": ";
                NomCocktailsLB.Font = new Font("Times New Roman", 10, FontStyle.Underline);
                NomCocktailsLB.AutoSize = true;

                m_composants.Add(new Label());
                Label AlcoolsLB = (Label)m_composants[m_composants.Count - 1];
                AlcoolsLB.Parent = this;
                AlcoolsLB.Location = new Point(NomCocktailsLB.Location.X + ecart* 5, apy * (i + 1));
                if (cockAlcools.Count > 0)
                    AlcoolsLB.Text = ((alcool)cockAlcools[0]).NOM_ALCOOL;
                else AlcoolsLB.Text = ((soft)cockSofts[0]).NOM_SOFT;
                AlcoolsLB.Visible = true;
                
                for (int j = 1; j < cockAlcools.Count; j++)
                    AlcoolsLB.Text += ", " + ((alcool)cockAlcools[j]).NOM_ALCOOL;
                AlcoolsLB.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                AlcoolsLB.AutoSize = true;
                if (cockSofts.Count > 0)
                    AlcoolsLB.Text += ",";

                m_composants.Add(new Label());
                Label SoftsLB = (Label)m_composants[m_composants.Count - 1];
                SoftsLB.Parent = this;
                int x = ((Label)m_composants[m_composants.Count - 2]).Location.X + ((Label)m_composants[m_composants.Count - 2]).Width;
                SoftsLB.Location = new Point(x, apy * (i + 1));
                SoftsLB.Text = "";
                SoftsLB.Visible = true;
                

                for (int j = 0; j < cockSofts.Count; j++)
                {
                    SoftsLB.Text = SoftsLB.Text + ((soft)cockSofts[j]).NOM_SOFT;
                    if ((j + 1) < cockSofts.Count)
                        SoftsLB.Text += ", ";
                }
                SoftsLB.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                SoftsLB.AutoSize = true;
            }
            
        }

        private void AffichageAjouterCocktail()
        {
            //Code 1
            if (prev != 1)
                m_recherche.Clean();
            prev = 1;

            //S'il y avait déjà qqc d'afficher, on l'efface
            Vider();

            int w = 200,
                h = 300,
                m = 75;
            
            //TextBox nouveau cocktail
            m_composants.Add(new Label());
            Label lbCocktail = (Label)m_composants[m_composants.Count - 1];
            lbCocktail.Parent = this;
            lbCocktail.Location = new Point((this.Width / 6) - (w / 2),50);
            lbCocktail.Text = "Nom Cocktail";
            lbCocktail.Visible = true;
            
            TextBox tbCocktail = new TextBox();
            m_composants.Add(tbCocktail);
            tbCocktail.Parent = this;
            tbCocktail.Size = new Size(130, 23);
            tbCocktail.Location = new Point((this.Width / 6), 50);


            //On affiche les alcools
            PanneauCBAjout pAlcools = new PanneauCBAjout((this.Width / 6) - (w / 2), m, w+100, h, "Alcools : ", m_recherche.NomAlcool(), m_recherche.ListeAlcools(), new EventHandler(CheckAlcool));
            pAlcools.Parent = this;
            m_composants.Add(pAlcools);

           

            //On affiche les softs
            PanneauCBAjout pSofts = new PanneauCBAjout((this.Width / 2) - (w / 4), m, w+100, h, "Softs : ", m_recherche.NomSoft(), m_recherche.ListeSofts(), new EventHandler(CheckSoft));
            //Panneau pSofts = new Panneau(300, 50, 200, 300, "Softs : ", m_recherche.NomSoft());
            pSofts.Parent = this;
            m_composants.Add(pSofts);

            //Bouton de validation
            Button bVal = new Button();
            m_composants.Add(bVal);
            bVal.Parent = this;
            bVal.Text = "Ajouter";
            bVal.Size = new Size(130, 23);
            bVal.Location = new Point((this.Width / 3) - (bVal.Size.Width / 2), this.Height - 100);
            
            
            
           //On lance l'ajout au click
            bVal.Click += new EventHandler(AjouterCocktailClick);


        }

        private void AjouterCocktailClick(Object sender, EventArgs e)
        {
            
            m_aCocktail.AddCocktail(new ArrayList() );
        }

        private void AffichageRecherche()
        {
            //Code 2
            if (prev != 2)
                m_recherche.Clean();
            prev = 2;

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
            bVal.Size = new Size(130, 23);
            bVal.Location = new Point((this.Width / 3) - (bVal.Size.Width / 2), this.Height - 100);
            //On lance la recherche au click
            bVal.Click += new EventHandler(RechercheClick);

            //Bouton de remise a zero du tableau
            Button bRAZ = new Button();
            m_composants.Add(bRAZ);
            bRAZ.Parent = this;
            bRAZ.Text = "Tout Vider";
            bRAZ.Size = new Size(80, 23);
            bRAZ.Location = new Point((this.Width * 2 / 3) - (bVal.Size.Width / 2), this.Height - 100);
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

        //Affiche la page d'ajout d'un soft
        protected void AffAjoutSoft()
        {
            //On vide la fenetre si jamais il y avait deja qqc d'affiche
            Vider();

            //Titre
            int hT = 30,
                py = 20;
            Label lTitre = new Label();
            m_composants.Add(lTitre);
            lTitre.TextAlign = ContentAlignment.MiddleCenter;
            lTitre.Parent = this;
            lTitre.Text = "Ajout d'un soft";
            lTitre.Size = new Size(this.Width - 2, hT);
            lTitre.Location = new Point(1, py);

            //Nom du soft
            int hN = 30,
                ecartX = 5,
                ecartY = 30,
                tabulation = 20;
            Label lNom = new Label();
            m_composants.Add(lNom);
            lNom.TextAlign = ContentAlignment.BottomLeft;
            lNom.Parent = this;
            lNom.Text = "Nom du soft : ";
            lNom.AutoSize = true;
            lNom.Size = new Size(lNom.Width, hN);
            lNom.Location = new Point(tabulation, lTitre.Location.Y + lTitre.Height + ecartY);
            //Entree
            TextBox tNom = new TextBox();
            m_composants.Add(tNom);
            tNom.Parent = this;
            tNom.MaxLength = 29;
            tNom.Size = new Size(200, hN);
            tNom.Location = new Point(lNom.Location.X + lNom.Width + ecartX, lNom.Location.Y);
            tNom.TextChanged += new EventHandler(ModAddSof);

            //Bouton de validation
            int lB = 80,
                hB = 30;
            Button bVal = new Button();
            m_composants.Add(bVal);
            bVal.Parent = this;
            bVal.Text = "Ajouter";
            bVal.Size = new Size(lB, hB);
            bVal.Location = new Point((tNom.Location.X + tNom.Width - lB) / 2, tNom.Location.Y + ecartY);
            bVal.Click += new EventHandler(ValAjoutSoft);
        }

        //Affiche la page d'ajout d'un alcool
        protected void AffAjoutAlcool()
        {
            //On vide la fenetre si jamais il y avait deja qqc d'affiche
            Vider();

            //Titre
            int hT = 30,
                py = 20;
            Label lTitre = new Label();
            m_composants.Add(lTitre);
            lTitre.TextAlign = ContentAlignment.MiddleCenter;
            lTitre.Parent = this;
            lTitre.Text = "Ajout d'un soft";
            lTitre.Size = new Size(this.Width - 2, hT);
            lTitre.Location = new Point(1, py);

            //Nom du alcool
            int hN = 30,
                ecartX = 5,
                ecartY = 30,
                tabulation = 20,
                dx = 0;
            Label lNom = new Label();
            m_composants.Add(lNom);
            lNom.TextAlign = ContentAlignment.BottomLeft;
            lNom.Parent = this;
            lNom.Text = "Nom de l'alcool : ";
            lNom.AutoSize = true;
            lNom.Size = new Size(lNom.Width, hN);
            lNom.Location = new Point(tabulation, lTitre.Location.Y + lTitre.Height + ecartY);
            //Entree
            TextBox tNom = new TextBox();
            m_composants.Add(tNom);
            tNom.Parent = this;
            tNom.MaxLength = 29;
            tNom.Size = new Size(200, hN);
            dx = lNom.Location.X + lNom.Width + ecartX;
            tNom.TextChanged += new EventHandler(ModAddAlc);

            //Degre du alcool
            Label lDeg= new Label();
            m_composants.Add(lDeg);
            lDeg.TextAlign = ContentAlignment.BottomLeft;
            lDeg.Parent = this;
            lDeg.Text = "Degre de l'alcool : ";
            lDeg.AutoSize = true;
            lDeg.Size = new Size(lDeg.Width, hN);
            lDeg.Location = new Point(lNom.Location.X, lNom.Location.Y + lNom.Height + ecartY);
            //Entree
            TextBox tDeg = new TextBox();
            m_composants.Add(tDeg);
            tDeg.Parent = this;
            tDeg.MaxLength = 29;
            tDeg.Size = new Size(200, hN);
            dx = Math.Max(dx, lDeg.Location.X + lDeg.Width + ecartX);
            tNom.Location = new Point(dx, lNom.Location.Y);
            tDeg.Location = new Point(dx, lDeg.Location.Y);
            tDeg.TextChanged += new EventHandler(ModDegAlcool);

            //Bouton de validation
            int lB = 80,
                hB = 30;
            Button bVal = new Button();
            m_composants.Add(bVal);
            bVal.Parent = this;
            bVal.Text = "Ajouter";
            bVal.Size = new Size(lB, hB);
            bVal.Location = new Point((tDeg.Location.X + tDeg.Width - lB) / 2, tDeg.Location.Y + ecartY);
            bVal.Click += new EventHandler(ValAjoutAlcool);
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
