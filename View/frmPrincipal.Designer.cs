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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.pnlUsuario = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSelec = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnCarreras = new System.Windows.Forms.Button();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.btnProfesores = new System.Windows.Forms.Button();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnInscripciones = new System.Windows.Forms.Button();
            this.btnComisiones = new System.Windows.Forms.Button();
            this.btnHorarios = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.pnlUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUsuario
            // 
            this.pnlUsuario.BackColor = System.Drawing.Color.Black;
            this.pnlUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlUsuario.Controls.Add(this.pictureBox1);
            this.pnlUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUsuario.Location = new System.Drawing.Point(0, 0);
            this.pnlUsuario.Name = "pnlUsuario";
            this.pnlUsuario.Size = new System.Drawing.Size(819, 120);
            this.pnlUsuario.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(931, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.pnlSelec);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.btnCarreras);
            this.panel1.Controls.Add(this.btnMaterias);
            this.panel1.Controls.Add(this.btnProfesores);
            this.panel1.Controls.Add(this.btnAlumnos);
            this.panel1.Controls.Add(this.btnInscripciones);
            this.panel1.Controls.Add(this.btnComisiones);
            this.panel1.Controls.Add(this.btnHorarios);
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 346);
            this.panel1.TabIndex = 0;
            // 
            // pnlSelec
            // 
            this.pnlSelec.BackColor = System.Drawing.Color.Black;
            this.pnlSelec.Location = new System.Drawing.Point(142, 3);
            this.pnlSelec.Name = "pnlSelec";
            this.pnlSelec.Size = new System.Drawing.Size(10, 30);
            this.pnlSelec.TabIndex = 21;
            // 
            // btnInicio
            // 
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(3, 3);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(146, 30);
            this.btnInicio.TabIndex = 20;
            this.btnInicio.Text = "   Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnCarreras
            // 
            this.btnCarreras.FlatAppearance.BorderSize = 0;
            this.btnCarreras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarreras.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnCarreras.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCarreras.Image = ((System.Drawing.Image)(resources.GetObject("btnCarreras.Image")));
            this.btnCarreras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarreras.Location = new System.Drawing.Point(3, 147);
            this.btnCarreras.Name = "btnCarreras";
            this.btnCarreras.Size = new System.Drawing.Size(146, 30);
            this.btnCarreras.TabIndex = 25;
            this.btnCarreras.Text = "  Carreras";
            this.btnCarreras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCarreras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCarreras.UseVisualStyleBackColor = true;
            this.btnCarreras.Click += new System.EventHandler(this.btnCarreras_Click);
            // 
            // btnMaterias
            // 
            this.btnMaterias.FlatAppearance.BorderSize = 0;
            this.btnMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterias.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnMaterias.ForeColor = System.Drawing.Color.White;
            this.btnMaterias.Image = ((System.Drawing.Image)(resources.GetObject("btnMaterias.Image")));
            this.btnMaterias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaterias.Location = new System.Drawing.Point(3, 111);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(146, 30);
            this.btnMaterias.TabIndex = 24;
            this.btnMaterias.Text = "  Materias";
            this.btnMaterias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaterias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaterias.UseVisualStyleBackColor = true;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // btnProfesores
            // 
            this.btnProfesores.FlatAppearance.BorderSize = 0;
            this.btnProfesores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfesores.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnProfesores.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProfesores.Image = ((System.Drawing.Image)(resources.GetObject("btnProfesores.Image")));
            this.btnProfesores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfesores.Location = new System.Drawing.Point(0, 75);
            this.btnProfesores.Name = "btnProfesores";
            this.btnProfesores.Size = new System.Drawing.Size(149, 30);
            this.btnProfesores.TabIndex = 23;
            this.btnProfesores.Text = " Profesores";
            this.btnProfesores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfesores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfesores.UseVisualStyleBackColor = true;
            this.btnProfesores.Click += new System.EventHandler(this.btnProfesores_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.FlatAppearance.BorderSize = 0;
            this.btnAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlumnos.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnAlumnos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAlumnos.Image = ((System.Drawing.Image)(resources.GetObject("btnAlumnos.Image")));
            this.btnAlumnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlumnos.Location = new System.Drawing.Point(0, 39);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(149, 30);
            this.btnAlumnos.TabIndex = 22;
            this.btnAlumnos.Text = " Alumnos";
            this.btnAlumnos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlumnos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnInscripciones
            // 
            this.btnInscripciones.FlatAppearance.BorderSize = 0;
            this.btnInscripciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscripciones.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnInscripciones.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInscripciones.Image = ((System.Drawing.Image)(resources.GetObject("btnInscripciones.Image")));
            this.btnInscripciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInscripciones.Location = new System.Drawing.Point(3, 219);
            this.btnInscripciones.Name = "btnInscripciones";
            this.btnInscripciones.Size = new System.Drawing.Size(146, 30);
            this.btnInscripciones.TabIndex = 28;
            this.btnInscripciones.Text = "  Inscripciones";
            this.btnInscripciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInscripciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInscripciones.UseVisualStyleBackColor = true;
            this.btnInscripciones.Click += new System.EventHandler(this.btnInscripciones_Click);
            // 
            // btnComisiones
            // 
            this.btnComisiones.FlatAppearance.BorderSize = 0;
            this.btnComisiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComisiones.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnComisiones.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnComisiones.Image = ((System.Drawing.Image)(resources.GetObject("btnComisiones.Image")));
            this.btnComisiones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComisiones.Location = new System.Drawing.Point(3, 183);
            this.btnComisiones.Name = "btnComisiones";
            this.btnComisiones.Size = new System.Drawing.Size(146, 30);
            this.btnComisiones.TabIndex = 27;
            this.btnComisiones.Text = "  Comisiones";
            this.btnComisiones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComisiones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComisiones.UseVisualStyleBackColor = true;
            this.btnComisiones.Click += new System.EventHandler(this.btnComisiones_Click);
            // 
            // btnHorarios
            // 
            this.btnHorarios.FlatAppearance.BorderSize = 0;
            this.btnHorarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHorarios.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnHorarios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHorarios.Image = ((System.Drawing.Image)(resources.GetObject("btnHorarios.Image")));
            this.btnHorarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHorarios.Location = new System.Drawing.Point(3, 291);
            this.btnHorarios.Name = "btnHorarios";
            this.btnHorarios.Size = new System.Drawing.Size(146, 30);
            this.btnHorarios.TabIndex = 26;
            this.btnHorarios.Text = "  Horarios";
            this.btnHorarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHorarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHorarios.UseVisualStyleBackColor = true;
            this.btnHorarios.Visible = false;
            this.btnHorarios.Click += new System.EventHandler(this.btnHorarios_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuarios.Image")));
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(3, 255);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(146, 30);
            this.btnUsuarios.TabIndex = 29;
            this.btnUsuarios.Text = "  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(151, 120);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(668, 346);
            this.pnlContenido.TabIndex = 21;
            // 
            // frmPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(819, 466);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicación";
            this.pnlUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlUsuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlSelec;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnCarreras;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.Button btnProfesores;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnInscripciones;
        private System.Windows.Forms.Button btnComisiones;
        private System.Windows.Forms.Button btnHorarios;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlContenido;
    }
}