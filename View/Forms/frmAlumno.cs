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
using Entities.Helpers;
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
                txtDNI.Text = alumno.DNI;
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

                AlumnoService s = new AlumnoService();

                if (this.alumno.Id != 0)
                    s.Update(alumno);
                else
                    s.Insert(alumno);

                CommonHelper.ShowInfo("Alumno guardado con éxito.");
                this.DialogResult = DialogResult.OK;
            }
            catch (WarningException ex)
            {
                CommonHelper.ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void validarEntidad()
        {
            string errores = "";
            int aux;

            if (txtDNI.Text.Trim() == "" || txtApellido.Text.Trim() == "" || txtNombre.Text.Trim() == "")
                errores += "Debe completar todos los campos. " + Environment.NewLine;

            if (txtDNI.Text != "" && !int.TryParse(txtDNI.Text, out aux))
                errores += "Ingrese el DNI únicamente con caracteres numéricos. " + Environment.NewLine;

            if (dtpNacimiento.Value.AddYears(16) > DateTime.Now)
                errores += "No se pueden registrar alumnos menores de 16. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            if (alumno == null) alumno = new Alumno();
            alumno.DNI = txtDNI.Text;
            alumno.Apellido = txtApellido.Text;
            alumno.Nombre = txtNombre.Text;
            alumno.FechaNac = dtpNacimiento.Value;

            AlumnoService s = new AlumnoService();

            var alumnos = s.GetAll().FindAll(x => x.Deshabilitado == false);

            foreach (var Alumno in alumnos)
            {
                if (Alumno.Id != alumno.Id) 
                {
                    if (Alumno.DNI == alumno.DNI)
                    {
                        throw new WarningException("Ya existe un alumno con el DNI " + Alumno.DNI + " .");
                    }
                }
            }
        }
    }
}
