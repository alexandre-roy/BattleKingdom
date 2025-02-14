namespace BattleKingdom.Models
{
    public class Mario : Heros, ICompetenceSpeciale
    {
        private int _degatDeBase;

        /// <summary>
        /// Instancie Mario
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="positionX">Sa posiition X</param>
        /// <param name="positionY">Sa position Y</param>
        /// <param name="nbCasesDeplacementMax">Son nombre de cases de déplacement max</param>
        /// <param name="nbPointsVie">Son nombre de points de vie</param>
        /// <param name="arme">Son arme</param>
        public Mario(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _degatDeBase = Arme.NbPointsDegat;
        }

        /// <summary>
        /// Augmente la puissance de son arme augmente de 10%.
        /// </summary>
        public void ActiverCompetenceSpeciale()
        {
            Arme.NbPointsDegat = (int)(Arme.NbPointsDegat * 1.1);
        }

        /// <summary>
        /// Rapporte la puissance de l'arme à son état d'origine.
        /// </summary>
        public void DesactiverCompetenceSpeciale()
        {
            Arme.NbPointsDegat = _degatDeBase;
        }
    }
}
