using BattleKingdom.Classes;
using BattleKingdom.Models;

namespace BattleKingdomTests
{
    public class PersonnageTests
    {
        [Fact]
        public void Nom_Personnage_Ne_peut_Pas_Etre_Nul_ou_Vide()
        {
            // ARRANGE
            Arme arme = new Arme("test", 0, 0);
            string nomNull = null;
            string nomVide = "";

            // ACT & ASSERT
            Assert.Throws<ArgumentException>(() => new Mario(nomNull, 0, 0, 0, 0, arme));
            Assert.Throws<ArgumentException>(() => new Luigi(nomVide, 0, 0, 0, 0, arme));
        }

        [Fact]
        public void Position_X_Ne_Doit_Pas_Etre_A_Lexterieur_Du_Jeu()
        {
            // ARRANGE
            Arme arme = new Arme("test", 0, 0);
            int position = 0;
            int positionNegative = -1;
            int positionHorsGrille = MoteurJeu.LARGEUR_GRILLE + 1;

            // ACT
            Mario mario1 = new Mario("test", 0, 0, position, 0, arme);
            Mario mario2 = new Mario("test", 0, 0, position, 0, arme);

            mario1.PositionX = positionNegative;
            mario2.PositionX = positionHorsGrille;

            // ASSERT
            Assert.Equal(position, mario1.PositionX);
            Assert.Equal(position, mario2.PositionX);
        }
        

        [Fact]
        public void Position_Y_Ne_Doit_Pas_Etre_A_Lexterieur_Du_Jeu()
        {
            // ARRANGE
            Arme arme = new Arme("test", 0, 0);
            int position = 0;
            int positionNegative = -1;
            int positionHorsGrille = MoteurJeu.LARGEUR_GRILLE + 1;

            // ACT
            Mario mario1 = new Mario("test", 0, 0, 0, position, arme);
            Mario mario2 = new Mario("test", 0, 0, 0, position, arme);

            mario1.PositionY = positionNegative;
            mario2.PositionY = positionHorsGrille;

            // ASSERT
            Assert.Equal(position, mario1.PositionY);
            Assert.Equal(position, mario2.PositionY);
        }

        [Fact]
        public void Nombre_De_Cases_De_Deplacement_Ne_Devrait_Pas_Etre_Superieur_A_Taille_De_La_Grille()
        {
            // ARRANGE
            Arme arme = new Arme("test", 0, 0);
            int deplacementHorsGrille = MoteurJeu.LARGEUR_GRILLE + 1;

            // ACT & ASSERT
            Assert.Throws<ExceptionPersonnage>(() => new Mario("test", 0, 0, deplacementHorsGrille, 0, arme));
        }

        [Fact]
        public void Nombre_De_Points_Vie_Ne_Doit_Pas_Etre_Negatif()
        {
            // ARRANGE
            Arme arme = new Arme("test", 100, 100);
            int vieNegatif = -1;

            // ACT
            Luigi luigi = new Luigi("test", 0, 0, 0, -1, arme);
            Mario mario = new Mario("test", 0, 0, 1, 1, arme);

            luigi.Attaquer(mario);

            // ASSERT
            Assert.Equal(luigi.NbPointsVie, 0);
            Assert.Equal(mario.NbPointsVie, 0);           
        }
    }
}