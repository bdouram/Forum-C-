using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LiberForum
{
    public partial class NewPost : System.Web.UI.Page
    {
        private string conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuario"] == null){
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSair_Click(object sender, EventArgs e) {
            Session["usuario"] = null;
            Session["moderador"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextArea"].Equals("") && Request.Form["TextTitle"].Equals(""))
            {
                Response.Write("<script>alert('Você não pode salvar um post com algo em branco.');</script>");
            }
            else
            {
                salva_post();
                Response.Redirect("Home.aspx");
            }
        }

        private void salva_post()
        {
            try
            {
                string strSQL1 = "INSERT INTO Post (email,texto,titulo) VALUES('" + Session["usuario"] + "','" + Request.Form["TextArea"] + "','" + Request.Form["TextTitle"] + "')";
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL1, cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}