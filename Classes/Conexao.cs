using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public static class Conexao
    {
        public static string getConexao()
        {
            return "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Maos_Voluntarias";
            //return "SERVER=mysql.meusite.com.br;UID=banco01;PASSWORD=TREgfds$%#$;DATABASE=bancoOnlineSistema";
        }
    }
}