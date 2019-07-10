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
    public partial class frmComision : Form
    {
        private Comision comision { get; set; }

        public frmComision()
        {
            InitializeComponent();
            dtpAño.CustomFormat = "yyyy";
        }

        public frmComision(Comision comision)
        {
            InitializeComponent();
            dtpAño.CustomFormat = "yyyy";
            this.comision = comision;
        }

        private void frmComision_Load(object sender, EventArgs e)
        {
            cmbCarrera.DataSource = new CarreraService().GetAll().FindAll(x => !x.Deshabilitado);
            cmbMateria.DataSource = new MateriaService().GetAll().FindAll(x => !x.Deshabilitado);
            cmbCuatrimestre.DataSource = new List<byte> { 1, 2 };
            cmbTurno.DataSource = new TurnoService().GetAll().OrderBy(x => x.Id).ToList();
            cmbModalidad.DataSource = new ModalidadService().GetAll().FindAll(x => !x.Deshabilitado);
            cmbProfesor.DataSource = new ProfesorService().GetAll().FindAll(x => !x.Deshabilitado);
            cmbAyudante.DataSource = new ProfesorService().GetAll().FindAll(x => !x.Deshabilitado);

            if (this.comision != null)
            {
                cmbCarrera.SelectedIndex = cmbCarrera.FindString(comision.Materia.Carrera.ToString());
                cmbMateria.SelectedIndex = cmbMateria.FindString(comision.Materia.ToString());
                dtpAño.Value = new DateTime(comision.Año, DateTime.Today.Month, DateTime.Today.Day);
                cmbCuatrimestre.SelectedIndex = comision.Cuatrimestre == null ? -1 : (byte)(comision.Cuatrimestre - 1);
                cmbTurno.SelectedIndex = cmbTurno.FindString(comision.Turno.ToString());
                cmbModalidad.SelectedItem = comision.Modalidad;
                cmbProfesor.SelectedIndex = cmbProfesor.FindString(comision.Profesor.ToString());
                cmbAyudante.SelectedIndex = comision.Ayudante == null ? -1 : cmbAyudante.FindString(comision.Ayudante.ToString());
            }
            else
            {
                cmbCarrera.SelectedIndex = -1;
                cmbMateria.SelectedIndex = -1;
                cmbMateria.Enabled = false;
                cmbCuatrimestre.SelectedIndex = -1;
                cmbCuatrimestre.Enabled = false;
                cmbTurno.SelectedIndex = -1;
                cmbModalidad.SelectedIndex = -1;
                cmbProfesor.SelectedIndex = -1;
                cmbAyudante.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                ComisionService s = new ComisionService();

                if (comision.Id != 0)
                    s.Update(comision);
                else
                    s.Insert(comision);

                CommonHelper.ShowInfo("Comisión guardada con éxito.");
                this.DialogResult = DialogResult.OK;
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

        private void validarEntidad()
        {
            string errores = "";

            if (cmbMateria.SelectedItem == null)
                errores += "Debe seleccionar una materia. " + Environment.NewLine;

            if (cmbCuatrimestre.SelectedItem == null && cmbCuatrimestre.Enabled)
                errores += "Debe seleccionar un cuatrimestre. " + Environment.NewLine;

            if (cmbTurno.SelectedItem == null)
                errores += "Debe seleccionar un turno. " + Environment.NewLine;

            if (cmbModalidad.SelectedItem == null)
                errores += "Debe seleccionar una modalidad. " + Environment.NewLine;

            if (cmbProfesor.SelectedItem == null)
                errores += "Debe seleccionar un profesor. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            if (comision == null) comision = new Comision();
            comision.Materia = (Materia)cmbMateria.SelectedItem;
            comision.Año = dtpAño.Value.Year;
            comision.Cuatrimestre = (byte?)(cmbCuatrimestre.SelectedItem ?? null);
            comision.Turno = (Turno)cmbTurno.SelectedItem;
            comision.Modalidad = (Modalidad)cmbModalidad.SelectedItem;
            comision.Profesor = (Profesor)cmbProfesor.SelectedItem;
            comision.Ayudante = (Profesor)cmbAyudante.SelectedItem ?? null;

            ComisionService s = new ComisionService();

            var comisiones = s.GetAll().FindAll(x => x.Deshabilitado == false);

            foreach (var Comision in comisiones)
            {
                if (Comision.Id != comision.Id)
                {
                    if (Comision.Materia.Id == comision.Materia.Id
                        && Comision.Año == comision.Año
                        && Comision.Cuatrimestre == comision.Cuatrimestre
                        && Comision.Turno.Id == comision.Turno.Id)
                    {
                        throw new WarningException("Ya existe una comisión para la materia " + Comision.Materia + ", año " 
                            + Comision.Año + (Comision.Cuatrimestre == null ? "" : ", cuatrimestre " + Comision.Cuatrimestre) + " y turno " + Comision.Turno + ".");
                    }
                }
            }
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMateria.SelectedItem == null)
                return;

            Materia materia = (Materia)cmbMateria.SelectedItem;
            
            cmbCuatrimestre.Enabled = materia.Cuatrimestre != 0;
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMateria.SelectedIndex = -1;

            if (cmbCarrera.SelectedIndex == -1)
            {
                cmbMateria.Enabled = false;
                return;
            }

            Carrera carrera = (Carrera)cmbCarrera.SelectedItem;

            cmbMateria.Enabled = true;
            cmbMateria.DataSource = new MateriaService().GetByCarreraId(carrera.Id);
        }
    }
}
