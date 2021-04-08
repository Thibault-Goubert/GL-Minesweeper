using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM
{
    public interface IReactions
    {
        void MarquerCase(int x, int y, bool drapeau);

        void ActualiserComptage(int restantes);

        void AfficherCaseNumerotee(int x, int y, int contenu);

        void AfficherCaseMinee(int x, int y, bool perdu);

        void AfficherCaseMarquee(int x, int y);

        void PartiePerdue();

        void PartieGagnee();
    }
}
