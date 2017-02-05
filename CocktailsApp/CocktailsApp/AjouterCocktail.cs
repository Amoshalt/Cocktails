using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsApp
{
    public class AjouterCocktail
    {
        protected Persistance m_persistance;
        protected ArrayList listeC;

        public AjouterCocktail()
        {
            Initialisation(new Persistance());
        }

        public AjouterCocktail(Persistance p)
        {
            Initialisation(p);
        }

        protected void Initialisation(Persistance p)
        {
            m_persistance = p;
            listeC = m_persistance.getCocktails();
        }
    }
}
