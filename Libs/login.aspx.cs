using Org.BouncyCastle.Ocsp;
using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.lib
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";
            string resposta = "{'situação':'false' }";
            if (!String.IsNullOrEmpty(Request["e"]) && !String.IsNullOrEmpty(Request["s"]))
            {
                Usuario usuario = new Usuario();
                Empresa empresa = new Empresa();
                
                string email = Request["e"].ToString();
                string senha = Request["s"].ToString();

                usuario = usuario.Logar(email, senha);
                string nomeUsuario = usuario.Nome;

                empresa = empresa.Logar(email, senha);
                string nomeEmpresa = empresa.Nome;


                if (!String.IsNullOrEmpty(nomeUsuario))
                {
                    Session["usuario"] = nomeUsuario;
                    Session["email"] = email;
                    resposta = "{'situação':'true', 'tipologin':'usuario'}";
                    Response.Write(resposta.Replace('\'', '\"'));
                    return;
                }

                if (!String.IsNullOrEmpty(nomeEmpresa))
                {
                    Session["empresa"] = nomeEmpresa;
                    Session["email"] = email;
                    resposta = "{'situação':'true', 'tipologin':'empresa'}";
                    Response.Write(resposta.Replace('\'', '\"'));
                    return;
                }
            }
            Response.Write(resposta.Replace('\'', '\"'));
        }
    }
}