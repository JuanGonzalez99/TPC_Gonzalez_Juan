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
    public partial class Inscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }

            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario.TipoUsuario.Nombre.ToLower() != "estudiante")
            {
                Response.Redirect("~/Docente.aspx");
                return;
            }

            if (IsPostBack)
                return;

            AlumnoService alumnoService = new AlumnoService();

            Alumno alumno = alumnoService.GetAlumnoByUserName(usuario.Nombre);

            List<AlumnoComision> alumnoComisiones = alumnoService.GetAlumnosComision().FindAll(x => x.Alumno.Id == alumno.Id
                                                                                                && x.Deshabilitado == false);
            List<Materia> materias = alumnoComisiones.Select(x => x.Comision.Materia).ToList();

            List<Carrera> carreras = new CarreraService().GetByAlumnoId(alumno.Id);
            MateriaService materiaService = new MateriaService();
            List<Materia> lista = new List<Materia>();

            foreach (var carrera in carreras)
            {
                lista.AddRange(materiaService.GetByCarreraId(carrera.Id));
            }

            foreach (var materia in materias)
            {
                lista.RemoveAll(x => x.Id == materia.Id);
                //lista = lista.Remove(materia);
            }

            lista.OrderBy(x => x.Año).ThenBy(x => x.Cuatrimestre).ToList();

            dgvMaterias.DataSource = lista;
            dgvMaterias.DataBind();
        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            int materiaId = Convert.ToInt32(row.Cells[0].Text);

            Materia materia = new MateriaService().GetById(materiaId);

            Session.Add("MateriaEstudiante", materia);
            Response.Redirect("~/InscripcionComision.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiante.aspx");
        }
    }
}