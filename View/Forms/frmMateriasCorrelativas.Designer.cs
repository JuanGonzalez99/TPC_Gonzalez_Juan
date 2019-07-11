namespace View.Forms
{
    partial class frmMateriasCorrelativas
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
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.lblCarreras = new System.Windows.Forms.Label();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(150, 407);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(96, 33);
            this.btnQuitar.TabIndex = 15;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(268, 407);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 33);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(28, 407);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(100, 33);
            this.btnAsignar.TabIndex = 12;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(109, 307);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(223, 21);
            this.cmbMaterias.TabIndex = 11;
            // 
            // lblCarreras
            // 
            this.lblCarreras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCarreras.AutoSize = true;
            this.lblCarreras.Location = new System.Drawing.Point(54, 310);
            this.lblCarreras.Name = "lblCarreras";
            this.lblCarreras.Size = new System.Drawing.Size(45, 13);
            this.lblCarreras.TabIndex = 13;
            this.lblCarreras.Text = "Materia:";
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.AllowUserToAddRows = false;
            this.dgvMaterias.AllowUserToDeleteRows = false;
            this.dgvMaterias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMaterias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMaterias.Location = new System.Drawing.Point(0, 0);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.RowHeadersVisible = false;
            this.dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterias.Size = new System.Drawing.Size(403, 269);
            this.dgvMaterias.TabIndex = 10;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(109, 352);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(223, 21);
            this.cmbEstado.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Estado:";
            // 
            // frmMateriasCorrelativas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 450);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.cmbMaterias);
            this.Controls.Add(this.lblCarreras);
            this.Controls.Add(this.dgvMaterias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMateriasCorrelativas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Correlativas";
            this.Load += new System.EventHandler(this.frmMateriasCorrelativas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label lblCarreras;
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label1;
    }
}