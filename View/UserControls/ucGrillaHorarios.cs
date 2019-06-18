﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Models;
using Services.Services;
using Entities.Helpers;
using View.Forms;

namespace View.UserControls
{
    public partial class ucGrillaHorarios : UserControl
    {
        private List<Horario> Horarios { get; set; }

        public ucGrillaHorarios()
        {
            InitializeComponent();
        }

        private void ucGrillaHorarios_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmHorario frm = new frmHorario();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmHorario frm = new frmHorario((Horario)dgvGrilla.SelectedRows[0].DataBoundItem);
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
                HorarioService s = new HorarioService();
                Horario entidad = (Horario)dgvGrilla.SelectedRows[0].DataBoundItem;
                s.Delete(entidad.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarGrilla()
        {
            HorarioService s = new HorarioService();

            try
            {
                Horarios = s.GetAll();
                dgvGrilla.DataSource = Horarios;
                dgvGrilla.Columns["Deshabilitado"].DisplayIndex = dgvGrilla.Columns.Count - 1;
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
                dgvGrilla.DataSource = Horarios;
            }
            else
            {
                string busqueda = txtBuscar.Text.ToUpper();
                List<Horario> lista = Horarios.FindAll(x => x.Id.ToString().Contains(busqueda)
                                                        || x.HoraInicio.ToString().Contains(busqueda)
                                                        || x.HoraFin.ToString().Contains(busqueda)
                                                        || x.DiaSemana.ToString().ToUpper().Contains(busqueda));
                dgvGrilla.DataSource = lista;
            }
        }
    }
}
