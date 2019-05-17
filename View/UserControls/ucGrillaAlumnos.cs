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

namespace View
{
    public partial class ucGrillaAlumnos : UserControl
    {
        private List<Alumno> alumnos { get; set; }

        public ucGrillaAlumnos()
        {
            InitializeComponent();
        }

        private void ucGrillaAlumnos_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAlumno frm = new frmAlumno();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (alumnos.Count < 1) return;

            frmAlumno frm = new frmAlumno((Alumno)dgvGrilla.SelectedRows[0].DataBoundItem);
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (alumnos.Count < 1) return;

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?",
                "Atención", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            AlumnoService s = new AlumnoService();
            Alumno a = new Alumno();
            a = (Alumno)dgvGrilla.SelectedRows[0].DataBoundItem;
            s.Delete(a.Id);
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            AlumnoService s = new AlumnoService();
            alumnos = s.GetAll();
            dgvGrilla.DataSource = alumnos;
        }
    }
}
