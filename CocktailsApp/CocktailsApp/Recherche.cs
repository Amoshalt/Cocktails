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
        protected string[] m_alcools;
        protected bool[] m_alcoolOK;

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
            ArrayList softs = m_pers.getSoft();
        }

        public string[] NomSoft()
        {
            return m_softs;
        }
    }
}
