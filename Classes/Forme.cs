using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Windows.Forms;
using NOEL_TP2MiniPaint.Classes;
using System.Reflection;
using System.Diagnostics;

namespace NOEL_TP2MiniPaint
{
	[DataContract]
	[XmlInclude(typeof(MonRectangle))]
	[XmlInclude(typeof(MonCercle))]
	[XmlInclude(typeof(MaLigne))]
	[XmlInclude(typeof(MonPolygone))]
	[XmlInclude(typeof(MonTriangle))]
	public abstract class Forme
	{
		#region declaration des variables
		string _id; //identifiant unique
		PointF[] _tabPoints; //tableau des points pour les triangles / polygones
		PointF _origine; //point d'origine de la forme
		PointF _fin; //point de fin de la forme
		Size _tailleForme;
		int _tailleCrayon;
		int _intCouleur; //couleur de la forme
		bool _pleine; //si la forme est pleine ou vide

		public delegate bool DelegueAction(PointF p_loc); //delegue contenant la méthode à réaliser (action deplacer, redimensionner...)
		[XmlIgnore]
		public DelegueAction action; //on a pas besoin de sauvegarder le delegué

		[XmlIgnore]
		List<Forme> lstFormesContours; //on a pas besoins de sauvegarder la liste des formes de contours

		[XmlIgnore] //on ne sauvegarde pas la couleur puisqu'on sauvegarde le rgb
		public Color CouleurCrayon
		{
			get { return Color.FromArgb(_intCouleur); }
			set { _intCouleur = value.ToArgb(); }
		}

		#endregion

		#region Accesseurs
		public string Id { get => _id; set => _id = value; }
		public Size TailleForme { get => _tailleForme; set => _tailleForme = value; }
		public int TailleCrayon { get => _tailleCrayon; set => _tailleCrayon = value; }
		public bool Pleine { get => _pleine; set => _pleine = value; }
		public PointF Origine { get => _origine; set => _origine = value; }
		public PointF Fin { get => _fin; set => _fin = value; }
		public PointF[] TabPoints { get => _tabPoints; set => _tabPoints = value; }
		public int IntCouleur { get => _intCouleur; set => _intCouleur = value; }
		public List<Forme> LstFormesContours { get => lstFormesContours; set => lstFormesContours = value; }
		#endregion

		public Forme(){ } //constructeur vide pour la sérialisation

		public Forme(PointF p_origine, Size p_tailleForme, Pen p_crayon, bool p_pleine) //Surcharge constructeur
		{
			_id = Guid.NewGuid().ToString(); //id unique
			_origine = p_origine;
			_fin.X = p_origine.X + p_tailleForme.Width;
			_fin.Y = p_origine.Y + p_tailleForme.Height;
			_tailleForme = p_tailleForme;
			_tailleCrayon = (int)p_crayon.Width;
			_pleine = p_pleine;
			CouleurCrayon = p_crayon.Color;
			lstFormesContours = new List<Forme>();
		}

		/// <summary>
		/// Permet de selectionner une forme
		/// </summary>
		/// <param name="p_loc"></param>
		/// <returns></returns>
		public virtual bool Selectionner(PointF p_loc)
		{
			if (verifierSelection(p_loc)) //on vérifie qu'on selectionne une forme
			{
				updateListe();
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Permet de dessiner la forme, définie dans chaque forme
		/// </summary>
		/// <param name="p_g"></param>
		public abstract void Dessiner(Graphics p_g);

		/// <summary>
		/// Permet de redimensionner la forme
		/// </summary>
		/// <param name="p_loc">Location de la souris</param>
		/// <returns>Si la redimmension à eu lieu ou non</returns>
		public virtual bool Redimensionner(PointF p_loc)
		{
			updateListe();

			int index = -1;
			for (int i = 0; i < lstFormesContours.Count; i++) //on parcours les carrés autours de la forme
			{
				if (lstFormesContours[i].verifierSelection(p_loc)) //Si on clique sur l'un des carré
				{
					index = i; //on stocke l'index pour savoir sur quel carré on a cliqué
					break;
				}
			}

			switch (index) //Selon le carré sélectionné le point d'origine et de fin ne seront pas les mêmes
			{
				case 0: //haut gauche
					Origine = p_loc;
					TailleForme = new Size((int)(Fin.X - Origine.X), (int)(Fin.Y - Origine.Y));
					break;

				case 1: //haut droite
					Origine = new PointF(Origine.X, p_loc.Y);
					Fin = new PointF(p_loc.X, Fin.Y);
					TailleForme = new Size((int)(Fin.X - Origine.X), (int)(Fin.Y - Origine.Y));
					break;

				case 2: //bas gauche
					Origine = new PointF(p_loc.X, Origine.Y);
					Fin = new PointF(Fin.X, p_loc.Y);
					TailleForme = new Size((int)(Fin.X - Origine.X), (int)(Fin.Y - Origine.Y));
					break;

				case 3: //bas droite
					Fin = p_loc;
					TailleForme = new Size((int)(Fin.X - Origine.X), (int)(Fin.Y - Origine.Y));
					break;
			}

			if(index != -1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Permet de déplacer la forme
		/// </summary>
		/// <param name="p_loc">Location de la souris</param>
		/// <returns>Retourne vrai si le déplacement c'est fait</returns>
		public virtual bool Deplacer(PointF p_loc)
		{
			if (verifierSelection(p_loc)) //on vérifie que la forme est bien selectionnée
			{
				updateListe();
				//on update les points d'origine et de fin
				PointF pt_origine = new PointF(p_loc.X - MiniPaint.diffX, p_loc.Y - MiniPaint.diffY);
				Origine = pt_origine;
				PointF pt_fin = new PointF(Origine.X + TailleForme.Width, Origine.Y + TailleForme.Height);
				Fin = pt_fin;
				return true;
			}
			else
			{
				return false;
			}
			
		}

		/// <summary>
		/// Permet de verifier si on clique dans la forme
		/// </summary>
		/// <param name="p_loc">location de la souris</param>
		/// <returns></returns>
		public bool verifierSelection(PointF p_loc)
		{
			int marge = 15;

			if (p_loc.X >= Origine.X - marge && p_loc.X <= Fin.X + marge && p_loc.Y >= Origine.Y - marge && p_loc.Y <= Fin.Y + marge)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Permet de mettre a jour la liste des formes de contours
		/// </summary>
		public virtual void updateListe()
		{
			lstFormesContours.Clear();
			Pen crayon = new Pen(Color.Red, 2);
			//on remplit la liste contenant les formes de contours
			lstFormesContours.Add(new MonRectangle(new PointF(Origine.X - 5, Origine.Y - 5), new Size(10, 10), crayon, false));
			lstFormesContours.Add(new MonRectangle(new PointF(Fin.X - 5, Origine.Y - 5), new Size(10, 10), crayon, false));
			lstFormesContours.Add(new MonRectangle(new PointF(Origine.X - 5, Fin.Y - 5), new Size(10, 10), crayon, false));
			lstFormesContours.Add(new MonRectangle(new PointF(Fin.X - 5, Fin.Y - 5), new Size(10, 10), crayon, false));
		}


		#region surcharges opérateurs

		/// <summary>
		/// On regarde si une forme est plus petite qu'une deuxieme forme
		/// </summary>
		/// <param name="f1">Premiere forme a comparer</param>
		/// <param name="f2">Deuxieme forme a comparer</param>
		/// <returns></returns>
		public static bool operator <=(Forme f1, Forme f2)
		{
			//Si la taille en largeur et hauteur de la première forme est inférieure à la deuxième forme on renvoie vrai
			if (f1.TailleForme.Width <= f2.TailleForme.Width && f1.TailleForme.Height <= f2.TailleForme.Height)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// On regarde si une forme est plus grande qu'une deuxieme forme
		/// </summary>
		/// <param name="f1">Première forme</param>
		/// <param name="f2">Deuxième forme</param>
		/// <returns></returns>
		public static bool operator >=(Forme f1, Forme f2)
		{
			//Si la taille en largeur et hauteur de la première forme est supérieure à la deuxième forme on renvoie vrai
			if (f1.TailleForme.Width >= f2.TailleForme.Width && f1.TailleForme.Height >= f2.TailleForme.Height)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

	}
}
