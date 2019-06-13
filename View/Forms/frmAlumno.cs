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
        private Alumno alumno { get; set; }

        public frmAlumno()
        {
            InitializeComponent();
        }

        public frmAlumno(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            if (this.alumno != null)
            {
                txtID.Text = alumno.Id.ToString();
                txtApellido.Text = alumno.Apellido;
                txtNombre.Text = alumno.Nombre;
                dtpNacimiento.Value = alumno.FechaNac;
            }
            else
            {
                dtpNacimiento.Value = DateTime.Now.AddYears(-16);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                if (alumno == null) alumno = new Alumno();
                alumno.Apellido = txtApellido.Text;
                alumno.Nombre = txtNombre.Text;
                alumno.FechaNac = dtpNacimiento.Value;

                AlumnoService s = new AlumnoService();
                if (this.alumno.Id != 0)
                    s.Update(alumno);
                else
                    s.Insert(alumno);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (WarningException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (dtpNacimiento.Value.AddYears(16) > DateTime.Now)
                throw new WarningException("No se pueden agregar alumnos menores de 16");
        }
    }
}
