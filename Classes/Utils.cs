using BattleKingdom.Models;

namespace BattleKingdom.Classes
{
    public static class Utils
    {
        public enum ValidationInitiales
        {
            Conformes,
            ErreurVides,
            ErreurFormat
        }
        public enum SantePersonnages
        {
            AucunGagnant,
            SuccesHeros,
            SuccesEnnemi
        }

        /// <summary>
        /// Valide les initiales du joueurs, il faut que ce soit 2 lettres majuscules
        /// </summary>
        /// <param name="pInitiales">Initiales saisies</param>
        /// <returns>Enum d'état de validation</returns>
        public static ValidationInitiales ValiderInitiales(string pInitiales)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retourne une chaîne de caractères pour bâtir l'infobulle d'une personnage afin de pouvoir
        /// connaître son nom, son nombre de cases de déplacement, le nombre de points de dégât de son arme
        /// et la distance d'attaque de son arme (si c'est un attaquant).
        /// </summary>
        /// <param name="pListePersonnages">La liste des personnages du jeu</param>
        /// <param name="pIndexPersonnage">La position d'index du personnage actif dans la liste</param>
        /// <returns>Retourne la chaîne de cartactères à afficher dans l'infobulle</returns>
        public static string FormattageInfoBulle(List<Personnage> pListePersonnages, int pIndexPersonnage)
        {
            throw new NotImplementedException();

        }


    }
}
