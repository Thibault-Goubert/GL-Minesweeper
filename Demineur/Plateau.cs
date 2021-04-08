using Jeu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demineur
{
    public class Plateau
    {
        public Partie partie;
        public int largeur, hauteur;
        Case[,] cases;

        private int mines, decouvertes, restantes;

        private Random des = new Random();
        private int mineAPlacer;

        public Plateau(Partie partie, int largeur, int hauteur, int mines)
        {
            this.partie = partie;
            this.largeur = largeur;
            this.hauteur = hauteur;
            this.mines = mines;
            this.restantes = mines;
            this.mineAPlacer = mines;

            cases = new Case[largeur, hauteur];

            //Initialise les cases du plateau
            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    bool isMine = false;
                    int test = des.Next(0, (hauteur * largeur) - ((y*largeur) +x));
                    if (test < mineAPlacer)
                    {
                        isMine = true;
                        mineAPlacer--;
                    }
                    cases[x,y] = new Case(this,x ,y, isMine); //Faire en sorte de minée aléatoirement
                }
            }
            //Créé les liaisons
            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {                    
                    // connection avec les voisines
                    int N = hauteur - 1;

                    if (x > 0 && y > 0) Connecter(cases[x, y], cases[x - 1, y - 1]);

                    if (x > 0) Connecter(cases[x, y], cases[x - 1, y]);

                    if (y > 0) Connecter(cases[x, y], cases[x, y - 1]);

                    if (x > 0 && y < N) Connecter(cases[x, y], cases[x - 1, y + 1]);
                }
            }
        }

        private void Connecter(Case c1, Case c2)
        {
            c1.Connecter(c2);
            c2.Connecter(c1);
        }

        public Case Trouver(int x, int y)
        {
            return cases[x, y];
        }

        public void IncrementerDecouvertes()
        {
            decouvertes++;
        }

        public void ModifierMarquees(bool marquee)
        {
            if (marquee) restantes--; else restantes++;
            partie.vue.ActualiserComptage(restantes);
        }

        public bool TesterSiGagne()
        {
            return decouvertes + mines == largeur * hauteur;
        }
    }
}
