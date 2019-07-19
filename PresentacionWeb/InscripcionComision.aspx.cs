using AccesoDatos.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class InscripcionComision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario.TipoUsuario != TipoUsuario.Estudiante)
            {
                Response.Redirect("~/Docente.aspx");
                return;
            }

            if (Session["MateriaEstudiante"] == null)
            {
                Response.Redirect("~/Estudiante.aspx");
                return;
            }

            if (IsPostBack)
                return;

            AlumnoService alumnoService = new AlumnoService();
            ComisionService comisionService = new ComisionService();

            Alumno alumno = alumnoService.GetAlumnoByUserName(usuario.Nombre);

            Materia materia = (Materia)Session["MateriaEstudiante"];

            List<Comision> lista = comisionService.GetActualesByMateria(materia.Id);

            try
            {
                dgvComisiones.DataSource = lista;
                dgvComisiones.DataBind();
            }
            catch (Exception ex)
            {
                CrearModal("Error", ex.Message);
            }
            finally
            {
                divSinRegistros.Visible = lista.Count == 0;
            }

        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            long comisionId = Convert.ToInt32(row.Cells[0].Text);
            string materia = row.Cells[1].Text;

            try
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                Alumno alumno = new AlumnoService().GetAlumnoByUserName(usuario.Nombre);

                new ComisionService().InscribirAlumno(comisionId, alumno.Id);
                Session.Remove("MateriaEstudiante");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                //    "alert(Usted se ha inscripto correctamente para la materia " + materia + ".); window.location=''" + Request.ApplicationPath + "Inscripciones.aspx", true);
                //CrearModal("Atención", "Usted se ha inscripto correctamente para la materia " + materia + ".");
                Response.Redirect("~/Inscripciones.aspx");
            }
            catch (Exception ex)
            {
                CrearModal("Error", "Algo salió mal, intente nuevamente en unos instantes.");
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("MateriaEstudiante");
            Response.Redirect("~/Inscripciones.aspx");
        }

        private void CrearModal(string Titulo, string Mensaje)
        {
            lblModalTitle.Text = Titulo;
            lblModalBody.Text = Mensaje;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalInscripto", "$('#modalInscripto').modal();", true);
            upModal.Update();
        }
    }
}