using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiberForum.Classes
{
    public class Topico
    {
        private string titulo;

        public string Titulo {
            get { return this.titulo; }
            set { this.titulo = value; }
        }
    }
}