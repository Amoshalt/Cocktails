using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsApp
{
    
    class ListeCocktails
    {
        protected Persistance m_persistance;
        protected int m_nbCocktails;
        protected ArrayList listeC;

        public ListeCocktails()
        {
            Initialisation(new Persistance());
        }

        public ListeCocktails(Persistance p)
        {
            Initialisation(p);
        }

        protected void Initialisation(Persistance p)
        {
            m_persistance = p;
            ArrayList listeC = new ArrayList();
            listeC = m_persistance.getCocktails();
            m_nbCocktails = listeC.Count;

        }

        public ArrayList[] getListeCI ()
        {
            ArrayList[] listeCI = new ArrayList[m_nbCocktails];
            ArrayList listeCIS = new ArrayList();
            ArrayList listeCIA = new ArrayList();

            listeCIS = m_persistance.getIngredientsSoft();
            return listeCI;
        }


    }
}
