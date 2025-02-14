# Co-d�veloppeur
* Nom �tudiant.e : Alexandre Roy
# GITHUB
* https://github.com/alexandre-roy/14C-H25-TP1-Roy_Alexandre
# DESCRIPTION
* Ce projet m�a permis d�en apprendre davantage sur la hi�rarchie, et de mieux comprendre qui peut acc�der � quoi. De plus, comme nous avons d� pr�parer notre projet seuls, cela m�a appris � s�parer mes fichiers en plusieurs dossiers. Lorsque j�ai rencontr� une erreur avec Git, j��tais plus � l�aise qu�avant pour la r�soudre, car je comprenais mieux le fonctionnement des diff�rentes parties. Ce projet m�a �galement appris � utiliser des interfaces et la d�rivation de classes.
# JUSTIFICATIONS DU D�COUPAGE ORGANIQUE
* Premi�rement, ma hi�rarchie est la suivante : En haut de tout, nous avons une classe Personnage, qui englobe les deux sous-classes Attaquant et Alli�. La classe Attaquant englobe les classes H�ros et Ennemis. De plus, la classe H�ros englobe les classes Mario, Luigi, Yoshi, Peach, et enfin la classe FamilleLapins.
* Personnage : Ici, la classe est abstraite parce qu�elle ne peut pas �tre instanci�e, mais elle sert de base pour d�autres classes en dessous d�elle. J�y ai aussi plac� la m�thode SeDeplacer car tous les personnages peuvent se d�placer. Le constructeur est protected, car il ne peut pas �tre instanci�, mais ses enfants peuvent utiliser la base.
* Attaquant : Ici, j�ai choisi de cr�er une classe et non une interface, car ses enfants SONT des attaquants, et non qu�ils ONT l�habilit� d�attaquer. C�est un concept de � �tre � et � avoir � qu�on avait vu en classe. Le constructeur est protected pour les m�mes raisons que Personnage. La m�thode Attaquer est, bien entendu, dans cette classe.
* Arme : Arme est une classe assez normale, elle n�h�rite de rien et rien n�h�rite d�elle.
* H�ros : Le constructeur est protected pour les m�mes raisons que Personnage et Attaquant.
* Ennemis : Le constructeur est public, car, contrairement � H�ros, Ennemis est instanci�.
* Alli� : Le constructeur est public pour les m�mes raisons que Ennemis.
* FamilleLapin : Le constructeur est public, encore pour les m�mes raisons.
* Mario, Luigi, Yoshi, Peach : Constructeurs publics, car ils sont aussi instanci�s. Ils poss�dent �galement l�interface des comp�tences sp�ciales.
* ICompetenceSpeciale : Ceci est une interface, elle contient seulement les m�thodes automatiquement abstraites de base, car elles peuvent �tre modifi�es dans le futur par Mario, Luigi, Yoshi, et Peach.
# IMPORTANT
* Comme nous en avions parl� dans un des cours pr�c�dents, je n�ai pas acc�s � l�extension pour cr�er des diagrammes de classes, alors j�ai ouvert mon TP sur un autre ordinateur, ajout� le diagramme, et me suis renvoy� le TP par la suite. Je ne peux pas ouvrir le fichier avec mon VSCode, donc je ne sais pas s�il sera encore bien format�. C�est pour cela que j�ai ajout� l�image diagramme.png dans mon dossier models. Vous pouvez maintenant voir mon diagramme � partir de cette photo. Merci !
