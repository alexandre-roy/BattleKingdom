using BattleKingdom.Classes;
using BattleKingdom.Models;

namespace BattleKingdomTests
{
    public class PersonnageTests
    {
        [Fact]
        public void Nom_Personnage_Ne_peut_Pas_Etre_Nul_ou_Vide()
        {
            Arme arme = new Arme("test", 0, 0);

            Assert.Throws<ArgumentException>(() => new Mario(null, 0, 0, 0, 0, arme));
            Assert.Throws<ArgumentException>(() => new Luigi("", 0, 0, 0, 0, arme));
        }

        [Fact]
        public void Position_X_Ne_Doit_Pas_Etre_A_Lexterieur_Du_Jeu()
        {
            Arme arme = new Arme("test", 0, 0);

            Assert.Throws<ExceptionPersonnage>(() => new Mario("test", -1, 0, 0, 0, arme));
            Assert.Throws<ExceptionPersonnage>(() => new Mario("test", MoteurJeu.LARGEUR_GRILLE + 1, 0, 5, 100, arme));
        }
        

        [Fact]
        public void Position_Y_Ne_Doit_Pas_Etre_A_Lexterieur_Du_Jeu()
        {
            Arme arme = new Arme("test", 0, 0);

            Assert.Throws<ExceptionPersonnage>(() => new Mario("test", 0, -1, 0, 0, arme));
            Assert.Throws<ExceptionPersonnage>(() => new Mario("test", 0, MoteurJeu.LARGEUR_GRILLE + 1, 0, 0, arme));
        }

        [Fact]
        public void Nombre_De_Cases_De_Deplacement_Ne_Devrait_Pas_Etre_Superieur_A_Taille_De_La_Grille()
        {
            Arme arme = new Arme("test", 0, 0);

            Assert.Throws<ExceptionPersonnage>(() => new Mario("test", 0, 0, MoteurJeu.LARGEUR_GRILLE + 1, 0, arme));
        }

        [Fact]
        public void Nombre_De_Points_Vie_Ne_Doit_Pas_Etre_Negatif()
        {
            Arme arme = new Arme("test", 0, 0);

            Mario mario = new Mario("test", 0, 0, 0, -1, arme);

            Assert.Equal(mario.NbPointsVie, 0);
        }
    }
}