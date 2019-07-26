using AccesoDatos.Services;
using Entities.Helpers;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class EditarNota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario.TipoUsuario != TipoUsuario.Docente)
            {
                Response.Redirect("~/Estudiante.aspx");
                return;
            }

            if (Session["ComisionDocente"] == null)
            {
                Response.Redirect("~/Comisiones.aspx");
                return;
            }

            if (Session["AlumnoComision"] == null)
            {
                Response.Redirect("~/AlumnosComision.aspx");
                return;
            }

            if (Session["Instancia"] == null)
            {
                Response.Redirect("~/NotasAlumno.aspx");
                return;
            }

            if (IsPostBack)
                return;

            AlumnoService alumnoService = new AlumnoService();
            InstanciaService instanciaService = new InstanciaService();

            int alumnoId = (int)Session["AlumnoComision"];
            long instanciaId = (long)Session["Instancia"];

            Instancia instancia = instanciaService.GetById(instanciaId);

            InstanciaAlumno instanciaAlumno = instanciaService.GetAllIncludeNotasAlumnos()
                .Find(x => x.Alumno.Id == alumnoId && x.Instancia.Id == instanciaId && x.Deshabilitado == false);

            List<string> dataSource = new List<string>();

            if (instancia.Tipo.Id == 1)
            {
                dataSource = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            }
            else
            {
                dataSource = new List<string> { "Aprobado", "Desaprobado" };
            }

            ddlNotas.DataSource = dataSource;
            ddlNotas.DataBind();

            if (instanciaAlumno != null && !string.IsNullOrEmpty(instanciaAlumno.Nota))
                ddlNotas.SelectedValue = instanciaAlumno.Nota;

            if (instanciaAlumno != null && !string.IsNullOrEmpty(instanciaAlumno.Comentarios))
                txtComentarios.Text = instanciaAlumno.Comentarios;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int alumnoId = (int)Session["AlumnoComision"];
                long instanciaId = (long)Session["Instancia"];

                string nota = ddlNotas.SelectedValue;
                string comentarios = txtComentarios.Text;

                InstanciaAlumno instanciaAlumno = new InstanciaAlumno
                {
                    Alumno = new Alumno { Id = alumnoId },
                    Instancia = new Instancia { Id = instanciaId },
                    Nota = nota,
                    Comentarios = comentarios
                };

                InstanciaService s = new InstanciaService();

                s.DeleteNota(instanciaAlumno.Instancia.Id, instanciaAlumno.Alumno.Id);

                s.InsertNota(instanciaAlumno);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "closeModal",
                    "$('#myModal').on('hide.bs.modal', function (e) {" +
                        "window.location.replace(\"/NotasAlumno.aspx\"); " +
                    "}); ", true);

                Session.Remove("Instancia");
                CrearModal("Atención", "Nota guardada con éxito.");
            }
            catch (WarningException ex)
            {
                CrearModal("Advertencia", ex.Message);
            }
            catch (Exception ex)
            {
                CrearModal("Error", "Ha ocurrido un error. Intente nuevamente en unos momentos");
                Response.Write("<script>console.log(' " + ex.Message + "');</script>");
            }
        }

        private void CrearModal(string Titulo, string Mensaje)
        {
            lblModalTitle.Text = Titulo;
            lblModalBody.Text = Mensaje;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}