namespace BattleKingdom.Models
{
    abstract class Personnage
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
    }
}
