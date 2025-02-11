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
            set { _nom = value; }
        }

        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        public int NbCasesDeplacementMax
        {
            get { return _nbCasesDeplacementMax; }
            set { _nbCasesDeplacementMax = value; }
        }

        public int NbPointsVie
        {
            get { return _nbPointsVie; }
            set { _nbPointsVie = value; }
        }

        protected Personnage(string nom, int positionX, int positionY, int nbCasesDeplacementMax, int nbPointsVie)
        {
            Nom = nom;
            PositionX = positionX;
            PositionY = positionY;
            NbCasesDeplacementMax = nbCasesDeplacementMax;
            NbPointsVie = nbPointsVie;
        }

        internal void SeDeplacer(int nouvellePositionX, int nouvellePositionY)
        {
            throw new NotImplementedException();
        }
    }
}
