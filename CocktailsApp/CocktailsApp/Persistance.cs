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

        public delegate void ChangementDB(object sender, EventArgs e);

        protected void Reinit()
        {
            //Emission ev
        }

        //Retourne la liste des cocktails
        public ArrayList getCocktails()
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<cocktail>();
            ArrayList listCocktail = new ArrayList();

            try
            {
                IQueryable<cocktail> requete = from d in table
                                               select d;
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

        //Retourne la liste des softs
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

        //Retourne la liste des alcools
        public ArrayList getAlcools()
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

        //Retourne la liste des ingredientalcool lies au cocktail dont le numero est passe en parametre
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
                Console.WriteLine("E getIngredientsAlcool : " + ex.GetBaseException().Message);
            }
            return listIAC;
        }

        //Retourne la liste des ingredientsoft lies au cocktail dont le numero est passe en parametre
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
                foreach (ingredientsoft ia in repIAS)
                {
                    listIAS.Add(ia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E getIngredientsSoft : " + ex.GetBaseException().Message);
            }
            return listIAS;
        }

        //Retourne la liste des softs contenus dans le cocktail dont le numero est passe en parametre
        public ArrayList getSoftsCocktail(int numCock)
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<soft>();
            ArrayList listeS = new ArrayList();
            ArrayList listeIngrSoft = getIngredientsSoft(numCock);

            for(int i = 0; i< listeIngrSoft.Count; i++)
            {
                int numSoft = ((ingredientsoft)listeIngrSoft[i]).NUM_SOFT;
                try
                {
                    var requete = from d in table
                                  where d.NUM_SOFT == numSoft
                                  select d;
                    var repS = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                    foreach (soft s in repS)
                    {
                        listeS.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("E getSoftsCocktails : " + ex.GetBaseException().Message);
                }
            }
            return listeS;

        }

        //Retourne la liste des alcools contenus dans le cocktail dont le numero est passe en parametre
        public ArrayList getAlcoolsCocktail(int numCock)
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<alcool>();
            ArrayList listeS = new ArrayList();
            ArrayList listeIngrAlcool = getIngredientsAlcool(numCock);

            for (int i = 0; i < listeIngrAlcool.Count; i++)
            {
                int numAlcool = ((ingredientalcool)listeIngrAlcool[i]).NUM_ALCOOL;
                try
                {
                    var requete = from d in table
                                  where d.NUM_ALCOOL == numAlcool
                                  select d;
                    var repS = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                    foreach (alcool s in repS)
                    {
                        listeS.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("E getAlcoolsCocktail : " + ex.GetBaseException().Message);
                }
            }
            return listeS;

        }

        public Boolean getExistenceCocktail(String nomCocktail)
        {
            Boolean existence = new Boolean();
            existence = true;
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<cocktail>();
            ArrayList lC = new ArrayList();

            try
            {
                var requete = from d in table
                              where d.NOM_COCKTAIL == nomCocktail
                              select d;
                var repC = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach(cocktail c in repC)
                {
                    lC.Add(c);
                }

                if (lC.Count  == 0)
                {
                    existence = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E getExistenceCocktail : " + ex.GetBaseException().Message);
            }

            return existence;
        }

        //Return true si le soft existe, false sinon
        public Boolean getExistenceSoft(String nomSoft)
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<soft>();
            ArrayList lS = new ArrayList();

            try
            {
                var requete = from d in table
                              where d.NOM_SOFT == nomSoft
                              select d;
                var repC = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (soft c in repC)
                {
                    lS.Add(c);
                }

                return (lS.Count != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E getExistenceCocktail : " + ex.GetBaseException().Message);
            }
            return true;
        }

        public Boolean getExistenceAlcool(String nomAlcool)
        {
            Boolean existence = new Boolean();
            existence = true;
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<alcool>();
            ArrayList lA = new ArrayList();

            try
            {
                var requete = from d in table
                              where d.NOM_ALCOOL == nomAlcool
                              select d;
                var repC = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (cocktail c in repC)
                {
                    lA.Add(c);
                }

                if (lA.Count == 0)
                {
                    existence = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E getExistenceCocktail : " + ex.GetBaseException().Message);
            }
            return existence;
        }

        public void CreationCocktail(cocktail c)
        {
            try
            {
                connexionBD.cocktail.Add(c);
                connexionBD.SaveChanges();
                Reinit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur Ajout Cocktail : " + e.GetBaseException().Message);
            }
        }

        public void CreationSoft(soft s)
        {
            try
            {
                connexionBD.soft.Add(s);
                connexionBD.SaveChanges();
                Reinit();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erreur Ajout Soft : " + e.GetBaseException().Message);
            }
        }

        public void CreationAlcool(alcool a)
        {
            try
            {
                connexionBD.alcool.Add(a);
                connexionBD.SaveChanges();
                Reinit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur Ajout Soft : " + e.GetBaseException().Message);
            }
        }

        public void CreationEtape(etaperecette et)
        {
            try
            {
                connexionBD.etaperecette.Add(et);
                connexionBD.SaveChanges();
                Reinit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur Ajout Soft : " + e.GetBaseException().Message);
            }
        }

        //Fonction verifiant s'il existe un cocktail avec les memes ingredients (peu importe les dosages)
        //Ne fonctionne pas s'il n'y a pas de soft ou pas d'alcool dans le cocktail
        public bool ExistenceCocktail(ArrayList al, ArrayList so)
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var tIAlcools = contexteBD.CreateObjectSet<ingredientalcool>();
            var tISofts = contexteBD.CreateObjectSet<ingredientsoft>();
            ArrayList lAvec = new ArrayList(), lSans = new ArrayList();
            ArrayList liste = new ArrayList();
            int[] alcools = new int[al.Count];
            for (int i = 0; i < al.Count; i++)
                alcools[i] = (int)al[i];
            int[] softs = new int[so.Count];
            for (int i = 0; i < so.Count; i++)
                softs[i] = (int)so[i];
            //On recherche les cocktails contenant tous nos alcools et aucun autre
            try
            {
                var req1 = from ia in tIAlcools
                           where alcools.Contains(ia.NUM_ALCOOL)
                           select ia.NUM_COCKTAIL;
                var res1 = ((ObjectQuery)req1).Execute(MergeOption.AppendOnly);
                foreach (int co in res1)
                {
                    lAvec.Add(co);
                    Console.WriteLine("Avec : " + co);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur (recherche alcools) : " + ex.GetBaseException().Message);
            }
            try
            {
                var req2 = from ia in tIAlcools
                           where !alcools.Contains(ia.NUM_ALCOOL)
                           select ia.NUM_COCKTAIL;
                var res2 = ((ObjectQuery)req2).Execute(MergeOption.AppendOnly);
                foreach (int co in res2)
                {
                    lSans.Add(co);
                }
                //lAvec contient les numeros des cocktails contenant au moins un alcool de la liste
                //lSans contient les numeros des cocktails contenant au moins un alcool qui n'est pas dans la liste
                //Tout cocktail dont le numero est dans lAvec et pas dans lSans contient tous les alcools de notre liste
                for(int i = 0; i < lAvec.Count; i++)
                {
                    if (!lSans.Contains(lAvec[i]))
                        liste.Add(lAvec[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur (recherche alcools) : " + ex.GetBaseException().Message);
            }
            //On utilise la même méthode pour les softs
            lSans = new ArrayList();
            lAvec = new ArrayList();



            Console.WriteLine("...");
            try
            {
                var req1 = from ia in tISofts
                           where softs.Contains(ia.NUM_SOFT)
                           select ia.NUM_COCKTAIL;
                var res1 = ((ObjectQuery)req1).Execute(MergeOption.AppendOnly);
                foreach (int co in res1)
                {
                    lAvec.Add(co);
                    Console.WriteLine("Avec : " + co);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur (recherche softs) : " + ex.GetBaseException().Message);
            }
            try
            {
                var req2 = from ia in tISofts
                           where !softs.Contains(ia.NUM_SOFT)
                           select ia.NUM_COCKTAIL;
                var res2 = ((ObjectQuery)req2).Execute(MergeOption.AppendOnly);
                foreach (int co in res2)
                {
                    lSans.Add(co);
                    Console.WriteLine("Sans : " + co);
                }
                //lAvec contient les numeros des cocktails contenant au moins un alcool de la liste
                //lSans contient les numeros des cocktails contenant au moins un alcool qui n'est pas dans la liste
                //Tout cocktail dont le numero est dans lAvec et pas dans lSans contient tous les alcools de notre liste
                for (int i = 0; i < lAvec.Count; i++)
                {
                    //Si il y a correspondance pour les softs et les alcools, c'est que le cocktail existe
                    if (!lSans.Contains(lAvec[i]) && liste.Contains(lAvec[i]))
                        return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur (recherche softs) : " + ex.GetBaseException().Message);
            }
            return false;
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

        //Retourne la liste des etaperecette liees au cocktail dont le numero est passe en parametre
        public ArrayList getEtapes(int numCo)
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table = contexteBD.CreateObjectSet<etaperecette>();
            ArrayList liste = new ArrayList();
            
            try
            {
                //On recupere les etapes dans l'ordre
                var requete = from d in table
                                where d.NUM_COCKTAIL == numCo
                                orderby d.NUM_ETAPE ascending
                                select d;
                var repS = ((ObjectQuery)requete).Execute(MergeOption.AppendOnly);
                foreach (etaperecette e in repS)
                {
                    liste.Add(e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("E getAlcoolsEtape : " + ex.GetBaseException().Message);
            }

            return liste;
        }
    }
}
