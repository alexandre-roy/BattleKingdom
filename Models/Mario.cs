namespace BattleKingdom.Models
{
    internal class Mario : Attaquant, ICompetenceSpeciale
    {
        public Mario(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {
        }

        public void ActiverCompetenceSpeciale()
        {
            throw new NotImplementedException();
        }

        public void DesactiverCompetenceSpeciale()
        {
            throw new NotImplementedException();
        }
    }
}
