
namespace BattleKingdom.Models
{
    internal class Attaquant : Personnage
    {
        private Arme _arme;

        public Arme Arme { get; set; }

        public Attaquant(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {
        }

        internal void Attaquer(Personnage ennemiCourant)
        {
            throw new NotImplementedException();
        }
    }
}
