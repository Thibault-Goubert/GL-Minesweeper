using System;
using System.Collections.Generic;
using System.Text;
using Demineur;
using IHM;

namespace Jeu
{
    public class Partie : IActions
    {
        Plateau plateau;
        Random rnd = new Random(); // à supprimer après le test

        public IReactions vue
        {
            get; set;
        }

        public void CommencerPartie(int largeur, int hauteur, int mines)
        {
            plateau = new Plateau(this, largeur, hauteur, mines);
        }

        public void DecouvrirCase(int x, int y)
        {
            //// à supprimer après le test
            //int i = rnd.Next(-1, 9);
            //if (i == -1)
            //    vue.AfficherCaseMinee(x, y, true);
            //else
            //    vue.AfficherCaseNumerotee(x, y, i);

            Case c = plateau.Trouver(x, y);
            bool minee = c.Decouvrir();
            if (minee)
            {
                vue.PartiePerdue();
            }
            else
            {
                bool gagnee = plateau.TesterSiGagne();
                if (gagnee)
                {
                    vue.PartieGagnee();
                }
            }
        }

        public void MarquerCase(int x, int y)
        {
            Case c = plateau.Trouver(x, y);
            c.Marquer();
        }

        public void TerminerPartie()
        {

        }
    }
}
