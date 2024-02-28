using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOEL_TP2MiniPaint.Classes
{
	public class MonCercle : Forme
	{
		public MonCercle() { } //Constructeur vide pour la sérialisation

		public MonCercle(PointF p_origine, Size p_taille, Pen p_crayon, bool p_pleine) : base(p_origine, p_taille, p_crayon, p_pleine) { } //Surcharge constructeur

		public override void Dessiner(Graphics p_g)
		{
			if (!Pleine) //on regarde si la forme est pleine ou vide
			{
				p_g.DrawEllipse(new Pen(CouleurCrayon, TailleCrayon), Origine.X, Origine.Y, TailleForme.Width, TailleForme.Height);
			}
			else
			{
				p_g.FillEllipse(new SolidBrush(CouleurCrayon), Origine.X, Origine.Y, TailleForme.Width, TailleForme.Height);
			}
		}

	}
}
