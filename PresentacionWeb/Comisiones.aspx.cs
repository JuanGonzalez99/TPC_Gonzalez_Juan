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
    public partial class Comisiones : System.Web.UI.Page
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

            if (Session["ComisionDocente"] != null)
            {
                Session.Remove("ComisionDocente");
            }

            if (IsPostBack)
                return;

            ProfesorService profesorService = new ProfesorService();

            Profesor profesor = profesorService.GetProfesorByUserName(usuario.Nombre);

            List<Comision> lista = new ComisionService().GetAll().FindAll(x => x.Profesor.Id == profesor.Id 
                                                                        || (x.Ayudante == null ? false : x.Ayudante.Id == profesor.Id));

            dgvComisiones.DataSource = lista
                .OrderByDescending(x => x.Año)
                .ThenBy(x => x.Cuatrimestre).ToList();
            dgvComisiones.DataBind();

            divSinRegistros.Visible = lista.Count == 0;
        }

        protected void btnAlumnos_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            long comisionId = Convert.ToInt64(row.Cells[0].Text);

            Comision comision = new ComisionService().GetById(comisionId);

            Session.Add("ComisionDocente", comision);
            Response.Redirect("~/AlumnosComision.aspx");
        }

        protected void btnInstancias_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            long comisionId = Convert.ToInt64(row.Cells[0].Text);

            Comision comision = new ComisionService().GetById(comisionId);

            Session.Add("ComisionDocente", comision);
            Response.Redirect("~/InstanciasComision.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Docente.aspx");
        }
    }
}