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
    public partial class Estudiante : System.Web.UI.Page
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

            if (IsPostBack)
                return;

            Alumno alumno = new AlumnoService().GetAlumnoByUserName(usuario.Nombre);

            txtAlumno.InnerText = "Bienvenide, " + alumno.Nombre + " " + alumno.Apellido;
        }

        protected void btnInscripciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inscripciones.aspx");
        }
    }
}