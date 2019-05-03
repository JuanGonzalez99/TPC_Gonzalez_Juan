namespace View
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.tsmAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.atsmAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsmAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProfesor = new System.Windows.Forms.ToolStripMenuItem();
            this.atsmProfesor = new System.Windows.Forms.ToolStripMenuItem();
            this.mtsmProfesor = new System.Windows.Forms.ToolStripMenuItem();
            this.aAlumnotsm = new System.Windows.Forms.ToolStripMenuItem();
            this.aProfesortsm = new System.Windows.Forms.ToolStripMenuItem();
            this.mProfesortsm = new System.Windows.Forms.ToolStripMenuItem();
            this.mAlumnotsm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMenu
            // 
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAlumno,
            this.tsmProfesor});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(1085, 24);
            this.mnsMenu.TabIndex = 3;
            this.mnsMenu.Text = "Menu";
            // 
            // tsmAlumno
            // 
            this.tsmAlumno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atsmAlumno,
            this.mtsmAlumno});
            this.tsmAlumno.Name = "tsmAlumno";
            this.tsmAlumno.Size = new System.Drawing.Size(67, 20);
            this.tsmAlumno.Text = "Alumnos";
            // 
            // atsmAlumno
            // 
            this.atsmAlumno.Name = "atsmAlumno";
            this.atsmAlumno.Size = new System.Drawing.Size(180, 22);
            this.atsmAlumno.Text = "Agregar";
            this.atsmAlumno.Click += new System.EventHandler(this.atsmAlumno_Click);
            // 
            // mtsmAlumno
            // 
            this.mtsmAlumno.Name = "mtsmAlumno";
            this.mtsmAlumno.Size = new System.Drawing.Size(180, 22);
            this.mtsmAlumno.Text = "Modificar";
            this.mtsmAlumno.Click += new System.EventHandler(this.mtsmAlumno_Click);
            // 
            // tsmProfesor
            // 
            this.tsmProfesor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atsmProfesor,
            this.mtsmProfesor});
            this.tsmProfesor.Name = "tsmProfesor";
            this.tsmProfesor.Size = new System.Drawing.Size(74, 20);
            this.tsmProfesor.Text = "Profesores";
            // 
            // atsmProfesor
            // 
            this.atsmProfesor.Name = "atsmProfesor";
            this.atsmProfesor.Size = new System.Drawing.Size(180, 22);
            this.atsmProfesor.Text = "Agregar";
            this.atsmProfesor.Click += new System.EventHandler(this.atsmProfesor_Click);
            // 
            // mtsmProfesor
            // 
            this.mtsmProfesor.Name = "mtsmProfesor";
            this.mtsmProfesor.Size = new System.Drawing.Size(125, 22);
            this.mtsmProfesor.Text = "Modificar";
            this.mtsmProfesor.Click += new System.EventHandler(this.mtsmProfesor_Click);
            // 
            // aAlumnotsm
            // 
            this.aAlumnotsm.Name = "aAlumnotsm";
            this.aAlumnotsm.Size = new System.Drawing.Size(32, 19);
            // 
            // aProfesortsm
            // 
            this.aProfesortsm.Name = "aProfesortsm";
            this.aProfesortsm.Size = new System.Drawing.Size(32, 19);
            // 
            // mProfesortsm
            // 
            this.mProfesortsm.Name = "mProfesortsm";
            this.mProfesortsm.Size = new System.Drawing.Size(32, 19);
            // 
            // mAlumnotsm
            // 
            this.mAlumnotsm.Name = "mAlumnotsm";
            this.mAlumnotsm.Size = new System.Drawing.Size(32, 19);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 637);
            this.Controls.Add(this.mnsMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicación";
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem aAlumnotsm;
        private System.Windows.Forms.ToolStripMenuItem mAlumnotsm;
        private System.Windows.Forms.ToolStripMenuItem aProfesortsm;
        private System.Windows.Forms.ToolStripMenuItem mProfesortsm;
        private System.Windows.Forms.ToolStripMenuItem tsmAlumno;
        private System.Windows.Forms.ToolStripMenuItem atsmAlumno;
        private System.Windows.Forms.ToolStripMenuItem mtsmAlumno;
        private System.Windows.Forms.ToolStripMenuItem tsmProfesor;
        private System.Windows.Forms.ToolStripMenuItem atsmProfesor;
        private System.Windows.Forms.ToolStripMenuItem mtsmProfesor;
    }
}