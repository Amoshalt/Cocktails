using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsApp
{
    
    public class ListeCocktails
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
            listeC = m_persistance.getCocktails();
            m_nbCocktails = listeC.Count;

        }
           
        public ArrayList[] getListeCI ()
        {
            ArrayList[] listeCI = new ArrayList[m_nbCocktails];
            ArrayList listeCIS = new ArrayList();
            ArrayList listeCIA = new ArrayList();
            
            for( int i = 0; i< m_nbCocktails; i++)
            {
                int NumCock = ((cocktail)listeC[i]).NUM_COCKTAIL;
                String NomCock = ((cocktail)listeC[i]).NOM_COCKTAIL;
                ArrayList listeIngrSoft = m_persistance.getIngredientsSoft(NumCock);
                
                for ( int j = 0; j< listeIngrSoft.Count;j++ )
                {
                    listeCIS.Add(listeIngrSoft[j]);
                }

                ArrayList listeIngrAlc = m_persistance.getIngredientsAlcool(NumCock);
                for (int j = 0; j < listeIngrAlc.Count; j++)
                {
                    listeCIA.Add(listeIngrAlc[j]);
                }

                listeCI[i][0] = NomCock;
                listeCI[i][1] = listeCIA;
                listeCI[i][2] = listeCIS;

            }
            return listeCI;
        }


    }
}
