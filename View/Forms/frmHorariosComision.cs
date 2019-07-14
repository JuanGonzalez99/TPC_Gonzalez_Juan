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
    public partial class frmHorariosComision : Form
    {
        private Comision comision { get; set; }
        private Horario horario { get; set; }

        public frmHorariosComision()
        {
            InitializeComponent();
        }

        public frmHorariosComision(Comision comision)
        {
            InitializeComponent();
            this.comision = comision;
        }

        private void frmHorariosComision_Load(object sender, EventArgs e)
        {
            this.Text = comision.ToString();

            cargarGrilla();

            dtpHoraInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 8, 0, 0);
            dtpHoraFin.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0);
            cmbDia.DataSource = Enum.GetValues(typeof(DiaDeLaSemana));
            cmbDia.SelectedIndex = -1;
        }

        private void btnAsignarHorario_Click(object sender, EventArgs e)
        {
            try
            {
                validarHorario();

                HorarioService s = new HorarioService();

                var aux = s.GetAll().Find(x => x.HoraInicio == horario.HoraInicio
                                        && x.HoraFin == horario.HoraFin
                                        && x.DiaSemana == horario.DiaSemana);

                if (aux == null)
                {
                    horario.Id = s.Insert(horario);
                }
                else
                {
                    horario = aux;
                }
                

                new ComisionService().AsignarHorario(comision.Id, horario.Id);

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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CommonHelper.SeleccionoRegistro(dgvHorarios, "Debe seleccionar un horario. "))
                    return;

                if (!CommonHelper.Confirma("¿Está seguro que desea quitar este horario?"))
                    return;

                var horario = (Horario)dgvHorarios.SelectedRows[0].DataBoundItem;

                new ComisionService().QuitarHorario(comision.Id, horario.Id);

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
                dgvHorarios.DataSource = new ComisionService().GetHorariosById(comision.Id)
                    .OrderBy(x => x.DiaSemana)
                    .ThenBy(x => x.HoraInicio)
                    .ThenBy(x => x.HoraFin).ToList();
                dgvHorarios.Columns["Id"].Visible = false;
                dgvHorarios.Columns["HoraInicio"].HeaderText = "Hora de inicio";
                dgvHorarios.Columns["HoraFin"].HeaderText = "Hora de fin";
                dgvHorarios.Columns["DiaSemana"].HeaderText = "Día de la semana";
                dgvHorarios.Columns["DiaSemana"].DisplayIndex = 0;
                dgvHorarios.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void validarHorario()
        {
            string errores = "";

            if (dtpHoraInicio.Text.Trim() == "" || dtpHoraFin.Text.Trim() == "")
                errores += "Debe completar todos los campos. " + Environment.NewLine;

            else if (dtpHoraInicio.Value >= dtpHoraFin.Value)
                errores += "La hora de fin debe ser mayor a la hora de inicio. " + Environment.NewLine;

            if (cmbDia.SelectedItem == null)
                errores += "Debe seleccionar un día. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            horario = new Horario();
            horario.HoraInicio = dtpHoraInicio.Value.TimeOfDay;
            horario.HoraFin = dtpHoraFin.Value.TimeOfDay;
            horario.DiaSemana = (DiaDeLaSemana)cmbDia.SelectedItem;

            ComisionService s = new ComisionService();

            var horarios = s.GetHorariosById(comision.Id);

            foreach (var Horario in horarios)
            {
                if (Horario.DiaSemana == horario.DiaSemana)
                {
                    if (Horario.HoraInicio == horario.HoraInicio && Horario.HoraFin == horario.HoraFin)
                    {
                        throw new WarningException("La comisión ya posee un horario con los mismos datos.");
                    }
                    if (horario.HoraInicio < Horario.HoraFin && horario.HoraFin > Horario.HoraInicio)
                    {
                        throw new WarningException("La comisión posee un horario que se superpone con el que está intentando asignar. Modifique el existente o quítelo e intente nuevamente.");
                    }
                }
            }

        }
    }
}
