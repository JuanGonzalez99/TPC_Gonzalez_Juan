﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using AccesoDatos.Services;
using View.Forms;
using Entities.Helpers;

namespace View.UserControls
{
    public partial class ucGrillaCarreras : UserControl
    {
        private List<Carrera> Carreras { get; set; }

        public ucGrillaCarreras()
        {
            InitializeComponent();
        }

        private void ucGrillaCarreras_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCarrera frm = new frmCarrera();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Carreras.Count < 1) return;
            
            frmCarrera frm = new frmCarrera((Carrera)dgvGrilla.SelectedRows[0].DataBoundItem);
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Carreras.Count < 1) return;

            if (!CommonHelper.Confirma())
                return;

            try
            {
                CarreraService s = new CarreraService();
                Carrera c = (Carrera)dgvGrilla.SelectedRows[0].DataBoundItem;

                MateriaService ms = new MateriaService();
                if (ms.GetByCarreraId(c.Id).Count > 0)
                {
                    MessageBox.Show("No se puede eliminar esta carrera; posee materias asociadas.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                s.Delete(c.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarGrilla()
        {
            CarreraService s = new CarreraService();

            try
            {
                Carreras = s.GetAll();
                dgvGrilla.DataSource = Carreras;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
