using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiberForum.Classes;
using System.Data;
using System.Data.SqlClient;

namespace LiberForum
{
    public partial class Register : System.Web.UI.Page
    {
        string conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Existe_Usuario())
            {
                Response.Write("<script>alert('Esse e-mail já está cadastrado.');</script>");
            }
            else
            {
                if (salva_usuario() == true)
                {
                    Session["usuario"] = inputEmail.Text;
                    Response.Redirect("Home.aspx");
                }
                else {
                    Response.Write("<script>alert('Erro ao salvar no Banco de Dados.');</script>");
                }
                
            }
        }

        private bool Existe_Usuario()
        {
            try
            {

                string strSQL = "SELECT u.email FROM Usuario u WHERE email ='" + inputEmail.Text + "'";
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                int i = 0;
                while (dr.Read())
                {
                    i++;
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

        private bool salva_usuario()
        {
            try
            {
                string strSQL1 = "INSERT INTO Usuario (email,senha,moderador) VALUES('" + inputEmail.Text + "','" + inputPassword.Text + "','0')" ;
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL1, cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                cn.Close();

                return (i > 0);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

}