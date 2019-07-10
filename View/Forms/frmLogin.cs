using AccesoDatos.Services;
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
            if (txtUsuario.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un nombre de usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtContraseña.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Usuario usuario = new UsuarioService().GetByUsername(txtUsuario.Text);

            if (usuario.Id == 0 || (usuario.TipoUsuario != null && usuario.TipoUsuario.Id != 3))
            {
                MessageBox.Show("El nombre de usuario ingresado no es válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContraseña.Text != usuario.Contraseña)
            {
                MessageBox.Show("Contraseña incorrecta. Intente nuevamente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            this.Hide();
            var frm = new frmPrincipal();
            frm.Closed += (s, args) => this.Close();
            frm.Show();
        }
    }
}
