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

        /* l'alcool m_alcool prend comme nom le nom rentré en paramètre
         Parametres:
         * String nom de l'alcool rentré
         */
        public void Nom(string n)
        {
            // nom non vide
            if(n != "")
                m_alcool.NOM_ALCOOL = n;
        }

        /* l'alcool m_alcool prend comme degre le degre rentré en paramètre
         Parametres:
         * Int degre
         */
        public void Degre(int d)
        {
            if ((d > 0) && (d <= 100))
                m_alcool.DEGRE = d;
        }

        /* Retourne un objet de type String contenant la phrase de succes ou non de l'ajout de l'alcool en fonction de l'existence ou d'un degre negatif
         */
        public string Valider()
        {
            if (m_alcool.DEGRE <= 0)
                return "Vous ajoutez un alcool, veuillez renseigner un degre superieur a 0";
            if (m_persistance.getExistenceAlcool(m_alcool.NOM_ALCOOL))
                return "Cet alcool existe deja.";
            m_persistance.CreationAlcool(m_alcool);
            return "Alcool ajoute avec succes";
        }
    }
}
