using BattleKingdom.Models;
using static BattleKingdom.Models.Personnage;

namespace BattleKingdom.Classes
{
    public static class GrilleJeu
    {
        /// <summary>
        /// Classe qui permet de créer une grilles avec des coordonnées en X et en Y.
        /// </summary>
        public class CoordonneesGrille
        {
            public int Y { get; set; }
            public int X { get; set; }

            public CoordonneesGrille(int pX, int pY)
            {
                Y = pY;
                X = pX;
            }

            public override bool Equals(object pObj)
            {
                if (pObj == null)
                    return false;
                if (!(pObj is CoordonneesGrille))
                    return false;
                return (this.Y == ((CoordonneesGrille)pObj).Y) && (this.X == ((CoordonneesGrille)pObj).X);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        /// <summary>
        /// Génère une position au hasard pour les personnages. Dans le cas des héros, ils seront positionnés dans les 3 rangées du bas de la grille, mais pour les ennemis, dans les 3 rangées du haut.
        /// </summary>
        /// <param name="pListePersonnages">Liste de tous les personnages du jeu</param>
        /// <param name="pTypePersonnage">Enum Héros, Allie ou Ennemi</param>
        /// <returns>Coordonnées au hasard du personnage à placer</returns>
        public static CoordonneesGrille GenererPositionHasardPersonnage(List<Personnage> pListePersonnages, TypePersonnage pTypePersonnage)
        {
            int X;
            int Y;

            CoordonneesGrille coordonnees;

            do
            {
                X = new Random().Next(MoteurJeu.LARGEUR_GRILLE);

                switch (pTypePersonnage)
                {
                    case TypePersonnage.Heros:
                        Y = MoteurJeu.LARGEUR_GRILLE - 1 - new Random().Next(3);
                        break;
                    case TypePersonnage.Ennemi:
                        Y = new Random().Next(3);
                        break;
                    case TypePersonnage.Allie:
                        Y = MoteurJeu.LARGEUR_GRILLE - 1;
                        break;
                    default:
                        Y = MoteurJeu.LARGEUR_GRILLE - 1;
                        break;
                }

                coordonnees = new GrilleJeu.CoordonneesGrille(X, Y);
            } while (EstCollisionDetectee(pListePersonnages, coordonnees));

            return coordonnees;
        }

        /// <summary>
        /// Détermine si les nouvelles coordonnées générées au hasard sont en conflit avec celle d'un autre personnage.
        /// </summary>
        /// <param name="pListePersonnages">Liste de tous les personnages.</param>
        /// <param name="pCoordonnees">Coordonnées au hasard nouvellement générées</param>
        /// <returns>True, s'il y a collision, false sinon.</returns>
        public static bool EstCollisionDetectee(List<Personnage> pListePersonnages, CoordonneesGrille pCoordonnees)
        {
            foreach (Personnage perso in pListePersonnages)
            {
                if (perso.PositionX.Equals(pCoordonnees.X) && perso.PositionY.Equals(pCoordonnees.Y))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Calcule le nombre de cases entre 2 entités.
        /// </summary>
        /// <param name="pSource">Coordonnées de l'entité de départ</param>
        /// <param name="pDestination">Coordonnées de l'entité de comparaison</param>
        /// <returns>Nombre de cases de distance.</returns>
        public static int CalculerDistance(CoordonneesGrille pSource, CoordonneesGrille pDestination)
        {
            return Math.Abs(pSource.X - pDestination.X) + Math.Abs(pSource.Y - pDestination.Y);
        }
    }
}