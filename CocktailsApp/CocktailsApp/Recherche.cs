using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Collections;

namespace CocktailsApp
{
    public class Recherche
    {
        protected Persistance m_persistance;
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
            m_persistance = p;

            //Initialisation des softs
            ArrayList softs = m_persistance.getSofts();
            m_softs = new string[softs.Count];
            m_softID = new int[softs.Count];
            m_softOK = new bool[softs.Count];
            for(int i = 0; i < softs.Count; i++)
            {
                m_softs[i] = ((soft)softs[i]).NOM_SOFT;
                m_softID[i] = ((soft)softs[i]).NUM_SOFT;
                m_softOK[i] = false;
            }

            //Initialisation des alcools
            ArrayList alcools = m_persistance.getAlccols();
            m_alcools = new string[alcools.Count];
            m_alcoolID = new int[alcools.Count];
            m_alcoolOK = new bool[alcools.Count];
            for (int i = 0; i < alcools.Count; i++)
            {
                m_alcools[i] = ((alcool)alcools[i]).NOM_ALCOOL;
                m_alcoolID[i] = ((alcool)alcools[i]).NUM_ALCOOL;
                m_alcoolOK[i] = false;
            }
        }

        //Remet tous les booleens a 'false'
        public void Clean()
        {
            for (int i = 0; i < m_softOK.Length; i++)
                m_softOK[i] = false;
            for (int i = 0; i < m_alcoolOK.Length; i++)
                m_alcoolOK[i] = false;
        }

        public bool[] ListeSofts()
        {
            return m_softOK;
        }

        public bool[] ListeAlcools()
        {
            return m_alcoolOK;
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
            if ((index >= 0) && (index < m_softOK.Length))
                m_softOK[index] = !m_softOK[index];
        }

        public void ModifAlcool(int index)
        {
            if ((index >= 0) && (index < m_alcoolOK.Length))
                m_alcoolOK[index] = !m_alcoolOK[index];
        }

        public ArrayList Valider()
        {
            ArrayList listeS = new ArrayList(), listeA = new ArrayList();
            for(int i = 0; i < m_softOK.Length; i++)
            {
                if (m_softOK[i])
                    listeS.Add(m_softID[i]);
            }
            for (int i = 0; i < m_alcoolOK.Length; i++)
            {
                if (m_alcoolOK[i])
                    listeA.Add(m_alcoolID[i]);
            }
            return m_persistance.RechercheComposee(listeS, listeA);
        }
    }
}
