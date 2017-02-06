using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsApp
{
    public class AjouterCocktail
    {
        protected Persistance m_persistance;
        protected cocktail m_cocktail;
        protected alcool[] m_alc;
        protected soft[] m_soft;
        protected bool[] m_aOK;
        protected bool[] m_sOK;
        protected int[] m_aQtt;
        protected int[] m_sQtt;

        public AjouterCocktail()
        {
            Initialisation(new Persistance());
        }

        public AjouterCocktail(Persistance p)
        {
            Initialisation(p);
        }

        protected void Initialisation(Persistance p)
        {
            m_persistance = p;
            m_cocktail = new cocktail();
            m_cocktail.NOM_COCKTAIL = "";
            ArrayList listeA = m_persistance.getAlcools();
            ArrayList listeS = m_persistance.getSofts();
            m_alc = new alcool[listeA.Count];
            m_soft = new soft[listeS.Count];
            m_aOK = new bool[listeA.Count];
            m_sOK = new bool[listeS.Count];
            m_aQtt = new int[listeA.Count];
            m_sQtt = new int[listeS.Count];
            for (int i = 0; i < listeA.Count; i++)
            {
                m_alc[i] = (alcool)listeA[i];
                m_aOK[i] = false;
                m_aQtt[i] = 0;
            }
            for (int i = 0; i < listeS.Count; i++)
            {
                m_soft[i] = (soft)listeS[i];
                m_sOK[i] = false;
                m_sQtt[i] = 0;
            }
        }

        //Ajoute/retire l'alcool des ingredients
        public void ChangeAl(int i)
        {
            if ((i >= 0) && (i < m_aOK.Length))
            {
                m_aOK[i] = !m_aOK[i];
                if (!m_aOK[i])
                    m_aQtt[i] = 0;
            }
        }

        //Modifie la quantite d'alcool
        public void QttAl(int i, int q)
        {
            if ((i >= 0) && (i < m_aOK.Length))
            {
                if (q > 0)
                    m_aQtt[i] = q;
            }
        }

        //Ajoute/retire le soft des ingredients
        public void ChangeSo(int i)
        {
            if ((i >= 0) && (i < m_sOK.Length))
            {
                m_sOK[i] = !m_sOK[i];
                if (!m_sOK[i])
                    m_sQtt[i] = 0;
            }
        }

        //Modifie la quantite de soft
        public void QttSo(int i, int q)
        {
            if ((i >= 0) && (i < m_sOK.Length))
            {
                if (q > 0)
                    m_sQtt[i] = q;
            }
        }

        public bool[] AlcoolOK()
        {
            return m_aOK;
        }

        public bool[] SoftOK()
        {
            return m_sOK;
        }

        //Modifie le nom du soft
        public void Nom(string n)
        {
            m_cocktail.NOM_COCKTAIL = n;
        }

        //On s'assure qu'il y ait au moins un ingredient et que chaque ingredient ait une quantite non nulle
        protected bool IngredientsOK()
        {
            bool test = false;
            for(int i = 0; i < m_aOK.Length; i++)
            {
                test |= m_aOK[i];
                if (m_aOK[i] && (m_aQtt[i] <= 0))
                    return false;
            }
            for(int i = 0; i < m_sOK.Length; i++)
            {
                test |= m_sOK[i];
                if (m_sOK[i] && (m_sQtt[i] <= 0))
                    return false;
            }
            return test;
        }

        //Verifie que le cocktail est unique
        protected bool Unique()
        {
            ArrayList la = new ArrayList(), ls = new ArrayList();
            for(int i = 0; i < m_aOK.Length; i++)
            {
                if (m_aOK[i])
                    la.Add(m_alc[i].NUM_ALCOOL);
            }
            for(int i = 0; i < m_sOK.Length; i++)
            {
                if (m_sOK[i])
                    ls.Add(m_soft[i].NUM_SOFT);
            }
            return !m_persistance.ExistenceCocktail(la, ls);
        }

        //Verifie le nom
        protected bool NomOK()
        {
            bool test = false;
            for (int i = 0; i < m_cocktail.NOM_COCKTAIL.Length; i++)
                test |= (m_cocktail.NOM_COCKTAIL[i] != ' ');
            return test && (m_cocktail.NOM_COCKTAIL != "");
        }

        //Ajoute le cocktail a la BDD
        public string AddCocktail(ArrayList listeIngr)
        {
            if (!IngredientsOK())
                return "Entrez une quantite valide pour chaque ingredient";
            if(!Unique())
                return "Un cocktail avec les memes ingredients exixte deja.";
            if (!NomOK())
                return "Ce nom n'est pas valide.";
            m_persistance.CreationCocktail(m_cocktail);
            return "Cocktail Ajoute";
        }
    }
}
