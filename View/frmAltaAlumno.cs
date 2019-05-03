using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace View
{
    public partial class frmAltaAlumno : Form
    {
        private Alumno alumno = null;
        private Boolean Edit;

        public frmAltaAlumno()
        {
            InitializeComponent();
            Edit = false;
        }

        public frmAltaAlumno(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;
            Edit = true;
        }

        private void frmAltaAlumno_Load(object sender, EventArgs e)
        {
            if (Edit)
            {
                txtNombre.Text = alumno.Nombre;
                txtApellido.Text = alumno.Apellido;
                txtID.Text = alumno.Id.ToString();
                dtpNacimiento.Value = alumno.FechaNac;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
