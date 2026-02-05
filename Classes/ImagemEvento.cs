using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaosVoluntarias.Classes
{
    public class ImagemEvento : Banco
    {
        public int Codigo { get; set; }
        public string Imagem { get; set; }
        public Evento Evento { get; set; }
        public ImagemEvento()
        {
        }

        public ImagemEvento(int codigo, string imagem, Evento evento)
        {
            Codigo = codigo;
            Imagem = imagem;
            Evento = evento;
        }

        public List<ImagemEvento> listarImagens(int codigo) 
        {
            List<ImagemEvento> imagens = new List<ImagemEvento>();
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro("vCodigoEvento", codigo.ToString());
            parametros.Add(parametro);

            MySqlDataReader dados = null;
            try
            {
                using (dados = Consultar("listarImagensEvento", parametros))
                {
                    while (dados.Read())
                    {
                       ImagemEvento imagem = new ImagemEvento();
                        imagem.Codigo = dados.GetInt32(0);

                        if (dados[1] != null)
                        {
                            byte[] f = (byte[])dados[1];
                            string base64 = Convert.ToBase64String(f, 0, f.Length);
                            imagem.Imagem = Convert.ToString("data:image/jpeg;base64,") + base64;
                        }

                        Evento evento = new Evento();
                        evento.Codigo = codigo;
                        imagem.Evento = evento;

                        imagens.Add(imagem);
                    }

                    return imagens;
                }
            }
            catch
            {
                return null;
            }
        }

        public void deletarImagem(int codigo)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro("vCodigoImagem", codigo.ToString());
            parametros.Add(parametro);
            try
            {
                Executar("deletarImagemEvento", parametros);
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}