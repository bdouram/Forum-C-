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
    public partial class WebForm2 : System.Web.UI.Page
    {
        #region Atributos
        private string conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        private string titulo;
        private string pergunta;
        private string autor;
        private string texto;
        private string id_postagem;
        private IDictionary<string, string> comentarios = new Dictionary<string, string>();
        #endregion
       
        #region Encapsulamento
        
        public IDictionary<string, string> Comentarios
        {
            get { return this.comentarios; }
            set { this.comentarios = value; }
        }

        public string Autor {
            get { return this.autor; }
            set { this.autor = value; }
        }

        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        public string Pergunta
        {
            get { return this.pergunta; }
            set { this.pergunta = value; }
        }

        public string Id_Postagem {
            get { return this.id_postagem;}
            set { this.id_postagem = value; }
        }

        public string Texto
        {
            get { return this.texto; }
            set { this.texto = value; }
        }

        #endregion
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 Id_Postagem = string.Format(Request.Params["post"]);
                 Titulo = Consulta_Titulo()[0];
                 Texto = Consulta_Titulo()[1];
                 Autor = Consulta_Titulo()[2];
                 Consulta_Comentarios();
            }
        }

        private string[] Consulta_Titulo() {
            try {

                string[] resultado = new string[3];
                string strSQL = "SELECT p.email,p.titulo, p.texto FROM Post p WHERE p.id_post ="+Id_Postagem;
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    resultado[0] = (string)dr["titulo"];
                    resultado[1] = (string)dr["texto"];
                    resultado[2] = (string)dr["email"];
                }

                dr.Close();
                cn.Close();
                return resultado;
            }catch(Exception ex){
                    throw (ex);
            }
        }

        private void Consulta_Comentarios() {
            try
            {

                string[] resultado = new string[3];
                string strSQL = "SELECT c.id_comentario, c.email, c.texto FROM Post p, Comentarios c WHERE p.id_post = c.id_post AND c.id_post=" + Id_Postagem;
                SqlConnection cn = new SqlConnection(this.conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Comentarios.Add((string)dr["email"] +"/"+ (int)dr["id_comentario"], (string)dr["texto"]);
                }

                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        protected void btnComentar_Click(object sender, EventArgs e)
        {

            
           if (Request.Form["TextArea"].Equals(""))
            {
                Id_Postagem = string.Format(Request.Params["post"]);
                Titulo = Consulta_Titulo()[0];
                Texto = Consulta_Titulo()[1];
                Autor = Consulta_Titulo()[2];
                Consulta_Comentarios();
                Response.Write("<script>alert('Você não pode salvar um comentário em branco.');</script>");
            }
            else {
                salvar_comentario(Request.Form["TextArea"]);
                Response.Redirect("Post.aspx?post=" + Request.Params["post"]);
            }
        }

        private void salvar_comentario(string texto) { 
            try
            {
                string strSQL = "INSERT INTO Comentarios (id_post, texto, email) VALUES (" + Request.Params["post"] +", '" + texto + "','" + Session["usuario"] + "')";
                string e = Id_Postagem;
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

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["moderador"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}