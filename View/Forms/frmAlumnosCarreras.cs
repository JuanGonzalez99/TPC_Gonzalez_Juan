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
    public partial class frmAlumnosCarreras : Form
    {
        private Alumno alumno { get; set; }

        public frmAlumnosCarreras()
        {
            InitializeComponent();
        }

        public frmAlumnosCarreras(Alumno alumno)
        {
            InitializeComponent();
            this.alumno = alumno;
        }

        private void frmAlumnosCarreras_Load(object sender, EventArgs e)
        {
            CarreraService s = new CarreraService();
            cmbCarreras.DataSource = s.GetAll();

            this.Text = alumno.Apellido + ", " + alumno.Nombre;
            cargarGrilla();
        }

        private void btnAsignarCarrera_Click(object sender, EventArgs e)
        {
            if (cmbCarreras.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una carrera", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Carrera carrera = (Carrera)cmbCarreras.SelectedItem;
            CarreraService s = new CarreraService();

            if (s.GetByAlumnoId(alumno.Id).Any(x => x.Id == carrera.Id))
            {
                MessageBox.Show("El alumno ya tiene asociada esa carrera", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            new AlumnoService().AsignarCarrera(alumno.Id, carrera.Id);

            cargarGrilla();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvCarreras, "Debe seleccionar una carrera. "))
                return;

            if (!CommonHelper.Confirma("¿Está seguro que desea quitar esta carrera?"))
                return;

            var carrera = (Carrera)dgvCarreras.SelectedRows[0].DataBoundItem;

            new AlumnoService().QuitarCarrera(alumno.Id, carrera.Id);

            cargarGrilla();
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
