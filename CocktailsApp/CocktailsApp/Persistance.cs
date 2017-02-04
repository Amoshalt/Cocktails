using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;

namespace CocktailsApp
{
    public class Persistance
    {
        private isi_projet2_tardymartial_remondvictorEntities connexionBD;

        public Persistance()
        {
            connexionBD = new isi_projet2_tardymartial_remondvictorEntities();
            
        }

        public ArrayList getCocktails()
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<cocktail>();
            ArrayList listCocktail = new ArrayList();

            try
            {
                IQueryable<cocktail> requete = from d in table
                                               select d;
                Console.WriteLine("\nRequete : " + requete.Expression + "\n");
                var repCock = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (cocktail cktl in repCock)
                {
                    listCocktail.Add(cktl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E1 : " + ex.GetBaseException().Message);
            }
            return listCocktail;
        }

        public ArrayList getSofts()
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<soft>();
            ArrayList listSoft = new ArrayList();

            try
            {
                var requete = from t in table
                              select t;
                var repSoft = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (soft sft in repSoft)
                {
                    listSoft.Add(sft);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E1 : " + ex.GetBaseException().Message);
            }
            return listSoft;
        }

        public ArrayList getAlccols()
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<alcool>();
            ArrayList liste = new ArrayList();

            try
            {
                var requete = from t in table
                              select t;
                var res = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (alcool al in res)
                {
                    liste.Add(al);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E1 : " + ex.GetBaseException().Message);
            }
            return liste;
        }


        public ArrayList getIngredientsAlcool(int numCock)
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<ingredientalcool>();
            ArrayList listIAC = new ArrayList();

            try
            {
                var requete = from d in table
                              where d.NUM_COCKTAIL == numCock
                              select d;
                var repIAC = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (ingredientalcool ia in repIAC)
                {
                    listIAC.Add(ia);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("E1 : " + ex.GetBaseException().Message);
            }
            return listIAC;
        }


        public ArrayList getIngredientsSoft(int numCock)
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<ingredientsoft>();
            ArrayList listIAS = new ArrayList();

            try
            {
                var requete = from d in table
                              where d.NUM_COCKTAIL == numCock
                              select d;
                var repIAS = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (ingredientalcool ia in repIAS)
                {
                    listIAS.Add(ia);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("E1 : " + ex.GetBaseException().Message);
            }
            return listIAS;
        }


        /* Fonction de recherche des cocktails disponibles a partir d'une liste de softs et une autre d'alcools
         * parametres :
         *  > ArrayList : contient les numeros correspondant aux softs disponibles.
         *  > ArrayList : contient les numeros correspondant aux alcools disponibles.
         * retour :
         *  > ArrayList : contient les entites 'Cocktail' representant les cocktails disponibles.
         */
        public ArrayList RechercheComposee(ArrayList softs, ArrayList alcools)
        {
            //On cree la liste des numeros des cocktails necessitant au moins un ingredient que nous n'avons pas
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var tIAlcools = contexteBD.CreateObjectSet<ingredientalcool>();
            var tISofts = contexteBD.CreateObjectSet<ingredientsoft>();
            var tCocktails = contexteBD.CreateObjectSet<cocktail>();
            ArrayList noCo = new ArrayList();
            ArrayList liste = new ArrayList();
            //On commence par les alcools
            try
            {
                int[] noAl = new int[alcools.Count];
                for (int i = 0; i < alcools.Count; i++)
                    noAl[i] = (int)alcools[i];
                var req1 = from ia in tIAlcools
                           where !noAl.Contains(ia.NUM_ALCOOL) 
                           select ia.NUM_COCKTAIL;
                var res1 = ((ObjectQuery)req1).Execute(MergeOption.AppendOnly);
                foreach (int co in res1)
                {
                    noCo.Add(co);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur (recherche alcools) : " + ex.GetBaseException().Message);
            }
            //On utilise la même méthode pour les softs
            try
            {
                int[] noSo = new int[softs.Count];
                for (int i = 0; i < softs.Count; i++)
                    noSo[i] = (int)softs[i];
                var req2 = from ia in tISofts
                           where !noSo.Contains(ia.NUM_SOFT)
                           select ia.NUM_COCKTAIL;
                var res2 = ((ObjectQuery)req2).Execute(MergeOption.AppendOnly);
                foreach (int co in res2)
                {
                    noCo.Add(co);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur (recherche softs) : " + ex.GetBaseException().Message);
            }
            //On ressort ainsi la liste des cocktails :
            //Les cocktails dispos sont ceux dont on n'a pas le numero.
            try
            {
                int[] nCo = new int[noCo.Count];
                for (int i = 0; i < noCo.Count; i++)
                    nCo[i] = (int)noCo[i];
                var req3 = from ia in tCocktails
                           where !nCo.Contains(ia.NUM_COCKTAIL)
                           orderby ia.NUM_COCKTAIL
                           select ia;
                var res3 = ((ObjectQuery)req3).Execute(MergeOption.AppendOnly);
                foreach (cocktail co in res3)
                {
                    liste.Add(co);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur (recherche cocktails) : " + ex.GetBaseException().Message);
            }
            return liste;
        }
    }
}
