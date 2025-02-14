namespace BattleKingdom.Models
{
    public class Allies : Personnage
    {
        /// <summary>
        /// Instancie un allié
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="positionX">Sa posiition X</param>
        /// <param name="positionY">Sa position Y</param>
        /// <param name="nbCasesDeplacementMax">Son nombre de cases de déplacement max</param>
        /// <param name="nbPointsVie">Son nombre de points de vie</param>
        public Allies(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {

        }
    }
}
