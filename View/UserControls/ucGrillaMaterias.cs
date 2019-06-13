using System;
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
    public partial class ucGrillaMaterias : UserControl
    {
        private List<Materia> Materias { get; set; }

        public ucGrillaMaterias()
        {
            InitializeComponent();
        }

        private void ucGrillaMaterias_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmMateria frm = new frmMateria();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Materias.Count < 1) return;

            frmMateria frm = new frmMateria((Materia)dgvGrilla.SelectedRows[0].DataBoundItem);
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Materias.Count < 1) return;
            
            if (!CommonHelper.Confirma())
                return;

            try
            {

                MateriaService s = new MateriaService();
                Materia m = new Materia();
                m = (Materia)dgvGrilla.SelectedRows[0].DataBoundItem;
                s.Delete(m.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarGrilla()
        {
            MateriaService s = new MateriaService();

            try
            {
                Materias = s.GetAll();
                dgvGrilla.DataSource = Materias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
