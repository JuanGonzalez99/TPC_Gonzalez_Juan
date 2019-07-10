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
                txtDNI.Text = profesor.DNI;
                txtApellido.Text = profesor.Apellido;
                txtNombre.Text = profesor.Nombre;
                dtpNacimiento.Value = profesor.FechaNac;
                dtpFechaIngreso.Value = profesor.FechaIngreso;
            }
            else
            {
                dtpNacimiento.Value = DateTime.Today.AddYears(-18);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                ProfesorService s = new ProfesorService();

                if (this.profesor.Id != 0)
                    s.Update(profesor);
                else
                    s.Insert(profesor);

                CommonHelper.ShowInfo("Profesor guardado con éxito.");
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

            if (dtpNacimiento.Value.AddYears(18) > DateTime.Today)
                errores += "No se pueden registrar menores de edad como profesores. " + Environment.NewLine;

            if (dtpFechaIngreso.Value.Date > DateTime.Today)
                errores += "No se puede registrar una fecha de ingreso mayor a la fecha actual. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            if (profesor == null) profesor = new Profesor();
            profesor.DNI = txtDNI.Text;
            profesor.Apellido = txtApellido.Text;
            profesor.Nombre = txtNombre.Text;
            profesor.FechaNac = dtpNacimiento.Value;
            profesor.FechaIngreso = dtpFechaIngreso.Value;

            ProfesorService s = new ProfesorService();

            var profesores = s.GetAll().FindAll(x => x.Deshabilitado == false);

            foreach (var Profesor in profesores)
            {
                if (Profesor.Id != profesor.Id)
                {
                    if (Profesor.DNI == profesor.DNI)
                    {
                        throw new WarningException("Ya existe un profesor con el DNI " + Profesor.DNI + ".");
                    }
                }
            }
        }
    }
}
