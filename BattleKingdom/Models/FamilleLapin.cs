namespace BattleKingdom.Models
{
    public class FamilleLapin : Heros
    {
        /// <summary>
        /// Instancie un personnage dans la famille lapins
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="positionX">Sa posiition X</param>
        /// <param name="positionY">Sa position Y</param>
        /// <param name="nbCasesDeplacementMax">Son nombre de cases de déplacement max</param>
        /// <param name="nbPointsVie">Son nombre de points de vie</param>
        /// <param name="arme">Son arme</param>
        public FamilleLapin(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {

        }
    }
}
