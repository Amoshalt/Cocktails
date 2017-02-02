using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Collections;

namespace CocktailsApp
{
    class Recherche
    {
        protected Persistance m_pers;
        protected string[] m_softs;
        protected bool[] m_softOK;
        protected int[] m_softID;
        protected string[] m_alcools;
        protected bool[] m_alcoolOK;
        protected int[] m_alcoolID;

        public Recherche()
        {
            Initialisation(new Persistance());
        }

        public Recherche(Persistance p)
        {
            Initialisation(p);
        }

        protected void Initialisation(Persistance p)
        {
            m_pers = p;

            //Initialisation des softs
            ArrayList softs = m_pers.getSofts();
            m_softs = new string[softs.Count];
            m_softOK = new bool[softs.Count];
            for(int i = 0; i < softs.Count; i++)
            {
                m_softs[i] = ((soft)softs[i]).NOM_SOFT;
                m_alcoolID[i] = ((soft)softs[i]).NUM_SOFT;
                m_softOK[i] = false;
            }

            //Initialisation des alcools
            ArrayList alcools = m_pers.getAlccols();
            m_alcools = new string[alcools.Count];
            m_alcoolOK = new bool[alcools.Count];
            for (int i = 0; i < alcools.Count; i++)
            {
                m_alcools[i] = ((alcool)alcools[i]).NOM_ALCOOL;
                m_alcoolID[i] = ((alcool)alcools[i]).NUM_ALCOOL;
                m_alcoolOK[i] = false;
            }
        }

        public string[] NomSoft()
        {
            return m_softs;
        }

        public string[] NomAlcool()
        {
            return m_alcools;
        }

        public void ModifSoft(int index)
        {
            if((index >= 0) && (index < m_softOK.Length))
                m_softOK[index] = !m_softOK[index];
        }

        public void ModifAlcool(int index)
        {
            if ((index >= 0) && (index < m_alcoolOK.Length))
                m_alcoolOK[index] = !m_alcoolOK[index];
        }

        public ArrayList Valider()
        {
            ArrayList liste = new ArrayList();
            return liste;
        }
    }
}
