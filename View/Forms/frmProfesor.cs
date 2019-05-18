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

        public frmProfesor()
        {
            InitializeComponent();
        }

        public frmProfesor(Profesor profesor)
        {
            InitializeComponent();
            this.profesor = profesor;
        }

        private void frmProfesor_Load(object sender, EventArgs e)
        {
            if (this.profesor != null)
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
            try
            {
                validarEntidad();

                if (profesor == null) profesor = new Profesor();
                profesor.Apellido = txtApellido.Text;
                profesor.Nombre = txtNombre.Text;
                profesor.FechaNac = dtpNacimiento.Value;
                profesor.FechaIngreso = dtpFechaIngreso.Value;

                ProfesorService s = new ProfesorService();
                if (this.profesor.Id != 0)
                    s.Update(profesor);
                else
                    s.Insert(profesor);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
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
                throw new Exception("Debe completar todos los campos");
        }
    }
}
