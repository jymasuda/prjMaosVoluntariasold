using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias.lib
{
    public partial class verificaLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string resposta = "{'situacao':'false'}";
            Usuario usuario = new Usuario();

            if (Session["usuario"] != null )
            {
                string email = Session["email"].ToString();
                usuario = usuario.pegarFotoPerfil(email);
                string user = Session["usuario"].ToString();
                resposta = "{'situacao':'usuario', 'nome':'"+ user +"','foto':'"+ usuario.Foto +"'}";
                Response.Write(resposta.Replace('\'', '\"'));
                return;
            }

            if (Session["empresa"] != null)
            {
                string email = Session["email"].ToString();
                usuario = usuario.pegarFotoPerfil(email);
                string empresa = Session["empresa"].ToString();
                resposta = "{'situacao':'empresa', 'nome':'" + empresa + "','foto':'"+ usuario.Foto +"'}";
                Response.Write(resposta.Replace('\'', '\"'));
                return;
            }

            Response.Write(resposta.Replace('\'', '\"'));

        }
    }
}