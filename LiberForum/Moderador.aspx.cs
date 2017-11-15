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
    public partial class Moderador : System.Web.UI.Page
    {
        private string conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["moderador"] == null || Session["moderador"].Equals(Session["usuario"])) {
                Response.Redirect("Login.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            string email = row.Cells[0].Text;

            if (e.CommandName == "Delete" && !Session["usuario"].Equals(email))
            {
                banir_Procedure(email);
                apagar_posts(email);
                deletar_usuario(email);
            }
            else if (!Session["usuario"].Equals(email))
            {
                insereModerador(email);
            }
            Response.Redirect("Moderador.aspx");
        }

        private void apagar_posts(string email) {
            try {
                string SQLPost = "SELECT id_post FROM Post WHERE email = '" + email + "'";
                string SQLDelComentarios = "DELETE FROM Comentarios WHERE id_post IN (" + SQLPost +")";
                executar_SQL(SQLDelComentarios);
                string SQLDelPost = "DELETE FROM Post WHERE email = '" + email + "'";
                executar_SQL(SQLDelPost);
                string SQLDelComentUsu = "DELETE FROM Comentarios WHERE email = '" + email + "'";
                executar_SQL(SQLDelComentUsu);
            }catch(Exception ex){
                throw (ex);
            }
        }

        private void deletar_usuario(string email) {
            try
            {
                string SQLDelPost = "DELETE FROM Usuario WHERE email = '" + email + "'";
                executar_SQL(SQLDelPost);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        
        }

        private void insereModerador(string email) {
            try {
                string SQLUsuario = "";
                if (consulta_Moderacao(email))
                {
                    SQLUsuario = "UPDATE Usuario SET moderador = 0 WHERE email = '" + email + "'";
                }
                else {
                    SQLUsuario = "UPDATE Usuario SET moderador = 1 WHERE email = '" + email + "'";
                }
                
                executar_SQL(SQLUsuario);
            }catch(Exception ex){
                throw(ex);
            }
        }

        private void executar_SQL(string strSQL) {
            SqlConnection cn = new SqlConnection(this.conexao);
            SqlCommand cmd = new SqlCommand(strSQL, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
        }

        private void banir_Procedure(string email) {
            try {
                string[] user = consulta_usuario(email);
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand("Banir", cn);
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", user[0]);
                cmd.Parameters.AddWithValue("@senha", user[1]);
                cmd.Parameters.AddWithValue("@moderador", Convert.ToBoolean(user[2]));
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();
            }catch(Exception ex){
                throw (ex);
            }
            
        }

        private bool consulta_Moderacao(string email) {
            SqlConnection cn = new SqlConnection(this.conexao);
            SqlCommand cmd = new SqlCommand("SELECT moderador FROM Usuario WHERE email = '" + email + "'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            bool i = false;
            while (dr.Read())
            {
                i = (bool) dr["moderador"];
            }
            cn.Close();
            dr.Close();
            return i;
        }

        private string[] consulta_usuario(string email) {
            try
            {
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE email = '" + email + "'", cn);
                string[] query = new string[3];
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    query[0] = (string)dr["email"];
                    query[1] = (string)dr["senha"];
                    query[2] = Convert.ToString(dr["moderador"]);
                }
                return query;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
        }
    }
}