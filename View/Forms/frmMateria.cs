using AccesoDatos.Services;
using Entities.Helpers;
using Entities.Models;
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

        public frmMateria()
        {
            InitializeComponent();
        }

        public frmMateria(Materia materia)
        {
            InitializeComponent();
            this.materia = materia;
        }

        private void frmMateria_Load(object sender, EventArgs e)
        {
            cmbCarrera.DataSource = new CarreraService().GetAll().FindAll(x => x.Deshabilitado == false);

            cmbCuatrimestre.DataSource = new List<byte> { 1, 2 };

            cmbTipoCursada.DataSource = new List<string> { "Anual", "Cuatrimestral" };

            if (this.materia != null)
            {
                txtID.Text = materia.Id.ToString();
                txtNombre.Text = materia.Nombre;
                cmbCarrera.SelectedIndex = cmbCarrera.FindString(materia.Carrera.ToString());
                cmbAño.SelectedIndex = cmbAño.FindString(materia.Año.ToString());

                if (materia.Cuatrimestre == null)
                {
                    cmbTipoCursada.SelectedIndex = cmbTipoCursada.FindString("Anual");
                }
                else
                {
                    cmbTipoCursada.SelectedIndex = cmbTipoCursada.FindString("Cuatrimestral");
                    cmbCuatrimestre.SelectedItem = materia.Cuatrimestre;
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

                MateriaService s = new MateriaService();

                if (this.materia.Id != 0)
                    s.Update(materia);
                else
                    s.Insert(materia);

                CommonHelper.ShowInfo("Materia guardada con éxito.");
                this.DialogResult = DialogResult.OK;
            }
            catch (WarningException ex)
            {
                CommonHelper.ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
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

            if (cmbCuatrimestre.SelectedItem == null && cmbCuatrimestre.Enabled)
                errores += "Debe especificar el cuatrimestre" + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            if (materia == null) materia = new Materia();
            materia.Nombre = txtNombre.Text;
            materia.Carrera = (Carrera)cmbCarrera.SelectedItem;
            materia.Año = (byte)cmbAño.SelectedItem;
            materia.Cuatrimestre = (byte?)(cmbCuatrimestre.SelectedItem ?? null);

            MateriaService s = new MateriaService();

            var materias = s.GetAll().FindAll(x => x.Deshabilitado == false);

            foreach (var Materia in materias)
            {
                if (Materia.Id != materia.Id)
                {
                    if (Materia.Carrera.Id == materia.Carrera.Id
                        && Materia.Nombre == materia.Nombre)
                    {
                        throw new WarningException("Ya existe una materia con el nombre \"" + Materia.Nombre + "\" para la carrera " +
                            Materia.Carrera.Nombre + ".");
                    }
                }
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
            string tipoCursada = (string)cmbTipoCursada.SelectedItem;
            if (tipoCursada == null)
                return;
            
            cmbCuatrimestre.Enabled = tipoCursada == "Cuatrimestral";
            if (tipoCursada == "Anual")
                cmbCuatrimestre.SelectedIndex = -1;
        }
    }
}
