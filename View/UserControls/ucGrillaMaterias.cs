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

namespace View.UserControls
{
    public partial class ucGrillaMaterias : UserControl
    {
        private List<Materia> Materias { get; set; }

        public ucGrillaMaterias()
        {
            InitializeComponent();
        }

        private void ucGrillaMaterias_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMateria frm = new frmMateria();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmMateria frm = new frmMateria((Materia)dgvGrilla.SelectedRows[0].DataBoundItem);
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

                MateriaService s = new MateriaService();
                Materia entidad = (Materia)dgvGrilla.SelectedRows[0].DataBoundItem;
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
            MateriaService s = new MateriaService();

            try
            {
                Materias = s.GetAll();
                dgvGrilla.DataSource = Materias.FindAll(x => x.Deshabilitado == false);
                dgvGrilla.Columns["Deshabilitado"].DisplayIndex = dgvGrilla.Columns.Count - 1;
                dgvGrilla.Columns["Deshabilitado"].Visible = false;
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
                dgvGrilla.DataSource = Materias.FindAll(x => x.Deshabilitado == false);
                dgvGrilla.Columns["Deshabilitado"].Visible = false;
            }
            else
            {
                string busqueda = txtBuscar.Text.ToUpper();
                List<Materia> lista = Materias.FindAll(x => x.Id.ToString().Contains(busqueda)
                                                        || x.Nombre.ToUpper().Contains(busqueda)
                                                        || x.Carrera.ToString().ToUpper().Contains(busqueda));
                dgvGrilla.DataSource = lista;
                dgvGrilla.Columns["Deshabilitado"].Visible = true;
            }
        }
    }
}
