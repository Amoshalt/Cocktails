using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /* Retourne un objet de type ArrayList contenant des ArrayList representant un cocktail de la BD avec le nom, les ingrédients contenu dans chaque cocktail
         * Contenu des sous-ArrayList :
         *  > NOM_COCKTAIL
         *  > ArrayList des NOM_ALCOOL
         *  > ArrayList des NOM_SOFT
         */
        public ArrayList getListeCI ()
        {
            //creation de la liste que l'on va renvoyer
            ArrayList listeCI = new ArrayList(m_nbCocktails);
            
            
            for( int i = 0; i< m_nbCocktails; i++)
            {
                ArrayList listeCIS = new ArrayList();
                ArrayList listeCIA = new ArrayList();

                //récupération des information necessaires du ième cocktail
                int NumCock = ((cocktail)listeC[i]).NUM_COCKTAIL;
                String NomCock = ((cocktail)listeC[i]).NOM_COCKTAIL;

                //recupération des ingrédients
                ArrayList listeIngrSoft = m_persistance.getSoftsCocktail(NumCock);
                ArrayList listeIngrAlc = m_persistance.getAlcoolsCocktail(NumCock);
                ArrayList listetemp = new ArrayList();

                //parcours de la liste des softs
                for ( int j = 0; j< listeIngrSoft.Count;j++ )
                {
                    listeCIS.Add(listeIngrSoft[j]);
                }

                //parcours de la liste des alcools
                for (int j = 0; j < listeIngrAlc.Count; j++)
                {
                    listeCIA.Add(listeIngrAlc[j]);
                }

                //creation array liste tempon des informationdu cocktail: 
                //case 0 nom, case 1 arrayliste des alcools, case 1 arrayliste des softs
                listetemp.Add(NomCock);
                listetemp.Add(listeCIA);
                listetemp.Add(listeCIS);
                
                //ajout de la liste tempon à la liste qu'on renvoit
                listeCI.Add(listetemp);
            }

            return listeCI;
        }


    }
}
