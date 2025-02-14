# Co-développeur
* Nom étudiant.e : Alexandre Roy
# GITHUB
* https://github.com/alexandre-roy/14C-H25-TP1-Roy_Alexandre
# DESCRIPTION
* Ce projet m’a permis d’en apprendre davantage sur la hiérarchie, et de mieux comprendre qui peut accéder à quoi. De plus, comme nous avons dû préparer notre projet seuls, cela m’a appris à séparer mes fichiers en plusieurs dossiers. Lorsque j’ai rencontré une erreur avec Git, j’étais plus à l’aise qu’avant pour la résoudre, car je comprenais mieux le fonctionnement des différentes parties. Ce projet m’a également appris à utiliser des interfaces et la dérivation de classes.
# JUSTIFICATIONS DU DÉCOUPAGE ORGANIQUE
* Premièrement, ma hiérarchie est la suivante : En haut de tout, nous avons une classe Personnage, qui englobe les deux sous-classes Attaquant et Allié. La classe Attaquant englobe les classes Héros et Ennemis. De plus, la classe Héros englobe les classes Mario, Luigi, Yoshi, Peach, et enfin la classe FamilleLapins.
* Personnage : Ici, la classe est abstraite parce qu’elle ne peut pas être instanciée, mais elle sert de base pour d’autres classes en dessous d’elle. J’y ai aussi placé la méthode SeDeplacer car tous les personnages peuvent se déplacer. Le constructeur est protected, car il ne peut pas être instancié, mais ses enfants peuvent utiliser la base.
* Attaquant : Ici, j’ai choisi de créer une classe et non une interface, car ses enfants SONT des attaquants, et non qu’ils ONT l’habilité d’attaquer. C’est un concept de « être » et « avoir » qu’on avait vu en classe. Le constructeur est protected pour les mêmes raisons que Personnage. La méthode Attaquer est, bien entendu, dans cette classe.
* Arme : Arme est une classe assez normale, elle n’hérite de rien et rien n’hérite d’elle.
* Héros : Le constructeur est protected pour les mêmes raisons que Personnage et Attaquant.
* Ennemis : Le constructeur est public, car, contrairement à Héros, Ennemis est instancié.
* Allié : Le constructeur est public pour les mêmes raisons que Ennemis.
* FamilleLapin : Le constructeur est public, encore pour les mêmes raisons.
* Mario, Luigi, Yoshi, Peach : Constructeurs publics, car ils sont aussi instanciés. Ils possèdent également l’interface des compétences spéciales.
* ICompetenceSpeciale : Ceci est une interface, elle contient seulement les méthodes abstraites de base, car elles peuvent être modifiées dans le futur par Mario, Luigi, Yoshi, et Peach.
# IMPORTANT
* Comme nous en avions parlé dans un des cours précédents, je n’ai pas accès à l’extension pour créer des diagrammes de classes, alors j’ai ouvert mon TP sur un autre ordinateur, ajouté le diagramme, et me suis renvoyé le TP par la suite. Je ne peux pas ouvrir le fichier avec mon VSCode, donc je ne sais pas s’il sera encore bien formaté. C’est pour cela que j’ai ajouté l’image diagramme.png dans mon dossier models. Vous pouvez maintenant voir mon diagramme à partir de cette photo. Merci !
