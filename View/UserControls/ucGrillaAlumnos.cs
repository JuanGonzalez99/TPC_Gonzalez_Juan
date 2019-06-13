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
using Entities.Helpers;

namespace View
{
    public partial class ucGrillaAlumnos : UserControl
    {
        private List<Alumno> Alumnos { get; set; }

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
            if (Alumnos.Count < 1) return;
            
            frmAlumno frm = new frmAlumno((Alumno)dgvGrilla.SelectedRows[0].DataBoundItem);
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Alumnos.Count < 1) return;

            if (!CommonHelper.Confirma())
                return;

            try
            {
                AlumnoService s = new AlumnoService();
                Alumno a = new Alumno();
                a = (Alumno)dgvGrilla.SelectedRows[0].DataBoundItem;
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
            AlumnoService s = new AlumnoService();

            try
            {
                Alumnos = s.GetAll();
                dgvGrilla.DataSource = Alumnos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
