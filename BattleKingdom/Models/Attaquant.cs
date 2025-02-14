
namespace BattleKingdom.Models
{
    public class Attaquant : Personnage
    {
        private Arme _arme;

        public Arme Arme { get; set; }

        protected Attaquant(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie, Arme arme) : base(nom, positionX, positionY, nbCasesDeplacementMax, nbPointsVie)
        {
            Arme = arme;
        }

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
