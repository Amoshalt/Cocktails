using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CocktailsApp
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Persistance persistance = new Persistance();
            Recherche recherche = new Recherche(persistance);
            ListeCocktails listeCocktails = new ListeCocktails(persistance);
            AjouterCocktail ajCock = new AjouterCocktail(persistance);

            AjoutSoft ajtSoft = new AjoutSoft(persistance);
            Form1 vue = new Form1(recherche, listeCocktails, ajCock, ajtSoft);

            Application.Run(vue);
        }
    }
}
