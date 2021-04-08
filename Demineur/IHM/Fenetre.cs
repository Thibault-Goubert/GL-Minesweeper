using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    public partial class Fenetre : Form, IReactions
    {
        // configuration de jeu
        int largeur_grille = 10;
        int hauteur_grille = 10;
        int taille_tuile = 20;
        int numero_mines = 10;

        // IHM
        Button[,] grille;

        // associations
        IActions jeu;

        public Fenetre(IActions model)
        {
            // initialisation IHM
            InitializeComponent();

            // initialisation de la grille
            grille = new Button[largeur_grille, hauteur_grille];

            // initialisation des tuiles
            for (int i = 0; i < largeur_grille; i++)
            {
                for (int j = 0; j < hauteur_grille; j++)
                {
                    // creation d'une tuile
                    grille[i, j] = new Button();
                    grille[i, j].Size = new Size(taille_tuile, taille_tuile);
                    grille[i, j].Font = new Font("Arial", 9, FontStyle.Bold);

                    // positionnement
                    grille[i, j].Location = new Point(i * taille_tuile, j * taille_tuile);
                    this.GridPanel.Controls.Add( grille[i, j] );

                    // gestionnaire des clics
                    grille[i, j].MouseUp += new MouseEventHandler(this.CellButton_Click);
                }
            }

            // connection
            jeu = model;
            jeu.vue = this;
            jeu.CommencerPartie(largeur_grille, hauteur_grille, numero_mines);
            MineLabel.Text = "Mines : " + numero_mines;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            jeu.CommencerPartie(largeur_grille, hauteur_grille, numero_mines);

            // reset des info
            StartButton.Image = global::Demineur.Properties.Resources.happySmiley;
            MineLabel.Text = "Mines : " + numero_mines;

            // couverture des cases
            for (int i = 0; i < largeur_grille; i++)
            {
                for (int j = 0; j < hauteur_grille; j++)
                {
                    grille[i, j].FlatStyle = FlatStyle.Standard;
                    grille[i, j].Enabled = true;
                    grille[i, j].Text = "";
                    grille[i, j].Image = null;
                    grille[i, j].ForeColor = Color.Empty;
                    grille[i, j].BackColor = Color.Empty;
                }
            }
        }

        private void CellButton_Click(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            int x = b.Location.X / taille_tuile;
            int y = b.Location.Y / taille_tuile;

            if( e.Button == MouseButtons.Left )
                jeu.DecouvrirCase(x, y);
            else
                jeu.MarquerCase(x, y);
        }

        void IReactions.MarquerCase(int x, int y, bool drapeau)
        {
            if( drapeau )
                grille[x, y].Image = global::Demineur.Properties.Resources.flag;
            else
                grille[x, y].Image = null;
        }

        void IReactions.ActualiserComptage(int restantes)
        {
            MineLabel.Text = "Mines : " + restantes;
        }

        void IReactions.AfficherCaseNumerotee(int x, int y, int contenu)
        {
            string contenuAAfficher = contenu.ToString();
            grille[x, y].Enabled = false;
            grille[x, y].FlatStyle = FlatStyle.Flat;
            grille[x, y].BackColor = Color.Silver;
            switch (contenu)
            {
                case 1: grille[x, y].ForeColor = Color.Blue; break;
                case 2: grille[x, y].ForeColor = Color.Green; break;
                case 3: grille[x, y].ForeColor = Color.Red; break;
                case 4: grille[x, y].ForeColor = Color.DarkBlue; break;
                case 5: grille[x, y].ForeColor = Color.DarkRed; break;
                case 6: grille[x, y].ForeColor = Color.DarkGreen; break;
                case 7: grille[x, y].ForeColor = Color.Magenta; break;
                case 8: grille[x, y].ForeColor = Color.Gray; break;
                default:
                    grille[x, y].ForeColor = Color.Empty;
                    contenuAAfficher = "";
                    break;
            }
            grille[x, y].Text = contenuAAfficher;
        }

        void IReactions.AfficherCaseMinee(int x, int y, bool perdu)
        {
            //grille[x, y].Enabled = false;
            grille[x, y].FlatStyle = FlatStyle.Flat;

            if (perdu)
                grille[x, y].Image = global::Demineur.Properties.Resources.foundedBomb;
            else
                grille[x, y].Image = global::Demineur.Properties.Resources.bomb;
        }

        void IReactions.AfficherCaseMarquee(int x, int y)
        {
            grille[x, y].Image = global::Demineur.Properties.Resources.notBomb;
        }

        void IReactions.PartiePerdue()
        {
            StartButton.Image = global::Demineur.Properties.Resources.sadSmiley;
            jeu.TerminerPartie();
        }

        void IReactions.PartieGagnee()
        {
            StartButton.Image = global::Demineur.Properties.Resources.winnerSmiley;
            jeu.TerminerPartie();
        }
    }
}
