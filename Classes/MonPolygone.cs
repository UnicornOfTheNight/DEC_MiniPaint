using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOEL_TP2MiniPaint.Classes
{
	public class MonPolygone : Forme
	{
		int nbCote;
		public int NbCote { get => nbCote; set => nbCote = value; }

		public MonPolygone() { } //Constructeur vide pour la sérialisation
		public MonPolygone(int p_nbCote, PointF p_origine, Size p_taille, Pen p_crayon, bool p_pleine) : base(p_origine, p_taille, p_crayon, p_pleine) //Surcharge constructeur
		{
			nbCote = p_nbCote;
			TabPoints = new PointF[nbCote];
			Origine = new PointF(Origine.X - TailleForme.Width / 2, Origine.Y - TailleForme.Height / 2);
			Fin = new PointF(Origine.X + TailleForme.Width, Origine.Y + TailleForme.Height);
		}

		public override void updateListe()
		{
			LstFormesContours.Clear();
			//haut gauche
			LstFormesContours.Add(new MonRectangle(new PointF(Origine.X - 5, Origine.Y - 5), new Size(10, 10), new Pen(Color.Gray, 2), false));
			//haut droite
			LstFormesContours.Add(new MonRectangle(new PointF(Fin.X - 5, Origine.Y - 5), new Size(10, 10), new Pen(Color.Gray, 2), false));
			//bas gauche
			LstFormesContours.Add(new MonRectangle(new PointF(Origine.X - 5, Fin.Y - 5), new Size(10, 10), new Pen(Color.Gray, 2), false));
			//bas droite
			LstFormesContours.Add(new MonRectangle(new PointF(Fin.X - 5, Fin.Y - 5), new Size(10, 10), new Pen(Color.Red, 2), false));
		}

		public override void Dessiner(Graphics p_g)
		{
			int rayon = TailleForme.Width / 2;

			for (int i = 0; i < nbCote; i++) //on calcul les coordonnées de chaque point
			{
				int x = Convert.ToInt32((Origine.X + rayon) + rayon * Math.Cos(2 * Math.PI * i / nbCote));
				int y = Convert.ToInt32((Origine.Y + rayon) + rayon * Math.Sin(2 * Math.PI * i / nbCote));
				TabPoints[i] = new PointF(x, y); //on remplis le tableau de points
			}

			if (!Pleine)
			{
				p_g.DrawPolygon(new Pen(CouleurCrayon, TailleCrayon), TabPoints);
			}
			else
			{
				p_g.FillPolygon(new SolidBrush(CouleurCrayon), TabPoints);
			}

		}

		public override bool Redimensionner(PointF p_loc)
		{
			updateListe();
			int index = -1;
			for (int i = 0; i < LstFormesContours.Count; i++)
			{
				if (LstFormesContours[i].verifierSelection(p_loc))
				{
					index = i;
					break;
				}
			}

			if(index == 3) //Si on selectionne le petit carré en bas à droite on peut redimensionner
			{
				int rayon = TailleForme.Width / 2; // rayon du polygone
				for (int i = 0; i < TabPoints.Length; i++) //on parcours les points du polygone
				{
					//on recalcule les coordonnées x et y 
					int x = Convert.ToInt32((Origine.X + rayon) + rayon * Math.Cos(2 * Math.PI * i / nbCote));
					int y = Convert.ToInt32((Origine.Y + rayon) + rayon * Math.Sin(2 * Math.PI * i / nbCote));
					TabPoints[i] = new PointF(x, y); //on met a jour le tableau de points
				}

				int largeur = (int)(p_loc.X - TabPoints.Min(obj => obj.X)); //on recalcule la largeur
				int hauteur = (int)(TabPoints.Max(obj => obj.Y) - TabPoints.Min(obj => obj.Y)); //on recalcule la hauteur
				Fin = p_loc; //on met à jour le point d efin
				TailleForme = new Size(largeur, hauteur); //on met a jour la taille

				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
