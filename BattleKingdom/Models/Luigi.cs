namespace BattleKingdom.Models
{
    public class Luigi : Heros, ICompetenceSpeciale
    {
        private int _deplacementDeBase;

        /// <summary>
        /// Instancie Luigi
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="positionX">Sa posiition X</param>
        /// <param name="positionY">Sa position Y</param>
        /// <param name="nbCasesDeplacementMax">Son nombre de cases de déplacement max</param>
        /// <param name="nbPointsVie">Son nombre de points de vie</param>
        /// <param name="arme">Son arme</param>
        public Luigi(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie, arme)
        {
            _deplacementDeBase = NbCasesDeplacementMax;
        }

        /// <summary>
        /// Augmente sa distance de 10%.
        /// </summary>
        public void ActiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = (int)(NbCasesDeplacementMax * 1.1);
        }

        /// <summary>
        /// Rapporte sa distance à la base.
        /// </summary>
        public void DesactiverCompetenceSpeciale()
        {
            NbCasesDeplacementMax = _deplacementDeBase;
        }
    }
}
