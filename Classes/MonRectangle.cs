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
	public class MonRectangle : Forme
	{
		public MonRectangle() {	} //Constructeur vide pour la sérialisation
		public MonRectangle(PointF p_origine, Size p_taille, Pen p_crayon, bool p_pleine) : base(p_origine, p_taille, p_crayon, p_pleine) { } //Surcharge constructeur
		
		public override void Dessiner(Graphics p_g)
		{	
			if (!Pleine) //on regarde si la forme est pleine ou vide 
			{
				Pen crayon = new Pen(CouleurCrayon, TailleCrayon);
				if (Origine.X > Fin.X && Origine.Y > Fin.Y) //cas dessin de droite vers gauche et de bas vers haut
				{
					p_g.DrawRectangle(crayon, Fin.X, Fin.Y, Origine.X - Fin.X, Origine.Y - Fin.Y);
				}
				else if (Origine.X > Fin.X && Origine.Y < Fin.Y) //cas dessin de droite à gauche et de haut vers bas
				{
					p_g.DrawRectangle(crayon, Fin.X, Origine.Y, Origine.X - Fin.X, Fin.Y - Origine.Y);
				}
				else if (Origine.X < Fin.X && Origine.Y > Fin.Y) //cas dessin de gauche vers droite et de bas vers haut
				{
					p_g.DrawRectangle(crayon, Origine.X, Fin.Y, Fin.X - Origine.X, Origine.Y - Fin.Y);
				}
				else //cas dessin normal (gauche vers droite et haut vers bas)
				{
					p_g.DrawRectangle(crayon, Origine.X, Origine.Y, TailleForme.Width, TailleForme.Height);
				}
			}
				
			else
			{
				Brush myBrush = new SolidBrush(CouleurCrayon);
				
				if (Origine.X > Fin.X && Origine.Y > Fin.Y) //cas dessin de droite vers gauche et de bas vers haut
				{
					p_g.FillRectangle(myBrush, Fin.X, Fin.Y, Origine.X - Fin.X, Origine.Y - Fin.Y);
				}
				else if (Origine.X > Fin.X && Origine.Y < Fin.Y) //cas dessin de droite à gauche et de haut vers bas
				{
					p_g.FillRectangle(myBrush, Fin.X, Origine.Y, Origine.X - Fin.X, Fin.Y - Origine.Y);
				}
				else if (Origine.X < Fin.X && Origine.Y > Fin.Y) //cas dessin de gauche vers droite et de bas vers haut
				{
					p_g.FillRectangle(myBrush, Origine.X, Fin.Y, Fin.X - Origine.X, Origine.Y - Fin.Y);
				}
				else //cas dessin normal (gauche vers droite et haut vers bas)
				{
					p_g.FillRectangle(myBrush, Origine.X, Origine.Y, TailleForme.Width, TailleForme.Height);
				}
			}
		}
	}
}
