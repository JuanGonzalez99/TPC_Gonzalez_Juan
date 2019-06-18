namespace View.Forms
{
    partial class frmMateria
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.cmbCuatrimestre = new System.Windows.Forms.ComboBox();
            this.cmbTipoCursada = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(111, 81);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(138, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(150, 283);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 33);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAceptar.Location = new System.Drawing.Point(40, 283);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 33);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Location = new System.Drawing.Point(111, 45);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(138, 20);
            this.txtID.TabIndex = 8;
            this.txtID.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ID:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Carrera:";
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Location = new System.Drawing.Point(111, 121);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(138, 21);
            this.cmbCarrera.TabIndex = 2;
            this.cmbCarrera.SelectedIndexChanged += new System.EventHandler(this.cmbCarrera_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Año:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cuatrimestre:";
            // 
            // cmbAño
            // 
            this.cmbAño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(111, 194);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(138, 21);
            this.cmbAño.TabIndex = 4;
            // 
            // cmbCuatrimestre
            // 
            this.cmbCuatrimestre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCuatrimestre.FormattingEnabled = true;
            this.cmbCuatrimestre.Location = new System.Drawing.Point(111, 234);
            this.cmbCuatrimestre.Name = "cmbCuatrimestre";
            this.cmbCuatrimestre.Size = new System.Drawing.Size(138, 21);
            this.cmbCuatrimestre.TabIndex = 5;
            // 
            // cmbTipoCursada
            // 
            this.cmbTipoCursada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoCursada.FormattingEnabled = true;
            this.cmbTipoCursada.Location = new System.Drawing.Point(111, 158);
            this.cmbTipoCursada.Name = "cmbTipoCursada";
            this.cmbTipoCursada.Size = new System.Drawing.Size(138, 21);
            this.cmbTipoCursada.TabIndex = 3;
            this.cmbTipoCursada.SelectedIndexChanged += new System.EventHandler(this.cmbTipoCursada_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tipo cursada:";
            // 
            // frmMateria
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(284, 328);
            this.Controls.Add(this.cmbTipoCursada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCuatrimestre);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCarrera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 367);
            this.Name = "frmMateria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materia";
            this.Load += new System.EventHandler(this.frmMateria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCarrera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.ComboBox cmbCuatrimestre;
        private System.Windows.Forms.ComboBox cmbTipoCursada;
        private System.Windows.Forms.Label label6;
    }
}