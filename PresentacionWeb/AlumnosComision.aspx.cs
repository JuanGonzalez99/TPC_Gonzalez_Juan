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
    public partial class AlumnosComision : System.Web.UI.Page
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

            if (IsPostBack)
                return;

            Comision comision = (Comision)Session["ComisionDocente"];

            AlumnoService alumnoService = new AlumnoService();
            List<AlumnoComision> lista = alumnoService.GetAlumnosComision().FindAll(x => x.Comision.Id == comision.Id
                                                                                    && x.Deshabilitado == false);

            dgvAlumnos.DataSource = lista;
            dgvAlumnos.DataBind();

            divSinRegistros.Visible = lista.Count == 0;
        }

        protected void btnNotas_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            int alumnoId = Convert.ToInt32(row.Cells[0].Text);

            Session.Add("AlumnoComision", alumnoId);
            Response.Redirect("~/NotasAlumno.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("ComisionDocente");
            Response.Redirect("~/Comisiones.aspx");
        }
    }
}