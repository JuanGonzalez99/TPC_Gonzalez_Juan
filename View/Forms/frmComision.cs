using AccesoDatos.Services;
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
            cmbMateria.DataSource = new MateriaService().GetAll().FindAll(x => !x.Deshabilitado);

            cmbCuatrimestre.DataSource = new List<byte> { 1, 2 };

            cmbModalidad.DataSource = new ModalidadService().GetAll().FindAll(x => !x.Deshabilitado);

            if (this.comision != null)
            {
                txtID.Text = comision.Id.ToString();
                cmbMateria.SelectedIndex = cmbMateria.FindString(comision.Materia.ToString());
                dtpAño.Value = new DateTime(comision.Año, DateTime.Today.Month, DateTime.Today.Day);
                cmbCuatrimestre.SelectedIndex = comision.Cuatrimestre == 0 ? -1 : (byte)(comision.Cuatrimestre - 1);
                cmbModalidad.SelectedItem = comision.Modalidad;
            }
            else
            {
                cmbMateria.SelectedIndex = -1;
                cmbCuatrimestre.SelectedIndex = -1;
                cmbModalidad.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                if (comision == null) comision = new Comision();
                comision.Materia = (Materia)cmbMateria.SelectedItem;
                comision.Año = dtpAño.Value.Year;
                comision.Cuatrimestre = (byte)(cmbCuatrimestre.SelectedItem ?? 0);
                comision.Modalidad = (Modalidad)cmbModalidad.SelectedItem;

                ComisionService s = new ComisionService();

                if (comision.Id != 0)
                    s.Update(comision);
                else
                    s.Insert(comision);

                this.DialogResult = DialogResult.OK;
            }
            catch (WarningException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validarEntidad()
        {
            string errores = "";

            if (cmbMateria.SelectedItem == null)
                errores += "Debe seleccionar una materia. " + Environment.NewLine;

            if (cmbCuatrimestre.SelectedItem == null && cmbCuatrimestre.Enabled)
                errores += "Debe seleccionar un cuatrimestre. ";

            if (cmbModalidad.SelectedItem == null)
                errores += "Debe seleccionar una modalidad. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }
        }

        private void cmbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMateria.SelectedItem == null)
                return;

            Materia materia = (Materia)cmbMateria.SelectedItem;
            
            cmbCuatrimestre.Enabled = materia.Cuatrimestre != 0;
        }
    }
}
