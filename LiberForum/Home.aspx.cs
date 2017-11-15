using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LiberForum
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["moderador"] = null;
            Response.Redirect("Login.aspx");
        }

    }
}