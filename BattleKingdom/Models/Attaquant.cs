
namespace BattleKingdom.Models
{
    public class Attaquant : Personnage
    {
        private Arme _arme;

        public Arme Arme { get; set; }

        public Attaquant(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {
            Arme = arme;
        }

        internal void Attaquer(Personnage ennemiCourant)
        {
            ennemiCourant.NbPointsVie -= Arme.NbPointsDegat;
        }
    }
}
