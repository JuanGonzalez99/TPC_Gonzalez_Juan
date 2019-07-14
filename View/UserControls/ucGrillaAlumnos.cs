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
using View.Forms;

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

            if (btnEliminar.Text == "Eliminar")
            {
                if (!CommonHelper.Confirma())
                    return;
            }

            try
            {
                AlumnoService s = new AlumnoService();
                Alumno entidad = (Alumno)dgvGrilla.SelectedRows[0].DataBoundItem;

                if (btnEliminar.Text == "Eliminar")
                    s.Delete(entidad.Id);
                else
                    s.Restaurar(entidad.Id);

                cargarGrilla();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void cargarGrilla()
        {
            AlumnoService s = new AlumnoService();

            try
            {
                Alumnos = s.GetAll();
                txtBuscar.Text = "";
                dgvGrilla.DataSource = Alumnos.FindAll(x => x.Deshabilitado == false || chbDeshabilitados.Checked);
                dgvGrilla.Columns["Id"].HeaderText = "Legajo";
                dgvGrilla.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
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
            List<Alumno> lista = Alumnos.FindAll(x => x.Deshabilitado == false || chbDeshabilitados.Checked);

            if (txtBuscar.Text != "")
            {
                string busqueda = txtBuscar.Text.ToUpper();
                lista = lista.FindAll(x => x.Id.ToString().Contains(busqueda)
                                    || x.DNI.ToString().Contains(busqueda)
                                    || x.Apellido.ToUpper().Contains(busqueda)
                                    || x.Nombre.ToUpper().Contains(busqueda)
                                    || x.FechaNac.ToShortDateString().Contains(busqueda));
            }

            dgvGrilla.DataSource = lista;

            dgvGrilla.Columns["Deshabilitado"].Visible = chbDeshabilitados.Checked;
        }

        private void btnCarreras_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmCarrerasAlumno frm = new frmCarrerasAlumno((Alumno)dgvGrilla.SelectedRows[0].DataBoundItem);
            frm.ShowDialog();
        }

        private void chbDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscar_TextChanged(sender, e);
        }

        private void dgvGrilla_SelectionChanged(object sender, EventArgs e)
        {
            var rows = dgvGrilla.SelectedRows;
            if (rows != null && rows.Count > 0)
            {
                Alumno alumno = (Alumno)dgvGrilla.SelectedRows[0].DataBoundItem;

                btnEliminar.Text = alumno.Deshabilitado ? "Restaurar" : "Eliminar";
            }
        }
    }
}
