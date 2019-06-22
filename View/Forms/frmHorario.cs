using Entities.Helpers;
using Entities.Models;
using AccesoDatos.Services;
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
    public partial class frmHorario : Form
    {
        private Horario horario { get; set; }

        public frmHorario()
        {
            InitializeComponent();
        }

        public frmHorario(Horario horario)
        {
            InitializeComponent();
            this.horario = horario;
        }

        private void frmHorario_Load(object sender, EventArgs e)
        {
            cmbDia.DataSource = Enum.GetValues(typeof(DiaDeLaSemana));

            if (this.horario != null)
            {
                txtID.Text = horario.Id.ToString();
                dtpHoraInicio.Value = DateTime.Today + horario.HoraInicio;
                dtpHoraFin.Value = DateTime.Today + horario.HoraFin;
                cmbDia.SelectedItem = horario.DiaSemana;
            }
            else
            {
                dtpHoraInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                                    8, 0, 0);
                dtpHoraFin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                                                    9, 0, 0);
                cmbDia.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                if (horario == null) horario = new Horario();
                horario.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
                horario.HoraFin = dtpHoraFin.Value.TimeOfDay;
                horario.DiaSemana = (DiaDeLaSemana)cmbDia.SelectedItem;

                HorarioService s = new HorarioService();
                if (this.horario.Id != 0)
                    s.Update(horario);
                else
                    s.Insert(horario);

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validarEntidad()
        {
            string errores = "";

            if (dtpHoraInicio.Text.Trim() == "" || dtpHoraFin.Text.Trim() == "")
                errores += "Debe completar todos los campos" + Environment.NewLine;

            if (cmbDia.SelectedItem == null)
                errores += "Debe seleccionar un día" + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }
        }
    }
}
