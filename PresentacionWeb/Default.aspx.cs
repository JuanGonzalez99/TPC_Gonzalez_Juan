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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                Response.Redirect("~/Estudiante.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioService s = new UsuarioService(); 

            Usuario usuario = s.GetByUsername(txtUsuario.Value);

            if (usuario.Id == 0)
            {
                CrearModal("Atención", "El nombre de usuario ingresado no se encuentra registrado. ");
            }
            else if (usuario.Contraseña != txtPassword.Value)
            {
                CrearModal("Atención", "La contraseña ingresada es incorrecta. ");
            }
            else
            {
                Session.Add("UserName", txtUsuario.Value);
                Response.Redirect("~/Estudiante.aspx");
            }
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