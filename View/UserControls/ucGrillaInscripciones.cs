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

namespace View.UserControls
{
    public partial class ucGrillaInscripciones : UserControl
    {
        private List<Inscripcion> Inscripciones { get; set; }

        public ucGrillaInscripciones()
        {
            InitializeComponent();
        }

        private void ucGrillaAlumnos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //frmInscripcion frm = new frmInscripcion();
            //if (frm.ShowDialog() == DialogResult.OK)
            //    cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;
            
            //frmInscripcion frm = new frmInscripcion((Inscripcion)dgvGrilla.SelectedRows[0].DataBoundItem);
            //if (frm.ShowDialog() == DialogResult.OK)
            //    cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //...
        }

        private void cargarGrilla()
        {
            //InscripcionService s = new InscripcionService();

            try
            {
                //Inscripciones = s.GetAll();
                dgvGrilla.DataSource = Inscripciones;
                dgvGrilla.Columns["FechaApertura"].HeaderText = "Fecha de apertura";
                dgvGrilla.Columns["FechaCierre"].HeaderText = "Fecha de cierre";
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
                dgvGrilla.DataSource = Inscripciones;
            }
            else
            {
                string busqueda = txtBuscar.Text.ToUpper();
                List<Inscripcion> lista = Inscripciones.FindAll(x => x.Id.ToString().Contains(busqueda)
                                                        || x.Año.ToString().Contains(busqueda)
                                                        || x.FechaApertura.ToShortDateString().Contains(busqueda)
                                                        || x.FechaCierre.ToShortDateString().Contains(busqueda));
                dgvGrilla.DataSource = lista;
            }
        }
    }
}
