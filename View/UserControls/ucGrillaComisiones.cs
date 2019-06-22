﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Forms;
using Entities.Helpers;
using Entities.Models;
using AccesoDatos.Services;

namespace View.UserControls
{
    public partial class ucGrillaComisiones : UserControl
    {
        private List<Comision> Comisiones { get; set; }

        public ucGrillaComisiones()
        {
            InitializeComponent();
        }

        private void ucGrillaComisiones_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmComision frm = new frmComision();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmComision frm = new frmComision((Comision)dgvGrilla.SelectedRows[0].DataBoundItem);
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
                ComisionService s = new ComisionService();
                Comision a = (Comision)dgvGrilla.SelectedRows[0].DataBoundItem;
                s.Delete(a.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarGrilla()
        {
            ComisionService s = new ComisionService();

            try
            {
                Comisiones = s.GetAll();
                dgvGrilla.DataSource = Comisiones.FindAll(x => x.Deshabilitado == false);
                dgvGrilla.Columns["Id"].Visible = false;
                dgvGrilla.Columns["Deshabilitado"].Visible = false;
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
                dgvGrilla.DataSource = Comisiones.FindAll(x => x.Deshabilitado == false);
                dgvGrilla.Columns["Deshabilitado"].Visible = false;
            }
            else
            {
                string busqueda = txtBuscar.Text.ToUpper();
                List<Comision> lista = Comisiones.FindAll(x => x.Id.ToString().Contains(busqueda)
                                                        || x.Materia.ToString().ToUpper().Contains(busqueda)
                                                        || x.Año.ToString().Contains(busqueda)
                                                        || x.Modalidad.ToString().Contains(busqueda));
                dgvGrilla.DataSource = lista;
                dgvGrilla.Columns["Deshabilitado"].Visible = true;
            }
        }
    }
}