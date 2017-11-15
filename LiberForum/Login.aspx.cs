using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace LiberForum
{
    public partial class Login : System.Web.UI.Page
    {
        private string conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool Existe_Usuario()
        {
            
            try
            {

                string strSQL = "SELECT u.email, u.moderador FROM Usuario u WHERE email ='" + inputEmail.Text + "'AND senha='" + inputPassword.Text+"'";
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                int i = 0;
                while (dr.Read())
                {
                    Session["usuario"] = (string) dr["email"];
                    Session["moderador"] = (bool) dr["moderador"];
                    i++;
                }

                if (i != 0) {
                    bool moderador = (bool) Session["moderador"];
                    if (!moderador)
                    {
                        Session["moderador"] = null;
                    }
                }
                
                dr.Close();
                cn.Close();

                return (i > 0);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (Existe_Usuario())
            {
                Response.Redirect("Home.aspx");
            }
            else {
                Response.Write("<script>alert('Usuário e/ou senha incorreto(s).');</script>");
            }
            
            //senao ->alerta de erro
        }
    }
}