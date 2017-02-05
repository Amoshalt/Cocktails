using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsApp
{
    public class AjoutAlcool
    {
        protected Persistance m_persistance;
        protected alcool m_alcool;

        public AjoutAlcool()
        {
            Initialiser(new Persistance());
        }

        public AjoutAlcool(Persistance p)
        {
            Initialiser(p);
        }

        protected void Initialiser(Persistance p)
        {
            m_persistance = p;
            m_alcool = new alcool();
        }

        public void Nom(string n)
        {
            if(n != "")
                m_alcool.NOM_ALCOOL = n;
        }

        public void Degre(int d)
        {
            if(d > 0)
                m_alcool.DEGRE = d;
        }

        public bool Valider()
        {
            if (m_persistance.getExistenceAlcool(m_alcool.NOM_ALCOOL))
                return false;
            m_persistance.CreationAlcool(m_alcool);
            return true;
        }
    }
}
