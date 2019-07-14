using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Session.Remove("Usuario");
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}