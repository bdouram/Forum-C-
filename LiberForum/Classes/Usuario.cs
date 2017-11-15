using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace LiberForum.Classes
{
    public class Usuario
    {

        public Usuario()
        {
            this.conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        }
        
        #region Atributos
        private string email;
        private string nome;
        private string senha;
        private string conexao;
        #endregion

        #region Encapsulamento
        public string Email 
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public string Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }
        #endregion

        #region Metodos
        private bool existeNoBanco() {
            try {
                string strSQL = "SELECT COUNT(email) FROM Usuario WHERE  email ='" + Email + "'";
                SqlConnection cn = new SqlConnection(conexao);
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cn.Open();
                object rowAffected = cmd.ExecuteScalar();
                cn.Close();
                if ((int)rowAffected > 0){
                    return true;
                }else{
                    return false;
                }
            }
            catch (Exception ex) {
                throw (ex);
            }
            
        }

        public bool salvar() {
            if (!existeNoBanco())
            {
                try {
                    string strSQL = "INSERT INTO Usuario ([email],[nome],[senha]) VALUES ('"+Email+"','"+Nome+"','"+Senha+"')";
                    SqlConnection cn = new SqlConnection(conexao);
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cn.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    cn.Close();
                    return (rowAffected > 0);
                }catch(Exception ex){
                    throw (ex);
                }
            }
            else {
                return false;
            }
        }
        #endregion
    }
}