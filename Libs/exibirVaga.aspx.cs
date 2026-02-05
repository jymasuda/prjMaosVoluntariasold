using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.Libs
{
    public partial class exibirVaga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situacao':'false'}";
            resposta = resposta.Replace('\'', '\"');

            if (Request["d"] != null && Request["c"] != null && Request["n"] != null)
                if(Request["d"] != "" && Request["c"] != "" && Request["n"] != "")
                {
                    Funcao funcao = new Funcao();
                    funcao.Nome = Request["n"].ToString();
                    Evento evento = new Evento();
                    evento.Codigo = int.Parse(Request["c"]);
                    FuncaoEvento vaga = new FuncaoEvento();
                    FuncaoEvento vaga1 = new FuncaoEvento();
                    FuncaoEvento dadosEvento = new FuncaoEvento(funcao, evento, DateTime.Parse(Request["d"]));
                    vaga = vaga1.exibeVaga(dadosEvento);
                    string data = vaga.Inicio.ToString("dd/MM HH:mm") + " até " + vaga.Fim.ToString("HH:mm");
                    resposta = "{'situacao':'true', 'data':'"+ data +"', 'descricao':'"+ vaga.Descricao +"', 'qtvaga':'"+ vaga.QuantidadeVagas +"'}";
                }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}