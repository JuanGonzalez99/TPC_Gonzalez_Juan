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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //validar();

                this.Hide();
                var frm = new frmPrincipal();
                frm.Closed += (s, args) => this.Close();
                frm.Show();
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

        private void validar()
        {
            string errores = "";

            if (txtUsuario.Text.Trim() == "")
                errores += "Debe ingresar un nombre de usuario." + Environment.NewLine;

            if (txtContraseña.Text.Trim() == "")
                errores += "Debe ingresar una contraseña." + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            Usuario usuario = new UsuarioService().GetByUsername(txtUsuario.Text);

            if (usuario.Id == 0 || (usuario.TipoUsuario != TipoUsuario.Administrador))
            {
                throw new WarningException("El nombre de usuario ingresado no es válido.");
            }

            if (txtContraseña.Text != usuario.Contraseña)
            {
                throw new WarningException("Contraseña incorrecta. Intente nuevamente.");
            }
        }
    }
}
