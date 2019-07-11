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
            try
            {
                validar();

                Materia correlativa = (Materia)cmbMaterias.SelectedItem;
                MateriaService s = new MateriaService();
                s.InsertCorrelativa(materia.Id, correlativa.Id, (EstadoMateria)cmbEstado.SelectedItem);

                cargarGrilla();

            }
            catch (WarningException ex)
            {
                CommonHelper.ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void validar()
        {
            string errores = "";

            if (cmbMaterias.SelectedItem == null)
                errores += "Debe seleccionar una materia" + Environment.NewLine;

            if (cmbEstado.SelectedItem == null)
                errores += "Debe seleccionar un estado" + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            Materia correlativa = (Materia)cmbMaterias.SelectedItem;
            MateriaService s = new MateriaService();

            if (s.GetCorrelativasById(materia.Id).Any(x => x.Correlativa.Id == correlativa.Id && x.Deshabilitado == false))
            {
                throw new WarningException("La materia ya tiene asociada esa correlativa");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvMaterias, "Debe seleccionar una materia de la grilla. "))
                return;

            if (!CommonHelper.Confirma("¿Está seguro que desea quitar esta correlativa?"))
                return;

            try
            {
                var correlativa = (MateriaCorrelativa)dgvMaterias.SelectedRows[0].DataBoundItem;

                new MateriaService().DeleteCorrelativa(correlativa.Materia.Id, correlativa.Correlativa.Id);

                cargarGrilla();
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void cargarGrilla()
        {
            try
            {
                dgvMaterias.DataSource = new MateriaService().GetCorrelativasById(materia.Id).FindAll(x => x.Deshabilitado == false);
                dgvMaterias.Columns["Id"].Visible = false;
                dgvMaterias.Columns["Materia"].Visible = false;
                dgvMaterias.Columns["EstadoRequerido"].HeaderText = "Estado requerido";
                dgvMaterias.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }
    }
}
