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
    public partial class frmUsuarioAlumno : Form
    {
        private UsuarioAlumno usuarioAlumno { get; set; }

        private List<Alumno> Alumnos { get; set; }

        public frmUsuarioAlumno()
        {
            InitializeComponent();
        }

        private void frmUsuarioAlumno_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            AlumnoService s = new AlumnoService();

            try
            {
                Alumnos = s.GetAll();
                dgvAlumnos.DataSource = Alumnos.FindAll(x => x.Deshabilitado == false);
                dgvAlumnos.Columns["Id"].HeaderText = "Legajo";
                dgvAlumnos.Columns["FechaNac"].HeaderText = "Fecha de nacimiento";
                dgvAlumnos.Columns["Deshabilitado"].Visible = false;
            }
            catch (Exception ex)
            {
                CommonHelper.ShowError(ex.Message);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (!CommonHelper.SeleccionoRegistro(dgvAlumnos))
                return;

            try
            {
                if (!validar())
                    return;

                UsuarioService s = new UsuarioService();

                usuarioAlumno.Usuario.Id = s.Insert(usuarioAlumno.Usuario);

                s.AsignarAlumno(usuarioAlumno.Usuario.Id, usuarioAlumno.Alumno.Id);

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

            Alumno alumno = (Alumno)dgvAlumnos.SelectedRows[0].DataBoundItem;

            usuarioAlumno = new UsuarioAlumno();
            usuarioAlumno.Alumno = alumno;
            usuarioAlumno.Usuario = new Usuario();
            usuarioAlumno.Usuario.Nombre = alumno.Id + "." + TipoUsuario.Estudiante.ToString().ToLower();
            usuarioAlumno.Usuario.Contraseña = alumno.DNI;
            usuarioAlumno.Usuario.TipoUsuario = TipoUsuario.Estudiante;
            usuarioAlumno.Usuario.Deshabilitado = false;

            var usuarios = s.GetAll().FindAll(x => x.Nombre == usuarioAlumno.Usuario.Nombre).OrderBy(x => x.Deshabilitado).ToList();

            foreach (var Usuario in usuarios)
            {
                if (Usuario.Deshabilitado == false)
                {
                    throw new WarningException("El alumno seleccionado ya tiene un usuario asociado.");
                }
                else
                {
                    if (CommonHelper.Confirma("El alumno seleccionado posee un usuario asignado que se encuentra deshabilitado. ¿Desea restaurarlo? Si selecciona \"No\", no se guardará el nuevo usuario."))
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
                    //if (!CommonHelper.Confirma("El alumno seleccionado tiene asociado un usuario deshabilitado que puede ser restaurado, ¿desea continuar de todos modos?"))
                    //    throw new WarningException("Asignación cancelada.");
                }
            }

            return true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Alumno> lista = Alumnos.FindAll(x => x.Deshabilitado == false);

            if (txtBuscar.Text != "")
            {
                string busqueda = txtBuscar.Text.ToUpper();
                lista = lista.FindAll(x => x.Id.ToString().Contains(busqueda)
                                    || x.DNI.ToString().Contains(busqueda)
                                    || x.Apellido.ToUpper().Contains(busqueda)
                                    || x.Nombre.ToUpper().Contains(busqueda)
                                    || x.FechaNac.ToShortDateString().Contains(busqueda));
            }

            dgvAlumnos.DataSource = lista;
        }
    }
}
