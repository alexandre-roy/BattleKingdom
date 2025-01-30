using BattleKingdom.Classes;
using System.Windows;

namespace BattleKingdom.Views
{
    public partial class Fin : Window
    {
        /// <summary>
        /// Constructeur de la fenêtre qui reçoit un booléen indiquant si ce sont les héros qui ont gagné la partie. 
        /// En fonction de ce booléen, une cinématique correspondant aux vainqueurs est lancée.
        /// </summary>
        /// <param name="pSuccesHeros">Booléen indiquant si ce sont les héros qui ont gagné la partie ou non.</param>
        /// <param name="pInitiales">Initiales du joueur.</param>
        public Fin(bool pSuccesHeros, string pInitiales)
        {
            InitializeComponent();

            if (pSuccesHeros)
            {
                mediaVideo.Source = new Uri("Resources/Videos/Victoire.mp4", UriKind.Relative);
                txtMessage.Text = $"Succès du héros {pInitiales}!";
                Journalisation.Tracer($"Succès du héros {pInitiales}!");
            }
            else
            {
                mediaVideo.Source = new Uri("Resources/Videos/Defaite.mp4", UriKind.Relative);
                txtMessage.Text = $"Défaite du héros {pInitiales}!";
                Journalisation.Tracer($"Défaite du héros {pInitiales}!");
            }
        }
    }
}