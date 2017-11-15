using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LiberForum.Classes
{
    public class Post
    {
        #region Construtor
        public Post() {
            this.conexao = "Data Source=DESKTOP-PIT72D7\\SQLEXPRESS;Initial Catalog=bd_forum;Integrated Security=True";
        }
        #endregion

        #region Atributos
        private string email;
        private string link;
        private string texto;
        private string conexao;
        #endregion

        #region Encapsulamento
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Link
        {
            get { return this.link; }
            set { this.link = value; }
        }

        public string Texto
        {
            get { return this.texto; }
            set { this.texto = value; }
        }
        #endregion

        #region Metodos
        public void salvar() { 
            
        }

        public void listar() {
           
        }
        #endregion
    }
}