# Robot de Bibliothèque

_Read this in other languages: [English](README.en.md)._

## Directives

Vous devez fournir une implémentation fonctionnelle en C# de `ILibraryRoutePlanner.cs` (que vous ne pouvez pas modifier) qui satisfait tous les tests d’acceptation (`AcceptanceTests.cs`).

**La version finale de votre code doit être disponible/poussée au moins 5 heures avant la rencontre avec l’équipe.**

Après avoir soumis votre code, vous participerez à une session de 90 minutes avec des membres de l’équipe de développement dans un environnement reflétant notre travail quotidien. Nous travaillerons ensemble sur votre code, avec de nouvelles contraintes ajoutées au problème. Vous devez donc avoir une solution bien structurée et compréhensible permettant une division facile des nouvelles tâches.

## Problème

Un petit robot autonome opère dans une bibliothèque. Son travail consiste à récupérer les livres demandés sur les étagères et les rapporter au comptoir de service.

La bibliothèque est représentée sous forme d’une grille rectangulaire de caractères :

- `#` représente un mur ou une étagère que le robot ne peut pas traverser.
- `.` représente une case libre sur laquelle le robot peut se déplacer.
- `S` représente le comptoir de service. Le robot commence ici et doit y revenir.
- Les lettres minuscules `a` à `z` représentent des livres demandés que le robot doit récupérer.

Il y a exactement un seul `S` dans la grille.  
Il peut y avoir zéro ou plusieurs livres demandés (lettres).  
Toutes les lignes et toutes les colonnes ont la même longueur.

Le robot peut se déplacer dans quatre directions :

- Haut (`U`)
- Bas (`D`)
- Gauche (`L`)
- Droite (`R`)

Chaque déplacement fait avancer le robot d’une case adjacente dans cette direction.

Le robot :

- Ne peut pas sortir des limites de la grille.
- Ne peut pas entrer dans une case `#`.
- Commence sur la case `S`.
- Ramasse automatiquement un livre lorsqu’il entre sur une case contenant une lettre.
  - Une fois le livre ramassé, cette case devient une case libre pour le reste du trajet.
  - Le robot peut transporter tous les livres en même temps.

Si aucun trajet valide n’est possible (par exemple, si un livre est complètement entouré de murs), vous devez retourner une chaîne de caractères vide.

## Exigences

- L’application doit implémenter l’interface `ILibraryRoutePlanner` et sa méthode `Start`.
- L’application doit calculer un trajet valide pour le robot (idéalement le plus court) qui :
  - Commence et se termine sur la case `S`,
  - Ramasse tous les livres demandés (cases `a` à `z`).
- Tous les tests d’acceptation dans `AcceptanceTests.cs` doivent réussir.

Vous êtes libre d’améliorer la suite de tests avec des tests pertinents supplémentaires ou d’ajouter de nouveaux critères d’acceptation.

## Exemples

`ILibraryRoutePlanner` est une interface entre votre code et nos tests unitaires. La solution inclut plusieurs tests simples pour valider votre compréhension de la logique métier. Voici un exemple simple pour commencer.

### Exemple 1

Entrée (string array) :

```
"#####",
"#Sa.#",
"#...#",
"#.b.#",
"#####"
```

Une sortie valide :

```
RDDUUL
```

Explication :

- Le robot commence sur `S` (rangée 1, colonne 1).
- `R` → se déplace vers `a` (1,2) et ramasse le livre.
- `D` → se déplace vers (2,2).
- `D` → se déplace vers `b` (3,2) et ramasse le livre.
- `U` → retourne à (2,2).
- `U` → revient où se trouvait `a` (désormais une case libre).
- `L` → retourne à `S`.

Les livres `a` et `b` ont été ramassés, et le robot termine sur `S`.

Plusieurs trajets optimaux peuvent exister. N’importe lequel est accepté.

### Exemple 2

Entrée :

```
"########",
"#S..a..#",
"#..##..#",
"#..b..##",
"########"
```

Une sortie possible :

```
RRRRDDLLLUUL
```

Le trajet est valide tant qu’il :

- Commence et se termine sur `S`,
- Visite `a` et `b` au moins une fois,
- N’entre jamais sur `#`,
- Reste dans les limites de la grille.
