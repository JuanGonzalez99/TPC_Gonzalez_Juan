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
    public partial class Notas : System.Web.UI.Page
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

            if (Session["ComisionAlumno"] == null)
            {
                Response.Redirect("~/MateriasEstudiante.aspx");
                return;
            }

            if (IsPostBack)
                return;

            AlumnoService alumnoService = new AlumnoService();
            ComisionService comisionService = new ComisionService();
            InstanciaService instanciaService = new InstanciaService();

            Alumno alumno = alumnoService.GetAlumnoByUserName(usuario.Nombre);
            Comision comision = comisionService.GetById((long)Session["ComisionAlumno"]);

            lblComision.Text = comision.ToString();

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
    }
}