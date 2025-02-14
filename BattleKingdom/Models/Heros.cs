namespace BattleKingdom.Models
{
    public class Heros : Attaquant
    {
        protected Heros(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {

        }
    }
}
