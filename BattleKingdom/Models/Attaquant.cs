
namespace BattleKingdom.Models
{
    public class Attaquant : Personnage
    {
        private Arme _arme;

        public Arme Arme { get; set; }

        /// <summary>
        /// Classe de base d'un attaquant
        /// </summary>
        /// <param name="nom">Son nom</param>
        /// <param name="positionX">Sa posiition X</param>
        /// <param name="positionY">Sa position Y</param>
        /// <param name="nbCasesDeplacementMax">Son nombre de cases de déplacement max</param>
        /// <param name="nbPointsVie">Son nombre de points de vie</param>
        /// <param name="arme">Son arme</param>
        protected Attaquant(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {
            Arme = arme;
        }

        /// <summary>
        /// Permet à un attaquant d'attaquer
        /// </summary>
        /// <param name="ennemiCourant">L'ennemi a attaquer</param>
        public void Attaquer(Personnage ennemiCourant)
        {
            ennemiCourant.NbPointsVie -= Arme.NbPointsDegat;
            if (ennemiCourant.NbPointsVie < 0)
            {
                ennemiCourant.NbPointsVie = 0;
            }           
        }
    }
}
