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
    public partial class ucGrillaCarreras : UserControl
    {
        private BindingList<Carrera> carreras { get; set; }

        public ucGrillaCarreras()
        {
            InitializeComponent();
        }

        private void ucGrillaCarreras_Load(object sender, EventArgs e)
        {
            CarreraService s = new CarreraService();
            carreras = new BindingList<Carrera>(s.GetAll());
            dgvGrilla.DataSource = carreras;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCarrera frm = new frmCarrera();
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (carreras.Count < 1) return;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (carreras.Count < 1) return;

            if (MessageBox.Show("¿Está seguro que desea eliminar el registro seleccionado?",
                "Atención", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            CarreraService s = new CarreraService();
            Carrera c = new Carrera();
            c = (Carrera)dgvGrilla.SelectedRows[0].DataBoundItem;
            carreras.Remove(carreras.First(x => x.Id == c.Id));
            s.Delete(c.Id);
            dgvGrilla.Refresh();
        }
    }
}
