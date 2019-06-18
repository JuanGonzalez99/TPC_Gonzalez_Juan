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
using Entities.Models;

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

        private void validarEntidad()
        {
            string errores = "";

            if (txtApellido.Text.Trim() == "" || txtNombre.Text.Trim() == "")
                errores += "Debe completar todos los campos" + Environment.NewLine;

            if (dtpNacimiento.Value.AddYears(16) > DateTime.Now)
                errores += "No se pueden agregar alumnos menores de 16" + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }
        }
    }
}
