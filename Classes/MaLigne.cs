using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOEL_TP2MiniPaint.Classes
{
	public class MaLigne : Forme
	{
		public MaLigne() { } //Constructeur vide pour la sérialisation

		public MaLigne(PointF p_origine, Size p_taille, Pen p_crayon, bool p_pleine) : base(p_origine, p_taille, p_crayon, p_pleine) { } //Surcharge constructeur
		
		public override void updateListe()
		{
			LstFormesContours.Clear();
			Pen crayon = new Pen(Color.Red, 2);
			LstFormesContours.Add(new MonRectangle(new PointF(Origine.X - 5, Origine.Y - 5), new Size(10, 10), crayon, false));
			LstFormesContours.Add(new MonRectangle(new PointF(Fin.X - 5, Fin.Y - 5), new Size(10, 10), crayon, false));		
		}

		public override void Dessiner(Graphics p_g)
		{
			p_g.DrawLine(new Pen(CouleurCrayon, TailleCrayon), Origine.X, Origine.Y, Origine.X + TailleForme.Width, Origine.Y + TailleForme.Height);
		}

		public override bool Redimensionner(PointF p_loc)
		{
			int index = -1;
			for (int i = 0; i < LstFormesContours.Count; i++)
			{
				if (LstFormesContours[i].verifierSelection(p_loc))
				{
					index = i;
				}
			}

			if (index == 0)//gauche
			{
				Origine = p_loc;
				TailleForme = new Size((int)(Fin.X - Origine.X), (int)(Fin.Y - Origine.Y));
			}
			else if (index == 1)//droite
			{
				Fin = p_loc;
				TailleForme = new Size((int)(Fin.X - Origine.X), (int)(Fin.Y - Origine.Y));
			}
			
			return true;
		}
	}
}
