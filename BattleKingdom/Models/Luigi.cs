namespace BattleKingdom.Models
{
    public class Luigi : Heros, ICompetenceSpeciale
    {
        private int _deplacementDeBase;

        public Luigi(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _deplacementDeBase = NbCasesDeplacementMax;
        }

        public void ActiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = (int)(NbCasesDeplacementMax * 1.1);
        }

        public void DesactiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = _deplacementDeBase;
        }
    }
}
