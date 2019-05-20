﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos.Services;
using Entities;

namespace View.Forms
{
    public partial class frmProfesor : Form
    {
        private Profesor Profesor { get; set; }

        public frmProfesor()
        {
            InitializeComponent();
        }

        public frmProfesor(Profesor profesor)
        {
            InitializeComponent();
            this.Profesor = profesor;
        }

        private void frmProfesor_Load(object sender, EventArgs e)
        {
            if (this.Profesor != null)
            {
                txtID.Text = Profesor.Id.ToString();
                txtApellido.Text = Profesor.Apellido;
                txtNombre.Text = Profesor.Nombre;
                dtpNacimiento.Value = Profesor.FechaNac;
                dtpFechaIngreso.Value = Profesor.FechaIngreso;
            }
            else
            {
                dtpNacimiento.Value = DateTime.Now.AddYears(-18);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                if (Profesor == null) Profesor = new Profesor();
                Profesor.Apellido = txtApellido.Text;
                Profesor.Nombre = txtNombre.Text;
                Profesor.FechaNac = dtpNacimiento.Value;
                Profesor.FechaIngreso = dtpFechaIngreso.Value;

                ProfesorService s = new ProfesorService();
                if (this.Profesor.Id != 0)
                    s.Update(Profesor);
                else
                    s.Insert(Profesor);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (WarningException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void validarEntidad()
        {
            if (txtApellido.Text.Trim() == "" || txtNombre.Text.Trim() == "")
                throw new WarningException("Debe completar todos los campos");

            if (dtpNacimiento.Value.AddYears(18) > DateTime.Now)
                throw new WarningException("No se pueden registrar menores de edad como profesores");
        }
    }
}
