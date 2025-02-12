namespace BattleKingdom.Models
{
    public class Mario : Heros, ICompetenceSpeciale
    {
        private int _degatDeBase;

        public Mario(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _degatDeBase = Arme.NbPointsDegat;
        }
        
        public void ActiverCompetenceSpeciale()
        {
            Arme.NbPointsDegat = (int)(Arme.NbPointsDegat * 1.1);
        }

        public void DesactiverCompetenceSpeciale()
        {
            Arme.NbPointsDegat = _degatDeBase;
        }
    }
}
