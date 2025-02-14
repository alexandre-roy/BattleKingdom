namespace BattleKingdom.Models
{
    public class Peach : Heros, ICompetenceSpeciale
    {
        private int _degatDeBase;
        private int _deplacementDeBase;

        /// <summary>
        /// Instancie Peach
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="positionX">Sa posiition X</param>
        /// <param name="positionY">Sa position Y</param>
        /// <param name="nbCasesDeplacementMax">Son nombre de cases de déplacement max</param>
        /// <param name="nbPointsVie">Son nombre de points de vie</param>
        /// <param name="arme">Son arme</param>
        public Peach(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _degatDeBase = Arme.NbPointsDegat;
            _deplacementDeBase = NbCasesDeplacementMax;
        }

        /// <summary>
        /// Rapporte la puissance de l'arme à son état d'origine.
        /// </summary>
        public void ActiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = (int)(NbCasesDeplacementMax * 1.1);
            Arme.NbPointsDegat = (int)(Arme.NbPointsDegat * 1.1);
        }

        /// <summary>
        /// Rapporte la puissance de l'arme à son état d'origine.
        /// </summary>
        public void DesactiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = _deplacementDeBase;
            Arme.NbPointsDegat = _degatDeBase;
        }
    }
}
