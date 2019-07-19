using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Forms;
using Entities.Helpers;
using Entities.Models;
using AccesoDatos.Services;

namespace View.UserControls
{
    public partial class ucGrillaComisiones : UserControl
    {
        private List<Comision> Comisiones { get; set; }

        public ucGrillaComisiones()
        {
            InitializeComponent();
        }

        private void ucGrillaComisiones_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmComision frm = new frmComision();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmComision frm = new frmComision((Comision)dgvGrilla.SelectedRows[0].DataBoundItem);
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
                ComisionService s = new ComisionService();
                Comision a = (Comision)dgvGrilla.SelectedRows[0].DataBoundItem;
                s.Delete(a.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarGrilla()
        {
            ComisionService s = new ComisionService();

            try
            {
                Comisiones = s.GetAll();
                if (txtBuscar.Text != "") txtBuscar.Text = "";
                dgvGrilla.DataSource = Comisiones.FindAll(x => x.Deshabilitado == false || chbDeshabilitados.Checked)
                    .OrderByDescending(x => x.Año)
                    .ThenBy(x => x.Cuatrimestre)
                    .ThenBy(x => x.Turno.Id)
                    .ThenBy(x => x.Materia.Nombre).ToList();
                dgvGrilla.Columns["Id"].Visible = false;
                dgvGrilla.Columns["Deshabilitado"].Visible = chbDeshabilitados.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Comision> lista = Comisiones.FindAll(x => x.Deshabilitado == false || chbDeshabilitados.Checked);

            if (txtBuscar.Text != "")
            {
                string busqueda = txtBuscar.Text.ToUpper();
                lista = lista.FindAll(x => x.Materia.ToString().ToUpper().Contains(busqueda)
                                    || x.Año.ToString().Contains(busqueda)
                                    || (x.Cuatrimestre == null ? ("ANUAL").Contains(busqueda) : x.Cuatrimestre.ToString().Contains(busqueda))
                                    || x.Turno.ToString().ToUpper().Contains(busqueda)
                                    || x.Modalidad.ToString().ToUpper().Contains(busqueda)
                                    || x.Profesor.ToString().ToUpper().Contains(busqueda)
                                    || (x.Ayudante == null ? /*("SIN AYUDANTE").Contains(busqueda)*/ false : x.Ayudante.ToString().ToUpper().Contains(busqueda)));
            }

            dgvGrilla.DataSource = lista
                    .OrderByDescending(x => x.Año)
                    .ThenBy(x => x.Cuatrimestre)
                    .ThenBy(x => x.Turno.Id)
                    .ThenBy(x => x.Materia.Id).ToList(); ;

            dgvGrilla.Columns["Deshabilitado"].Visible = chbDeshabilitados.Checked;
        }

        private void chbDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(sender, e);
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
                //else if (e.ColumnIndex == dgvGrilla.Columns["Ayudante"].Index)
                //{
                //    DataGridViewCellStyle style = new DataGridViewCellStyle(dgvGrilla.DefaultCellStyle);
                //    style.Font = new Font(dgvGrilla.Font, FontStyle.Italic);
                //    e.CellStyle = style;
                //    e.Value = "Sin ayudante";
                //    e.FormattingApplied = true;
                //}
            }
        }

        private void dgvGrilla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvGrilla.Columns["Materia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Profesor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGrilla.Columns["Ayudante"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmHorariosComision frm = new frmHorariosComision((Comision)dgvGrilla.SelectedRows[0].DataBoundItem);
            frm.ShowDialog();
        }
    }
}
