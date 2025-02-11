namespace BattleKingdom.Models
{
    internal class Arme
    {
		private string _nom;
		private int _nbDistanceMax;
		private int _nbPointsDegat;
        private int _nbCasesMaxDistance;


        public Arme()
        {
        }

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
        public int NbCasesMaxDistance { get; set; }

        public Arme(string nom, int nbDistanceMax, int nbPointsDegat)
        {
            Nom = nom;
            NbDistanceMax = nbDistanceMax;
            NbPointsDegat = nbPointsDegat;
        }
    }
}
