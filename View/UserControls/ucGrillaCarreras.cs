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
    public partial class ucGrillaCarreras : UserControl
    {
        private List<Carrera> Carreras { get; set; }

        public ucGrillaCarreras()
        {
            InitializeComponent();
        }

        private void ucGrillaCarreras_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCarrera frm = new frmCarrera();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmCarrera frm = new frmCarrera((Carrera)dgvGrilla.SelectedRows[0].DataBoundItem);
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
                CarreraService s = new CarreraService();
                Carrera c = (Carrera)dgvGrilla.SelectedRows[0].DataBoundItem;

                MateriaService ms = new MateriaService();
                if (ms.GetByCarreraId(c.Id).Count > 0)
                {
                    CommonHelper.ShowWarning("No se puede eliminar esta carrera; posee materias asociadas.");
                    return;
                }

                s.Delete(c.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void cargarGrilla()
        {
            CarreraService s = new CarreraService();

            try
            {
                Carreras = s.GetAll();
                txtBuscar.Text = "";
                dgvGrilla.DataSource = Carreras.FindAll(x => x.Deshabilitado == false || chbDeshabilitados.Checked);
                dgvGrilla.Columns["Id"].HeaderText = "Código";
                dgvGrilla.Columns["NombreCorto"].HeaderText = "Nombre corto";
                dgvGrilla.Columns["Duracion"].HeaderText = "Duración";
                dgvGrilla.Columns["Deshabilitado"].DisplayIndex = dgvGrilla.Columns.Count - 1;
                dgvGrilla.Columns["Deshabilitado"].Visible = chbDeshabilitados.Checked;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Carrera> lista = Carreras.FindAll(x => x.Deshabilitado == false || chbDeshabilitados.Checked);

            if (txtBuscar.Text != "")
            {
                string busqueda = txtBuscar.Text.ToUpper();
                lista = lista.FindAll(x => x.Id.ToString().Contains(busqueda)
                                    || x.Nombre.ToUpper().Contains(busqueda)
                                    || x.NombreCorto.ToUpper().Contains(busqueda)
                                    || x.Duracion.ToString().Contains(busqueda));
            }

            dgvGrilla.DataSource = lista;
            dgvGrilla.Columns["Deshabilitado"].Visible = chbDeshabilitados.Checked;
        }

        private void chbDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(sender, e);
        }
    }
}
