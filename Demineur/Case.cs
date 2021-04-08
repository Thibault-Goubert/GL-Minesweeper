using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur
{
    public class Case 
    {
        Plateau plateau;
        private bool minee, marquee, decouverte;
        private List<Case> voisines;
        int x, y;
        int nbMinesVoisines; //nb de voisine minée

        public Case(Plateau plateau, int x, int y, bool minee)
        {
            this.plateau = plateau;
            this.minee = minee;
            this.x = x;
            this.y = y;
            this.voisines = new List<Case>();
        }

        public void Marquer()
        {
            if (!decouverte)
            {
                marquee = !marquee;
                plateau.ModifierMarquees(marquee);
                plateau.partie.vue.MarquerCase(x, y, marquee);
            }
        }

        public void Connecter(Case c)
        {
            voisines.Add(c);
            if (c.minee)
            {
                nbMinesVoisines++;
            }
        }

        public bool Decouvrir()
        {
            if (decouverte || marquee)
            {
                return false;
            }
            decouverte = true;
            plateau.IncrementerDecouvertes();
            if (minee)
            {
                plateau.partie.vue.AfficherCaseMinee(x,y,true);
                return true;
            }
            else
            {
                plateau.partie.vue.AfficherCaseNumerotee(x,y, nbMinesVoisines);
                if (nbMinesVoisines == 0)
                {
                    foreach(Case voisine in voisines)
                    {
                        voisine.Decouvrir();
                    }
                }
                return false;
            }
            //return minee;
        }

        public void Afficher()
        {

        }
    }
}
