using AccesoDatos.Services;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Forms
{
    public partial class frmCarrerasAlumno : Form
    {
        private Alumno alumno { get; set; }

        public frmCarrerasAlumno()
        {
            InitializeComponent();
        }

        public frmCarrerasAlumno(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;
        }

        private void frmAlumnosCarreras_Load(object sender, EventArgs e)
        {
            CarreraService s = new CarreraService();
            cmbCarreras.DataSource = s.GetAll().FindAll(x => x.Deshabilitado == false);

            this.Text = alumno.ToString();
            cargarGrilla();
        }

        private void btnAsignarCarrera_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCarreras.SelectedItem == null)
                {
                    CommonHelper.ShowWarning("Debe seleccionar una carrera");
                    return;
                }

                Carrera carrera = (Carrera)cmbCarreras.SelectedItem;
                CarreraService s = new CarreraService();

                if (s.GetByAlumnoId(alumno.Id).Any(x => x.Id == carrera.Id))
                {
                    CommonHelper.ShowWarning("El alumno ya tiene asociada esa carrera");
                    return;
                }

                new AlumnoService().AsignarCarrera(alumno.Id, carrera.Id);

                cargarGrilla();

            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonHelper.SeleccionoRegistro(dgvCarreras, "Debe seleccionar una carrera. "))
                    return;

                if (!CommonHelper.Confirma("¿Está seguro que desea quitar esta carrera?"))
                    return;

                var carrera = (Carrera)dgvCarreras.SelectedRows[0].DataBoundItem;

                new AlumnoService().QuitarCarrera(alumno.Id, carrera.Id);

                cargarGrilla();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void cargarGrilla()
        {
            try
            {
                dgvCarreras.DataSource = new CarreraService().GetByAlumnoId(alumno.Id).FindAll(x => x.Deshabilitado == false);
                dgvCarreras.Columns["Id"].HeaderText = "Código";

                dgvCarreras.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }
    }
}
