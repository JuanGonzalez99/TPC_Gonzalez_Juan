namespace View.Forms
{
    partial class frmCarrerasAlumno
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnAsignarCarrera = new System.Windows.Forms.Button();
            this.cmbCarreras = new System.Windows.Forms.ComboBox();
            this.lblCarreras = new System.Windows.Forms.Label();
            this.dgvCarreras = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVolver.Location = new System.Drawing.Point(272, 238);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 33);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnAsignarCarrera
            // 
            this.btnAsignarCarrera.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAsignarCarrera.Location = new System.Drawing.Point(32, 238);
            this.btnAsignarCarrera.Name = "btnAsignarCarrera";
            this.btnAsignarCarrera.Size = new System.Drawing.Size(100, 33);
            this.btnAsignarCarrera.TabIndex = 6;
            this.btnAsignarCarrera.Text = "Asignar carrera";
            this.btnAsignarCarrera.UseVisualStyleBackColor = true;
            this.btnAsignarCarrera.Click += new System.EventHandler(this.btnAsignarCarrera_Click);
            // 
            // cmbCarreras
            // 
            this.cmbCarreras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCarreras.FormattingEnabled = true;
            this.cmbCarreras.Location = new System.Drawing.Point(84, 164);
            this.cmbCarreras.Name = "cmbCarreras";
            this.cmbCarreras.Size = new System.Drawing.Size(288, 21);
            this.cmbCarreras.TabIndex = 5;
            // 
            // lblCarreras
            // 
            this.lblCarreras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarreras.AutoSize = true;
            this.lblCarreras.Location = new System.Drawing.Point(29, 167);
            this.lblCarreras.Name = "lblCarreras";
            this.lblCarreras.Size = new System.Drawing.Size(49, 13);
            this.lblCarreras.TabIndex = 7;
            this.lblCarreras.Text = "Carreras:";
            // 
            // dgvCarreras
            // 
            this.dgvCarreras.AllowUserToAddRows = false;
            this.dgvCarreras.AllowUserToDeleteRows = false;
            this.dgvCarreras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCarreras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCarreras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarreras.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCarreras.Location = new System.Drawing.Point(0, 0);
            this.dgvCarreras.Name = "dgvCarreras";
            this.dgvCarreras.RowHeadersVisible = false;
            this.dgvCarreras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarreras.Size = new System.Drawing.Size(410, 111);
            this.dgvCarreras.TabIndex = 4;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnQuitar.Location = new System.Drawing.Point(154, 238);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(96, 33);
            this.btnQuitar.TabIndex = 9;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // frmAlumnosCarreras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 292);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAsignarCarrera);
            this.Controls.Add(this.cmbCarreras);
            this.Controls.Add(this.lblCarreras);
            this.Controls.Add(this.dgvCarreras);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAlumnosCarreras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmAlumnosCarreras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnAsignarCarrera;
        private System.Windows.Forms.ComboBox cmbCarreras;
        private System.Windows.Forms.Label lblCarreras;
        private System.Windows.Forms.DataGridView dgvCarreras;
        private System.Windows.Forms.Button btnQuitar;
    }
}