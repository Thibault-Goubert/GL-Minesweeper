using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // initialiser le jeu
            IActions model = new Jeu.Partie();
            Fenetre vue = new Fenetre(model);

            // lancer le jeu
            Application.EnableVisualStyles();
            Application.Run(vue);
        }
    }
}
