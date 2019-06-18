using Entities.Models;
using Services.Services;
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
    public partial class frmComision : Form
    {
        private Comision comision { get; set; }

        public frmComision()
        {
            InitializeComponent();
        }

        public frmComision(Comision comision)
        {
            InitializeComponent();
            this.comision = comision;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                if (comision == null) comision = new Comision();


                ComisionService s = new ComisionService();

                if (comision.Id != 0)
                    s.Update(comision);
                else
                    s.Insert(comision);

                this.DialogResult = DialogResult.OK;
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

        private void validarEntidad()
        {
            string errores = "";

            if (errores != "")
            {
                throw new WarningException(errores);
            }
        }
    }
}
