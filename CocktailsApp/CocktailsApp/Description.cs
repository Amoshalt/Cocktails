
using System.Windows.Forms;

namespace CocktailsApp
{
    //Fenetre affichant les details sur un cocktail
    class Description : Form
    {
        protected Label m_lNom;
        protected cocktail m_cocktail;
        protected etaperecette[] m_etapes;

        public Description(cocktail c)
        {
            Recuperation();
        }

        protected void Recuperation()
        {
            //
        }
    }
}
