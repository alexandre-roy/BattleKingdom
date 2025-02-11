using BattleKingdom.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace BattleKingdom.Views
{

    public partial class SelectionHeros : Window
    {
        private string _initiales;
        private int _nbHerosSelectionnes = 0;
        private List<string> _nomHerosSelectionnes = new List<string>();

        /// <summary>
        /// Constructeur de la fenêtre qui reçoit les initiales de la précédente fenêtre
        /// </summary>
        /// <param name="pInitiales">Initiales du joueur</param>
        public SelectionHeros(string pInitiales)
        {
            InitializeComponent();

            Journalisation.Tracer("Ouverture de la fenêtre SelectionHeros");

            _initiales = pInitiales;

            // On peut mettre cette ligne en commentaire... ;)
            trameSonore.Play();
        }

        /// <summary>
        /// Gère la sélection des héros, permettant de sélectionner jusqu'à 3 personnages.
        /// </summary>
        /// <param name="pSender">Le toggle bouton qui a été cliqué</param>
        /// <param name="pEvent">Objet Event du gestionnaire d'événements</param>
        private void GererSelection(object pSender, RoutedEventArgs pEvent)
        {
            ToggleButton bouton = pSender as ToggleButton;
            // Tracer des informations sur l'événement
            Journalisation.Tracer($"Événement déclenché par : {pEvent.Source}, Type d'événement : {pEvent.RoutedEvent.Name}");

            if ((bool)bouton.IsChecked)
            {
                if (_nbHerosSelectionnes < MoteurJeu.NB_HEROS)
                {
                    _nomHerosSelectionnes.Add(bouton.Name);
                    txtNbHerosSelectionne.Text = ++_nbHerosSelectionnes + "/" + MoteurJeu.NB_HEROS;

                    Journalisation.Tracer($"Ajout du héros {bouton.Name}");
                }
            }

            if (!(bool)bouton.IsChecked)
            {
                _nomHerosSelectionnes.Remove(bouton.Name);
                txtNbHerosSelectionne.Text = --_nbHerosSelectionnes + "/" + MoteurJeu.NB_HEROS;

                Journalisation.Tracer($"Retrait du héros {bouton.Name}");
            }

            if (_nbHerosSelectionnes == MoteurJeu.NB_HEROS)
            {
                foreach (ToggleButton enfant in grille.Children)
                {
                    if (enfant.IsChecked == false)
                        enfant.IsEnabled = false;
                }
            }
            else
            {
                foreach (ToggleButton enfant in grille.Children)
                    enfant.IsEnabled = true;
            }
        }


        /// <summary>
        /// Sur le clic du bouton Démarrer, cette méthode appelle la fenêtre Jeu et fermet celle en cours
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void DemarrerJeu(object pSender, RoutedEventArgs pEvent)
        {
            if (_nbHerosSelectionnes == 3)
            {
                Jeu jeu = new Jeu(_initiales, _nomHerosSelectionnes);

                jeu.Show();
                Close();

                Journalisation.Tracer($"Sélection finale des héros: {string.Join(", ", _nomHerosSelectionnes)}");
                Journalisation.Tracer("Fermeture de la fenêtre SelectionHeros");
            }
        }
    }
}