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
        }
    }
}