﻿using System.Diagnostics;
using BattleKingdom.Classes;

namespace BattleKingdom.Models
{
    public abstract class Personnage
    {
        public enum TypePersonnage
        {
            Heros,
            Allie,
            Ennemi
        }

        private string _nom;
        private int _positionX;
        private int _positionY;
        private int _nbCasesDeplacementMax;
        private int _nbPointsVie;

        public string Nom
        {
            get { return _nom; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(Nom), "Le nom ne doit pas être nul ou des espaces vides.");
                }
                _nom = value; 
            }
        }

        public int PositionX
        {
            get { return _positionX; }
            set {
                try
                {
                    if (value < 0 || value > MoteurJeu.LARGEUR_GRILLE)
                    {
                        throw new ExceptionPersonnage((value), "La position x ne peut pas être à l'extérieur de la grille.");
                    }
                    _positionX = value;
                }
                catch (ExceptionPersonnage)
                {
                    Trace.WriteLine("La position x ne peut pas être à l'extérieur de la grille.");
                }
                
            }
        }

        public int PositionY
        {
            get { return _positionY; }
            set {
                try
                {
                    if (value < 0 || value > MoteurJeu.LARGEUR_GRILLE)
                    {
                        throw new ExceptionPersonnage((value), "La position y ne peut pas être à l'extérieur de la grille.");
                    }
                    _positionY = value;
                }
                catch (ExceptionPersonnage)
                {
                    Trace.WriteLine("La position y ne peut pas être à l'extérieur de la grille.");
                }
            }
        }

        public int NbCasesDeplacementMax
        {
            get { return _nbCasesDeplacementMax; }
            set {
                if (value > MoteurJeu.LARGEUR_GRILLE)
                {
                    throw new ExceptionPersonnage((value), "Le nombre de cases de déplacement ne doit pas être supérieur à la taile de la grille.");
                }
                _nbCasesDeplacementMax = value; 
            }
        }

        public int NbPointsVie
        {
            get { return _nbPointsVie; }
            set {
                if (value < 0)
                {
                    value = 0;
                }
                _nbPointsVie = value; }
        }

        protected Personnage(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie)
        {
            Nom = nom;
            PositionX = positionX;
            PositionY = positionY;
            NbCasesDeplacementMax = nbCasesDeplacementMax;
            NbPointsVie = nbPointsVie;
        }

        public void SeDeplacer(int nouvellePositionX, int nouvellePositionY)
        {
            PositionX = nouvellePositionX;
            PositionY = nouvellePositionY;
        }
    }

    public class ExceptionPersonnage : Exception
    {
        public ExceptionPersonnage(int valeur, string message) : base($"La valeur {valeur} est invalide.")
        {

        }
    }
}
