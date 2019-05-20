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

namespace View
{
    public partial class ucGrillaProfesores : UserControl
    {
        private List<Profesor> Profesores { get; set; }

        public ucGrillaProfesores()
        {
            InitializeComponent();
        }

        private void ucGrillaProfesores_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProfesor frm = new frmProfesor();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Profesores.Count < 1) return;

            frmProfesor frm = new frmProfesor((Profesor)dgvGrilla.SelectedRows[0].DataBoundItem);
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Profesores.Count < 1) return;

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?",
                "Atención", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            ProfesorService s = new ProfesorService();
            Profesor p = new Profesor();
            p = (Profesor)dgvGrilla.SelectedRows[0].DataBoundItem;
            s.Delete(p.Id);
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ProfesorService s = new ProfesorService();
            Profesores = s.GetAll();
            dgvGrilla.DataSource = Profesores;
        }
    }
}
