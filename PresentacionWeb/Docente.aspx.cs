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
    public partial class Docente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario.TipoUsuario.Nombre.ToLower() != "docente")
            {
                Response.Redirect("~/Estudiante.aspx");
                return;
            }

            Profesor profesor = new ProfesorService().GetProfesorByUserName(usuario.Nombre);

            txtProfesor.InnerText = "Bienvenide, " + profesor.Nombre + " " + profesor.Apellido;
        }

        protected void btnComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comisiones.aspx");
        }
    }
}