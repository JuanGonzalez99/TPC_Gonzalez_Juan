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

namespace View
{
    public partial class frmAlumno : Form
    {
        private Alumno alumno = null;
        private Boolean Edit;

        public frmAlumno()
        {
            InitializeComponent();
            Edit = false;
            this.alumno = new Alumno();
        }

        public frmAlumno(Alumno alumno)
        {
            InitializeComponent();
            Edit = true;
            this.alumno = alumno;
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            if (Edit)
            {
                txtID.Text = alumno.Id.ToString();
                txtApellido.Text = alumno.Apellido;
                txtNombre.Text = alumno.Nombre;
                dtpNacimiento.Value = alumno.FechaNac;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim() == "" || txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia", MessageBoxButtons.OK);
                return;
            }

            AlumnoService s = new AlumnoService();
            alumno.Apellido = txtApellido.Text;
            alumno.Nombre = txtNombre.Text;
            alumno.FechaNac = dtpNacimiento.Value;

            if (Edit)
                s.Update(alumno);
            else
                s.Insert(alumno);

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
