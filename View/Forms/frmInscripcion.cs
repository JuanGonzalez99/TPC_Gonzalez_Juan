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
    public partial class frmInscripcion : Form
    {
        private Inscripcion inscripcion { get; set; }

        public frmInscripcion()
        {
            InitializeComponent();
            dtpAño.CustomFormat = "yyyy";
        }

        public frmInscripcion(Inscripcion inscripcion)
        {
            InitializeComponent();
            dtpAño.CustomFormat = "yyyy";
            this.inscripcion = inscripcion;
        }

        private void frmInscripcion_Load(object sender, EventArgs e)
        {
            cmbCuatrimestre.DataSource = new List<byte> { 1, 2 };

            if (this.inscripcion != null)
            {
                dtpAño.Value = new DateTime(inscripcion.Año, DateTime.Today.Month, DateTime.Today.Day);
                chbAnual.Checked = inscripcion.Cuatrimestre == null;
                cmbCuatrimestre.SelectedIndex = chbAnual.Checked ? -1 : (int)(inscripcion.Cuatrimestre - 1);
                dtpApertura.Value = inscripcion.FechaApertura;
                dtpCierre.Value = inscripcion.FechaCierre;
            }
            else
            {
                cmbCuatrimestre.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                InscripcionService s = new InscripcionService();

                if (inscripcion.Id != 0)
                    s.Update(inscripcion);
                else
                    s.Insert(inscripcion);

                CommonHelper.ShowInfo("Inscripción guardada correctamente.");

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

            if (cmbCuatrimestre.Enabled && cmbCuatrimestre.SelectedItem == null)
                errores += "Debe especificar el cuatrimestre" + Environment.NewLine;

            if (dtpApertura.Value >= dtpCierre.Value)
                errores += "La fecha de apertura no puede ser mayor o igual a la fecha de cierre. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            if (inscripcion == null) inscripcion = new Inscripcion();
            inscripcion.Año = dtpAño.Value.Year;
            inscripcion.Cuatrimestre = (byte?)cmbCuatrimestre.SelectedItem ?? null;
            inscripcion.FechaApertura = dtpApertura.Value;
            inscripcion.FechaCierre = dtpCierre.Value;

            InscripcionService s = new InscripcionService();

            var inscripciones = s.GetAll();

            foreach (var Inscripcion in inscripciones)
            {
                if (Inscripcion.Id != inscripcion.Id)
                {
                    if (Inscripcion.Año == inscripcion.Año
                        && Inscripcion.Cuatrimestre == inscripcion.Cuatrimestre)
                    {
                        throw new WarningException("Ya existe un período de inscripción para las materias " +
                            (Inscripcion.Cuatrimestre == null ? "anuales" : "del " + 
                                (Inscripcion.Cuatrimestre == 1 ? "primer" : "segundo") + 
                            " cuatrimestre") + 
                            " para el año " + Inscripcion.Año + ". Modifique el existente.");
                    }
                }
            }
        }

        private void chbAnual_CheckedChanged(object sender, EventArgs e)
        {
            cmbCuatrimestre.Enabled = !chbAnual.Checked;

            if (!cmbCuatrimestre.Enabled)
                cmbCuatrimestre.SelectedIndex = -1;
        }
    }
}
