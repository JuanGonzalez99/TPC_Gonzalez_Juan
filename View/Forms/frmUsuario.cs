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
    public partial class frmUsuario : Form
    {
        private Usuario usuario;

        public frmUsuario()
        {
            InitializeComponent();
        }

        public frmUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = Enum.GetValues(typeof(TipoUsuario));

            if (this.usuario != null)
            {
                txtID.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre;
                txtContraseña.Text = usuario.Contraseña;
                cmbTipo.SelectedIndex = cmbTipo.FindString(usuario.TipoUsuario.ToString());
            }
            else
            {
                cmbTipo.SelectedIndex = -1;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                validarEntidad();

                UsuarioService s = new UsuarioService();

                if (this.usuario.Id != 0)
                    s.Update(usuario);
                else
                    s.Insert(usuario);

                CommonHelper.ShowInfo("Usuario guardado con éxito.");
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
                errores += "Debe ingresar un nomber. " + Environment.NewLine;

            if (txtContraseña.Text.Trim() == "")
                errores += "Debe ingresar una contraseña. " + Environment.NewLine;

            if (cmbTipo.SelectedItem == null)
                errores += "Debe seleccionar un tipo de usuario. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            if (usuario == null) usuario = new Usuario();
            usuario.Nombre = txtNombre.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.TipoUsuario = (TipoUsuario)cmbTipo.SelectedItem;
        }
    }
}
