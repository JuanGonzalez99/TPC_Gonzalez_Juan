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
    public partial class frmAltaProfesor : Form
    {
        private Profesor profesor = null;
        private Boolean Edit;

        public frmAltaProfesor()
        {
            InitializeComponent();
            Edit = false;
        }

        public frmAltaProfesor(Profesor profesor)
        {
            InitializeComponent();
            this.profesor = profesor;
            Edit = true;
        }

        private void frmAltaProfesor_Load(object sender, EventArgs e)
        {
            if (Edit)
            {
                txtNombre.Text = profesor.Nombre;
                txtApellido.Text = profesor.Apellido;
                txtID.Text = profesor.Id.ToString();
                dtpNacimiento.Value = profesor.FechaNac;
                dtpIngreso.Value = profesor.FechaIngreso;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
