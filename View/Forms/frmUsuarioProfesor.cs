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
    public partial class frmUsuarioProfesor : Form
    {
        private UsuarioProfesor usuarioProfesor { get; set; }

        private List<Profesor> Profesores { get; set; }

        public frmUsuarioProfesor()
        {
            InitializeComponent();
        }

        private void frmUsuarioProfesor_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            ProfesorService s = new ProfesorService();

            try
            {
                Profesores = s.GetAll();
                dgvProfesores.DataSource = Profesores.FindAll(x => x.Deshabilitado == false);
                dgvProfesores.Columns["Id"].HeaderText = "Legajo";
                dgvProfesores.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
                dgvProfesores.Columns["FechaIngreso"].HeaderText = "Fecha de ingreso";
                dgvProfesores.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvProfesores))
                return;

            try
            {
                if (!validar())
                    return;

                UsuarioService s = new UsuarioService();

                usuarioProfesor.Usuario.Id = s.Insert(usuarioProfesor.Usuario);

                s.AsignarProfesor(usuarioProfesor.Usuario.Id, usuarioProfesor.Profesor.Id);

                CommonHelper.ShowInfo("Usuario asignado con éxito.");
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

        private bool validar()
        {
            UsuarioService s = new UsuarioService();

            Profesor profesor = (Profesor)dgvProfesores.SelectedRows[0].DataBoundItem;
            
            usuarioProfesor = new UsuarioProfesor();
            usuarioProfesor.Profesor = profesor;
            usuarioProfesor.Usuario = new Usuario();
            usuarioProfesor.Usuario.Nombre = profesor.Id + "." + TipoUsuario.Docente.ToString().ToLower();
            usuarioProfesor.Usuario.Contraseña = profesor.DNI;
            usuarioProfesor.Usuario.TipoUsuario = TipoUsuario.Docente;
            usuarioProfesor.Usuario.Deshabilitado = false;

            var usuarios = s.GetAll().FindAll(x => x.Nombre == usuarioProfesor.Usuario.Nombre).OrderBy(x => x.Deshabilitado).ToList();

            foreach (var Usuario in usuarios)
            {
                if (Usuario.Deshabilitado == false)
                {
                    throw new WarningException("El profesor seleccionado ya tiene un usuario asociado.");
                }
                else
                {
                    if (CommonHelper.Confirma("El profesor seleccionado posee un usuario asignado que se encuentra deshabilitado. ¿Desea restaurarlo? Si selecciona \"No\", no se guardará el nuevo usuario."))
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
                    //if (!CommonHelper.Confirma("El profesor seleccionado tiene asociado un usuario deshabilitado que puede ser restaurado, ¿desea continuar de todos modos?"))
                    //    throw new WarningException("Asignación cancelada.");
                }
            }

            return true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Profesor> lista = Profesores.FindAll(x => x.Deshabilitado == false);

            if (txtBuscar.Text != "")
            {
                string busqueda = txtBuscar.Text.ToUpper();
                lista = lista.FindAll(x => x.Id.ToString().Contains(busqueda)
                                    || x.DNI.ToString().Contains(busqueda)
                                    || x.Apellido.ToUpper().Contains(busqueda)
                                    || x.Nombre.ToUpper().Contains(busqueda)
                                    || x.FechaNac.ToShortDateString().Contains(busqueda)
                                    || x.FechaIngreso.ToShortDateString().Contains(busqueda));
            }

            dgvProfesores.DataSource = lista;
        }
    }
}
