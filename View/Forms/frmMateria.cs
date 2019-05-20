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
        private Materia Materia { get; set; }

        public frmMateria()
        {
            InitializeComponent();
        }

        public frmMateria(Materia materia)
        {
            InitializeComponent();
            this.Materia = materia;
        }

        private void frmMateria_Load(object sender, EventArgs e)
        {
            cmbCarrera.DataSource = new CarreraService().GetAll();
            List<byte> cuatrimestres = new List<byte> { 0, 1, 2 };
            cmbCuatrimestre.DataSource = cuatrimestres;

            if (this.Materia != null)
            {
                txtID.Text = Materia.Id.ToString();
                txtNombre.Text = Materia.Nombre;
                cmbCarrera.SelectedIndex = cmbCarrera.FindString(Materia.Carrera.ToString());
            }
            else
            {
                cmbAño.Enabled = false;
                cmbCarrera.SelectedIndex = -1;
                cmbAño.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                if (Materia == null) Materia = new Materia();
                Materia.Nombre = txtNombre.Text;
                Materia.Carrera = (Carrera)cmbCarrera.SelectedItem;
                Materia.Año = (byte)cmbAño.SelectedItem;
                Materia.Cuatrimestre = (byte)cmbCuatrimestre.SelectedItem;

                MateriaService s = new MateriaService();
                if (this.Materia.Id != 0)
                    s.Update(Materia);
                else
                    s.Insert(Materia);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (WarningException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void validarEntidad()
        {
            if (txtNombre.Text.Trim() == "")
                throw new WarningException("Debe ingresar un nombre");

            if (cmbCarrera.SelectedItem == null)
                throw new WarningException("Debe seleccionar una carrera");

            if (cmbAño.SelectedItem == null)
                throw new WarningException("Debe seleccionar un año");

            if (cmbCuatrimestre.SelectedItem == null)
                cmbCuatrimestre.SelectedValue = 0;
        }

        private void cmbCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            Carrera aux = (Carrera)cmbCarrera.SelectedItem;
            if (aux == null) return;

            byte length = aux.Duracion;
            List<byte> años = new List<byte>();
            for (byte i = 1; i <= length; i++)
            {
                años.Add(i);
            }
            cmbAño.DataSource = años;

            cmbAño.Enabled = true;
            cmbAño.SelectedIndex = -1;
        }
    }
}
