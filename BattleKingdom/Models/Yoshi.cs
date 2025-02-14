
namespace BattleKingdom.Models
{
    public class Yoshi : Heros, ICompetenceSpeciale
    {
        private int _distanceArmeDeBase;

        /// <summary>
        /// Instancie Yoshi
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="positionX">Sa posiition X</param>
        /// <param name="positionY">Sa position Y</param>
        /// <param name="nbCasesDeplacementMax">Son nombre de cases de déplacement max</param>
        /// <param name="nbPointsVie">Son nombre de points de vie</param>
        /// <param name="arme">Son arme</param>
        public Yoshi(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _distanceArmeDeBase = Arme.NbDistanceMax;
        }

        /// <summary>
        /// Augmente la distance de son arme augmente de 10%.
        /// </summary>
        public void ActiverCompetenceSpeciale()
        {
            Arme.NbDistanceMax = (int)(Arme.NbDistanceMax * 1.1);
        }

        /// <summary>
        /// Rapporte la distance de l'arme à son état d'origine.
        /// </summary>
        public void DesactiverCompetenceSpeciale()
        {
            Arme.NbDistanceMax = _distanceArmeDeBase;
        }
    }
}
