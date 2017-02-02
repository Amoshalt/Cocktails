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
    class Persistance
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
                var requete = from d in table
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


        public ArrayList getSoft()
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


    }
}
