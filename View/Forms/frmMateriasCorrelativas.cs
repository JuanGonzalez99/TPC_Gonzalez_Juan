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
    public partial class frmMateriasCorrelativas : Form
    {
        private Materia materia { get; set; }

        public frmMateriasCorrelativas()
        {
            InitializeComponent();
        }

        public frmMateriasCorrelativas(Materia materia)
        {
            InitializeComponent();
            this.materia = materia;
        }

        private void frmMateriasCorrelativas_Load(object sender, EventArgs e)
        {
            MateriaService s = new MateriaService();
            cmbMaterias.DataSource = s.GetByCarreraId(materia.Carrera.Id).FindAll(x => !x.Deshabilitado);
            cmbEstado.DataSource = s.GetAllEstados().FindAll(x => x.Descripcion == "Aprobada" || x.Descripcion == "Regularizada");

            cmbMaterias.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            cargarGrilla();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cmbMaterias.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una materia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Materia correlativa = (Materia)cmbMaterias.SelectedItem;
            MateriaService s = new MateriaService();

            if (s.GetCorrelativasById(materia.Id).Any(x => x.Id == correlativa.Id))
            {
                MessageBox.Show("La materia ya tiene asociada esa correlativa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            s.InsertCorrelativa(materia.Id, correlativa.Id, (EstadoMateria)cmbEstado.SelectedItem);

            cargarGrilla();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvMaterias, "Debe seleccionar una materia. "))
                return;

            if (!CommonHelper.Confirma("¿Está seguro que desea quitar esta correlativa?"))
                return;

            try
            {
                var correlativa = (Materia)dgvMaterias.SelectedRows[0].DataBoundItem;

                new MateriaService().DeleteCorrelativa(this.materia.Id, correlativa.Id);

                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarGrilla()
        {
            try
            {
                dgvMaterias.DataSource = new MateriaService().GetCorrelativasById(materia.Id).FindAll(x => x.Deshabilitado == false);
                dgvMaterias.Columns["Id"].HeaderText = "Código";

                dgvMaterias.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
