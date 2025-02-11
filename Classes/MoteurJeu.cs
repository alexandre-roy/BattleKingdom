using BattleKingdom.Models;
using static BattleKingdom.Classes.Utils;
using static BattleKingdom.Models.Personnage;

namespace BattleKingdom.Classes
{
    public class MoteurJeu
    {
        public enum TypeAction
        {
            Aucune,
            Attaque,
            Deplacement,
            Competence
        }

        public const int NB_HEROS = 3;
        public const int NB_ENNEMIS = 3;
        public const int LARGEUR_GRILLE = 20;

        public List<Personnage> ListePersonnages { get; set; }
        public Personnage HerosCourant { get; set; }
        public Personnage EnnemiCourant { get; set; }
        public TypeAction ActionCourante { get; set; }

        public int NbActionRestante { get; set; }

        /// <summary>
        /// Constructeur de la classe MoteurJeu. Il permet d'instancer dynamiquement les classes correspondantes aux 3 héros sélectionnés.
        /// </summary>
        /// <param name="pNomHerosSelectionnes">Liste des noms des personnages choisis</param>

        public MoteurJeu(List<string> pNomHerosSelectionnes)
        {
            ListePersonnages = new List<Personnage>();

            GrilleJeu.CoordonneesGrille positionPersonnage;

            Arme arme01 = new Arme("Gun01", 10, 10);
            Arme arme02 = new Arme("Gun02", 10, 10);
            Arme arme03 = new Arme("Gun03", 10, 10);

            positionPersonnage = GrilleJeu.GenererPositionHasardPersonnage(ListePersonnages, TypePersonnage.Heros);
            ListePersonnages.Add(Activator.CreateInstance(DefinirClasseHeros(pNomHerosSelectionnes[0]), pNomHerosSelectionnes[0], positionPersonnage.X, positionPersonnage.Y, 10, 15, arme01) as Personnage);

            positionPersonnage = GrilleJeu.GenererPositionHasardPersonnage(ListePersonnages, TypePersonnage.Heros);
            ListePersonnages.Add(Activator.CreateInstance(DefinirClasseHeros(pNomHerosSelectionnes[1]), pNomHerosSelectionnes[1], positionPersonnage.X, positionPersonnage.Y, 10, 15, arme02) as Personnage);

            positionPersonnage = GrilleJeu.GenererPositionHasardPersonnage(ListePersonnages, TypePersonnage.Heros);
            ListePersonnages.Add(Activator.CreateInstance(DefinirClasseHeros(pNomHerosSelectionnes[2]), pNomHerosSelectionnes[2], positionPersonnage.X, positionPersonnage.Y, 10, 15, arme03) as Personnage);

            InitialiserEnnemis(ListePersonnages);

            ActionCourante = TypeAction.Aucune;
            NbActionRestante = 3;
        }

        /// <summary>
        /// Retourne le type (classe) dont le nom correspond au héros à instancier.
        /// </summary>
        /// <param name="pHeros">Nom du héros correspondant à la classe à instancier</param>
        /// <returns></returns>
        private Type DefinirClasseHeros(string pHeros)
        {
            List<string> familleMario = new List<string> { "Mario", "Luigi", "Yoshi", "Peach" };

            if (familleMario.Contains(pHeros))
                return Type.GetType($"BattleKingdom.Models.{pHeros}, BattleKingdom");
            else
                return Type.GetType("BattleKingdom.Models.FamilleLapin, BattleKingdom"); 
        }

        /// <summary>
        /// Évalue si l'attaque est possible selon le nombre de cases atteignable par l'arme de l'attaquant
        /// </summary>
        /// <param name="pAttaquant">Personnage attaquant</param>
        /// <param name="pAttaque">Personnage attaqué</param>
        /// <returns>True si l'attaque est possible, false dans le cas contraire.</returns>
        public bool EstAttaquePossible(Personnage pAttaquant, Personnage pAttaque)
        {
            if (pAttaquant == null || pAttaque == null)
                return false;

            int distance = GrilleJeu.CalculerDistance(new GrilleJeu.CoordonneesGrille(pAttaquant.PositionX, pAttaquant.PositionY), new GrilleJeu.CoordonneesGrille(pAttaque.PositionX, pAttaque.PositionY));

            if (distance <= (pAttaquant as Attaquant).Arme.NbCasesMaxDistance)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Évalue si le déplacement est possible selon la capacité de déplacment (en nombre cases MAX) du héros courant.
        /// </summary>
        /// <param name="pPositionX">Destination en X</param>
        /// <param name="pPositionY">DEstination en Y</param>
        /// <returns>True si possible, false sinon</returns>
        public bool EstDeplacementPossible(int pPositionX, int pPositionY)
        {
            if (HerosCourant == null)
                return false;

            int distance = GrilleJeu.CalculerDistance(new GrilleJeu.CoordonneesGrille(HerosCourant.PositionX, HerosCourant.PositionY), new GrilleJeu.CoordonneesGrille(pPositionX, pPositionY));

            if (distance <= HerosCourant.NbCasesDeplacementMax)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Vérifie si le personnage a des compétences spéciales et active si c'est le cas.
        /// </summary>
        /// <returns>True si possible, false sinon</returns>
        public bool EstCompetencePossible()
        {
            if (HerosCourant == null)
                return false;

            (HerosCourant as ICompetenceSpeciale).ActiverCompetenceSpeciale(); 

            return true;
        }

        /// <summary>
        /// Marque l'action comme terminée, réduit le nombre d'actions totales et s'il ne reste plus d'actions possibles, désactive les compétences spéciales pour revenir aux compétences normales des personnages.
        /// </summary>
        public void ActionCompletee()
        {
            NbActionRestante--;

            // Tour terminé
            if (NbActionRestante == 0)
            {
                foreach (Personnage personnage in ListePersonnages.FindAll(p => p is ICompetenceSpeciale && p.NbPointsVie > 0))
                {
                    (personnage as ICompetenceSpeciale).DesactiverCompetenceSpeciale();
                }
            }
        }

        /// <summary>
        /// Pour un ennemi en particulier, cherche le héros le plus proche.
        /// </summary>
        /// <param name="pEnnemi">Personnage ennemi</param>
        /// <returns>Personnage le plus proche</returns>
        public Personnage TrouverHerosPlusProche(Personnage pEnnemi)
        {
            Personnage herosPlusProche = null;
            int distancePlusProche = LARGEUR_GRILLE;

            foreach (Personnage heros in ListePersonnages.FindAll(p => p is (Heros) && p.NbPointsVie > 0))
            {
                int distance = GrilleJeu.CalculerDistance(new GrilleJeu.CoordonneesGrille(pEnnemi.PositionX, pEnnemi.PositionY), new GrilleJeu.CoordonneesGrille(heros.PositionX, heros.PositionY));

                if (distance < distancePlusProche || herosPlusProche is null)
                {
                    herosPlusProche = heros;
                    distancePlusProche = distance;
                }
            }

            return herosPlusProche;
        }

        /// <summary>
        /// Déplace un ennemi vers le héros le plus proche
        /// </summary>
        /// <param name="pEnnemi">Personnage ennemi</param>
        /// <param name="pHerosPlusProche">Personnage héro le plus proche</param>
        public void DeplacerVersHerosPlusProche(Personnage pEnnemi, Personnage pHerosPlusProche)
        {
            int distance = GrilleJeu.CalculerDistance(new GrilleJeu.CoordonneesGrille(pEnnemi.PositionX, pEnnemi.PositionY), new GrilleJeu.CoordonneesGrille(pHerosPlusProche.PositionX, pHerosPlusProche.PositionY));
            int distanceRestante;

            int nouvellePositionX = pEnnemi.PositionX;
            int nouvellePositionY = pEnnemi.PositionY;

            // Si la distance entre le héros et l'ennemi est moins grande que ce que l'ennemi peut faire au maximum
            if (distance >= pEnnemi.NbCasesDeplacementMax)
                distanceRestante = pEnnemi.NbCasesDeplacementMax;
            else
                distanceRestante = distance - 1;

            while (distanceRestante > 0)
            {
                if (distanceRestante > 0 && nouvellePositionX < pHerosPlusProche.PositionX)
                {
                    nouvellePositionX++;
                    distanceRestante--;
                }
                else if (distanceRestante > 0 && nouvellePositionX > pHerosPlusProche.PositionX)
                {
                    nouvellePositionX--;
                    distanceRestante--;
                }

                if (distanceRestante > 0 && nouvellePositionY < pHerosPlusProche.PositionY)
                {
                    nouvellePositionY++;
                    distanceRestante--;
                }
                else if (distanceRestante > 0 && nouvellePositionY > pHerosPlusProche.PositionY)
                {
                    nouvellePositionY--;
                    distanceRestante--;
                }

                if (!GrilleJeu.EstCollisionDetectee(ListePersonnages, new GrilleJeu.CoordonneesGrille(nouvellePositionX, nouvellePositionY)))
                    pEnnemi.SeDeplacer(nouvellePositionX, nouvellePositionY);
                else
                    break;
            }
        }

        /// <summary>
        /// Permet d'instancier les 3 ennemis du jeu (Ziggy, Smasher et Kong) et les rajouter
        /// à la liste des personnage en cours.
        /// </summary>
        /// <param name="pListePersonnages">Liste des personnages</param>
        public static void InitialiserEnnemis(List<Personnage> pListePersonnages)
        {
            GrilleJeu.CoordonneesGrille positionPersonnage;

            positionPersonnage = GrilleJeu.GenererPositionHasardPersonnage(pListePersonnages, TypePersonnage.Ennemi);
            pListePersonnages.Add(new Ennemis("Ziggy", positionPersonnage.X, positionPersonnage.Y, 5, 100));

            positionPersonnage = GrilleJeu.GenererPositionHasardPersonnage(pListePersonnages, TypePersonnage.Ennemi);
            pListePersonnages.Add(new Ennemis("Smasher", positionPersonnage.X, positionPersonnage.Y, 7, 50));

            positionPersonnage = GrilleJeu.GenererPositionHasardPersonnage(pListePersonnages, TypePersonnage.Ennemi);
            pListePersonnages.Add(new Ennemis("Kong", positionPersonnage.X, positionPersonnage.Y, 3, 150));
        }

        /// <summary>
        /// Évalue la santé des joueurs pour déterminer éventuellement quelle équipe gagne
        /// </summary>
        /// <param name="pListePersonnages">Liste des personnages en cours sur le jeu</param>
        /// <returns>L'état du jeu : y-a-t'il un gagnant et si oui, quelle équipe? (ennemis ou héros)</returns>
        public static SantePersonnages EvaluerSantePersonnages(List<Personnage> pListePersonnages)
        {
            bool herosEnVie = pListePersonnages.Any(p => p is Heros && p.NbPointsVie > 0);
            bool ennemisEnVie = pListePersonnages.Any(p => p is Ennemis && p.NbPointsVie > 0);

            if (herosEnVie)
            {
                return SantePersonnages.SuccesHeros;
            }
            else if (ennemisEnVie)
            {
                return SantePersonnages.SuccesEnnemi;
            }
            else
            {
                return SantePersonnages.AucunGagnant;
            }
        }
    }
}