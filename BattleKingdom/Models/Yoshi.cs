
namespace BattleKingdom.Models
{
    public class Yoshi : Heros, ICompetenceSpeciale
    {
        private int _distanceArmeDeBase;

        public Yoshi(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _distanceArmeDeBase = Arme.NbDistanceMax;
        }

        public void ActiverCompetenceSpeciale()
        {
            Arme.NbDistanceMax = (int)(Arme.NbDistanceMax * 1.1);
        }

        public void DesactiverCompetenceSpeciale()
        {
            Arme.NbDistanceMax = _distanceArmeDeBase;
        }
    }
}
