namespace BattleKingdom.Models
{
    interface ICompetenceSpeciale
    {
        /// <summary>
        /// Active une compétence spéciale
        /// </summary>
        abstract void ActiverCompetenceSpeciale();

        /// <summary>
        /// Désactive une compétence spéciale
        /// </summary>
        abstract void DesactiverCompetenceSpeciale();
    }
}
