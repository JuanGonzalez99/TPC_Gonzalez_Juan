﻿using AccesoDatos.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class MateriasEstudiante : System.Web.UI.Page
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

            if (Session["ComisionAlumno"] != null)
            {
                Session.Remove("ComisionAlumno");
            }

            if (IsPostBack)
                return;

            AlumnoService alumnoService = new AlumnoService();

            Alumno alumno = alumnoService.GetAlumnoByUserName(usuario.Nombre);

            List<AlumnoComision> alumnoComisiones = alumnoService.GetAlumnosComision(includeHorarios: true).FindAll(x => x.Alumno.Id == alumno.Id && x.Estado == EstadoMateria.Cursando && x.Deshabilitado == false);

            List<Comision> lista = alumnoComisiones.Select(x => x.Comision).ToList();

            dgvMaterias.DataSource = lista
                .OrderBy(x => x.Materia.Carrera.Id)
                .ThenBy(x => x.Año)
                .ThenBy(x => x.Cuatrimestre).ToList();
            dgvMaterias.DataBind();

            divSinRegistros.Visible = lista.Count == 0;
        }

        protected void btnNotas_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow row = (GridViewRow)button.NamingContainer;

            long comisionId = Convert.ToInt64(row.Cells[0].Text);

            Session.Add("ComisionAlumno", comisionId);
            Response.Redirect("~/Notas.aspx");
        }

        protected void btnDarseDeBaja_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiante.aspx");
        }
    }
}