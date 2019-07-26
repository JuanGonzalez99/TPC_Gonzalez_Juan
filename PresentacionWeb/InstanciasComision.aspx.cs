using AccesoDatos.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace PresentacionWeb
{
    public partial class InstanciasComision : System.Web.UI.Page
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

            InstanciaService instanciaService = new InstanciaService();
            List<Instancia> lista = instanciaService.GetAll().FindAll(x => x.Comision.Id == comision.Id
                                                                                    && x.Deshabilitado == false);

            dgvInstancias.DataSource = lista;
            dgvInstancias.DataBind();

            divSinRegistros.Visible = lista.Count == 0;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgregarInstancia.aspx");
        }

        [WebMethod(EnableSession = true)]
        public static string DeleteInstancia(string instancia)
        {
            try
            {
                long instanciaId = long.Parse(instancia);

                InstanciaService s = new InstanciaService();

                var notasAlumnos = s.GetAllIncludeNotasAlumnos().FindAll(x => x.Instancia.Id == instanciaId && x.Deshabilitado == false);

                bool pudoBorrar;

                if (notasAlumnos != null && notasAlumnos.Count > 0)
                {
                    pudoBorrar = false;
                }
                else
                {
                    s.Delete(instanciaId);
                    pudoBorrar = true;
                }

                return JsonConvert.SerializeObject(new { exito = pudoBorrar });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new { exito = false, error = ex.Message });
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("ComisionDocente");
            Response.Redirect("~/Comisiones.aspx");
        }
    }
}