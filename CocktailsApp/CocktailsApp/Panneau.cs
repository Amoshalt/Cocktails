using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace CocktailsApp
{
    public class Panneau : Panel
    {
        protected Label m_titre;
        protected Label[] m_lElements;
        protected Panel m_sousPanel;

        public Panneau()
        {
            Initialisation(10, 10, 100, 100, "Panneau");
            Donnees(new string[0], null);
        }

        public Panneau(int x, int y, int l, int h, string titre, string[] liste, EventHandler e)
        {
            Initialisation(x, y, l, h, titre);
            Donnees(liste, e);
        }

        protected void Initialisation(int x, int y, int l, int h, string titre)
        {
            //Parametres generaux
            Size = new Size(l, h);
            Location = new Point(x, y);
            //Titre
            int tHaut = 20, tLarg = l - 2;
            m_titre = new Label();
            m_titre.Parent = this;
            m_titre.Size = new Size(tLarg, tHaut);
            m_titre.Location = new Point(1, 1);
            Titre(titre);
            //Sous-panel
            int pHaut = h - (3 + tHaut);
            m_sousPanel = new Panel();
            m_sousPanel.Parent = this;
            m_sousPanel.Location = new Point(1, 2 + tHaut);
            m_sousPanel.Size = new Size(tLarg, pHaut);
            //ScrollBar automatique de notre sous-Panel
            m_sousPanel.AutoScroll = false;
            m_sousPanel.HorizontalScroll.Enabled = false;
            m_sousPanel.HorizontalScroll.Visible = false;
            m_sousPanel.HorizontalScroll.Maximum = 0;
            m_sousPanel.AutoScroll = true;
            //Permet d'utiliser la molette de la souris pour naviguer dans la liste, à condition d'avoir clique sur le sou-panel
            m_sousPanel.Click += new EventHandler(Focus);
        }

        protected void Focus(Object sender, EventArgs e)
        {
            m_sousPanel.Focus();
        }

        // evenement curseur passe sur la zone du cocktail afficher --> case grisée
        protected void Survol(Object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.LightGray;
        }

        // evenement curseur passe quitte la zone du cocktail afficher
        protected void Sortie(Object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Transparent;
        }

        public void Titre(string titre)
        {
            m_titre.Text = titre;
        }

        //Fonction d'actualisation des donnees du tableau
        public void Donnees(string[] liste, EventHandler e)
        {
            Vider();
            m_lElements = new Label[liste.Length];
            int ecart = 30,
                px = 1,
                py = 5;
            for (int i = 0; i < liste.Length; i++)
            {
                int ty = py + (i * ecart);
                //Ajout du label avec le nom de l'element
                m_lElements[i] = new Label();
                m_lElements[i].Location = new Point(px, ty);
                m_lElements[i].Size = new Size(m_sousPanel.Width - (1 + px), ecart - 2);
                m_lElements[i].Parent = m_sousPanel;
                m_lElements[i].TextAlign = ContentAlignment.MiddleLeft;
                m_lElements[i].Text = liste[i];
                m_lElements[i].TabIndex = i;
                m_lElements[i].MouseEnter += new EventHandler(Survol);
                m_lElements[i].MouseLeave += new EventHandler(Sortie);
                if(e != null)
                    m_lElements[i].Click += e;
            }
        }

        //Fonction de nettoyage de l'écran
        protected void Vider()
        {
            for (int i = 0; (m_lElements != null) && (i < m_lElements.Length); i++)
            {
                if (this.Controls.Contains((Control)m_lElements[i]))
                {
                    this.Controls.Remove((Control)m_lElements[i]);
                    ((Control)m_lElements[i]).Dispose();
                }
            }
            m_lElements = new Label[0];
        }
    }
}
