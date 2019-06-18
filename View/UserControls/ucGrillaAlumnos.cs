using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos.Services;
using Entities.Models;
using Entities.Helpers;

namespace View
{
    public partial class ucGrillaAlumnos : UserControl
    {
        private List<Alumno> Alumnos { get; set; }

        public ucGrillaAlumnos()
        {
            InitializeComponent();
        }

        private void ucGrillaAlumnos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAlumno frm = new frmAlumno();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;
            
            frmAlumno frm = new frmAlumno((Alumno)dgvGrilla.SelectedRows[0].DataBoundItem);
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            if (!CommonHelper.Confirma())
                return;

            try
            {
                AlumnoService s = new AlumnoService();
                Alumno entidad = (Alumno)dgvGrilla.SelectedRows[0].DataBoundItem;
                s.Delete(entidad.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarGrilla()
        {
            AlumnoService s = new AlumnoService();

            try
            {
                Alumnos = s.GetAll();
                dgvGrilla.DataSource = Alumnos;
                dgvGrilla.Columns["Id"].HeaderText = "Legajo";
                dgvGrilla.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
                dgvGrilla.Columns["Deshabilitado"].DisplayIndex = dgvGrilla.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                dgvGrilla.DataSource = Alumnos;
            }
            else
            {
                string busqueda = txtBuscar.Text.ToUpper();
                List<Alumno> lista = Alumnos.FindAll(x => x.Id.ToString().Contains(busqueda)
                                                        || x.Apellido.ToUpper().Contains(busqueda)
                                                        || x.Nombre.ToUpper().Contains(busqueda)
                                                        || x.FechaNac.ToShortDateString().Contains(busqueda));
                dgvGrilla.DataSource = lista;
            }
        }
    }
}
