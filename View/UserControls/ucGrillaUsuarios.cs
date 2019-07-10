using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Models;
using AccesoDatos.Services;
using Entities.Helpers;
using View.Forms;

namespace View.UserControls
{
    public partial class ucGrillaUsuarios : UserControl
    {
        private List<Usuario> Usuarios { get; set; }

        public ucGrillaUsuarios()
        {
            InitializeComponent();
        }

        private void ucGrillaUsuarios_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }


        private void cargarGrilla()
        {
            UsuarioService s = new UsuarioService();

            try
            {
                Usuarios = s.GetAll();
                dgvGrilla.DataSource = Usuarios.FindAll(x => x.Deshabilitado == false);
                dgvGrilla.Columns["Nombre"].HeaderText = "Nombre de usuario";
                dgvGrilla.Columns["TipoUsuario"].HeaderText = "Tipo de usuario";
                dgvGrilla.Columns["Deshabilitado"].DisplayIndex = dgvGrilla.Columns.Count - 1;
                dgvGrilla.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            frmUsuario frm = new frmUsuario((Usuario)dgvGrilla.SelectedRows[0].DataBoundItem);
            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            if (!CommonHelper.Confirma())
                return;

            try
            {
                UsuarioService s = new UsuarioService();
                Usuario entidad = (Usuario)dgvGrilla.SelectedRows[0].DataBoundItem;
                s.Delete(entidad.Id);
                cargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                dgvGrilla.DataSource = Usuarios.FindAll(x => x.Deshabilitado == false);
                dgvGrilla.Columns["Deshabilitado"].Visible = false;
            }
            else
            {
                string busqueda = txtBuscar.Text.ToUpper();
                List<Usuario> lista = Usuarios.FindAll(x => x.Id.ToString().Contains(busqueda)
                                                        || x.Nombre.ToUpper().Contains(busqueda)
                                                        || x.Contraseña.ToUpper().Contains(busqueda)
                                                        || x.TipoUsuario.Nombre.ToUpper().Contains(busqueda));
                dgvGrilla.DataSource = lista;
                dgvGrilla.Columns["Deshabilitado"].Visible = true;
            }
        }
    }
}
