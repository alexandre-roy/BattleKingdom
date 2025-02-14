using BattleKingdom.Classes;
using BattleKingdom.Models;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using static System.Net.Mime.MediaTypeNames;

namespace BattleKingdom.Views
{
    public partial class Jeu : Window
    {
        private string _initiales;
        private MoteurJeu _moteurJeu;


        /// <summary>
        /// Constructeur de la fenêtre Jeu qui reçoit 2 valeurs de la précédente fenêtre en paramètres. Elle instancie la classe MoteurJeu et crée le visuel
        /// </summary>
        /// <param name="pInitiales">Initiales du joueur</param>
        /// <param name="pNomHerosSelectionnes">Liste des noms des personnages choisis</param>

        public Jeu(string pInitiales, List<string> pNomHerosSelectionnes)
        {
            InitializeComponent();

            Journalisation.Tracer("Ouverture de la fenêtre Jeu");

            _initiales = pInitiales;
            _moteurJeu = new MoteurJeu(pNomHerosSelectionnes);

            CreationGrilleTerrain();
            CreationPanneau();
            CreationPersonnages();

            DemarrerJeu();
        }

        /// <summary>
        /// Créer la grille du terrain à l'aide de bouton transparents et ajoute les événements MouseEnter, MouseLeave et Click
        /// </summary>
        private void CreationGrilleTerrain()
        {
            Journalisation.Tracer("Création de la grille du terrain");

            for (int i = 0; i < MoteurJeu.LARGEUR_GRILLE; i++)
            {
                grilleTerrain.RowDefinitions.Add(new RowDefinition());
                grilleTerrain.ColumnDefinitions.Add(new ColumnDefinition());

                for (int j = 0; j < MoteurJeu.LARGEUR_GRILLE; j++)
                {
                    Button boutonCase = new Button();

                    boutonCase.MouseEnter += new MouseEventHandler(GererSurCase);
                    boutonCase.MouseLeave += new MouseEventHandler(GererHorsCase);
                    boutonCase.Click += new RoutedEventHandler(GererSelectionCase);

                    Grid.SetRow(boutonCase, i);
                    Grid.SetColumn(boutonCase, j);

                    grilleTerrain.Children.Add(boutonCase);
                }
            }
        }

        /// <summary>
        /// Dessine le panneau de contrôle des personnages (image des personnags, boutons déplacement, attaque et pour certains, activer la compétence spéciale
        /// </summary>
        private void CreationPanneau()
        {
            Journalisation.Tracer("Création de la grille de contrôles");

            for (int i = 0; i < MoteurJeu.NB_HEROS; i++)
            {
                Grid ligneControle = new Grid();
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());
                ligneControle.ColumnDefinitions.Add(new ColumnDefinition());

                Grid.SetRow(ligneControle, i);

                Image heros = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom + "xPersonnage",
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/" + _moteurJeu.ListePersonnages[i].Nom + ".png", UriKind.Relative)),
                    ToolTip = _moteurJeu.ListePersonnages[i].Nom
                };
                RenderOptions.SetBitmapScalingMode(heros, BitmapScalingMode.Fant);
                RegisterName(heros.Name, heros);
                Grid.SetColumn(heros, 0);
                ligneControle.Children.Add(heros);

                Image deplacement = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Deplacement.ToString(),
                    ToolTip = MoteurJeu.TypeAction.Deplacement.ToString(),
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/Deplacement.png", UriKind.Relative))
                };
                RenderOptions.SetBitmapScalingMode(deplacement, BitmapScalingMode.Fant);
                RegisterName(deplacement.Name, deplacement);
                deplacement.MouseDown += new MouseButtonEventHandler(GererSelectionAction);
                Grid.SetColumn(deplacement, 1);
                ligneControle.Children.Add(deplacement);

                Image attaque = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Attaque.ToString(),
                    ToolTip = MoteurJeu.TypeAction.Attaque.ToString(),
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/Attaque.png", UriKind.Relative))
                };
                RenderOptions.SetBitmapScalingMode(attaque, BitmapScalingMode.Fant);
                RegisterName(attaque.Name, attaque);
                attaque.MouseDown += new MouseButtonEventHandler(GererSelectionAction);
                Grid.SetColumn(attaque, 2);
                ligneControle.Children.Add(attaque);

                if (_moteurJeu.ListePersonnages[i] is ICompetenceSpeciale) 
                {
                    Image competence = new Image
                    {
                        Name = _moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Competence.ToString(),
                        ToolTip = MoteurJeu.TypeAction.Competence.ToString(),
                        Uid = i.ToString(),
                        Source = new BitmapImage(new Uri("/Resources/Images/Competence.png", UriKind.Relative))
                    };
                    RenderOptions.SetBitmapScalingMode(competence, BitmapScalingMode.Fant);
                    RegisterName(competence.Name, competence);
                    competence.MouseDown += new MouseButtonEventHandler(GererSelectionAction);
                    Grid.SetColumn(competence, 3);
                    ligneControle.Children.Add(competence);
                }

                grilleControles.Children.Add(ligneControle);
            }
        }

        /// <summary>
        /// Crée les personnages du jeu en les ajoutant à la grille de terrain. 
        /// Les personnages ennemis sont associés à un événement de clic de souris afin de pouvoir les attaquer.
        /// </summary>
        private void CreationPersonnages()
        {
            Journalisation.Tracer("Création des personnages");

            for (int i = 0; i < _moteurJeu.ListePersonnages.Count; i++)
            {
                Image personnage = new Image
                {
                    Name = _moteurJeu.ListePersonnages[i].Nom,
                    Uid = i.ToString(),
                    Source = new BitmapImage(new Uri("/Resources/Images/" + _moteurJeu.ListePersonnages[i].Nom + ".png", UriKind.Relative)),
                    ToolTip = Utils.FormattageInfoBulle(_moteurJeu.ListePersonnages, i)
                };

                RenderOptions.SetBitmapScalingMode(personnage, BitmapScalingMode.Fant);

                // Pour permettre la recherche du contrôle avec FindName
                RegisterName(personnage.Name, personnage);

                if (_moteurJeu.ListePersonnages[i] is Ennemis)
                    personnage.MouseDown += new MouseButtonEventHandler(SelectionEnnemi);

                Grid.SetColumn(personnage, _moteurJeu.ListePersonnages[i].PositionX);
                Grid.SetRow(personnage, _moteurJeu.ListePersonnages[i].PositionY);

                grilleTerrain.Children.Add(personnage);
            }
        }

        /// <summary>
        /// Méthode déclenchée par le choix d'une action du panneau de contrôle. Détermine laquelle des actions a été sélectionnée (dépalcement, attaque ou compétence spéciale)
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void GererSelectionAction(object pSender, RoutedEventArgs pEvent)
        {
            _moteurJeu.HerosCourant = _moteurJeu.ListePersonnages[int.Parse((pSender as Image).Uid)];
            _moteurJeu.ActionCourante = (MoteurJeu.TypeAction)Enum.Parse(typeof(MoteurJeu.TypeAction), (pSender as Image).Name.Substring((pSender as Image).Name.IndexOf("x") + 1));

            if (_moteurJeu.ActionCourante == MoteurJeu.TypeAction.Competence && _moteurJeu.EstCompetencePossible())
            {
                Journalisation.Tracer($"{_moteurJeu.HerosCourant.Nom} a utilisé sa compétence", txtTrace);
                ActionCompletee();
            }
            else
                Journalisation.Tracer($"{_initiales} sélectionne l'action {_moteurJeu.ActionCourante} du héros {_moteurJeu.HerosCourant.Nom}", txtTrace);
        }


        /// <summary>
        /// Sélectionne un ennemi et effectue une attaque si l'action courante est une attaque.
        /// Vérifie si l'attaque est possible, effectue l'attaque et évalue les morts.
        /// </summary>
        private void SelectionEnnemi(object pSender, RoutedEventArgs pEvent)
        {
            _moteurJeu.EnnemiCourant = _moteurJeu.ListePersonnages[int.Parse((pSender as Image).Uid)];

            if (_moteurJeu.ActionCourante == MoteurJeu.TypeAction.Attaque)
            {
                if (_moteurJeu.EstAttaquePossible(_moteurJeu.HerosCourant, _moteurJeu.EnnemiCourant))
                {
                    (_moteurJeu.HerosCourant as Attaquant).Attaquer(_moteurJeu.EnnemiCourant);

                    Journalisation.Tracer($"{_moteurJeu.HerosCourant.Nom} a attaqué l'ennemi {_moteurJeu.EnnemiCourant.Nom}", txtTrace);

                    EvaluerMorts(true);
                    ActionCompletee();
                }
                else
                {

                    Journalisation.Tracer($"{_moteurJeu.EnnemiCourant.Nom} est trop loin de {_moteurJeu.HerosCourant.Nom}, choisir un autre personnage ou action, ou encore passer son tour", txtTrace);

                }

            }
        }

        /// <summary>
        /// En survolant les cases de la grille, une couleur indique si le héros courant peut se déplacer (vert) ou non (rouge)
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void GererSurCase(object pSender, RoutedEventArgs pEvent)
        {
            if (_moteurJeu.HerosCourant != null && _moteurJeu.ActionCourante == MoteurJeu.TypeAction.Deplacement)
            {
                int positionX = int.Parse((pSender as Button).GetValue(Grid.ColumnProperty).ToString());
                int positionY = int.Parse((pSender as Button).GetValue(Grid.RowProperty).ToString());

                if (_moteurJeu.EstDeplacementPossible(positionX, positionY))
                    (pSender as Button).Background = Brushes.Green;
                else
                    (pSender as Button).Background = Brushes.Red;
            }
        }

        /// <summary>
        /// Réinitialiser la couleur de la case en la quittant.
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void GererHorsCase(object pSender, RoutedEventArgs pEvent)
        {
            (pSender as Button).Background = Brushes.White;
        }

        /// <summary>
        /// En cliquant sur une case, si l'action courant est un déplacement, alors on effectue cette action.
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void GererSelectionCase(object pSender, RoutedEventArgs pEvent)
        {
            int positionX = int.Parse((pSender as Button).GetValue(Grid.ColumnProperty).ToString());
            int positionY = int.Parse((pSender as Button).GetValue(Grid.RowProperty).ToString());

            if (_moteurJeu.ActionCourante == MoteurJeu.TypeAction.Deplacement && _moteurJeu.EstDeplacementPossible(positionX, positionY))
            {
                _moteurJeu.HerosCourant.SeDeplacer(positionX, positionY);
                Journalisation.Tracer($"{_moteurJeu.HerosCourant.Nom} s'est déplacé vers la case {positionX},{positionY}", txtTrace);
                ActionCompletee();
            }
        }

        /// <summary>
        /// On démare le jeu en commençant par les héros.
        /// </summary>
        private void DemarrerJeu()
        {
            Journalisation.Tracer("Démarrage du jeu", txtTrace);

            TourHeros();
        }


        /// <summary>
        /// Complète l'action en cours, désactive les contrôles d'action utilisés, rafraîchit les tooltips (infobulle sur les personnages), 
        /// retire les personnages morts, et passe au tour suivant (héros ou ennemi).
        /// </summary>
        private void ActionCompletee()
        {
            _moteurJeu.ActionCompletee();

            if (!EstPartieTerminee())
            {
                // Si on est rendu là, c'est qu'il n'y a toujours pas de gagnant ou de perdant
                for (int i = 0; i < _moteurJeu.ListePersonnages.Count; i++)
                {
                    // Désactivation des contrôles utilisés
                    if (_moteurJeu.HerosCourant != null && _moteurJeu.ListePersonnages[i].Nom == _moteurJeu.HerosCourant.Nom)
                    {
                        Image controleUtilise = FindName(_moteurJeu.HerosCourant.Nom + "x" + _moteurJeu.ActionCourante.ToString()) as Image;
                        controleUtilise.IsEnabled = false;
                        controleUtilise.Opacity = 0.5;
                    }

                    // Rafraîchissement des tooltips et retrait des contrôles des personnages morts
                    if (_moteurJeu.ListePersonnages[i].NbPointsVie > 0)
                    {
                        Grid.SetColumn(FindName(_moteurJeu.ListePersonnages[i].Nom) as Image, _moteurJeu.ListePersonnages[i].PositionX);
                        Grid.SetRow(FindName(_moteurJeu.ListePersonnages[i].Nom) as Image, _moteurJeu.ListePersonnages[i].PositionY);

                        (FindName(_moteurJeu.ListePersonnages[i].Nom) as Image).ToolTip = Utils.FormattageInfoBulle(_moteurJeu.ListePersonnages, i);
                    }
                    else
                    {
                        grilleTerrain.Children.Remove(FindName(_moteurJeu.ListePersonnages[i].Nom) as Image);

                        // Lorsqu'un héros est mort, on désactive ses contrôles
                        if (_moteurJeu.ListePersonnages[i] is Heros)
                        {
                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "xPersonnage") as Image).IsEnabled = false;
                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "xPersonnage") as Image).Opacity = 0.5;

                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Attaque.ToString()) as Image).IsEnabled = false;
                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Attaque.ToString()) as Image).Opacity = 0.5;

                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Deplacement.ToString()) as Image).IsEnabled = false;
                            (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Deplacement.ToString()) as Image).Opacity = 0.5;

                            if (_moteurJeu.ListePersonnages[i] is ICompetenceSpeciale) 
                            {
                                (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Competence.ToString()) as Image).IsEnabled = false;
                                (FindName(_moteurJeu.ListePersonnages[i].Nom + "x" + MoteurJeu.TypeAction.Competence.ToString()) as Image).Opacity = 0.5;
                            }
                        }
                    }
                }

                // Lorsqu'un tour (3 actions) est complété
                if (_moteurJeu.HerosCourant != null)
                {
                    // Tour des héros complété
                    if (_moteurJeu.NbActionRestante == 0)
                    {
                        ReactiverControlesHeros();
                        TourEnnemi();
                    }
                    else
                        Journalisation.Tracer($"\n> Tour restant pour le héros {_initiales}: {_moteurJeu.NbActionRestante}", txtTrace);
                }
                else
                {
                    if (_moteurJeu.NbActionRestante == 0)
                        TourHeros();
                    else
                        Journalisation.Tracer($"\n> Tour restant pour l'ennemi: {_moteurJeu.NbActionRestante}", txtTrace);
                }
            }
        }

        /// <summary>
        /// Constitue une liste de personnages morts, qu'ils soient héros ou ennemis.
        /// </summary>
        /// <param name="estHeros">Booléen indiquant si la liste concerne les héros (true) ou les ennemis (false)</param>
        private void EvaluerMorts(bool estHeros)
        {
            if (estHeros)
            {
                List<Personnage> ennemisMorts = _moteurJeu.ListePersonnages.FindAll(p => p is Ennemis && p.NbPointsVie <= 0);

                if (ennemisMorts.Count > 0)
                    Journalisation.Tracer($"Liste des ennemis morts: {string.Join(", ", ennemisMorts.Select(p => p.Nom))}", txtTrace);
            }
            else
            {
                List<Personnage> herosMorts = _moteurJeu.ListePersonnages.FindAll(p => p is Heros && p.NbPointsVie <= 0);

                if (herosMorts.Count > 0)
                    Journalisation.Tracer($"Liste des héros morts: {string.Join(",", herosMorts.Select(p => p.Nom))}", txtTrace);
            }
        }

        /// <summary>
        /// Évalue la fin de la partie et si c'est le cas, affiche la fenêtre de fin indiquant si les héros ou les ennemis ont gagné.
        /// </summary>
        /// <returns>Booléen indiquant si la partie est terminée ou non</returns>
        private bool EstPartieTerminee()
        {
            bool estSuccesHeros = false;

            switch (MoteurJeu.EvaluerSantePersonnages(_moteurJeu.ListePersonnages))
            {
                case Utils.SantePersonnages.AucunGagnant:
                    return false;
                case Utils.SantePersonnages.SuccesHeros:
                    estSuccesHeros = true;

                    break;
                case Utils.SantePersonnages.SuccesEnnemi:
                    estSuccesHeros = false;

                    break;
            }

            Fin fin = new Fin(estSuccesHeros, _initiales);
            fin.Show();
            Close();

            return true;
        }

        /// <summary>
        /// Réinitialise pour un nouveau tour du Héros
        /// </summary>
        private void TourHeros()
        {
            _moteurJeu.NbActionRestante = 3;

            _moteurJeu.HerosCourant = null;
            _moteurJeu.EnnemiCourant = null;
            _moteurJeu.ActionCourante = MoteurJeu.TypeAction.Aucune;

            Journalisation.Tracer($"\n\n_____C'est au tour du héros {_initiales}_____", txtTrace);
            Journalisation.Tracer($"\n> Tour restant pour {_initiales}: {_moteurJeu.NbActionRestante}", txtTrace);
        }

        /// <summary>
        /// Réactive les contrôles d'action pour les héros.
        /// </summary>
        private void ReactiverControlesHeros()
        {

            // Réactivation des contrôles des héros
            foreach (Personnage personnage in _moteurJeu.ListePersonnages.FindAll(p => p is Heros && p.NbPointsVie > 0))
            {
                Image controleAttaque = (Image)FindName(personnage.Nom + "x" + MoteurJeu.TypeAction.Attaque.ToString());
                controleAttaque.IsEnabled = true;
                controleAttaque.Opacity = 1;

                Image controleDeplacement = (Image)FindName(personnage.Nom + "x" + MoteurJeu.TypeAction.Deplacement.ToString());
                controleDeplacement.IsEnabled = true;
                controleDeplacement.Opacity = 1;

                if (personnage is ICompetenceSpeciale) 
                {
                    Image controleCompetence = (Image)FindName(personnage.Nom + "x" + MoteurJeu.TypeAction.Competence.ToString());
                    controleCompetence.IsEnabled = true;
                    controleCompetence.Opacity = 1;
                }
            }
        }

        /// <summary>
        /// Déclenchée lorsque l'utilisateur clique sur Passer son tour.
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEvent"></param>
        private void PasserTourHeros(object pSender, RoutedEventArgs pEvent)
        {
            Journalisation.Tracer($"Le héros {_initiales} passe son tour", txtTrace);

            ReactiverControlesHeros();
            TourEnnemi();
        }

        /// <summary>
        /// Réinitialise pour un nouveau tour des ennemis
        /// </summary>
        private void TourEnnemi()
        {
            _moteurJeu.NbActionRestante = 3;

            _moteurJeu.HerosCourant = null;
            _moteurJeu.EnnemiCourant = null;
            _moteurJeu.ActionCourante = MoteurJeu.TypeAction.Aucune;

            Journalisation.Tracer("\n\n_____C'est au tour de l'ennemi_____", txtTrace);
            Journalisation.Tracer($"\n> Tour restant pour l'ennemi: {_moteurJeu.NbActionRestante}", txtTrace);

            foreach (Personnage ennemi in _moteurJeu.ListePersonnages.FindAll(p => p is Ennemis && p.NbPointsVie > 0))
            {
                Personnage herosPlusProche = _moteurJeu.TrouverHerosPlusProche(ennemi);

                if (herosPlusProche != null)
                {
                    _moteurJeu.DeplacerVersHerosPlusProche(ennemi, herosPlusProche);

                    Journalisation.Tracer($"Déplacement de {ennemi.Nom} vers {herosPlusProche.Nom}", txtTrace);
                    ActionCompletee();

                    // Si le nombre d'action est à 3, c'est qu'on est rendu au Héros
                    if (_moteurJeu.NbActionRestante == 3)
                        return;

                    if (_moteurJeu.EstAttaquePossible(ennemi, herosPlusProche))
                    {
                        (ennemi as Attaquant).Attaquer(herosPlusProche);

                        Journalisation.Tracer($"{ennemi.Nom} a attaqué {herosPlusProche.Nom}", txtTrace);

                        EvaluerMorts(false);
                        ActionCompletee();
                    }
                    else
                        Journalisation.Tracer($"{ennemi.Nom} ne peut pas attaquer {herosPlusProche.Nom}", txtTrace);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Trace.Flush();
        }
    }
}
