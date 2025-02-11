namespace BattleKingdom.Models
{
    internal class Ennemis : Attaquant
    {
        public Ennemis(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {

        }
    }
}
