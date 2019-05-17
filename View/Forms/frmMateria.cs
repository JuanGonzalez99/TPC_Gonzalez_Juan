using AccesoDatos.Services;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Forms
{
    public partial class frmMateria : Form
    {
        private Materia materia { get; set; }
        private bool Edit { get; set; }

        public frmMateria()
        {
            InitializeComponent();
            Edit = false;
            materia = new Materia();
        }

        public frmMateria(Materia materia)
        {
            InitializeComponent();
            Edit = true;
            this.materia = materia;
        }

        private void frmMateria_Load(object sender, EventArgs e)
        {
            cmbCarrera.DataSource = new CarreraService().GetAll();
            if (Edit)
            {
                txtID.Text = materia.Id.ToString();
                txtNombre.Text = materia.Nombre;
                cmbCarrera.SelectedIndex = cmbCarrera.FindString(materia.Carrera.Nombre);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre", "Advertencia", MessageBoxButtons.OK);
                return;
            }

            MateriaService s = new MateriaService();
            materia.Nombre = txtNombre.Text;
            materia.Carrera = (Carrera)cmbCarrera.SelectedItem;
            materia.Año = (byte)cmbAño.SelectedItem;
            materia.Cuatrimestre = (byte)cmbCuatrimestre.SelectedItem;

            if (this.materia.Id != 0)
                s.Update(materia);
            else
                s.Insert(materia);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
