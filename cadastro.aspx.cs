using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null || Session["empresa"] != null || Session["email"] != null)
            {
                Response.Redirect("index.aspx");
            }

            if (String.IsNullOrEmpty(Request["t"]))
            {
                Response.Redirect("index.aspx");
            }

            if (Request["t"] == "usuario")
            {

                litFormCadastro.Text = $@"<div class=""cadastro-input"">
                <label for=""txtNome"">Nome Completo:</label>
                <input type=""text"" name=""txtNome"" id=""txtNome"" placeholder=""Digite o nome completo..."">
            </div>

            <div class=""cadastro-input"">
                <label for=""txtEmail"">E-mail:</label>
                <input type=""text"" name=""txtEmail"" id=""txtEmail"" placeholder=""Digite seu e-mail..."">
            </div>

            <div class=""cadastro-input"">
                <label for=""txtSenha"">Senha:</label>
                <input type=""password"" name=""txtSenha"" id=""txtSenha"" placeholder=""Digite sua senha..."">
            </div>

            <div class=""cadastro-input"">
                <label for=""txtSenhaConfirmar"">Confirmar Senha:</label>
                <input type=""password"" name=""txtSenhaConfirmar"" id=""txtSenhaConfirmar"" placeholder=""Confirme sua senha..."">
            </div>

            <div class=""cadastro-input"">
                <label for=""txtCPF"">CPF:</label>
                <input type=""text"" name=""txtCPF"" id=""txtCPF"" placeholder=""Digite seu CPF..."">
            </div>

            <div class=""cadastro-input"">
                <label for=""txtRG"">RG: </label>
                <input type=""text"" name=""txtRG"" id=""txtRG"" placeholder=""Digite seu RG..."">    
            </div>
    
            <div class=""cadastro-input"">
                <label for=""input-documento"">Foto do Documento</label>
                <div class=""input-documento"">
                    <i class=""material-symbols-outlined"">photo_camera</i>
                    <label for=""fileDocumento"" id='txtLabelDocumento' >Insira uma imagem...</label>
                    <input type=""file"" name=""fileDocumento"" id=""fileDocumento"" accept=""image/png,image/jpeg,image/jpg "">
                </div>    
            </div>

            <div class=""centro"">
                <p id=""spanMsg""></p>
                <button class=""btn azul"" type=""submit"" id=""btnCadastrar"">Cadastre-se</button>
                <br>
                <a href="""">Já possui uma conta? Entre!</a>
            </div>";

            }

            if (Request["t"] == "empresa")
            {
                

                litFormCadastro.Text = $@"<div class=""cadastro-input"">
                <label for=""txtNome"">Nome da organização:</label>
                <input type=""text"" name=""txtNome"" id=""txtNome"" placeholder=""Digite o nome completo...""/>
            </div>

            <div class=""cadastro-input"">
                <label for=""txtEmail"">E-mail:</label>
                <input type=""text"" name=""txtEmail"" id=""txtEmail"" placeholder=""Digite seu e-mail...""/>
            </div>

            <div class=""cadastro-input"">
                <label for=""txtSenha"">Senha:</label>
                <input type=""password"" name=""txtSenha"" id=""txtSenha"" placeholder=""Digite sua senha...""/>
            </div>

            <div class=""cadastro-input"">
                <label for=""txtSenhaConfirmar"">Confirmar Senha:</label>
                <input type=""password"" name=""txtSenhaConfirmar"" id=""txtSenhaConfirmar"" placeholder=""Confirme sua senha...""/>
            </div>

            <div class=""cadastro-input"">
                <label for=""txtCNPJ"">CNPJ:</label>
                <input type=""text"" name=""txtCNPJ"" id=""txtCNPJ"" placeholder=""Digite seu CNPJ...""/>
            </div>

            <div class=""cadastro-input"">
                <label for=""txtSite"">Link do site da empressa: <span>Opcional</span></label>
                <input type=""text"" name=""txtSite"" id=""txtSite"" placeholder=""Digite o link do site...""/>    
            </div>

            <div class=""cadastro-input"">
                <label for=""txtTelefone"">Telefone:</label>
                <input type=""text"" name=""txtTelefone"" id=""txtTelefone"" placeholder=""(99) 99999-9999""/>    
            </div>

            <div class=""centro"">
                <p id=""spanMsg""></p>
                <button class=""btn azul"" type=""submit"" id=""btnCadastrar"">Cadastre-se</button>
                <br/>
                <a href="""">Já possui uma conta? Entre!</a>
            </div>";
            }





        }
    }
}