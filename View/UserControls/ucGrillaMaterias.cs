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
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void cargarGrilla()
        {
            MateriaService s = new MateriaService();

            try
            {
                Materias = s.GetAll();
                dgvGrilla.DataSource = Materias.FindAll(x => x.Deshabilitado == false);
                dgvGrilla.Columns["Id"].HeaderText = "Código";
                dgvGrilla.Columns["Deshabilitado"].DisplayIndex = dgvGrilla.Columns.Count - 1;
                dgvGrilla.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
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
                                                        || x.Carrera.ToString().ToUpper().Contains(busqueda)
                                                        || (x.Cuatrimestre == null ? ("ANUAL").Contains(busqueda) : x.Cuatrimestre.ToString().Contains(busqueda)));
                dgvGrilla.DataSource = lista;
                dgvGrilla.Columns["Deshabilitado"].Visible = true;
            }
        }

        private void btnCorrelativas_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            Materia materia = (Materia)dgvGrilla.SelectedRows[0].DataBoundItem;

            frmMateriasCorrelativas frm = new frmMateriasCorrelativas(materia);
            frm.ShowDialog();
        }

        private void dgvGrilla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvGrilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Carrera"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvGrilla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
            {
                if (e.ColumnIndex == dgvGrilla.Columns["Cuatrimestre"].Index)
                {
                    e.Value = "Anual";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
