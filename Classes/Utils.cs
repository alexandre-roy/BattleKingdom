using System.ComponentModel;
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
            if (string.IsNullOrWhiteSpace(pInitiales))
            {
                return ValidationInitiales.ErreurVides;
            }
            else if (pInitiales.Length != 2 || pInitiales != pInitiales.ToUpper())
            {
                return ValidationInitiales.ErreurFormat;
            }
            else return ValidationInitiales.Conformes;

        }

        /// <summary>
        /// Retourne une chaîne de caractères pour bâtir l'infobulle d'une personnage afin de pouvoir
        /// connaître son nom, son nombre de cases de déplacement, le nombre de points de dégât de son arme,
        /// son nombre de points de vie, et la distance d'attaque de son arme (si c'est un attaquant).
        /// </summary>
        /// <param name="pListePersonnages">La liste des personnages du jeu</param>
        /// <param name="pIndexPersonnage">La position d'index du personnage actif dans la liste</param>
        /// <returns>Retourne la chaîne de cartactères à afficher dans l'infobulle</returns>
        public static string FormattageInfoBulle(List<Personnage> pListePersonnages, int pIndexPersonnage)
        {
            Personnage personnage = pListePersonnages[pIndexPersonnage];
            
            string description = $"{personnage.Nom}\n\nDéplacement: {personnage.NbCasesDeplacementMax} cases\nPoints de vie: {personnage.NbPointsVie}\n";

            if (personnage is Attaquant a)
            {
                description += $"Points de dégat: {a.Arme.NbPointsDegat}\nDistance d'attaque: {a.Arme.NbDistanceMax}";
            }

            return description;
        }
    }
}
