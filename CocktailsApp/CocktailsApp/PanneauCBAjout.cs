using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CocktailsApp
{
    class PanneauCBAjout : PanneauCB
    {
        protected TextBox[] m_tbElements;

        public PanneauCBAjout() : base()
        {
            Donnees(new string[0], new bool[0], null);
        }

        public PanneauCBAjout(int x, int y, int l, int h, string titre, string[] liste, bool[] test, EventHandler e) : base(x, y, l, h, titre, new string[0], new bool[0], e)
        {
            Donnees(liste, test, e);
        }

        public void Donnees(string[] liste, bool[] test, EventHandler e)
        {
            Vider();
            m_lElements = new Label[liste.Length];
            m_cElements = new CheckBox[liste.Length];
            m_tbElements = new TextBox[liste.Length];
            int ecart = 30,
                tab = 15,
                px = 1,
                py = 5;
            for (int i = 0; i < liste.Length; i++)
            {
                int ty = py + (i * ecart);
                //Ajout du label avec le nom de l'element
                m_lElements[i] = new Label();
                m_lElements[i].Size = new Size(m_sousPanel.Width - (1 + px + tab), ecart - 2);
                m_lElements[i].Parent = m_sousPanel;
                m_lElements[i].Text = liste[i];
                m_lElements[i].Location = new Point(px + tab, ty);

                //Ajout de la textBox avec rien à l'intérieur:
                m_tbElements[i] = new TextBox();
                m_lElements[i].Parent = m_sousPanel;
                m_lElements[i].Size = new Size(m_sousPanel.Width - (1 + px + tab), ecart - 2);
                m_lElements[i].Location = new Point(px + tab, ty + ecart);

                //Ajout de la Checkbox pour (de)selectionner l'element
                m_cElements[i] = new CheckBox();
                //m_composants.Add(cAl);
                m_cElements[i].Parent = m_sousPanel;
                //On permet enregistre l'index pour retrouver a quel element la checkbox correspond par la suite
                m_cElements[i].TabIndex = i;
                m_cElements[i].Location = new Point(px, ty - 5);
                //Si l'utilisateur avait declare cet element comme disponnible, on coche la case
                if ((i < test.Length) && test[i])
                    m_cElements[i].Checked = true;
                //On s'assure que l'action soit transmise a la couche metier
                if (e != null)
                    m_cElements[i].Click += e;
            }

        }

        protected new void Vider()
        {
            base.Vider();
            for (int i = 0; (m_tbElements != null) && (i < m_tbElements.Length); i++)
            {
                if (this.Controls.Contains((Control)m_tbElements[i]))
                {
                    this.Controls.Remove((Control)m_tbElements[i]);
                    ((Control)m_tbElements[i]).Dispose();
                }
            }
            m_tbElements = new TextBox[0];
        }
    }
}
