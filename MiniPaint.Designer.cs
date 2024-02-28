namespace NOEL_TP2MiniPaint
{
	partial class MiniPaint
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniPaint));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.annulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.suivantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbFormes = new System.Windows.Forms.GroupBox();
			this.btPolygone = new System.Windows.Forms.Button();
			this.btFill = new System.Windows.Forms.Button();
			this.btLigne = new System.Windows.Forms.Button();
			this.btTriangle = new System.Windows.Forms.Button();
			this.btCercle = new System.Windows.Forms.Button();
			this.btRectangle = new System.Windows.Forms.Button();
			this.gbCrayon = new System.Windows.Forms.GroupBox();
			this.rbPleine = new System.Windows.Forms.RadioButton();
			this.rbVide = new System.Windows.Forms.RadioButton();
			this.btCouleur = new System.Windows.Forms.Button();
			this.lbCouleurCrayon = new System.Windows.Forms.Label();
			this.lbTailleCrayon = new System.Windows.Forms.Label();
			this.numTailleCrayon = new System.Windows.Forms.NumericUpDown();
			this.tipRectangle = new System.Windows.Forms.ToolTip(this.components);
			this.tipCercle = new System.Windows.Forms.ToolTip(this.components);
			this.tipTriangle = new System.Windows.Forms.ToolTip(this.components);
			this.tipLigne = new System.Windows.Forms.ToolTip(this.components);
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.redimensionnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deplacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changerLaCouleurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.effacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tipPolygone = new System.Windows.Forms.ToolTip(this.components);
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.colorChangement = new System.Windows.Forms.ColorDialog();
			this.tipCrayon = new System.Windows.Forms.ToolTip(this.components);
			this.tipRemplissage = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1.SuspendLayout();
			this.gbFormes.SuspendLayout();
			this.gbCrayon.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTailleCrayon)).BeginInit();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.annulerToolStripMenuItem,
            this.suivantToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1111, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fichierToolStripMenuItem
			// 
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripMenuItem,
            this.enregistrerToolStripMenuItem});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			this.fichierToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
			this.fichierToolStripMenuItem.Text = "Fichier";
			// 
			// ouvrirToolStripMenuItem
			// 
			this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
			this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.ouvrirToolStripMenuItem.Text = "Ouvrir...";
			this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
			// 
			// enregistrerToolStripMenuItem
			// 
			this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
			this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.enregistrerToolStripMenuItem.Text = "Enregistrer...";
			this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
			// 
			// annulerToolStripMenuItem
			// 
			this.annulerToolStripMenuItem.Name = "annulerToolStripMenuItem";
			this.annulerToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
			this.annulerToolStripMenuItem.Text = "Annuler";
			this.annulerToolStripMenuItem.Click += new System.EventHandler(this.annulerToolStripMenuItem_Click);
			// 
			// suivantToolStripMenuItem
			// 
			this.suivantToolStripMenuItem.Name = "suivantToolStripMenuItem";
			this.suivantToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
			this.suivantToolStripMenuItem.Text = "Suivant";
			this.suivantToolStripMenuItem.Click += new System.EventHandler(this.suivantToolStripMenuItem_Click);
			// 
			// gbFormes
			// 
			this.gbFormes.Controls.Add(this.btPolygone);
			this.gbFormes.Controls.Add(this.btFill);
			this.gbFormes.Controls.Add(this.btLigne);
			this.gbFormes.Controls.Add(this.btTriangle);
			this.gbFormes.Controls.Add(this.btCercle);
			this.gbFormes.Controls.Add(this.btRectangle);
			this.gbFormes.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbFormes.Location = new System.Drawing.Point(8, 31);
			this.gbFormes.Name = "gbFormes";
			this.gbFormes.Size = new System.Drawing.Size(436, 202);
			this.gbFormes.TabIndex = 1;
			this.gbFormes.TabStop = false;
			this.gbFormes.Text = "Formes";
			// 
			// btPolygone
			// 
			this.btPolygone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btPolygone.BackgroundImage")));
			this.btPolygone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btPolygone.Location = new System.Drawing.Point(360, 31);
			this.btPolygone.Name = "btPolygone";
			this.btPolygone.Size = new System.Drawing.Size(63, 62);
			this.btPolygone.TabIndex = 4;
			this.btPolygone.Text = " ";
			this.btPolygone.UseVisualStyleBackColor = true;
			this.btPolygone.Click += new System.EventHandler(this.btType_Click);
			// 
			// btFill
			// 
			this.btFill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btFill.BackgroundImage")));
			this.btFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btFill.Location = new System.Drawing.Point(18, 123);
			this.btFill.Name = "btFill";
			this.btFill.Size = new System.Drawing.Size(63, 62);
			this.btFill.TabIndex = 6;
			this.btFill.Text = " ";
			this.btFill.UseVisualStyleBackColor = true;
			this.btFill.Click += new System.EventHandler(this.btFill_Click);
			// 
			// btLigne
			// 
			this.btLigne.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLigne.BackgroundImage")));
			this.btLigne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btLigne.Location = new System.Drawing.Point(276, 31);
			this.btLigne.Name = "btLigne";
			this.btLigne.Size = new System.Drawing.Size(63, 62);
			this.btLigne.TabIndex = 3;
			this.btLigne.Text = " ";
			this.btLigne.UseVisualStyleBackColor = true;
			this.btLigne.Click += new System.EventHandler(this.btType_Click);
			// 
			// btTriangle
			// 
			this.btTriangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btTriangle.BackgroundImage")));
			this.btTriangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btTriangle.Location = new System.Drawing.Point(189, 31);
			this.btTriangle.Name = "btTriangle";
			this.btTriangle.Size = new System.Drawing.Size(63, 62);
			this.btTriangle.TabIndex = 2;
			this.btTriangle.Text = " ";
			this.btTriangle.UseVisualStyleBackColor = true;
			this.btTriangle.Click += new System.EventHandler(this.btType_Click);
			// 
			// btCercle
			// 
			this.btCercle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btCercle.BackgroundImage")));
			this.btCercle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btCercle.Location = new System.Drawing.Point(102, 31);
			this.btCercle.Name = "btCercle";
			this.btCercle.Size = new System.Drawing.Size(63, 62);
			this.btCercle.TabIndex = 1;
			this.btCercle.Text = " ";
			this.btCercle.UseVisualStyleBackColor = true;
			this.btCercle.Click += new System.EventHandler(this.btType_Click);
			// 
			// btRectangle
			// 
			this.btRectangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btRectangle.BackgroundImage")));
			this.btRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btRectangle.Location = new System.Drawing.Point(18, 31);
			this.btRectangle.Name = "btRectangle";
			this.btRectangle.Size = new System.Drawing.Size(63, 62);
			this.btRectangle.TabIndex = 0;
			this.btRectangle.Text = " ";
			this.btRectangle.UseVisualStyleBackColor = true;
			this.btRectangle.Click += new System.EventHandler(this.btType_Click);
			// 
			// gbCrayon
			// 
			this.gbCrayon.Controls.Add(this.rbPleine);
			this.gbCrayon.Controls.Add(this.rbVide);
			this.gbCrayon.Controls.Add(this.btCouleur);
			this.gbCrayon.Controls.Add(this.lbCouleurCrayon);
			this.gbCrayon.Controls.Add(this.lbTailleCrayon);
			this.gbCrayon.Controls.Add(this.numTailleCrayon);
			this.gbCrayon.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbCrayon.Location = new System.Drawing.Point(505, 31);
			this.gbCrayon.Name = "gbCrayon";
			this.gbCrayon.Size = new System.Drawing.Size(473, 202);
			this.gbCrayon.TabIndex = 5;
			this.gbCrayon.TabStop = false;
			this.gbCrayon.Text = "Crayon";
			// 
			// rbPleine
			// 
			this.rbPleine.AutoSize = true;
			this.rbPleine.Location = new System.Drawing.Point(251, 141);
			this.rbPleine.Name = "rbPleine";
			this.rbPleine.Size = new System.Drawing.Size(168, 27);
			this.rbPleine.TabIndex = 5;
			this.rbPleine.Text = "Forme pleine";
			this.rbPleine.UseVisualStyleBackColor = true;
			this.rbPleine.CheckedChanged += new System.EventHandler(this.rbPleine_CheckedChanged);
			// 
			// rbVide
			// 
			this.rbVide.AutoSize = true;
			this.rbVide.Checked = true;
			this.rbVide.Location = new System.Drawing.Point(251, 99);
			this.rbVide.Name = "rbVide";
			this.rbVide.Size = new System.Drawing.Size(151, 27);
			this.rbVide.TabIndex = 4;
			this.rbVide.TabStop = true;
			this.rbVide.Text = "Forme vide";
			this.rbVide.UseVisualStyleBackColor = true;
			// 
			// btCouleur
			// 
			this.btCouleur.BackColor = System.Drawing.Color.Black;
			this.btCouleur.Location = new System.Drawing.Point(136, 113);
			this.btCouleur.Name = "btCouleur";
			this.btCouleur.Size = new System.Drawing.Size(43, 43);
			this.btCouleur.TabIndex = 3;
			this.btCouleur.Text = " ";
			this.btCouleur.UseVisualStyleBackColor = false;
			this.btCouleur.Click += new System.EventHandler(this.btCouleur_Click);
			// 
			// lbCouleurCrayon
			// 
			this.lbCouleurCrayon.AutoSize = true;
			this.lbCouleurCrayon.Location = new System.Drawing.Point(7, 123);
			this.lbCouleurCrayon.Name = "lbCouleurCrayon";
			this.lbCouleurCrayon.Size = new System.Drawing.Size(123, 23);
			this.lbCouleurCrayon.TabIndex = 2;
			this.lbCouleurCrayon.Text = "Couleur : ";
			// 
			// lbTailleCrayon
			// 
			this.lbTailleCrayon.AutoSize = true;
			this.lbTailleCrayon.Location = new System.Drawing.Point(6, 39);
			this.lbTailleCrayon.Name = "lbTailleCrayon";
			this.lbTailleCrayon.Size = new System.Drawing.Size(90, 23);
			this.lbTailleCrayon.TabIndex = 1;
			this.lbTailleCrayon.Text = "Taille : ";
			// 
			// numTailleCrayon
			// 
			this.numTailleCrayon.Location = new System.Drawing.Point(113, 37);
			this.numTailleCrayon.Name = "numTailleCrayon";
			this.numTailleCrayon.Size = new System.Drawing.Size(66, 31);
			this.numTailleCrayon.TabIndex = 0;
			this.numTailleCrayon.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numTailleCrayon.ValueChanged += new System.EventHandler(this.numTailleCrayon_ValueChanged);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Enabled = false;
			this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redimensionnerToolStripMenuItem,
            this.deplacerToolStripMenuItem,
            this.changerLaCouleurToolStripMenuItem,
            this.effacerToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(203, 100);
			// 
			// redimensionnerToolStripMenuItem
			// 
			this.redimensionnerToolStripMenuItem.Enabled = false;
			this.redimensionnerToolStripMenuItem.Name = "redimensionnerToolStripMenuItem";
			this.redimensionnerToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
			this.redimensionnerToolStripMenuItem.Text = "Redimensionner";
			this.redimensionnerToolStripMenuItem.Click += new System.EventHandler(this.redimensionnerToolStripMenuItem_Click);
			// 
			// deplacerToolStripMenuItem
			// 
			this.deplacerToolStripMenuItem.Enabled = false;
			this.deplacerToolStripMenuItem.Name = "deplacerToolStripMenuItem";
			this.deplacerToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
			this.deplacerToolStripMenuItem.Text = "Déplacer";
			this.deplacerToolStripMenuItem.Click += new System.EventHandler(this.deplacerToolStripMenuItem_Click);
			// 
			// changerLaCouleurToolStripMenuItem
			// 
			this.changerLaCouleurToolStripMenuItem.Enabled = false;
			this.changerLaCouleurToolStripMenuItem.Name = "changerLaCouleurToolStripMenuItem";
			this.changerLaCouleurToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
			this.changerLaCouleurToolStripMenuItem.Text = "Changer la couleur";
			this.changerLaCouleurToolStripMenuItem.Click += new System.EventHandler(this.changerLaCouleurToolStripMenuItem_Click);
			// 
			// effacerToolStripMenuItem
			// 
			this.effacerToolStripMenuItem.Enabled = false;
			this.effacerToolStripMenuItem.Name = "effacerToolStripMenuItem";
			this.effacerToolStripMenuItem.Size = new System.Drawing.Size(202, 24);
			this.effacerToolStripMenuItem.Text = "Effacer la forme";
			this.effacerToolStripMenuItem.Click += new System.EventHandler(this.effacerToolStripMenuItem_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// MiniPaint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1111, 517);
			this.ContextMenuStrip = this.contextMenuStrip;
			this.Controls.Add(this.gbCrayon);
			this.Controls.Add(this.gbFormes);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MiniPaint";
			this.Text = "MiniPaint";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MiniPaint_Paint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MiniPaint_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MiniPaint_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MiniPaint_MouseUp);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.gbFormes.ResumeLayout(false);
			this.gbCrayon.ResumeLayout(false);
			this.gbCrayon.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTailleCrayon)).EndInit();
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
		private System.Windows.Forms.GroupBox gbFormes;
		private System.Windows.Forms.Button btRectangle;
		private System.Windows.Forms.Button btCercle;
		private System.Windows.Forms.Button btPolygone;
		private System.Windows.Forms.Button btLigne;
		private System.Windows.Forms.Button btTriangle;
		private System.Windows.Forms.GroupBox gbCrayon;
		private System.Windows.Forms.ToolTip tipRectangle;
		private System.Windows.Forms.ToolTip tipCercle;
		private System.Windows.Forms.ToolTip tipTriangle;
		private System.Windows.Forms.ToolTip tipLigne;
		private System.Windows.Forms.Button btCouleur;
		private System.Windows.Forms.Label lbCouleurCrayon;
		private System.Windows.Forms.Label lbTailleCrayon;
		private System.Windows.Forms.NumericUpDown numTailleCrayon;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.RadioButton rbPleine;
		private System.Windows.Forms.RadioButton rbVide;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem redimensionnerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deplacerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changerLaCouleurToolStripMenuItem;
		private System.Windows.Forms.ToolTip tipPolygone;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripMenuItem annulerToolStripMenuItem;
		private System.Windows.Forms.ColorDialog colorChangement;
		private System.Windows.Forms.Button btFill;
		private System.Windows.Forms.ToolStripMenuItem suivantToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem effacerToolStripMenuItem;
		private System.Windows.Forms.ToolTip tipCrayon;
		private System.Windows.Forms.ToolTip tipRemplissage;
	}
}

