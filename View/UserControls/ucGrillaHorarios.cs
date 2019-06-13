using System;
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
            //frmHorario frm = new frmHorario();
            //if (frm.ShowDialog() == DialogResult.OK)
            //    cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Horarios.Count < 1) return;
            
            //frmHorario frm = new frmHorario((Horario)dgvGrilla.SelectedRows[0].DataBoundItem);
            //if (frm.ShowDialog() == DialogResult.OK)
            //    cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Horarios.Count < 1) return;

            if (!CommonHelper.Confirma())
                return;

            try
            {
                HorarioService s = new HorarioService();
                Horario a = new Horario();
                a = (Horario)dgvGrilla.SelectedRows[0].DataBoundItem;
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
            HorarioService s = new HorarioService();

            try
            {
                Horarios = s.GetAll();
                dgvGrilla.DataSource = Horarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
