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
    public partial class EditarPost : System.Web.UI.Page
    {
        private string conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        private string id_coment_on_post;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.id_coment_on_post = Request.QueryString["post"];

            if (Session["moderador"] != null)
            {
                string[] post = consulta_usuario_moderador();
                TextTitle.Text = post[0];
                TextArea.Text = post[1];
            }
            else {
                string[] post = consulta_usuario();
                if (Session["usuario"] == null || post[0].Equals(""))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    TextTitle.Text = post[0];
                    TextArea.Text = post[1];
                }
            }
            
        }

        private string[] consulta_usuario() {
            try
            {
                string[] resultado= new string[2];
                string strSQL = "SELECT p.titulo,p.texto FROM Post p WHERE p.id_post = " + this.id_coment_on_post + " AND p.email='" + (string)Session["usuario"] + "'";
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    resultado[0] = (string)dr["titulo"];
                    resultado[1] = (string)dr["texto"];
                }

                dr.Close();
                cn.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextArea"].Equals(""))
            {
                Response.Write("<script>alert('Você não pode salvar um comentário em branco.');</script>");
            }
            else
            {
                salva_post();
                Response.Redirect("Post.aspx?post=" + this.id_coment_on_post);
            }
        }

        protected void btnApagar_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                apagar_post();
                Response.Redirect("Home.aspx");
            }
            else
            {
                // Não faz nada.
            }
        }

        private void salva_post()
        {
            try
            {
                DateTime now = DateTime.Now;
                string hora_edicao = now.Day + "/" + now.Month + "/" + now.Year + " às " + now.Hour + ":" + now.Minute + ":" + now.Second + ".";
                string strSQL = "UPDATE Post SET texto ='" + Request.Form["TextArea"] + "    (Editado em:" + hora_edicao + ")' WHERE id_post=" + this.id_coment_on_post;
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void apagar_post() {
            try
            {
                DateTime now = DateTime.Now;
                string strSQL1 = "DELETE FROM Comentarios WHERE id_post = "+this.id_coment_on_post;
                string strSQL2 = "DELETE FROM Post WHERE id_post = " + this.id_coment_on_post;
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd1 = new SqlCommand(strSQL1, cn);
                SqlCommand cmd2 = new SqlCommand(strSQL2, cn);
                cn.Open();

                int i = cmd1.ExecuteNonQuery();
                int j = cmd2.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private string[] consulta_usuario_moderador()
        {
            try
            {
                string[] resultado = new string[2];
                string strSQL = "SELECT p.titulo,p.texto FROM Post p WHERE p.id_post = '" + this.id_coment_on_post + "'";
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    resultado[0] = (string)dr["titulo"];
                    resultado[1] = (string)dr["texto"];
                }

                dr.Close();
                cn.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}