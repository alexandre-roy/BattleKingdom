namespace BattleKingdom.Models
{
    public class Ennemis : Attaquant
    {
        public Ennemis(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {

        }
    }
}
