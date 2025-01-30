namespace BattleKingdom.Models
{
    internal class Arme
    {
		private string _nom;
		private int _nbDistanceMax;
		private int _nbPointsDegat;

		public string Nom
		{
			get { return _nom; }
			set { _nom = value; }
		}

		public int NbDistanceMax
		{
			get { return _nbDistanceMax; }
			set { _nbDistanceMax = value; }
		}

		public int NbPointsDegat
		{
			get { return _nbPointsDegat; }
			set { _nbPointsDegat = value; }
		}
    }
}
