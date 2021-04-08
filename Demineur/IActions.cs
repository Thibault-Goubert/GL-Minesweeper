using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM
{
    public interface IActions
    {
        IReactions vue { get; set; }

        void CommencerPartie(int largeur, int hauteur, int mines);

        void TerminerPartie();

        void MarquerCase(int x, int y);

        void DecouvrirCase(int x, int y);
    }
}
