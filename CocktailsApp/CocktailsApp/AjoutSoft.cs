using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsApp
{
    public class AjoutSoft
    {
        protected Persistance m_persistance;
        protected soft m_soft;

        public AjoutSoft()
        {
            Initialiser(new Persistance());
        }

        public AjoutSoft(Persistance p)
        {
            Initialiser(p);
        }

        protected void Initialiser(Persistance p)
        {
            m_persistance = p;
            m_soft = new soft();
        }

        public void Nom(string n)
        {
            m_soft.NOM_SOFT = n;
        }

        public bool Valider()
        {
            if (m_persistance.getExistenceSoft(m_soft.NOM_SOFT))
                return false;
            m_persistance.CreationSoft(m_soft);
            return true;
        }
    }
}
