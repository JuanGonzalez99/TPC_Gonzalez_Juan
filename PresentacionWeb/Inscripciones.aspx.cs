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
            if (Session["UserName"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            AlumnoService alumnoService = new AlumnoService();

            Alumno alumno = alumnoService.GetAlumnoByUserName((string)Session["UserName"]);

            List<Carrera> carreras = new CarreraService().GetByAlumnoId(alumno.Id);

            MateriaService s = new MateriaService();
            List<Materia> lista = new List<Materia>();

            foreach (var carrera in carreras)
            {
                lista.AddRange(s.GetByCarreraId(carrera.Id));
            }

            dgvMaterias.DataSource = lista;
            dgvMaterias.DataBind();

            
            if (dgvMaterias.Columns.Count > 0)
            {
                dgvMaterias.Columns[0].Visible = false;
                dgvMaterias.Columns[4].Visible = false;
            }
            else
            {
                dgvMaterias.HeaderRow.Cells[0].Visible = false;
                dgvMaterias.HeaderRow.Cells[4].Visible = false;
                foreach (GridViewRow gvr in dgvMaterias.Rows)
                {
                    gvr.Cells[0].Visible = false;
                    gvr.Cells[4].Visible = false;
                }
            }
        }
    }
}