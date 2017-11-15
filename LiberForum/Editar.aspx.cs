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
    public partial class Editar : System.Web.UI.Page
    {
        private string conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        private string id_coment_on_post;
        private string retornoPagina;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else {
                this.id_coment_on_post = Request.QueryString["post"];
                this.retornoPagina = Request.QueryString["retorno"];
                string comentario = consulta_Comentario(id_coment_on_post);
                if (!comentario.Equals(""))
                {
                    TextArea.Text = comentario;
                }
                else {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        private string consulta_Comentario(string id_comentario) {
            try
            {

                string resultado ="";
                string strSQL = "SELECT c.email,c.texto FROM Comentarios c WHERE c.id_comentario=" + id_comentario + " AND c.email='" + (string) Session["usuario"]+"'";
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    resultado = (string)dr["texto"];
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

        private void salva_comentario() { 
            try
            {
                DateTime now = DateTime.Now;
                string hora_edicao = now.Day+ "/"+now.Month+"/"+now.Year+ " às "+now.Hour+":"+now.Minute+":"+now.Second+".";
                string strSQL = "UPDATE comentarios SET texto ='" + Request.Form["TextArea"]  + "    (Editado em:" + hora_edicao + ")' WHERE id_comentario=" + this.id_coment_on_post;
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

        private void deleta_comentario()
        {
            try
            {
                DateTime now = DateTime.Now;

                string strSQL = "DELETE FROM Comentarios WHERE id_comentario=" + this.id_coment_on_post;   
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

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Request.Form["TextArea"].Equals(""))
            {
                Response.Write("<script>alert('Você não pode salvar um comentário em branco.');</script>");
            }
            else {
                salva_comentario();
                Response.Redirect("Post.aspx?post="+this.retornoPagina);
            }
        }

        protected void btnApagar_Click(object sender, EventArgs e) {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                deleta_comentario();
                Response.Redirect("Post.aspx?post=" + this.retornoPagina);
            }
            else
            {
                // Não faz nada.
            }
        }
    }
}