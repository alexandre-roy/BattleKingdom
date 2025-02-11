using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleKingdom.Models
{
    internal class Heros : Attaquant
    {
        public Heros(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {
        }
    }
}
