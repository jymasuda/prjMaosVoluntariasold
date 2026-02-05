using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class TipoUsuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public TipoUsuario()
        {
        }

        public TipoUsuario(int codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

    }
}