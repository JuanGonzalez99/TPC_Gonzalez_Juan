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
            
            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?",
                "Atención", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            MateriaService s = new MateriaService();
            Materia m = new Materia();
            m = (Materia)dgvGrilla.SelectedRows[0].DataBoundItem;
            s.Delete(m.Id);
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            MateriaService s = new MateriaService();
            Materias = s.GetAll();
            dgvGrilla.DataSource = Materias;
        }
    }
}
