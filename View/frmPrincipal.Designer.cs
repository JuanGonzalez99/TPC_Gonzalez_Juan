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
            this.tsmProfesor = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsmAlumno.Name = "tsmAlumno";
            this.tsmAlumno.Size = new System.Drawing.Size(62, 20);
            this.tsmAlumno.Text = "Alumno";
            this.tsmAlumno.Click += new System.EventHandler(this.tsmAlumno_Click);
            // 
            // tsmProfesor
            // 
            this.tsmProfesor.Name = "tsmProfesor";
            this.tsmProfesor.Size = new System.Drawing.Size(63, 20);
            this.tsmProfesor.Text = "Profesor";
            this.tsmProfesor.Click += new System.EventHandler(this.tsmProfesor_Click);
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
            this.Text = "Aplicación";
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmAlumno;
        private System.Windows.Forms.ToolStripMenuItem tsmProfesor;
    }
}