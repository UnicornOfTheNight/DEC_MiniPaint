using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOEL_TP2MiniPaint.Classes
{
	public class MonTriangle : Forme
	{
		public MonTriangle() { } //Constructeur vide pour la sérialisation

		public MonTriangle(PointF p_origine, Size p_taille, Pen p_crayon, bool p_pleine) : base(p_origine, p_taille, p_crayon, p_pleine) //Surcharge constructeur
		{
			//on remplit le tableau de points
			TabPoints = new PointF[3];
			TabPoints[0] = Origine;
			TabPoints[1] = new PointF(Origine.X - (Fin.X - Origine.X), Fin.Y);
			TabPoints[2] = Fin;

			PointF deb = new PointF(TabPoints.Min(obj => obj.X), TabPoints.Min(obj => obj.Y));
			PointF fin = new PointF(TabPoints.Max(obj => obj.X), TabPoints.Max(obj => obj.Y));
			Origine = deb;
			Fin = fin;
			TailleForme = new Size((int)(fin.X - deb.X), (int)(fin.Y - deb.Y));		
		}

		public override void Dessiner(Graphics p_g)
		{
			if (!Pleine)
			{
				p_g.DrawPolygon(new Pen(CouleurCrayon, TailleCrayon), TabPoints);
			}
			else
			{
				p_g.FillPolygon(new SolidBrush(CouleurCrayon), TabPoints);
			}

		}

		public override bool Deplacer(PointF p_loc)
		{
			if (base.Deplacer(p_loc)) 
			{
				//on update les points du tableau
				if (TabPoints[0].Y < TabPoints[1].Y) //Si la forme est à l'endroit (pointe en haut)
				{
					TabPoints[0] = new PointF(Origine.X + TailleForme.Width / 2, Origine.Y);
					TabPoints[1] = new PointF(Origine.X, Fin.Y);
					TabPoints[2] = Fin;
				}
				else //Si la pointe est vers le bas
				{
					TabPoints[0] = new PointF(Origine.X + TailleForme.Width / 2, Fin.Y);
					TabPoints[1] = Origine;
					TabPoints[2] = new PointF(Fin.X, Origine.Y);
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		public override bool Redimensionner(PointF p_loc)
		{
			if (base.Redimensionner(p_loc))
			{
				//on met a jour le tableau de points
				if (TabPoints[0].Y < TabPoints[1].Y) //Si la pointe est vers le haut
				{
					TabPoints[0] = new PointF(Origine.X + TailleForme.Width / 2, Origine.Y);
					TabPoints[1] = new PointF(Origine.X, Fin.Y);
					TabPoints[2] = Fin;
				}
				else //Si la pointe est vers le bas
				{
					TabPoints[0] = new PointF(Origine.X + TailleForme.Width / 2, Fin.Y);
					TabPoints[1] = Origine;
					TabPoints[2] = new PointF(Fin.X, Origine.Y);
				}
				return true;
			}
			else return false;
		}
	}
}
