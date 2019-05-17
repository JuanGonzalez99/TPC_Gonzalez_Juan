using System;
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
        private Profesor profesor { get; set; }
        private bool Edit { get; set; }

        public frmProfesor()
        {
            InitializeComponent();
            Edit = false;
            this.profesor = new Profesor();
        }

        public frmProfesor(Profesor profesor)
        {
            InitializeComponent();
            Edit = true;
            this.profesor = profesor;
        }

        private void frmProfesor_Load(object sender, EventArgs e)
        {
            if (Edit)
            {
                txtID.Text = profesor.Id.ToString();
                txtApellido.Text = profesor.Apellido;
                txtNombre.Text = profesor.Nombre;
                dtpNacimiento.Value = profesor.FechaNac;
                dtpFechaIngreso.Value = profesor.FechaIngreso;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim() == "" || txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia", MessageBoxButtons.OK);
                return;
            }

            ProfesorService s = new ProfesorService();
            profesor.Apellido = txtApellido.Text;
            profesor.Nombre = txtNombre.Text;
            profesor.FechaNac = dtpNacimiento.Value;
            profesor.FechaIngreso = dtpFechaIngreso.Value;

            if (Edit)
                s.Update(profesor);
            else
                s.Insert(profesor);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
