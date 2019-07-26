using AccesoDatos.Services;
using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class NotasAlumno : System.Web.UI.Page
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
                Response.Redirect("~/AlumnosComision");
                return;
            }

            if (IsPostBack)
                return;

            AlumnoService alumnoService = new AlumnoService();
            ComisionService comisionService = new ComisionService();
            InstanciaService instanciaService = new InstanciaService();

            Alumno alumno = alumnoService.GetById((int)Session["AlumnoComision"]);

            lblAlumno.Text = alumno.ToString();

            Comision comision = (Comision)Session["ComisionDocente"];

            List<Instancia> instancias = instanciaService.GetAll()
                .FindAll(x => x.Comision.Id == comision.Id && x.Deshabilitado == false);

            List<InstanciaAlumno> conNota = instanciaService.GetAllIncludeNotasAlumnos()
                .FindAll(x => instancias.Any(y => y.Id == x.Instancia.Id) && x.Alumno.Id == alumno.Id && x.Deshabilitado == false);

            List<InstanciaAlumno> lista = new List<InstanciaAlumno>();

            foreach (var instancia in instancias)
            {
                InstanciaAlumno instanciaAlumno = new InstanciaAlumno();
                instanciaAlumno.Instancia = instancia;

                var aux = conNota.Find(x => x.Instancia.Id == instancia.Id && x.Deshabilitado == false);
                if (aux != null)
                {
                    instanciaAlumno.Nota = aux.Nota;
                    instanciaAlumno.Comentarios = aux.Comentarios;
                }

                lista.Add(instanciaAlumno);
            }
            
            dgvNotas.DataSource = lista;
            dgvNotas.DataBind();

            divSinRegistros.Visible = lista.Count == 0;
        }
        
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            long instanciaId = Convert.ToInt64(row.Cells[0].Text);

            Session.Add("Instancia", instanciaId);
            Response.Redirect("~/EditarNota.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            long instanciaId = Convert.ToInt64(row.Cells[0].Text);
            int alumnoId = (int)Session["AlumnoComision"];

            try
            {
                InstanciaService s = new InstanciaService();

                s.DeleteNota(instanciaId, alumnoId);

                row.Cells[2].Text = "";
            }
            catch (Exception ex)
            {
                CrearModal("Error", "Ha ocurrido un error. Intente nuevamente en unos momentos");
                Response.Write("<script>console.log(' " + ex.Message + "');</script>");
            }

        }

        [WebMethod (EnableSession = true)]
        public static string DeleteNota(string instancia)
        {
            try
            {
                int alumnoId = (int)HttpContext.Current.Session["AlumnoComision"];
                long instanciaId = long.Parse(instancia);

                InstanciaService s = new InstanciaService();

                s.DeleteNota(instanciaId, alumnoId);

                return JsonConvert.SerializeObject(new { exito = true });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { exito = false, error = ex.Message });
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("AlumnoComision");
            Response.Redirect("~/AlumnosComision.aspx");
        }

        private void CrearModal(string Titulo, string Mensaje)
        {
            lblModalTitle.Text = Titulo;
            lblModalBody.Text = Mensaje;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void dgvNotas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nota = e.Row.Cells[3].Text;
                if (string.IsNullOrEmpty(nota) || nota.Trim() == "" || nota == "&nbsp;")
                {
                    e.Row.Cells[5].Controls[3].Visible = false;
                }
            }
        }
    }
}