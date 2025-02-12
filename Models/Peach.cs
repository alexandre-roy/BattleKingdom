namespace BattleKingdom.Models
{
    public class Peach : Heros, ICompetenceSpeciale
    {
        private int _degatDeBase;
        private int _deplacementDeBase;

        public Peach(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _degatDeBase = Arme.NbPointsDegat;
            _deplacementDeBase = NbCasesDeplacementMax;
        }

        public void ActiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = (int)(NbCasesDeplacementMax * 1.1);
            Arme.NbPointsDegat = (int)(Arme.NbPointsDegat * 1.1);
        }

        public void DesactiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = _degatDeBase;
            Arme.NbPointsDegat = _deplacementDeBase = NbCasesDeplacementMax;
        }
    }
}
