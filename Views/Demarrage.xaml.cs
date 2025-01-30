using BattleKingdom.Classes;
using System.Windows;
using System.Windows.Controls;

namespace BattleKingdom.Views
{
    public partial class Demarrage : Window
    {
        public Demarrage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Méthode exécutée via le bouton Confirmer. Elle valide le format des initiales avant de passer à la fenêtre SelectionHeros.
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void Confirmer(object pSender, RoutedEventArgs pEvent)
        {
            string initiales = txtInitiales.Text.Trim();

            switch (Utils.ValiderInitiales(initiales))
            {
                case Utils.ValidationInitiales.Conformes:
                    SelectionHeros selectionHeros = new SelectionHeros(initiales);

                    selectionHeros.Show();
                    Close();

                    Journalisation.Tracer($"Fermeture de la fenêtre Init avec initiales sélectionnées: {initiales}");
                    break;
                case Utils.ValidationInitiales.ErreurVides:
                    ErreurValidationsInitiales(txtMessage, txtInitiales, "Les initiales doivent être renseignées");

                    break;
                case Utils.ValidationInitiales.ErreurFormat:
                    ErreurValidationsInitiales(txtMessage, txtInitiales, "Les initiales doivent être 2 caractères majuscules");

                    break;
            }
        }

        /// <summary>
        /// Affiche le message d'erreurs dans le UI
        /// </summary>
        /// <param name="pControleAffichageErreur">Contrôle où on affiche l'erreur</param>
        /// <param name="pControleEnErreur">Contrôle où on saisi les initiales</param>
        /// <param name="pMessageErreur">Message d'erreur</param>
        private void ErreurValidationsInitiales(TextBlock pControleAffichageErreur, TextBox pControleEnErreur, string pMessageErreur)
        {
            Journalisation.Tracer(pMessageErreur);

            pControleAffichageErreur.Text = pMessageErreur;
            pControleEnErreur.ToolTip = pMessageErreur;
        }
    }
}