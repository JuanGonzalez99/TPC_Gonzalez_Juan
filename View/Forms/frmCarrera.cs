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
    public partial class frmCarrera : Form
    {
        private Carrera carrera { get; set; }

        public frmCarrera()
        {
            InitializeComponent();
        }

        public frmCarrera(Carrera carrera)
        {
            InitializeComponent();
            this.carrera = carrera;
        }

        private void frmCarrera_Load(object sender, EventArgs e)
        {
            List<byte> Duracion = new List<byte>();
            for (byte i = 1; i <= 10; i++)
                Duracion.Add(i);
            cmbDuracion.DataSource = Duracion;

            if (this.carrera != null)
            {
                txtID.Text = carrera.Id.ToString();
                txtNombre.Text = carrera.Nombre;
                txtNombreCorto.Text = carrera.NombreCorto;
                cmbDuracion.SelectedIndex = cmbDuracion.FindString(carrera.Duracion.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                if (carrera == null) carrera = new Carrera();
                carrera.Nombre = txtNombre.Text;
                carrera.NombreCorto = txtNombreCorto.Text;
                carrera.Duracion = (byte)cmbDuracion.SelectedItem;

                CarreraService s = new CarreraService();
                if (this.carrera.Id != 0)
                    s.Update(carrera);
                else
                    s.Insert(carrera);
            
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
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
            if (txtNombre.Text.Trim() == "" || txtNombreCorto.Text.Trim() == "")
                throw new Exception("Debe completar todos los campos");
            
            if (txtNombreCorto.Text.Length > 10)
                throw new Exception("Nombre corto demasiado largo");
        }
    }
}
