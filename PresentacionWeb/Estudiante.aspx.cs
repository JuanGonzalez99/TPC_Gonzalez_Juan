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
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(),
                "tmp", "<script type='text/javascript'>alumno();</script>", false);

            var nombreUsuario = (string)Session["UserName"];

            Alumno alumno = new AlumnoService().GetAlumnoByUserName(nombreUsuario);

            txtAlumno.InnerText = "Bienvenide, " + alumno.Nombre + " " + alumno.Apellido;
        }
    }
}