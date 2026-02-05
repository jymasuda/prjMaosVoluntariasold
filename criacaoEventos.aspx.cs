using MySql.Data.MySqlClient;
using prjMaosVoluntarias.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjMaosVoluntarias
{
    public partial class criacaoEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cidade cidade = new Cidade();   
                CategoriaEvento categoriaEvento = new CategoriaEvento();

                litLabelFU.Text = "<label id='txtLabel' style='margin-left: 10px;margin-top: 5px;' for='fuDocumento'>Insira uma imagem...</label>";
                ddlCidade.Items.Add(new ListItem("Selecione", "-1"));
                List<Cidade> cidades = new List<Cidade>(cidade.Listar());
                foreach (Cidade c in cidades)
                {
                    ddlCidade.Items.Add(new ListItem(c.Nome, c.Codigo.ToString()));
                }

                ddlCategoria.Items.Add(new ListItem("Selecione", "-1"));
                List<CategoriaEvento> categorias = new List<CategoriaEvento>(categoriaEvento.Listar());
                foreach (CategoriaEvento c in categorias)
                {
                    ddlCategoria.Items.Add(new ListItem(c.Nome, c.Codigo.ToString()));
                }
            }
            if (Session["empresa"] == null || Session["email"] == null)
                Response.Redirect("index.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
                if (Session["empresa"] != null)
                {
                    if (String.IsNullOrEmpty(txtNome.Text))
                    {
                        txtNome.Focus();
                        litMsg.Text = "<p class='txt-Erro'>O nome do evento não pode estar vázio!</p>";
                        return;
                    }
                    if (String.IsNullOrEmpty(txtEndereco.Text))
                    {
                        txtEndereco.Focus();
                        litMsg.Text = "<p class='txt-Erro'>O endereço do evento não pode estar vazio!</p>";
                        return;
                    }
                    if (String.IsNullOrEmpty(txtDataInicio.Text))
                    {
                        txtDataInicio.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data de início do evento não pode estar vazia!</p>";
                        return;
                    }
                    if (ddlCidade.SelectedIndex <= 0)
                    {
                        ddlCidade.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A cidade do evento não pode estar vazia!</p>";
                        return;
                    }
                    if (String.IsNullOrEmpty(txtDataFinal.Text))
                    {
                        txtDataFinal.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data final do evento não pode estar vazia!</p>";
                        return;
                    }
                    if (ddlCategoria.SelectedIndex <= 0)
                    {
                        ddlCategoria.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A categoria do evento não pode estar vazia!</p>";
                        return;
                    }
                    if (String.IsNullOrEmpty(txtDataLimite.Text))
                    {
                        txtDataLimite.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data de limite das inscrições do evento não pode estar vazia!</p>";
                        return;
                    }
                    if (fuDocumento.FileName == "" || fuDocumento.FileName == null)
                    {
                        fuDocumento.Focus();
                        litMsg.Text = "<p class='txt-Erro'>Escolha uma foto para o evento!</p>";
                        return;
                    }
                    if (String.IsNullOrEmpty(txtDescricao.Text))
                    {
                        txtDescricao.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A descrição do evento não pode estar vazia!</p>";
                        return;
                    }
                    DateTime dataInicio = DateTime.Parse(txtDataInicio.Text);
                    DateTime dataFim = DateTime.Parse(txtDataFinal.Text);
                    DateTime dataLimite = DateTime.Parse(txtDataLimite.Text);

                    if (dataInicio < DateTime.Now)
                    {
                        txtDataInicio.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data inicial deve ser depois da data atual</p>";
                        return;
                    }
                    if (dataFim < DateTime.Now)
                    {
                        txtDataFinal.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data final deve ser depois da data atual</p>";
                        return;
                    }
                    if (dataLimite < DateTime.Now)
                    {
                        txtDataLimite.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data limite deve ser depois da data atual</p>";
                        return;
                    }
                    if (dataFim < dataInicio)
                    {
                        txtDataFinal.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data final deve ser depois da data inicial</p>";
                        return;
                    }
                    if (dataLimite > dataInicio)
                    {
                        txtDataLimite.Focus();
                        litMsg.Text = "<p class='txt-Erro'>A data limite deve ser antes da data inicial</p>";
                        return;
                    }

                    string email = Session["email"].ToString();
                    Evento evento = new Evento();
                    int proximoCodigo = evento.proximoEvento();
                    try
                    {
                        string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=Maos_Voluntarias";
                        using (MySqlConnection conexao = new MySqlConnection(linhaConexao))
                        {
                            conexao.Open();
                            string comando = $@"insert into evento (cd_evento, nm_evento, ds_evento, ds_endereco, dt_inicio, dt_fim, dt_limite_inscricao, nm_imagem, nm_email, cd_categoria_evento, cd_cidade)
                                    values ({proximoCodigo}, '{txtNome.Text}', '{txtDescricao.Text}', '{txtEndereco.Text}', '{DateTime.Parse(txtDataInicio.Text).ToString("yyyy-MM-dd HH-mm")}', '{DateTime.Parse(txtDataFinal.Text).ToString("yyyy-MM-dd HH-mm")}', '{DateTime.Parse(txtDataLimite.Text).ToString("yyyy-MM-dd HH-mm")}',@foto , '{email}', {ddlCategoria.SelectedValue}, {ddlCidade.SelectedValue});";
                            MySqlCommand cSQL = new MySqlCommand(comando, conexao);
                            MemoryStream ms = new MemoryStream();
                            Bitmap figura = new Bitmap(fuDocumento.FileContent);
                            figura.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] foto = ms.ToArray();

                            cSQL = new MySqlCommand(comando, conexao);
                            MySqlParameter parametro = new MySqlParameter("@foto", MySqlDbType.Binary);
                            parametro.Value = foto;
                            cSQL.Parameters.Add(parametro);
                            cSQL.ExecuteNonQuery();
                            conexao.Close();

                            HttpCookie toastId = new HttpCookie("toastId");
                            toastId.Value = "eventoCriado";
                            HttpContext.Current.Response.Cookies.Add(toastId);  
                            Response.Redirect("evento.aspx?c=" + proximoCodigo);
                            
                            return;
                        }
                    }
                    catch
                    {
                        litMsg.Text = "<h1 style='font-size: 20px; display: flex; justify-content: center;'>Erro de conexão.</h1>";
                        return;
                    }
                    litMsg.Text = "";
                    txtNome.Text = "";
                    txtEndereco.Text = "";
                    txtDescricao.Text = "";
                    txtDataInicio.Text = "";
                    txtDataFinal.Text = "";
                    txtDataLimite.Text = "";
                    ddlCategoria.SelectedIndex = -1;
                    ddlCidade.SelectedIndex = -1;
                    fuDocumento.Attributes.Clear();

                }
            
            
            //evento.criarEvento(proximoCodigo.ToString(), txtNome.Text, txtDescricao.Text, txtEndereco.Text, txtDataInicio.Text, txtDataFinal.Text, txtDataLimite.Text, foto.ToString(), "saojudas@gmail.com", ddlCategoria.SelectedValue.ToString(), ddlCidade.SelectedValue.ToString());

        }

    }
}
