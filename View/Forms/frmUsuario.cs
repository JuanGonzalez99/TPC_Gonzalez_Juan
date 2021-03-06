﻿using AccesoDatos.Services;
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
                txtNombre.Text = usuario.Nombre;
                txtContraseña.Text = usuario.Contraseña;
                cmbTipo.SelectedIndex = cmbTipo.FindString(usuario.TipoUsuario.ToString());

                txtNombre.Enabled = usuario.TipoUsuario == TipoUsuario.Administrador;
            }
            else
            {
                cmbTipo.SelectedIndex = cmbTipo.FindString(TipoUsuario.Administrador.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarEntidad())
                    return;

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

        private bool validarEntidad()
        {
            string errores = "";

            if (txtNombre.Text.Trim() == "")
                errores += "Debe ingresar un nombre. " + Environment.NewLine;

            if (txtContraseña.Text.Trim() == "")
                errores += "Debe ingresar una contraseña. " + Environment.NewLine;

            if (errores != "")
            {
                throw new WarningException(errores);
            }

            if (usuario == null) usuario = new Usuario();
            usuario.Nombre = txtNombre.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.TipoUsuario = (TipoUsuario)cmbTipo.SelectedItem;

            if (usuario.TipoUsuario == TipoUsuario.Administrador && (usuario.Nombre.Contains(".docente") || usuario.Nombre.Contains(".estudiante")))
            {
                throw new WarningException("Por favor, no utilice las extensiones utilizadas para otro tipo de usuarios. Puede generar conflictos.");
            }

            UsuarioService s = new UsuarioService();

            var usuarios = s.GetAll().OrderBy(x => x.Deshabilitado).ToList();

            foreach (var Usuario in usuarios)
            {
                if (Usuario.Id == usuario.Id)
                    continue;

                if (Usuario.Nombre != usuario.Nombre)
                    continue;
                
                if (Usuario.Deshabilitado == false)
                {
                    throw new WarningException("Ya existe un usuario con el mismo nombre.");
                }

                //if (!CommonHelper.Confirma("Existe un usuario deshabilitado con el mismo nombre del tipo " + 
                //    Usuario.TipoUsuario + " que puede ser restaurado, ¿desea continuar de todos modos?"))
                //    throw new WarningException("Guardado cancelado.");

                if (CommonHelper.Confirma("Existe un usuario deshabilitado con el mismo nombre. ¿Desea restaurarlo? Si selecciona \"No\", no se guardará el nuevo usuario."))
                {
                    s.Restaurar(Usuario.Id);

                    CommonHelper.ShowInfo("Usuario restaurado correctamente.");
                    this.DialogResult = DialogResult.OK;

                    return false;
                }
                else
                {
                    throw new WarningException("Restauración cancelada");
                }
            }

            return true;
        }
    }
}
