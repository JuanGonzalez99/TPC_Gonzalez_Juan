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
using System.Reflection;

namespace View.UserControls
{
    public partial class ucGrillaUsuarios : UserControl
    {
        private List<Usuario> Usuarios { get; set; }
        private List<UsuarioAlumno> UsuariosAlumnos { get; set; }
        private List<UsuarioProfesor> UsuariosProfesores { get; set; }

        private bool Carga;

        public ucGrillaUsuarios()
        {
            InitializeComponent();
        }

        private void ucGrillaUsuarios_Load(object sender, EventArgs e)
        {
            Carga = true;

            dgvGrilla.AutoGenerateColumns = false;

            cmbTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuario));
            cmbTipoUsuario.SelectedIndex = -1;

            Carga = false;
        }


        private void cargarGrilla()
        {
            UsuarioService s = new UsuarioService();

            try
            {
                TipoUsuario tipo = (TipoUsuario)cmbTipoUsuario.SelectedItem;

                Usuarios = s.GetAll();
                UsuariosAlumnos = s.GetAllAlumnos();
                UsuariosProfesores = s.GetAllProfesores();

                dgvGrilla.Columns.Clear();
                dgvGrilla.AutoGenerateColumns = false;

                switch (tipo)
                {
                    case TipoUsuario.Estudiante:
                        {
                            dgvGrilla.DataSource = UsuariosAlumnos.FindAll(x => x.Alumno.Deshabilitado == false && x.Usuario.Deshabilitado == false);

                            DataGridViewTextBoxColumn dgvc;

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Alumno.Id"; dgvc.HeaderText = "Legajo";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Alumno"; dgvc.HeaderText = "Alumno";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Usuario.Nombre"; dgvc.HeaderText = "Nombre de usuario";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Usuario.Contraseña"; dgvc.HeaderText = "Contraseña";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Usuario.TipoUsuario"; dgvc.HeaderText = "Tipo de usuario";
                            dgvGrilla.Columns.Add(dgvc);

                        } break;
                    case TipoUsuario.Docente:
                        {
                            dgvGrilla.DataSource = UsuariosProfesores.FindAll(x => x.Profesor.Deshabilitado == false && x.Usuario.Deshabilitado == false);

                            DataGridViewTextBoxColumn dgvc;

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Profesor.Id"; dgvc.HeaderText = "Legajo";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Profesor"; dgvc.HeaderText = "Profesor";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Usuario.Nombre"; dgvc.HeaderText = "Nombre de usuario";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Usuario.Contraseña"; dgvc.HeaderText = "Contraseña";
                            dgvGrilla.Columns.Add(dgvc);

                            dgvc = new DataGridViewTextBoxColumn();
                            dgvc.DataPropertyName = "Usuario.TipoUsuario"; dgvc.HeaderText = "Tipo de usuario";
                            dgvGrilla.Columns.Add(dgvc);

                        } break;
                    case TipoUsuario.Administrador:
                        {
                            dgvGrilla.AutoGenerateColumns = true;
                            dgvGrilla.DataSource = Usuarios.FindAll(x => x.TipoUsuario == tipo && x.Deshabilitado == false);
                            dgvGrilla.Columns["Id"].Visible = false;
                            dgvGrilla.Columns["Nombre"].HeaderText = "Nombre de usuario";
                            dgvGrilla.Columns["TipoUsuario"].HeaderText = "Tipo de usuario";
                            dgvGrilla.Columns["Deshabilitado"].Visible = false;
                        } break;
                }
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbTipoUsuario.SelectedItem == null)
            {
                CommonHelper.ShowWarning("Debe seleccionar un tipo de usuario.");
                return;
            }

            var frm = new Form();

            switch ((TipoUsuario)cmbTipoUsuario.SelectedItem)
            {
                case TipoUsuario.Estudiante:
                    frm = new frmUsuarioAlumno();
                    break;
                case TipoUsuario.Docente:
                    break;
                case TipoUsuario.Administrador:
                    break;
            }

            if (frm.ShowDialog() == DialogResult.OK)
                cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvGrilla))
                return;

            var frm = new Form();

            switch ((TipoUsuario)cmbTipoUsuario.SelectedItem)
            {
                case TipoUsuario.Estudiante:
                    UsuarioAlumno obj = (UsuarioAlumno)dgvGrilla.SelectedRows[0].DataBoundItem;
                    frm = new frmUsuarioAlumno(obj);
                    break;
                case TipoUsuario.Docente:
                    break;
                case TipoUsuario.Administrador:
                    break;
            }

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
                CommonHelper.ShowError(ex.Message);
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
                                                        || x.TipoUsuario.ToString().ToUpper().Contains(busqueda));
                dgvGrilla.DataSource = lista;
                dgvGrilla.Columns["Deshabilitado"].Visible = true;
            }
        }

        private void cmbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Carga) return;

            if (cmbTipoUsuario.SelectedItem == null)
                return;

            TipoUsuario tipoUsuario = (TipoUsuario)cmbTipoUsuario.SelectedItem;
            
            cargarGrilla();
        }

        #region Acceso a propiedades en grilla

        //Gracias al link http://www.developer-corner.com/blog/2007/07/19/datagridview-how-to-bind-nested-objects/

        private void dgvGrilla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dgvGrilla.Rows[e.RowIndex].DataBoundItem != null) 
                && (dgvGrilla.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(dgvGrilla.Rows[e.RowIndex].DataBoundItem, 
                    dgvGrilla.Columns[e.ColumnIndex].DataPropertyName);
            }
        }

        private string BindProperty(object property, string propertyName)
        {
            string retValue = "";

            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;

                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();

                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;

                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }

            return retValue;
        }

        #endregion
    }
}
