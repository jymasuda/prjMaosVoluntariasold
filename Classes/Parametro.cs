using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class Parametro
    {
        public string Nome { get; set; }
        public string Valor { get; set; }

        public Parametro(string nome, string valor)
        { 
            this.Nome = nome;
            this.Valor = valor;
        }
    }
}