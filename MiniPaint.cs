using Microsoft.VisualBasic;
using NOEL_TP2MiniPaint.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using static NOEL_TP2MiniPaint.Forme;

namespace NOEL_TP2MiniPaint
{
	public partial class MiniPaint : Form
	{
		#region declaration variables
		public enum TypeForme //contient les différentes formes
		{
			Rectangle,
			Cercle,
			Triangle,
			Polygone,
			Ligne
		};

		List<Forme> lstFormes; //liste des formes dessinées
		Forme formeSelectionnee; //forme selectionnée par l'utilisateur
		TypeForme type; //type de la forme
		bool pleine; //remplissage de la forme (pleine ou vide)
		bool remplissage = false; //si l'utilisateur a cliqué sur le bouton pour remplir des formes 
		bool clique = false; //permet de savoir si l'utilisateur à cliquer (utile pour le mouse_move)
		Pen crayon; //crayon pour dessiner les formes
		int nbCotePolygone; //nombre de cotés du polygone à dessiner
		PointF debut; //point où l'utilisateur à cliquer au début de dessin d'une forme
		PointF[] tabPt; //tableau des points pouhr les polygones
		Stack modifications; //pile des actions de modifications (ajout, déplacement, redimensionnement)
		Stack annulations; //pile des annulations effectuées
		public static float diffX = 0, diffY = 0; //difference poit d'origine / location souris, utile pour le déplacement d'une forme

		#endregion
		
		public MiniPaint()
		{
			InitializeComponent();

			tipRectangle.SetToolTip(btRectangle, "Rectangle");
			tipCercle.SetToolTip(btCercle, "Cercle");
			tipLigne.SetToolTip(btLigne, "Ligne");
			tipTriangle.SetToolTip(btTriangle, "Triangle");
			tipPolygone.SetToolTip(btPolygone, "Polygone régulier");
			tipRemplissage.SetToolTip(btFill, "Remplir une forme");

			lstFormes = new List<Forme>();
			type = TypeForme.Rectangle;
			pleine = false;
			debut = new PointF();
			modifications = new Stack();
			annulations = new Stack();
			crayon = new Pen(Color.Black, 2);
			nbCotePolygone = 5;
		}

		#region fonctions

		/// <summary>
		/// Serialise toutes les formes dessinées (xml)
		/// </summary>
		/// <param name="p_lstFormes"></param>
		/// <param name="chemin"></param>
		private void Serialiser(List<Forme> p_lstFormes, string chemin)
		{
			FileStream fichier = new FileStream(chemin + @"\formes.xml", FileMode.Create); //on crée le fichier avec le nom formes.xml par défaut
			XmlSerializer sf = new XmlSerializer(typeof(List<Forme>));
			sf.Serialize(fichier, p_lstFormes); //on sérialise dans le fichier

			fichier.Close(); //on ferme le fichier
		}

		/// <summary>
		/// Déserialise toutes les formes d'un fichier (xml)
		/// </summary>
		/// <param name="chemin"></param>
		/// <returns></returns>
		private void Deserialiser(string chemin)
		{
			if (chemin != "") //on vérifie que le chemin est bien renseigné
			{
				FileStream fichier = new FileStream(chemin, FileMode.Open); //on ouvre le fichier
				XmlSerializer sf = new XmlSerializer(typeof(List<Forme>));
				try
				{
					lstFormes = (List<Forme>)sf.Deserialize(fichier); //on déserialise pour remplir la liste de formes à dessiner
				}
				catch
				{
					MessageBox.Show("Une erreur est survenue. Veuillez vous assurer de choisir un fichier correct.");
				}
				fichier.Close(); //on ferme le fichier
			}
		}

		/// <summary>
		/// Methode pour dessiner les formes 
		/// </summary>
		/// <param name="e"></param>
		private void dessiner(MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			g.Clear(Color.White);

			switch(type) //le dessin sera différent selon le type de la forme
			{
				case TypeForme.Rectangle:
					MonRectangle rect = new MonRectangle(debut, new Size((int)(e.Location.X - debut.X), (int)(e.Location.Y - debut.Y)), crayon, pleine);
					rect.Dessiner(g);
					break;

				case TypeForme.Cercle:
					MonCercle cercle = new MonCercle(debut, new Size((int)(e.Location.X - debut.X), (int)(e.Location.Y - debut.Y)), crayon, pleine);
					cercle.Dessiner(g);
					break;

				case TypeForme.Ligne:
					MaLigne ligne = new MaLigne(debut, new Size((int)(e.Location.X - debut.X), (int)(e.Location.Y - debut.Y)), crayon, pleine);
					ligne.Dessiner(g);			
					break;

				case TypeForme.Triangle:
					MonTriangle triangle = new MonTriangle(debut, new Size((int)(e.Location.X - debut.X), (int)(e.Location.Y - debut.Y)), crayon, pleine);
					triangle.Dessiner(g);
					break;

				case TypeForme.Polygone:
					tabPt = new PointF[nbCotePolygone];
					float longueurCote = e.Location.X - debut.X;

					for (int i = 0; i < nbCotePolygone; i++) //on calcule les coordonnées de chaque points du polygone
					{
						int x = Convert.ToInt32(debut.X + longueurCote * Math.Cos(2 * Math.PI * i / nbCotePolygone));
						int y = Convert.ToInt32(debut.Y + longueurCote * Math.Sin(2 * Math.PI * i / nbCotePolygone));
						tabPt[i] = new PointF(x, y);
					}
					
					//on dessine le polygone
					if (!pleine)
					{
						g.DrawPolygon(crayon, tabPt);
					}
					else
					{
						g.FillPolygon(new SolidBrush(colorDialog.Color), tabPt);
					}

					break;
			}

			MiniPaint_Paint(null, new PaintEventArgs(g, new Rectangle(0, 0, Width, Height)));
			g.Dispose();
		}

		/// <summary>
		/// Appelé quand on fait une modification sur une forme, avant que la modification soit faite
		/// </summary>
		public void setFormeTmp()
		{
			//on doit créer une forme pour enregistrer l'état de la forme selectionné
			Forme formeT;
			Type typeForme = formeSelectionnee.GetType(); //on récupère le type de la forme selectionee 
			switch (typeForme.Name)
			{
				case "MonPolygone":
					formeT = new MonPolygone();
					break;

				case "MonCercle":
					formeT = new MonCercle();
					break;

				case "MonTriangle":
					formeT = new MonTriangle();
					break;

				case "MaLigne":
					formeT = new MaLigne();
					break;

				default:
					formeT = new MonRectangle();
					break;
			}

			PropertyInfo[] tabProprietes = typeForme.GetProperties(); //on récupère les variables de la classe de la forme
			for (int i = 0; i < tabProprietes.Length; i++) //on parcours les propriétés
			{
				object valeurPropriete = tabProprietes[i].GetValue(formeSelectionnee, null); //on récupère la valeur de la propriété de la forme selectionnée
				tabProprietes[i].SetValue(formeT, valeurPropriete); //on met cette valeur récupérée dans la forme tempon
			}

			modifications.Push(formeT); //on ajout la forme tmp dans la file de modifications
			//si on fait modifications.Push(formeSelectionnee) ca ne fonctionne pas car ca met a jour les propriété dans la file aussi alors que le but est de sauvegarder la forme avant modif
		}

		/// <summary>
		/// Permet d'ajouter la forme ajoutée à la liste des formes a dessiner
		/// </summary>
		/// <param name="p_loc">location de la souris</param>
		private void enregistrerForme(Point p_loc)
		{
			Size tailleForme = new Size(Math.Abs((int)(p_loc.X - debut.X)), Math.Abs((int)(p_loc.Y - debut.Y))); //On calcul la taille de la forme (on prend la valeur abs pour quand on dessine à l'envers

			PointF[] tab = new PointF[] { debut, new PointF(2 * debut.X - p_loc.X, p_loc.Y), p_loc };
			PointF debTriangle = debut;

			//La location du début et le point du debut du triangle change selon la direction qu'on dessine la forme 
			if (debut.X >= p_loc.X && debut.Y >= p_loc.Y) //dessin de droite à gauche et de bas en haut
			{
				debut = p_loc;
				debTriangle.Y = p_loc.Y;
			}
			else if (debut.X < p_loc.X && debut.Y > p_loc.Y) //dessin de gauche a droite et de bas en haut
			{
				debut.Y = p_loc.Y;
				debTriangle.Y = p_loc.Y;
			}
			else if (debut.X > p_loc.X && debut.Y < p_loc.Y) //dessin de droite a gauche et de haut en bas
			{
				debut.X = p_loc.X;
			}

			switch (type) //Selon le type de forme dessinée on ajoute une forme à la liste
			{
				case TypeForme.Rectangle:
					lstFormes.Add(new MonRectangle(debut, tailleForme, crayon, pleine));
					break;

				case TypeForme.Cercle:
					lstFormes.Add(new MonCercle(debut, tailleForme, crayon, pleine));
					break;

				case TypeForme.Ligne:
					lstFormes.Add(new MaLigne(debut, tailleForme, crayon, pleine));
					break;

				case TypeForme.Triangle:
					MonTriangle tr = new MonTriangle(debTriangle, tailleForme, crayon, pleine);
					tr.TabPoints = tab;
					lstFormes.Add(tr);
					break;

				case TypeForme.Polygone:
					//on calcul la taille du polygone en prenant les points max et min en x et en y du tableau
					int largeur = Math.Abs((int)tabPt.Max(obj => obj.X) - (int)tabPt.Min(obj => obj.X));
					int hauteur = Math.Abs((int)tabPt.Max(obj => obj.Y) - (int)tabPt.Min(obj => obj.Y));
					MonPolygone poly = new MonPolygone(nbCotePolygone, debut, new Size(largeur, hauteur), crayon, pleine);
					poly.TabPoints = tabPt;
					lstFormes.Add(poly);
					break;
			}
		}

		/// <summary>
		/// Methode pour remplir une forme avec une couleur
		/// </summary>
		private void remplirForme()
		{
			foreach (Forme f in lstFormes) //on parcours toutes les formes dessinées
			{
				if (f.Selectionner(MousePosition)) //on regarde si on a cliquer sur une forme 
				{
					formeSelectionnee = f; //la forme selectionnee prend la forme sur laquelle on a cliquer pour la sauvegarde
					setFormeTmp(); //on enregistre la forme avant la modification
					formeSelectionnee = null; //on remet la forme selectionnee a null

					if (!f.Pleine) //Si la forme n'était pas pleine on la remplit
					{
						f.Pleine = true;
					}
					f.CouleurCrayon = colorDialog.Color; //elle prend la couleur qui est dans l'encadré CRAYON
					Invalidate(); //on actualise
					break; //on sort de la boucle
				}
			}
		}

		#endregion

		#region evenements menu

		/// <summary>
		/// Pour ouvrir un fichier
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string chemin = "";

			openFileDialog.Filter = "XML Files|*.xml"; //on autorise seulement les fichier XML à être ouverts
			DialogResult result = openFileDialog.ShowDialog(); //on ouvre la fenetre de dialogue pour recuperer le fichier

			if (result == DialogResult.OK) //si l'utilisateur à choisis un fichier
			{
				chemin = openFileDialog.FileName; //on récupere le chemin du fichier
			}

			Deserialiser(chemin); //on deserialise les données
			Invalidate(); //on actualise
		}

		/// <summary>
		/// Pour enregistrer les formes dans un fichier
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string chemin = "";
			folderBrowserDialog.ShowNewFolderButton = true; //permet de créer un nouveau dossier dans la boite de dialogue

			DialogResult result = folderBrowserDialog.ShowDialog(); //on ouvre la boite de dialogue
			
			if (result == DialogResult.OK) //Si l'utilisateur à choisi un chemin
			{
				chemin = folderBrowserDialog.SelectedPath; //on stocke le chemin choisi
			}
			Serialiser(lstFormes, chemin); //on sérialise
		}
		
		/// <summary>
		/// Annulation de la derniere action effectuée (ajout, redimmensionnement, déplacement)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void annulerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(modifications.Count > 0) //si des modifications on été faites
			{
				bool existe = false;
				Forme f = (Forme)modifications.Pop(); // On récupère la dernière forme ajouté a la pile
				for (int i = 0; i < lstFormes.Count; i++) //on parcours les formes
				{
					if (lstFormes[i].Id == f.Id) //Si la forme parcourue correspond à la forme modifiée
					{
						existe = true;
						annulations.Push(lstFormes[i]); //on sauvegarde la forme avant qu'elle soit remise à son etat d'avant 
						lstFormes[i] = f; //la forme récupère ses valeurs précédentes
						break; //on peut sortir de la boucle
					}
				}

				if (!existe)//si la forme n'est pas trouvée dans la liste c'est qu'elle a été effacée
				{
					lstFormes.Add(f); // on rajoute la forme à la liste principale
					annulations.Push(f);//on ajoute la forme à la pile des annulations
				}

			}
			else if(lstFormes.Count > 0) //Si il n'y a pas de modification mais qu'il existe des formes l'annulation revient a effacer la derniere forme ajoutée
			{
				annulations.Push(lstFormes[lstFormes.Count - 1]); //on sauvegarde la forme
				lstFormes.RemoveAt(lstFormes.Count - 1); //on retire la forme de la liste principale
			}

			Invalidate(); //on actualise
		}

		/// <summary>
		/// Annulation des annulations
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void suivantToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (annulations.Count > 0)
			{
				bool existe = false;
				Forme f = (Forme)annulations.Pop(); //on recupere la derniere forme où les modifications ont été annulées
				
				for (int i = 0; i < lstFormes.Count; i++) //on parcours la liste des formes
				{
					if (lstFormes[i].Id == f.Id) //si la forme parcourue correspond à la forme f
					{
						if (f.Equals(lstFormes[i])) //Si la forme est la même c'est qu'elle à juste été ajoutée
						{
							lstFormes.RemoveAt(lstFormes.Count - 1);
						}
						else
						{
							modifications.Push(lstFormes[i]); //on ajoute la forme dans la pile des modifications sur les formes
							lstFormes[i] = f; //la forme reprend ses propriétés
							
						}
						existe = true;
						break;
					}
				}

				if (!existe) //si la forme n'existe pas on l'ajoute à la liste principale
				{
					lstFormes.Add(f); 
				}
				
				Invalidate();
			}
		}
		#endregion

		#region evenements menu clic droit

		/// <summary>
		/// Clic droit pour redimensionner une forme
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void redimensionnerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			formeSelectionnee.action = formeSelectionnee.Redimensionner; //on met le délégué de l'action en cours sur la méthode de redimension
			setFormeTmp(); //on enregistre la forme avant qu'elle soit modifiée
		}
		
		/// <summary>
		/// Clic droit pour déplacer une forme
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void deplacerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			formeSelectionnee.action = formeSelectionnee.Deplacer; //on met le délégué de l'action en cours sur la méthode de redimension
			setFormeTmp(); //on enregistre la forme avant qu'elle soit modifiée
		}

		/// <summary>
		/// Clic droit pour effacer une forme
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void effacerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			setFormeTmp(); //on enregistre la forme avant qu'elle soit effacée
			lstFormes.Remove(formeSelectionnee); // on efface la forme
			formeSelectionnee = null; //on met la forme selectionnée sur nul
			contextMenuStrip.Enabled = false;  //on n'autorise plus les actions clic droit car aucune forme n'est selectionnée
			Invalidate(); //on actualise
		}

		/// <summary>
		/// Clic droit pour changer la couleur d'une forme
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void changerLaCouleurToolStripMenuItem_Click(object sender, EventArgs e)
		{
			colorChangement.ShowDialog(); //On fait choisir une couleur à l'utilisateur
			formeSelectionnee.CouleurCrayon = colorChangement.Color; //On change la couleur de la forme
			Invalidate(); //on actualise
		}

		#endregion

		#region evenements dessin forme

		/// <summary>
		/// Quand l'utilisateur selectionne un type de forme a dessiner (rectangle, cercle, etc.)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btType_Click(object sender, EventArgs e)
		{
			Button btCliquer = (Button)sender; //on récupère le bouton qui a été cliqué

			switch (btCliquer.Name) //Selon le bouton de forme cliquer on change la variable type pour la forme
			{
				case "btRectangle":
					type = TypeForme.Rectangle;
					break;

				case "btCercle":
					type = TypeForme.Cercle;
					break;

				case "btTriangle":
					type = TypeForme.Triangle;
					break;

				case "btLigne":
					type = TypeForme.Ligne;
					break;

				case "btPolygone":
					string reponse = Interaction.InputBox("Nombre de côtés du polygone ?", "Polygone", "5"); //on demande le nombre de coté du polygone (5 par défaut)

					if (int.TryParse(reponse, out nbCotePolygone)) //Si l'utulisateur a appuyer sur ok la variable du nb de coté du poly prend le nombre de coté renseigné 
					{
						if (nbCotePolygone >= 3) //le nombre de côté doit être supérieur ou égal à 3
						{
							type = TypeForme.Polygone;
						}
						else
						{
							MessageBox.Show("Veuillez mettre un nombre de coté de minimum 3.");
						}
					}
										
					break;
			}
		}
		
		/// <summary>
		/// Permet de choisir une couleur
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btCouleur_Click(object sender, EventArgs e)
		{
			colorDialog.ShowDialog(); //on montre la fenetre de couleurs
			btCouleur.BackColor = colorDialog.Color; //on actualise la couleur du petit carré contenant la couleur actuelle
			crayon.Color = colorDialog.Color; //on change la couleur du crayon
		}

		/// <summary>
		/// Pour savoir si la forme dessinée doit être pleine ou vide
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbPleine_CheckedChanged(object sender, EventArgs e)
		{
			pleine = (pleine == true) ? false : true; //Si la variable pleine est à true on la met à false et si elle est à false on la met à true
		}

		/// <summary>
		/// Permet de changer la taille du crayon pour le dessin de la prochaine forme
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void numTailleCrayon_ValueChanged(object sender, EventArgs e)
		{
			crayon.Width = Convert.ToInt32(numTailleCrayon.Value); //on change la taille du crayon
		}

		/// <summary>
		/// Quand on clique sur le bouton pour remplir une forme
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btFill_Click(object sender, EventArgs e)
		{
			remplissage = true;
			clique = false;
		}

		private void MiniPaint_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			foreach (Forme forme in lstFormes) //on parcours les formes de la liste des formes a dessiner
			{
				forme.Dessiner(g); //on dessine la forme				
			}

			if (formeSelectionnee != null) //on regarde si une forme est selectionnée
			{
				foreach (Forme contour in formeSelectionnee.LstFormesContours) //on parcours les formes de contours de la forme selectionnée (les petits carrés)
				{
					contour.Dessiner(g); //on dessine le petit carré
				}
			}

			g.Dispose();
		}

		#endregion

		#region evenements souris
		
		private void MiniPaint_MouseDown(object sender, MouseEventArgs e)
		{
			if (formeSelectionnee != null) //on regarde si une forme est selectionnée
			{
				//on enregistre la diférence entre le point d'origine de la forme et le point de la souris
				diffX = e.Location.X - formeSelectionnee.Origine.X;
				diffY = e.Location.Y - formeSelectionnee.Origine.Y;
			}
			clique = true; //on a cliquer 
			debut = e.Location; //on enregistre le point du click
		}

		private void MiniPaint_MouseUp(object sender, MouseEventArgs e)
		{

			if (!lstFormes.Contains(formeSelectionnee) && debut != e.Location && formeSelectionnee == null) // si une nouvelle forme à été dessinée
			{
				enregistrerForme(e.Location); //on eneregistre la forme
			}
			else //si on a effectué une action sur une forme déjà existante
			{
				if (remplissage) //Si on veut remplir une forme 
				{
					remplirForme(); //on appelle la fonction pour remplir la forme
				}
				else //si on selectionne une forme pour faire autre chose
				{
					formeSelectionnee = null; //on met la forme selectionnee a null
					List<Forme> lstTmp = new List<Forme>();
					foreach (Forme forme in lstFormes) //on parcours les formes dessinnées
					{
						if (forme.Selectionner(e.Location)) //si la forme correspond à la location du click de la souris
						{
							lstTmp.Add(forme);
							formeSelectionnee = forme;
							formeSelectionnee.action = formeSelectionnee.Selectionner; //on met le delegué sur la méthode selectionner
							contextMenuStrip.Enabled = true; //on autorise l'affichage menu du click droit
							foreach (ToolStripItem item in contextMenuStrip.Items) //on autorise tous les item
							{
								item.Enabled = true;
							}

						}
						Invalidate(); //on actualise
					}

					if (formeSelectionnee == null)//si il n'y a pas de forme selectionnée
					{
						//On interdit l'affichage du menu au click droit
						contextMenuStrip.Enabled = false;
					}
				}
			}

			clique = false;
			remplissage = false;
		}

		private void MiniPaint_MouseMove(object sender, MouseEventArgs e)
		{ 
			if (clique) //Si on a cliquer dans la fenetre
			{
				if (formeSelectionnee == null) //si aucune forme n'est selectionnée on peut dessiner
				{
					dessiner(e);
				}
				else //si une forme est selectionné on effectue une action
				{
					formeSelectionnee.action(e.Location); //on appelle le delegué de la forme selectionnée
					Invalidate(); //on actualise
				}
			}
		}
		
		#endregion
	}
}
