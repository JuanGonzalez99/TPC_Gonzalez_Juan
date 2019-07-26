using AccesoDatos.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class AgregarInstancia : System.Web.UI.Page
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

            InstanciaService s = new InstanciaService();

            List<TipoInstancia> lista = s.GetAllTipoInstancias();

            ddlTipo.DataSource = lista;
            ddlTipo.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                InstanciaService s = new InstanciaService();
                Instancia instancia = validar();

                s.Insert(instancia);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "closeModal", 
                    "$('#myModal').on('hide.bs.modal', function (e) {" +
                        "window.location.replace(\"/InstanciasComision.aspx\"); " +
                    "}); ", true);

                CrearModal("Atención", "Instancia creada con éxito.");
            }
            catch (WarningException ex)
            {
                CrearModal("Advertencia", ex.Message);
            }
            catch (Exception ex)
            {
                CrearModal("Error", "Ha ocurrido un error. Intente nuevamente en unos momentos");
                Response.Write("<script>console.log(' " + ex.Message + "');</script>");
            }
        }

        private Instancia validar()
        {
            Instancia instancia = new Instancia();
            InstanciaService s = new InstanciaService();

            instancia.Comision = (Comision)Session["ComisionDocente"];
            instancia.Nombre = txtNombre.Text;
            instancia.Tipo = s.GetTipoInstanciaByDesc(ddlTipo.SelectedValue);

            if (instancia.Nombre.Trim() == "")
            {
                throw new WarningException("Por favor, ingrese el nombre de la instancia.");
            }

            var instancias = s.GetAll().FindAll(x => x.Comision.Id == instancia.Comision.Id && x.Deshabilitado == false);

            foreach (var Instancia in instancias)
            {
                if (Instancia.Nombre == instancia.Nombre)
                {
                    throw new WarningException("Ya existe una instancia con el mismo nombre. Cámbielo e intente nuevamente.");
                }
            }

            return instancia;
        }

        private void CrearModal(string Titulo, string Mensaje)
        {
            lblModalTitle.Text = Titulo;
            lblModalBody.Text = Mensaje;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}