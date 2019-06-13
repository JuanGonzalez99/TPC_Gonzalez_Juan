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

            cmbCuatrimestre.DataSource = new List<byte> { 1, 2 };

            cmbTipoCursada.DataSource = new List<string> { "Anual", "Cuatrimestral" };

            if (this.Materia != null)
            {
                txtID.Text = Materia.Id.ToString();
                txtNombre.Text = Materia.Nombre;
                cmbCarrera.SelectedIndex = cmbCarrera.FindString(Materia.Carrera.ToString());
                cmbAño.SelectedIndex = cmbAño.FindString(Materia.Año.ToString());

                if (Materia.Cuatrimestre == 0)
                {
                    cmbTipoCursada.SelectedIndex = cmbTipoCursada.FindString("Anual");
                    cmbCuatrimestre.SelectedIndex = -1;
                }
                else
                {
                    cmbTipoCursada.SelectedIndex = cmbTipoCursada.FindString("Cuatrimestral");
                    cmbCuatrimestre.SelectedItem = Materia.Cuatrimestre;
                }
            }
            else
            {
                cmbAño.SelectedIndex = -1;
                cmbCarrera.SelectedIndex = -1;
                cmbCuatrimestre.SelectedIndex = -1;
                cmbTipoCursada.SelectedIndex = -1;

                cmbAño.Enabled = false;
                cmbCuatrimestre.Enabled = false;
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

                this.Close();
            }
            catch (WarningException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void validarEntidad()
        {
            string errores = "";

            if (txtNombre.Text.Trim() == "")
                errores += "Debe ingresar un nombre" + Environment.NewLine;

            if (cmbCarrera.SelectedItem == null)
                errores += "Debe seleccionar una carrera" + Environment.NewLine;

            if (cmbAño.SelectedItem == null)
                errores += "Debe seleccionar un año" + Environment.NewLine;

            if (cmbCuatrimestre.SelectedItem == null && cmbTipoCursada.SelectedText == "Cuatrimestral")
                errores += "Debe especificar el cuatrimestre" + Environment.NewLine;

            else if (cmbCuatrimestre.SelectedItem == null)
                cmbCuatrimestre.DataSource = new List<byte> { 0 };

            if (errores != "")
            {
                throw new WarningException(errores);
            }
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

        private void cmbTipoCursada_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aux = (string)cmbTipoCursada.SelectedItem;
            if (aux == null) return;
            
            cmbCuatrimestre.Enabled = aux == "Cuatrimestral";
            if (aux == "Anual") cmbCuatrimestre.SelectedIndex = -1;
        }
    }
}
