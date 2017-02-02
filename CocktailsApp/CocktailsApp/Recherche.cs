using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Windows.Forms;

namespace CocktailsApp
{
    class Recherche
    {
        protected isi_projet2_tardymartial_remondvictorEntities connexionBD;
        protected string[] m_softs;
        protected bool[] m_softOK;
        protected string[] m_alcools;
        protected bool[] m_alcoolOK;

        public Recherche()
        {
            connexionBD = new isi_projet2_tardymartial_remondvictorEntities();
            Initialisation();
        }

        public Recherche(isi_projet2_tardymartial_remondvictorEntities BD)
        {
            connexionBD = BD;
            Initialisation();
        }

        protected void Initialisation()
        {
            var contexteBD = ((IObjectContextAdapter)connexionBD).ObjectContext;
            var table1 = contexteBD.CreateObjectSet<soft>();
            var table2 = contexteBD.CreateObjectSet<alcool>();
            try
            {
                var requete1 = from t in table1
                               select t.NOM_SOFT;
                var nomsSoft = ((ObjectQuery)requete1).Execute(MergeOption.AppendOnly);
                //On compte le nombre d'entrees
                int i = 0;
                foreach (var v in nomsSoft)
                    i++;
                m_softs = new string[i];
                m_softOK = new bool[i];
                i = 0;
                foreach (string s in nomsSoft)
                {
                    m_softOK[i] = false;
                    m_softs[i] = s;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.GetBaseException().Message);
            }
            try
            {
                var requete2 = from d in table2
                               select d.NOM_ALCOOL;
                var nomsAlccol = ((ObjectQuery)requete2).Execute(MergeOption.AppendOnly);
                //On compte le nombre d'entrees
                int i = 0;
                foreach (var v in nomsAlccol)
                    i++;
                m_alcools = new string[i];
                m_alcoolOK = new bool[i];
                i = 0;
                foreach (string s in nomsAlccol)
                {
                    m_alcoolOK[i] = false;
                    m_alcools[i] = s;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.GetBaseException().Message);
            }
        }

        public string[] NomSoft()
        {
            return m_softs;
        }
    }
}
