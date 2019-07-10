namespace View.Forms
{
    partial class frmInscripcion
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
            this.dtpApertura = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCierre = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpAño = new System.Windows.Forms.DateTimePicker();
            this.cmbCuatrimestre = new System.Windows.Forms.ComboBox();
            this.chbAnual = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtpApertura
            // 
            this.dtpApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpApertura.Location = new System.Drawing.Point(104, 161);
            this.dtpApertura.Name = "dtpApertura";
            this.dtpApertura.ShowUpDown = true;
            this.dtpApertura.Size = new System.Drawing.Size(138, 20);
            this.dtpApertura.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Apertura:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(150, 283);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 33);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(40, 283);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(92, 33);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cuatrimestre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Año:";
            // 
            // dtpCierre
            // 
            this.dtpCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCierre.Location = new System.Drawing.Point(104, 209);
            this.dtpCierre.Name = "dtpCierre";
            this.dtpCierre.ShowUpDown = true;
            this.dtpCierre.Size = new System.Drawing.Size(138, 20);
            this.dtpCierre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Cierre:";
            // 
            // dtpAño
            // 
            this.dtpAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAño.Location = new System.Drawing.Point(104, 66);
            this.dtpAño.Name = "dtpAño";
            this.dtpAño.ShowUpDown = true;
            this.dtpAño.Size = new System.Drawing.Size(138, 20);
            this.dtpAño.TabIndex = 1;
            // 
            // cmbCuatrimestre
            // 
            this.cmbCuatrimestre.FormattingEnabled = true;
            this.cmbCuatrimestre.Location = new System.Drawing.Point(174, 112);
            this.cmbCuatrimestre.Name = "cmbCuatrimestre";
            this.cmbCuatrimestre.Size = new System.Drawing.Size(68, 21);
            this.cmbCuatrimestre.TabIndex = 2;
            // 
            // chbAnual
            // 
            this.chbAnual.AutoSize = true;
            this.chbAnual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbAnual.Location = new System.Drawing.Point(34, 114);
            this.chbAnual.Name = "chbAnual";
            this.chbAnual.Size = new System.Drawing.Size(53, 17);
            this.chbAnual.TabIndex = 23;
            this.chbAnual.Text = "Anual";
            this.chbAnual.UseVisualStyleBackColor = true;
            this.chbAnual.CheckedChanged += new System.EventHandler(this.chbAnual_CheckedChanged);
            // 
            // frmInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 328);
            this.Controls.Add(this.chbAnual);
            this.Controls.Add(this.cmbCuatrimestre);
            this.Controls.Add(this.dtpAño);
            this.Controls.Add(this.dtpCierre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpApertura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInscripcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inscripcion";
            this.Load += new System.EventHandler(this.frmInscripcion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpApertura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCierre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpAño;
        private System.Windows.Forms.ComboBox cmbCuatrimestre;
        private System.Windows.Forms.CheckBox chbAnual;
    }
}