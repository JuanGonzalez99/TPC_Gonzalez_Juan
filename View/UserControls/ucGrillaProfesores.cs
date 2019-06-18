using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Models;
using AccesoDatos.Services;
using View.Forms;
using Entities.Helpers;

namespace View
{
    public partial class ucGrillaProfesores : UserControl
    {
        private List<Profesor> Profesores { get; set; }

        public ucGrillaProfesores()
        {
            InitializeComponent();
        }

        private void ucGrillaProfesores_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProfesor frm = new frmProfesor();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmProfesor frm = new frmProfesor((Profesor)dgvGrilla.SelectedRows[0].DataBoundItem);
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

                ProfesorService s = new ProfesorService();
                Profesor entidad = (Profesor)dgvGrilla.SelectedRows[0].DataBoundItem;
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
            ProfesorService s = new ProfesorService();

            try
            {
                Profesores = s.GetAll();
                dgvGrilla.DataSource = Profesores;
                dgvGrilla.Columns["Id"].HeaderText = "Legajo";
                dgvGrilla.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
                dgvGrilla.Columns["FechaIngreso"].HeaderText = "Fecha de ingreso";
                dgvGrilla.Columns["FechaIngreso"].DisplayIndex = dgvGrilla.Columns["FechaNac"].Index;
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
                dgvGrilla.DataSource = Profesores;
            }
            else
            {
                string busqueda = txtBuscar.Text.ToUpper();
                List<Profesor> lista = Profesores.FindAll(x => x.Id.ToString().Contains(busqueda)
                                                        || x.Apellido.ToUpper().Contains(busqueda)
                                                        || x.Nombre.ToUpper().Contains(busqueda)
                                                        || x.FechaNac.ToShortDateString().Contains(busqueda)
                                                        || x.FechaIngreso.ToShortDateString().Contains(busqueda));
                dgvGrilla.DataSource = lista;
            }
        }
    }
}
