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
           
        public ArrayList getListeCI ()
        {

            ArrayList listeCI = new ArrayList(m_nbCocktails);
            
            
            for( int i = 0; i< m_nbCocktails; i++)
            {
                ArrayList listeCIS = new ArrayList();
                ArrayList listeCIA = new ArrayList();

                int NumCock = ((cocktail)listeC[i]).NUM_COCKTAIL;
                /*MessageBox.Show(i.ToString());
                MessageBox.Show((((cocktail)listeC[i]).NUM_COCKTAIL).ToString());
                MessageBox.Show(((cocktail)listeC[i]).NOM_COCKTAIL);*/
                String NomCock = ((cocktail)listeC[i]).NOM_COCKTAIL;
                ArrayList listeIngrSoft = m_persistance.getSoftsCocktail(NumCock);
                ArrayList listeIngrAlc = m_persistance.getAlcoolsCocktail(NumCock);
                ArrayList listetemp = new ArrayList();
                for ( int j = 0; j< listeIngrSoft.Count;j++ )
                {
                    listeCIS.Add(listeIngrSoft[j]);
                }

                
                for (int j = 0; j < listeIngrAlc.Count; j++)
                {
                    listeCIA.Add(listeIngrAlc[j]);
                }

                listetemp.Add(NomCock);
                listetemp.Add(listeCIA);
                listetemp.Add(listeCIS);
                
                listeCI.Add(listetemp);
            }

            return listeCI;
        }


    }
}
