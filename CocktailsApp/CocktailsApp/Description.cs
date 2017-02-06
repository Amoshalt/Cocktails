
using System.Drawing;
using System.Windows.Forms;

namespace CocktailsApp
{
    //Fenetre affichant les details sur un cocktail
    class Description : Form
    {
        protected Label m_lNom;
        protected cocktail m_cocktail;
        protected string[] m_etapes;
        protected Recherche m_recherche;

        public Description(cocktail c, Recherche r)
        {
            Initialisation(c, r);
        }

        protected void Initialisation(cocktail c, Recherche r)
        {
            m_cocktail = c;
            m_recherche = r;
            Recuperation();
            //Parametres de la fenetre
            int l = 500,
                h = 500;
            this.Size = new Size(l, h);
            //Label
            int labH = 30;
            m_lNom = new Label();
            m_lNom.Parent = this;
            m_lNom.Font = new Font("Times New Roman", 20, FontStyle.Regular);
            m_lNom.AutoSize = true;
            m_lNom.Text = c.NOM_COCKTAIL;
            m_lNom.Size = new Size(l - 2, labH);
            //Affichage des etapes
            int ecart = 30,
                px = labH + 20,
                py = 50;
            for(int i = 0; i < m_etapes.Length; i++)
            {
                Label tl = new Label();
                tl.Parent = this;
                tl.Location = new Point(px, py + (i * ecart));
                tl.Size = new Size(l - (px + 1), ecart - 2);
                tl.Text = m_etapes[i];
            }
        }

        //Fonction appel a la couche persistance pour recuperation des etapes recette du cocktail
        protected void Recuperation()
        {
            m_etapes = m_recherche.Instructions(m_cocktail);
        }
    }
}
