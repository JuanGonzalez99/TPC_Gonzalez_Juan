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

            if (usuario.TipoUsuario != TipoUsuario.Estudiante)
            {
                Response.Redirect("~/Docente.aspx");
                return;
            }

            if (Session["MateriaEstudiante"] != null)
            {
                Session.Remove("MateriaEstudiante");
            }

            if (IsPostBack)
                return;

            #region Creacion de listado de materias a las que se puede inscribir

            AlumnoService alumnoService = new AlumnoService();
            MateriaService materiaService = new MateriaService();

            Alumno alumno = alumnoService.GetAlumnoByUserName(usuario.Nombre);

            List<AlumnoComision> alumnoComisiones = alumnoService.GetAlumnosComision()
                .FindAll(x => x.Alumno.Id == alumno.Id && x.Deshabilitado == false);

            List<Materia> materiasAExcluir = alumnoComisiones
                .Where(x => x.Estado <= EstadoMateria.Cursando)
                .Select(x => x.Comision.Materia).ToList();

            List<Carrera> carreras = new CarreraService().GetByAlumnoId(alumno.Id);
            List<Materia> lista = new List<Materia>();

            foreach (var carrera in carreras)
            {
                lista.AddRange(materiaService.GetByCarreraId(carrera.Id));
            }

            List<Materia> aux = new List<Materia>(lista);

            foreach (var materia in aux)
            {
                List<MateriaCorrelativa> materiasCorrelativas = materiaService.GetCorrelativasById(materia.Id)
                    .FindAll(x => x.Deshabilitado == false);
 
                foreach (var correlativa in materiasCorrelativas)
                {
                    bool puedeCursar = false;

                    foreach (var alumnoComision in alumnoComisiones)
                    {
                        if (alumnoComision.Comision.Materia.Id == correlativa.Correlativa.Id
                            && (alumnoComision.Estado == correlativa.EstadoRequerido || alumnoComision.Estado == EstadoMateria.Aprobada))
                            puedeCursar = true;
                    }

                    if (!puedeCursar)
                    {
                        lista.Remove(materia);
                        break;
                    }
                }

            }

            foreach (var materia in materiasAExcluir)
            {
                lista.RemoveAll(x => x.Id == materia.Id);
            }

            #endregion

            dgvMaterias.DataSource = lista
                .OrderBy(x => x.Carrera.Id)
                .ThenBy(x => x.Año)
                .ThenBy(x => x.Cuatrimestre).ToList();

            dgvMaterias.DataBind();

            divSinRegistros.Visible = lista.Count == 0;
        }

        protected void btnComisiones_Click(object sender, EventArgs e)
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