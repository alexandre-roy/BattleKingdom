namespace BattleKingdom.Models
{
    public class Arme
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
        public int NbCasesMaxDistance { get; set; }


        /// <summary>
		/// Instancie une arme
		/// </summary>
		/// <param name="nom">Son nom</param>
		/// <param name="nbDistanceMax">Le nombre de cases d'attaque max</param>
		/// <param name="nbPointsDegat">Le nombre de points dégats</param>
        public Arme(string nom, int nbDistanceMax, int nbPointsDegat)
        {
            Nom = nom;
            NbDistanceMax = nbDistanceMax;
            NbPointsDegat = nbPointsDegat;
        }
    }
}
