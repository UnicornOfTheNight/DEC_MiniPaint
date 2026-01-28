Pour faire des actions sur une forme déjà dessinée, faire un clic droit dessus.

# 🎨 DEC MiniPaint

![Type](https://img.shields.io/badge/Type-Logiciel%20de%20Dessin-orange)
![License](https://img.shields.io/badge/License-MIT-blue)
![Language](https://img.shields.io/badge/Language-C%23%20%2F%20Java%20%2F%20Python-green)

**DEC MiniPaint** est une application de dessin vectoriel (ou matriciel) développée dans le cadre académique. Elle reprend les fonctionnalités essentielles d'un logiciel comme Microsoft Paint, avec une architecture logicielle mettant l'accent sur la **Programmation Orientée Objet**.

## 🖌️ Description

L'objectif de ce projet est de permettre à l'utilisateur de dessiner des formes géométriques, de tracer des lignes à main levée et de manipuler des propriétés graphiques (couleurs, épaisseur). 

D'un point de vue technique, ce projet sert à démontrer la maîtrise de :
* La gestion des événements souris (Clic, Drag & Drop).
* Le rendu graphique (GDI+, Graphics2D, Canvas).
* L'architecture de classes (Classe Mère `Forme`, Classes Filles `Rectangle`, `Cercle`, etc.).

## ✨ Fonctionnalités

### Outils de Dessin
* **Crayon / Pinceau** : Dessin à main levée.
* **Formes Géométriques** :
    * ⬜ Rectangle / Carré.
    * ⚪ Ellipse / Cercle.
    * 📏 Ligne droite.
* **Gomme** : Effacement partiel ou total.

### Propriétés
* **Palette de couleurs** : Choix de la couleur de contour et de remplissage.
* **Épaisseur du trait** : Réglage de la taille du pinceau/contour.

### Gestion de Fichiers
* **Nouveau** : Effacer la zone de dessin.
* **Sauvegarder** : Export de l'image (format `.png`, `.jpg` ou format propriétaire `.xml`/`.json` pour la réédition).
* **Charger** : Ouvrir un dessin existant.

## 🛠 Technologies & Architecture

* **Langage** : C#
* **IDE** : Visual Studio

### Concepts POO abordés
Ce projet utilise intensivement l'**Héritage** et le **Polymorphisme** :
> Une classe abstraite `Forme` définit les propriétés communes (Position X,Y, Couleur). Chaque outil (Rectangle, Cercle) hérite de cette classe et redéfinit la méthode `Dessiner()`.

## 🚀 Installation & Utilisation

1.  **Cloner le dépôt :**
    ```bash
    git clone [https://github.com/UnicornOfTheNight/DEC_MiniPaint.git](https://github.com/UnicornOfTheNight/DEC_MiniPaint.git)
    ```

2.  **Ouvrir le projet :**
    * Ouvrez la solution (`.sln`) ou le dossier projet dans votre IDE favori.

3.  **Compiler et Lancer :**
    * Lancez le build (`Ctrl+B` ou `F5`).
    * Une fenêtre blanche (Canvas) devrait apparaître.

4.  **Utilisation :**
    * Sélectionnez un outil dans la barre latérale/supérieure.
    * Choisissez une couleur.
    * Cliquez et glissez la souris sur la zone blanche pour dessiner.

## 🧠 Défis Techniques

* **Double Buffering** : Mise en place pour éviter le scintillement (flickering) lors du redessin des formes.
* **Gestion du "Undo/Redo"** : (Si implémenté) Utilisation de deux piles (Stacks) pour stocker l'historique des actions.
* **Redimensionnement** : Gestion de la fenêtre et des ancrages des outils.

## 👥 Auteur

* **UnicornOfTheNight** - *Développement*

---
*Projet réalisé pour le Diplôme d'Études Collégiales.*
